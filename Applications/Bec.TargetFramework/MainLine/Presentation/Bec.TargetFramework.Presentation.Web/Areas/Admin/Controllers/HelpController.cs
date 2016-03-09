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
using System.Linq.Expressions;
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

        private async Task<MultiSelectList> GetRoles()
        {
            var selectRole = ODataHelper.Select<VRoleHierarchyDTO>(x => new
            {
                x.RoleID,
                x.RoleName
            }, false);
            var allRoles = (await queryClient.QueryAsync<VRoleHierarchyDTO>("VRoleHierarchies", selectRole)).ToList();
            return new MultiSelectList(allRoles, "RoleID", "RoleName");
        }
        public async Task<ActionResult> ViewAddHelp(HelpPageDTO page)
        {
            TempData.Remove("Items");
            ViewBag.Types = GetHelpPageTypes();
            ViewBag.roles = await GetRoles();
            return PartialView("_AddHelp", page);
        }

        public async Task<ActionResult> ViewEditHelp(Guid pageId)
        {
            TempData.Remove("Items");
            var page = (await GetHelpPages(pageId, null, string.Empty)).FirstOrDefault();
            if (page != null)
            {
                ViewBag.Types = GetHelpPageTypes();
                ViewBag.roles = await GetRoles();
                return PartialView("_EditHelp", page);
            }
            else return View("Index");
        }

        public async Task<ActionResult> ViewDeleteHelp(Guid pageId)
        {
            var page = (await GetHelpPages(pageId, null, string.Empty)).FirstOrDefault();
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
                this.AddToastMessage("Edit Successfully", "The help has been edited.", ToastType.Success);
            }
            catch (Exception)
            {
                TempData.Remove("HelpPageId");
                this.AddToastMessage("Edit Unsuccessfully", "The help could not be edited. Please try again.", ToastType.Error);
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
            var helpList = await GetHelpPages(null, pageType, string.Empty);
            var helpModelList = new List<HelpModel>();
            foreach (var item in helpList)
            {
                var helpModel = new HelpModel(item);
                helpModelList.Add(helpModel);
            }
            return Json(new { Items = helpModelList, Count = helpList.Count }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetHelpItems(Guid pageId)
        {
            var list = await helpClient.GetHelpPageItemsAsync(pageId);
            var IsEmpty = (list == null) || (list.ToList().Count == 0);
            var data = new List<HelpPageItemDTO>();
            if (!IsEmpty)
            {
                data = list.ToList();
                if (data.Any())
                {
                    data.ForEach(x =>
                    {
                        if (x.HelpPageItemRoles != null && x.HelpPageItemRoles.Any())
                        {
                            x.RoleId = x.HelpPageItemRoles.Select(y => y.RoleID).ToArray();
                        }
                    });
                }
            }
            TempData["Items"] = data;
            var jsonData = new { IsEmpty, Items = data };
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
            var list = await GetHelpPages(pageId, null, string.Empty);
            return list.FirstOrDefault();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult AddTempHelpPageItem(HelpPageItemDTO item)
        {
            IList<HelpPageItemDTO> list = null;
            var result = false;
            if (item.HelpPageItemID == default(Guid))
            {
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
                result = list.Count > 0;
            }
            else
            {
                if (TempData["Items"] != null)
                {
                    list = (IList<HelpPageItemDTO>)TempData["Items"];
                    var itemHelp = list.FirstOrDefault(x => x.HelpPageItemID == item.HelpPageItemID);
                    if (itemHelp != null)
                    {
                        itemHelp.Title = item.Title;
                        itemHelp.Selector = item.Selector;
                        itemHelp.Description = item.Description;
                        itemHelp.Position = item.Position;
                        itemHelp.TabContainerId = item.TabContainerId;
                        itemHelp.EffectiveOn = item.EffectiveOn;
                        itemHelp.RoleId = item.RoleId;
                        itemHelp.JustOrder = item.JustOrder;
                    }
                    TempData["Items"] = list;
                    result = list.Count > 0;
                }
            }
            var jsonData = new { result, Items = list };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult EditTempHelpPageItem(HelpPageItemDTO item)
        {
            IList<HelpPageItemDTO> list = null;
            var result = false;
            if (item.HelpPageItemID == default(Guid))
            {
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
                result = true;
            }
            else
            {
                if (TempData["Items"] != null)
                {
                    list = (IList<HelpPageItemDTO>)TempData["Items"];
                    var itemHelp = list.FirstOrDefault(x => x.HelpPageItemID == item.HelpPageItemID);
                    if (itemHelp != null)
                    {
                        itemHelp.Title = item.Title;
                        itemHelp.Selector = item.Selector;
                        itemHelp.Description = item.Description;
                        itemHelp.Position = item.Position;
                        itemHelp.TabContainerId = item.TabContainerId;
                        itemHelp.EffectiveOn = item.EffectiveOn;
                        itemHelp.RoleId = item.RoleId;
                        if (itemHelp.Status != HelpPageItemStatusEnum.New.GetIntValue())
                        {
                            itemHelp.Status = HelpPageItemStatusEnum.Modified.GetIntValue();
                            itemHelp.JustOrder = false;
                        }
                    }
                    TempData["Items"] = list;
                    result = true;
                }
            }
            var jsonData = new { result, Items = list };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
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
            if (id != null && id != Guid.Empty)
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
            else
            {
                TempData["Items"] = null;
                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
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
                        RoleId = item.RoleId,
                        JustOrder = item.JustOrder,
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
                    if (item.JustOrder != true)
                    {
                        item.JustOrder = (item.Status != HelpPageItemStatusEnum.Modified.GetIntValue() ? true : false);
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
                        RoleId = item.RoleId,
                        DisplayOrder = newOrder,
                        JustOrder = item.JustOrder
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

        public async Task<JsonResult> ValidateAddHelp(HelpPageTypeIdEnum? helpType, string helpUrl)
        {
            if (!helpType.HasValue)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            var list = await GetHelpPages(null, helpType, helpUrl);
            return Json(list.Count == 0, JsonRequestBehavior.AllowGet);
        }

        private async Task<List<HelpPageDTO>> GetHelpPages(Guid? helpId, HelpPageTypeIdEnum? helpType, string helpUrl)
        {
            var select = ODataHelper.Select<HelpPageDTO>(x => new { x.HelpPageID, x.PageName, x.PageUrl, x.HelpPageTypeId, x.CreatedOn, x.ModifiedOn });
            var filter = string.Empty;
            if (helpId.HasValue)
            {
                var helpIdValue = helpId.Value;
                filter = ODataHelper.Filter<HelpPageDTO>(x => x.HelpPageID == helpIdValue);
            }
            else if (helpType.HasValue)
            {
                var helpTypeValue = helpType.GetIntValue();
                var where = ODataHelper.Expression<HelpPageDTO>(x => x.HelpPageTypeId == helpTypeValue);
                if (helpType == HelpPageTypeIdEnum.ShowMeHow && !string.IsNullOrEmpty(helpUrl))
                {
                    var lowerUrl = helpUrl.Trim().ToLowerInvariant();
                    where = Expression.And(where, ODataHelper.Expression<HelpPageDTO>(x => x.PageUrl.ToLower() == lowerUrl));
                }
                filter = ODataHelper.Filter(where);
            }
            return (await queryClient.QueryAsync<HelpPageDTO>("HelpPages", select + filter)).ToList();
        }
    }
}