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
using Bec.TargetFramework.Presentation.Web.Filters;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    [ClaimsRequired("Add", "SupportFunctions", Order = 1000)]
    public class HelpController : Controller
    {
        enum ItemStatus
        {
            New = 1,
            Modified = 2,
            Deleted = 3
        };
        public IQueryLogicClient queryClient { get; set; }
        public IHelpLogicClient helpClient { get; set; }
        public IList<SelectListItem> GetHelpPageTypes()
        {
            return new List<SelectListItem> {
                new SelectListItem { Value = PageType.Tour.GetIntValue().ToString(), Text=PageType.Tour.GetStringValue()},
                new SelectListItem { Value = PageType.ShowMeHow.GetIntValue().ToString(), Text=PageType.ShowMeHow.GetStringValue()},
                new SelectListItem { Value = PageType.Callout.GetIntValue().ToString(), Text=PageType.Callout.GetStringValue()}
            };
        }
        public ActionResult Index()
        {
            ViewBag.Types = GetHelpPageTypes();
            return View();
        }

        public ActionResult ViewAddHelp(HelpPageDTO page)
        {
            TempData.Remove("Items");
            ViewBag.Types = GetHelpPageTypes();
            return PartialView("_AddHelp", page);
        }

        public async Task<ActionResult> ViewEditHelp(Guid pageId)
        {
            TempData.Remove("Items");
            var page = await GetHelpDto(pageId);
            if (page != null)
            {
                ViewBag.Types = GetHelpPageTypes();
                return PartialView("_EditHelp", page);
            }
            else return View("Index");
        }

        public async Task<ActionResult> ViewDeleteHelp(Guid pageId)
        {
            var page = await GetHelpDto(pageId);
            return PartialView("_DeleteHelpPage", page);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddHelp(HelpPageDTO page)
        {
            try
            {
                List<HelpItemDTO> items;
                if (TempData["Items"] != null)
                {
                    items = (List<HelpItemDTO>)TempData["Items"];
                    page.HelpItems = items.FindAll(x => x.Status != ItemStatus.Deleted.GetIntValue());
                }
                TempData["HelpPageId"] = await helpClient.CreateHelpPageAsync(page);
                this.AddToastMessage("Add Successfully", "The help has been added.", ToastType.Success, false);
            }
            catch (Exception)
            {
                TempData.Remove("HelpPageId");
                this.AddToastMessage("Add Unsuccessfully", "The help cannot be added. Please try again.", ToastType.Error, false);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditHelp(HelpPageDTO page)
        {
            try
            {
                List<HelpItemDTO> tempListItem;
                if (TempData["Items"] != null)
                {
                    tempListItem = (List<HelpItemDTO>)TempData["Items"];
                    page.HelpItems = tempListItem;
                }
                TempData["HelpPageId"] = await helpClient.EditHelpPageAsync(page);
                this.AddToastMessage("Add Successfully", "The help has been updated.", ToastType.Success, false);
            }
            catch (Exception)
            {
                TempData.Remove("HelpPageId");
                this.AddToastMessage("Add Unsuccessfully", "The help cannot be modified. Please try again.", ToastType.Error, false);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteHelp(HelpPageDTO page)
        {
            try
            {
                await helpClient.DeleteHelpPageAsync(page);
                this.AddToastMessage("Delete Successfully", "The help has been deleted", ToastType.Success, false);
            }
            catch (Exception)
            {
                this.AddToastMessage("Delete Unsuccessfully", "The help cannot be deleted. Please try again.", ToastType.Error, false);
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> HelpPages(PageType? pageType)
        {
            TempData["CurrentType"] = pageType;
            TempData["isShowMeHowItem"] = pageType == PageType.ShowMeHow;
            TempData["isCalloutItem"] = pageType == PageType.Callout;

            var selectPage = ODataHelper.Select<HelpPageDTO>(x => new { x.HelpPageID, x.PageName, x.PageUrl, x.PageType, x.CreatedOn, x.ModifiedOn });
            var filterPage = pageType.GetIntValue() > 0 ? ODataHelper.Filter<HelpPageDTO>(x => x.PageType == pageType.GetIntValue()) : String.Empty;
            JObject res = await queryClient.QueryAsync("HelpPages", ODataHelper.RemoveParameters(Request) + selectPage + filterPage);
            return Content(res.ToString(Formatting.None), "application/json");
        }

        public async Task<ActionResult> GetHelpItems(Guid pageId)
        {
            var list = await GetItemsOnPage(pageId);
            var result = list != null && list.ToList().Count > 0;
            if (result)
            {
                TempData["Items"] = list.ToList();
            }

            var jsonData = new { result, Items = list, IsSortable = false };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        private async Task<IEnumerable<HelpItemDTO>> GetItemsOnPage(Guid pageId)
        {
            var selectItem = ODataHelper.Select<HelpItemDTO>(x => new { x.HelpItemID, x.HelpPageID, x.Title, x.Description, x.DisplayOrder, x.EffectiveOn, x.Position, x.Selector, x.TabContainerId });
            var filterItem = ODataHelper.Filter<HelpItemDTO>(x => x.HelpPageID == pageId);
            var orderItem = ODataHelper.OrderBy<HelpItemDTO>(x => new { x.DisplayOrder });
            var list = await queryClient.QueryAsync<HelpItemDTO>("HelpItems", selectItem + filterItem + orderItem);
            return list;
        }


        private async Task<HelpPageDTO> GetHelpDto(Guid pageId)
        {
            var select = ODataHelper.Select<HelpPageDTO>(x => new { x.HelpPageID, x.PageName, x.PageUrl, x.PageType, x.CreatedOn, x.ModifiedOn });
            var filter = ODataHelper.Filter<HelpPageDTO>(x => x.HelpPageID == pageId);
            var list = await queryClient.QueryAsync<HelpPageDTO>("HelpPages", select + filter);
            return list.FirstOrDefault();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AddItem(HelpItemDTO item)
        {
            if (item.HelpItemID == default(Guid))
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
                item.HelpItemID = Guid.NewGuid();
                list.Add(item);
                TempData["Items"] = list;
                var jsonData = new { result = list.Count > 0, Items = list };
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (TempData["Items"] != null)
                {
                    var list = (IList<HelpItemDTO>)TempData["Items"];
                    var itemHelp = list.FirstOrDefault(x => x.HelpItemID == item.HelpItemID);
                    if (itemHelp != null)
                    {
                        itemHelp.Title = item.Title;
                        itemHelp.Selector = item.Selector;
                        itemHelp.Description = item.Description;
                        itemHelp.Position = item.Position;
                        itemHelp.TabContainerId = item.TabContainerId;
                    }
                    TempData["Items"] = list;
                    var jsonData = new { result = list.Count > 0, Items = list };
                    return Json(jsonData, JsonRequestBehavior.AllowGet);
                }
                return null;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult EditItem(HelpItemDTO item)
        {
            if (item.HelpItemID == default(Guid))
            {
                IList<HelpItemDTO> list = null;
                if (TempData["Items"] != null)
                {
                    list = (IList<HelpItemDTO>)TempData["Items"];
                    item.DisplayOrder = list.Count + 1;
                    item.Status = ItemStatus.New.GetIntValue();
                }
                else
                {
                    list = new List<HelpItemDTO>();
                    item.DisplayOrder = 1;
                    item.Status = ItemStatus.New.GetIntValue();
                }
                item.HelpItemID = Guid.NewGuid();
                list.Add(item);
                TempData["Items"] = list;
                var jsonData = new { result = true, Items = list };
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (TempData["Items"] != null)
                {
                    var list = (IList<HelpItemDTO>)TempData["Items"];
                    var itemHelp = list.FirstOrDefault(x => x.HelpItemID == item.HelpItemID);
                    if (itemHelp != null)
                    {
                        itemHelp.Title = item.Title;
                        itemHelp.Selector = item.Selector;
                        itemHelp.Description = item.Description;
                        itemHelp.Position = item.Position;
                        itemHelp.TabContainerId = item.TabContainerId;
                        if (itemHelp.Status != ItemStatus.New.GetIntValue())
                        {
                            itemHelp.Status = ItemStatus.Modified.GetIntValue();
                        }
                    }
                    TempData["Items"] = list;
                    var jsonData = new { result = true, Items = list };
                    return Json(jsonData, JsonRequestBehavior.AllowGet);
                }
                return null;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult GetItem(Guid? id)
        {
            if (TempData["Items"] != null)
            {
                var list = (IList<HelpItemDTO>)TempData["Items"];
                var item = list.FirstOrDefault(x => x.HelpItemID == id);
                var jsonData = new { Item = item };
                TempData["Items"] = list;
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteItem(Guid? id)
        {
            if (TempData["Items"] != null)
            {
                var list = (IList<HelpItemDTO>)TempData["Items"];
                var item = list.FirstOrDefault(x => x.HelpItemID == id);
                if (item != null)
                {
                    if (item.Status == ItemStatus.New.GetIntValue())
                    {
                        list.Remove(item);
                    }
                    else
                    {
                        item.Status = ItemStatus.Deleted.GetIntValue();
                    }
                }                
                TempData["Items"] = list;
                var jsonData = new { result = list.Count > 0, Items = list };
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            return Json(new { result = false }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UpdateTemporaryOrder(List<int> orders)
        {
            var result = true;
            var newList = new List<HelpItemDTO>();
            if (TempData["Items"] == null || orders == null || orders.Count == 0)
            {
                result = false;
            }
            else
            {
                var currentList = (IList<HelpItemDTO>)TempData["Items"];
                var newOrder = 1;
                foreach (var order in orders)
                {
                    var item = currentList.FirstOrDefault(i => i.DisplayOrder == order);
                    if (item == null)
                    {
                        result = false;
                        break;
                    }
                    var newItem = new HelpItemDTO
                    {
                        HelpItemID = Guid.NewGuid(),
                        Title = item.Title,
                        Selector = item.Selector,
                        Description = item.Description,
                        Position = item.Position,
                        TabContainerId = item.TabContainerId,
                        EffectiveOn = item.EffectiveOn
                    };
                    newItem.DisplayOrder = newOrder;
                    newList.Add(newItem);
                    newOrder += 1;
                }
                if (result)
                {
                    TempData["Items"] = newList;
                }
            }
            var jsonData = new { result, Items = newList };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult UpdateTemporaryOrderOnEditPage(List<int> orders)
        {
            var result = true;
            var newList = new List<HelpItemDTO>();
            if (TempData["Items"] == null || orders == null || orders.Count == 0)
            {
                result = false;
            }
            else
            {
                var currentList = (IList<HelpItemDTO>)TempData["Items"];
                var newOrder = 1;
                foreach (var order in orders)
                {
                    var item = currentList.FirstOrDefault(i => i.DisplayOrder == order && i.Status != ItemStatus.Deleted.GetIntValue());
                    if (item == null)
                    {
                        result = false;
                        break;
                    }

                    if (item.Status <= 0)
                    {
                        item.Status = ItemStatus.Modified.GetIntValue();
                    }
                    item.DisplayOrder = newOrder;
                    newList.Add(item);
                    newOrder += 1;
                }
                if (result)
                {
                    foreach (var item in currentList.Where(i => i.Status == ItemStatus.Deleted.GetIntValue()))
                    {
                        newList.Add(item);    
                    }                    
                    TempData["Items"] = newList;
                }
            }
            var jsonData = new { result, Items = newList };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }
    }
}