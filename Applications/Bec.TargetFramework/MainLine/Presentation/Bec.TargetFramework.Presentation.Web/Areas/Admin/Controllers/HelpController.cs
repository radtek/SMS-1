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
        public IQueryLogicClient queryClient { get; set; }
        public IHelpLogicClient helpClient { get; set; }
        public IList<SelectListItem> GetHelpPageTypes()
        {
            return new List<SelectListItem> {
                new SelectListItem { Value = HelpPageTypeIdEnum.Tour.GetIntValue().ToString(), Text=HelpPageTypeIdEnum.Tour.GetStringValue()},
                new SelectListItem { Value = HelpPageTypeIdEnum.Callout.GetIntValue().ToString(), Text=HelpPageTypeIdEnum.Callout.GetStringValue()},
                new SelectListItem { Value = HelpPageTypeIdEnum.ShowMeHow.GetIntValue().ToString(), Text=HelpPageTypeIdEnum.ShowMeHow.GetStringValue()}
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
                List<HelpPageItemDTO> items;
                var itemDeleteStatus = HelpPageItemStatusEnum.Deleted.GetIntValue();
                if (TempData["Items"] != null)
                {
                    items = (List<HelpPageItemDTO>)TempData["Items"];
                    page.HelpPageItems = items.FindAll(x => x.Status != itemDeleteStatus);
                }
                var createdBy = WebUserHelper.GetWebUserObject(HttpContext).Email;
                TempData["HelpPageId"] = await helpClient.CreateHelpPageAsync(createdBy, page);
                this.AddToastMessage("Add Successfully", "The help has been added.", ToastType.Success);
            }
            catch (Exception)
            {
                TempData.Remove("HelpPageId");
                this.AddToastMessage("Add Unsuccessfully", "The help cannot be added. Please try again.", ToastType.Error);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditHelp(HelpPageDTO page)
        {
            try
            {
                List<HelpPageItemDTO> tempListItem;
                if (TempData["Items"] != null)
                {
                    tempListItem = (List<HelpPageItemDTO>)TempData["Items"];
                    page.HelpPageItems = tempListItem;
                }
                var modifiedBy = WebUserHelper.GetWebUserObject(HttpContext).Email;
                TempData["HelpPageId"] = await helpClient.EditHelpPageAsync(modifiedBy, page);
                this.AddToastMessage("Add Successfully", "The help has been updated.", ToastType.Success);
            }
            catch (Exception)
            {
                TempData.Remove("HelpPageId");
                this.AddToastMessage("Add Unsuccessfully", "The help cannot be modified. Please try again.", ToastType.Error);
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
                this.AddToastMessage("Delete Successfully", "The help has been deleted", ToastType.Success);
            }
            catch (Exception)
            {
                this.AddToastMessage("Delete Unsuccessfully", "The help cannot be deleted. Please try again.", ToastType.Error);
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> HelpPages(HelpPageTypeIdEnum? pageType)
        {
            TempData["CurrentType"] = pageType;
            TempData["isShowMeHowItem"] = pageType == HelpPageTypeIdEnum.ShowMeHow;
            TempData["isCalloutItem"] = pageType == HelpPageTypeIdEnum.Callout;
            var pageTypeValue = pageType.GetIntValue();
            var selectPage = ODataHelper.Select<HelpPageDTO>(x => new { x.HelpPageID, x.PageName, x.PageUrl, x.HelpPageTypeId, x.CreatedOn, x.ModifiedOn });
            var filterPage = pageTypeValue > 0 ? ODataHelper.Filter<HelpPageDTO>(x => x.HelpPageTypeId == pageTypeValue) : String.Empty;
            JObject res = await queryClient.QueryAsync("HelpPages", ODataHelper.RemoveParameters(Request) + selectPage + filterPage);
            return Content(res.ToString(Formatting.None), "application/json");
        }

        public async Task<ActionResult> GetHelpItems(Guid pageId)
        {
            var list = await GetItemsOnPage(pageId);
            var IsEmpty = (list == null) || (list.ToList().Count == 0);
            var data = new List<HelpPageItemDTO>();
            if (!IsEmpty)
            {
                data = list.ToList();
                TempData["Items"] = data;
            }
            else
            {
                TempData["Items"] = data;
            }
            var jsonData = new { IsEmpty, Items = data, IsSortable = false };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        private async Task<IEnumerable<HelpPageItemDTO>> GetItemsOnPage(Guid pageId)
        {
            var selectItem = ODataHelper.Select<HelpPageItemDTO>(x => new { x.HelpPageItemID, x.HelpPageID, x.Title, x.Description, x.DisplayOrder, x.EffectiveOn, x.Position, x.Selector, x.TabContainerId });
            var filterItem = ODataHelper.Filter<HelpPageItemDTO>(x => x.HelpPageID == pageId);
            var orderItem = ODataHelper.OrderBy<HelpPageItemDTO>(x => new { x.DisplayOrder });
            var list = await queryClient.QueryAsync<HelpPageItemDTO>("HelpPageItems", selectItem + filterItem + orderItem);
            return list;
        }


        private async Task<HelpPageDTO> GetHelpDto(Guid pageId)
        {
            var select = ODataHelper.Select<HelpPageDTO>(x => new { x.HelpPageID, x.PageName, x.PageUrl, x.HelpPageTypeId, x.CreatedOn, x.ModifiedOn });
            var filter = ODataHelper.Filter<HelpPageDTO>(x => x.HelpPageID == pageId);
            var list = await queryClient.QueryAsync<HelpPageDTO>("HelpPages", select + filter);
            return list.FirstOrDefault();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AddTempHelpPageItem(HelpPageItemDTO item)
        {
            if (item.HelpPageItemID == default(Guid))
            {
                IList<HelpPageItemDTO> list = null;
                if (TempData["Items"] != null)
                {
                    list = (IList<HelpPageItemDTO>)TempData["Items"];
                    var maxOrder = list.OrderByDescending(x => x.DisplayOrder).Take(1).FirstOrDefault();
                    item.DisplayOrder = maxOrder != null ? (maxOrder.DisplayOrder + 1) : (list.Count + 1);
                }
                else
                {
                    list = new List<HelpPageItemDTO>();
                    item.DisplayOrder = 1;
                }
                item.HelpPageItemID = Guid.NewGuid();
                list.Add(item);
                TempData["Items"] = list;
                var jsonData = new { result = list.Count > 0, Items = list };
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (TempData["Items"] != null)
                {
                    var list = (IList<HelpPageItemDTO>)TempData["Items"];
                    var itemHelp = list.FirstOrDefault(x => x.HelpPageItemID == item.HelpPageItemID);
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
        public JsonResult EditTempHelpPageItem(HelpPageItemDTO item)
        {
            if (item.HelpPageItemID == default(Guid))
            {
                IList<HelpPageItemDTO> list = null;
                if (TempData["Items"] != null)
                {
                    list = (IList<HelpPageItemDTO>)TempData["Items"];
                    var maxOrder = list.OrderByDescending(x => x.DisplayOrder).Take(1).FirstOrDefault();
                    item.DisplayOrder = maxOrder != null ? (maxOrder.DisplayOrder + 1) : (list.Count + 1);
                    item.Status = HelpPageItemStatusEnum.New.GetIntValue();
                }
                else
                {
                    list = new List<HelpPageItemDTO>();
                    item.DisplayOrder = 1;
                    item.Status = HelpPageItemStatusEnum.New.GetIntValue();
                }
                item.HelpPageItemID = Guid.NewGuid();
                list.Add(item);
                TempData["Items"] = list;
                var jsonData = new { result = true, Items = list };
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            else
            {
                if (TempData["Items"] != null)
                {
                    var list = (IList<HelpPageItemDTO>)TempData["Items"];
                    var itemHelp = list.FirstOrDefault(x => x.HelpPageItemID == item.HelpPageItemID);
                    if (itemHelp != null)
                    {
                        itemHelp.Title = item.Title;
                        itemHelp.Selector = item.Selector;
                        itemHelp.Description = item.Description;
                        itemHelp.Position = item.Position;
                        itemHelp.TabContainerId = item.TabContainerId;
                        if (itemHelp.Status != HelpPageItemStatusEnum.New.GetIntValue())
                        {
                            itemHelp.Status = HelpPageItemStatusEnum.Modified.GetIntValue();
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
                var list = (IList<HelpPageItemDTO>)TempData["Items"];
                var item = list.FirstOrDefault(x => x.HelpPageItemID == id);
                var jsonData = new { Item = item };
                TempData["Items"] = list;
                return Json(jsonData, JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult DeleteTempHelpPageItem(Guid? id)
        {
            if (TempData["Items"] != null)
            {
                var list = (IList<HelpPageItemDTO>)TempData["Items"];
                var item = list.FirstOrDefault(x => x.HelpPageItemID == id);
                if (item != null)
                {
                    if (item.Status == HelpPageItemStatusEnum.New.GetIntValue())
                    {
                        list.Remove(item);
                    }
                    else
                    {
                        item.Status = HelpPageItemStatusEnum.Deleted.GetIntValue();
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
            var newList = new List<HelpPageItemDTO>();
            if (TempData["Items"] == null || orders == null || orders.Count == 0)
            {
                result = false;
            }
            else
            {
                var currentList = (IList<HelpPageItemDTO>)TempData["Items"];
                var newOrder = 1;
                foreach (var order in orders)
                {
                    var item = currentList.FirstOrDefault(i => i.DisplayOrder == order);
                    if (item == null)
                    {
                        result = false;
                        break;
                    }
                    var newItem = new HelpPageItemDTO
                    {
                        HelpPageItemID = Guid.NewGuid(),
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
            var newList = new List<HelpPageItemDTO>();
            var itemDeletedStatus = HelpPageItemStatusEnum.Deleted.GetIntValue();
            if (TempData["Items"] == null || orders == null || orders.Count == 0)
            {
                result = false;
            }
            else
            {
                var currentList = (IList<HelpPageItemDTO>)TempData["Items"];
                var newOrder = 1;
                foreach (var order in orders)
                {
                    var item = currentList.FirstOrDefault(i => i.DisplayOrder == order && i.Status != itemDeletedStatus);
                    if (item == null)
                    {
                        result = false;
                        break;
                    }

                    if (item.Status <= 0)
                    {
                        item.Status = HelpPageItemStatusEnum.Modified.GetIntValue();
                    }
                    var newItem = new HelpPageItemDTO
                    {
                        HelpPageItemID = item.HelpPageItemID,
                        HelpPageID = item.HelpPageID,
                        Title = item.Title,
                        Selector = item.Selector,
                        Description = item.Description,
                        Position = item.Position,
                        TabContainerId = item.TabContainerId,
                        EffectiveOn = item.EffectiveOn,
                        CreatedBy = item.CreatedBy,
                        CreatedOn = item.CreatedOn,
                        Status = item.Status,
                        DisplayOrder = newOrder
                    };
                    newList.Add(newItem);
                    newOrder += 1;
                }
                if (result)
                {
                    foreach (var item in currentList.Where(i => i.Status == itemDeletedStatus))
                    {
                        item.DisplayOrder = 0;
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