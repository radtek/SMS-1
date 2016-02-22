using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Presentation.Web.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    public class HelpController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Types = new List<SelectListItem> {
                new SelectListItem { Value = PageType.Tour.ToString(), Text=PageType.Tour.GetStringValue() },
                new SelectListItem { Value = PageType.ShowMeHow.ToString(), Text=PageType.ShowMeHow.GetStringValue() },
                new SelectListItem { Value = PageType.Callout.ToString(), Text=PageType.Callout.GetStringValue() }
            };
            var pageId = Guid.NewGuid();
            TempData["HelpPageId"] = pageId.ToString();
            TempData.Keep("HelpPageId");
            return View();
        }

        public ActionResult ViewAddHelp()
        {
            return PartialView("_AddHelp");
        }

        public async Task<ActionResult> GetHelps(PageType? type)
        {
            TempData["CurrentType"] = type;
            var pageId = Guid.Parse(TempData["HelpPageId"].ToString());
            TempData.Keep("HelpPageId");
            var list = new List<HelpPageDTO> { 
                new HelpPageDTO { HelpPageID = pageId, CreatedOn = DateTime.Now, ModifiedOn = DateTime.Now, PageName = "Test", PageUrl = "/Admin/Test", PageType = PageType.Tour.GetIntValue() } ,
                new HelpPageDTO { HelpPageID = pageId, CreatedOn = DateTime.Now, ModifiedOn = DateTime.Now, PageName = "Test 1", PageUrl = "/Admin/Test1", PageType = PageType.Tour.GetIntValue() } 
            };
            var jsonData = new { Count = list.Count, Items = list };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetHelpItems(Guid? pageId)
        {
            pageId = Guid.Parse(TempData["HelpPageId"].ToString());
            var list = new List<HelpItemDTO>
            {
                new HelpItemDTO { HelpItemID = Guid.NewGuid(), HelpPageID = pageId.Value, Title = "Test 1" },
                new HelpItemDTO { HelpItemID = Guid.NewGuid(), HelpPageID = pageId.Value, Title = "Test 1" }
            };
            var jsonData = new { IsEmpty = list.Count == 0, Items = list, IsSortable = false };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}