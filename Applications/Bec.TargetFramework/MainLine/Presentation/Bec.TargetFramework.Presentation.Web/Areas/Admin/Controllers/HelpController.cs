using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Presentation.Web.Areas.Admin.Models;
using Bec.TargetFramework.Presentation.Web.Helpers;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Bec.TargetFramework.Presentation.Web.Models.ToastrNotification;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    public class HelpController : Controller
    {
        public IQueryLogicClient queryClient { get; set; }
        public IHelpLogicClient helpClient { get; set; }
        public IList<SelectListItem> GetTypes()
        {
            return new List<SelectListItem> {
                new SelectListItem { Value = PageType.Tour.GetIntValue().ToString(), Text=PageType.Tour.GetStringValue()},
                new SelectListItem { Value = PageType.ShowMeHow.GetIntValue().ToString(), Text=PageType.ShowMeHow.GetStringValue()},
                new SelectListItem { Value = PageType.Callout.GetIntValue().ToString(), Text=PageType.Callout.GetStringValue()}
            };
        }
        public ActionResult Index()
        {
            ViewBag.Types = GetTypes();
            return View();
        }

        public ActionResult ViewAddHelp(HelpPageDTO page)
        {
            TempData["Items"] = null;
            ViewBag.Types = GetTypes();
            return PartialView("_AddHelp", page);
        }

        public async Task<ActionResult> ViewDeleteHelp(Guid pageId)
        {
            var pages = await GetHelpDtos(pageId);
            return PartialView("_DeleteHelpPage", pages.FirstOrDefault());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddHelp(HelpPageDTO page)
        {
            List<HelpItemDTO> items;
            if (TempData["Items"] != null)
            {
                items = (List<HelpItemDTO>)TempData["Items"];
                page.HelpItems = items;
            }
            TempData["HelpPageId"] = await helpClient.CreateHelpPageAsync(page);
            this.AddToastMessage("Add Successfully", "The help has been added", ToastType.Success, false);
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteHelp(HelpPageDTO page)
        {
            await helpClient.DeleteHelpPageAsync(page);
            this.AddToastMessage("Delete Successfully", "The help has been deleted", ToastType.Success, false);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> GetHelps(PageType? type)
        {

            var val = type == null ? 0 : type.GetIntValue();
            TempData["CurrentType"] = type;

            if (val == 2)
            {
                TempData["isShowMeHowItem"] = true;
            }
            if (val == 3)
            {
                TempData["isCalloutItem"] = true;
            }

            var selectPage = ODataHelper.Select<HelpPageDTO>(x => new { x.HelpPageID, x.PageName, x.PageUrl, x.PageType, x.CreatedOn, x.ModifiedOn });
            var filterPage = val != 0 ? ODataHelper.Filter<HelpPageDTO>(x => x.PageType == val) : String.Empty;
            JObject res = await queryClient.QueryAsync("HelpPages", ODataHelper.RemoveParameters(Request) + selectPage + filterPage);
            return Content(res.ToString(Formatting.None), "application/json");

        }

        public async Task<ActionResult> GetHelpItems(Guid pageId)
        {
            var selectItem = ODataHelper.Select<HelpItemDTO>(x => new { x.HelpItemID, x.HelpPageID, x.Title });
            var filterItem = ODataHelper.Filter<HelpItemDTO>(x => x.HelpPageID == pageId);
            var orderItem = ODataHelper.OrderBy<HelpItemDTO>(x => new { x.DisplayOrder });
            var list = await queryClient.QueryAsync<HelpItemDTO>("HelpItems", selectItem + filterItem + orderItem);

            var jsonData = new { IsEmpty = list.Count() == 0, Items = list, IsSortable = false };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }


        private async Task<List<HelpPageDTO>> GetHelpDtos(Guid? pageId)
        {
            var select = ODataHelper.Select<HelpPageDTO>(x => new { x.HelpPageID, x.PageName, x.PageUrl, x.PageType, x.CreatedOn, x.ModifiedOn });
            var filter = string.Empty;
            if (pageId.HasValue)
            {
                var val = pageId.Value;
                filter = ODataHelper.Filter<HelpPageDTO>(x => x.HelpPageID == val);
            }
            var list = await queryClient.QueryAsync<HelpPageDTO>("HelpPages", select + filter);
            return list.ToList();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AddItem(HelpItemDTO item)
        {
            IList<HelpItemDTO> list = null;
            if (TempData["Items"] != null)
            {
                list = (IList<HelpItemDTO>)TempData["Items"];
                item.DisplayOrder = list.Count + 1;
            }
            else
            {
                list = new List<HelpItemDTO>();
                item.DisplayOrder = 1;
            }
            list.Add(item);
            TempData["Items"] = list;
            var jsonData = new { IsEmpty = list.Count == 0, Items = list };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}