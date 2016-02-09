using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Filters;
using Bec.TargetFramework.Presentation.Web.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    [ClaimsRequired("Add", "Company", Order = 1000)]
    public class NewsArticleController : ApplicationControllerBase
    {
        public IQueryLogicClient QueryClient { get; set; }
        public IMiscLogicClient MiscClient { get; set; }

        public ActionResult Index(Guid? selectedNewsArticleID)
        {
            if (selectedNewsArticleID.HasValue)
            {
                TempData["NewsArticleID"] = selectedNewsArticleID;
            }
            return View();
        }

        public async Task<ActionResult> GetNewsArticles()
        {
            var select = ODataHelper.Select<NewsArticleDTO>(x => new
            {
                x.NewsArticleID,
                x.DateTime,
                x.Title,
                x.Content
            });

            JObject res = await QueryClient.QueryAsync("NewsArticles", Request.QueryString + select);
            return Content(res.ToString(Formatting.None), "application/json");
        }

        public ActionResult ViewAddNewsArticle()
        {
            return PartialView("_AddNewsArticle");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddNewsArticle(NewsArticleDTO dto)
        {
            var newsArticleID = await MiscClient.AddNewsArticleAsync(dto);
            return RedirectToAction("Index", new { selectedNewsArticleID = newsArticleID });
        }
    }
}