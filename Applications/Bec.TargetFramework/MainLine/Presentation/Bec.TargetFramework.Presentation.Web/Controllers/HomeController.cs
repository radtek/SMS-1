using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Settings;
using System.Threading.Tasks;
using System.Web.Mvc;
using System;
using System.Linq;
using Bec.TargetFramework.Presentation.Web.Helpers;
using Bec.TargetFramework.Entities;

namespace Bec.TargetFramework.Presentation.Web.Controllers
{
    public class HomeController : Controller
    {
        public ITFSettingsLogicClient SettingsClient { get; set; }
        public IMiscLogicClient MiscLogicClient { get; set; }
        public IQueryLogicClient QueryLogicClient { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }

        public ActionResult ThreatsExplained()
        {
            return View();
        }

        public ActionResult BuyersAtRisk()
        {
            return View();
        }

        public async Task<ActionResult> ConveyancingFirmFaq()
        {
            var commonSettings = (await SettingsClient.GetSettingsAsync()).AsSettings<CommonSettings>();
            ViewBag.SupportTelephoneNumber = commonSettings.SupportTelephoneNumber;

            return View();
        }

        public ActionResult ConveyancersAtRisk()
        {
            return View();
        }

        public ActionResult HowItWorks()
        {
            return View();
        }

        public ActionResult SafeBuyerSpecification()
        {
            return View();
        }

        public ActionResult SafeBuyerProduct()
        {
            return View();
        }

        public ActionResult HowTheSmsHelpsLenders()
        {
            return View();
        }

        public ActionResult FreeTrial()
        {
            return View();
        }

        public ActionResult SafeMoveSchemeBenefits()
        {
            return View();
        }

        public ActionResult HowTheSMSHelpsConveyancingFirms()
        {
            return View();
        }

        public ActionResult ConveyancersCompliance()
        {
            return View();
        }

        public ActionResult LendersCompliance()
        {
            return View();
        }

        public ActionResult ConveyancingFirmRegistration()
        {
            return View();
        }

        public ActionResult MortgageBrokerRegistration()
        {
            return View();
        }

        public ActionResult ForThePublicIntroduction()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult TutorialsForProfessionals()
        {
            return View();
        }

        public ActionResult TutorialsForPublic()
        {
            return View();
        }

        public ActionResult HowToKeepConsumersSafe()
        {
            return View();
        }

        public async Task<ActionResult> News(Guid? articleID)
        {
            if (articleID.HasValue)
            {
                var select = ODataHelper.Select<NewsArticleDTO>(x => new { x.NewsArticleID, x.Title, x.DateTime, x.Content });
                var filter = ODataHelper.Filter<NewsArticleDTO>(x => x.NewsArticleID == articleID);
                var articles = await QueryLogicClient.QueryAsync<NewsArticleDTO>("NewsArticles", select + filter);
                return View("Article", articles.FirstOrDefault());
            }
            else
            {
                var select = ODataHelper.Select<NewsArticleDTO>(x => new { x.NewsArticleID, x.Title, x.DateTime, x.Content });
                var orderby = ODataHelper.OrderBy<NewsArticleDTO>(x => new { x.DateTime }) + " desc";
                var articles = await QueryLogicClient.QueryAsync<NewsArticleDTO>("NewsArticles", select + orderby);
                return View(articles);
            }
        }
    }
}