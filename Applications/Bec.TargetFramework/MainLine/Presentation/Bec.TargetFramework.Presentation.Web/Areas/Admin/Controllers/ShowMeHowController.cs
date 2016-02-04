using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Presentation.Web.Areas.Admin.Models;
using Bec.TargetFramework.Presentation.Web.Filters;
using Bec.TargetFramework.Presentation.Web.Helpers;
using Bec.TargetFramework.Presentation.Web.Models.ToastrNotification;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    [ClaimsRequired("Add", "ShowMeHow", Order = 1000)]
    public class ShowMeHowController : Controller
    {
        const string _defaultSystemUrl = "SMH";
        public IQueryLogicClient queryClient { get; set; }
        public ISmhLogicClient smhClient { get; set; }

        private async Task<List<SelectListItem>> GetRoles()
        {
            var select = ODataHelper.Select<RoleDTO>(x => new { x.RoleID, x.RoleName });
            var roles = await queryClient.QueryAsync<RoleDTO>("Roles", select);
            return roles.Select(x => new SelectListItem { Text = x.RoleName, Value = x.RoleID.ToString() }).ToList();
        }

        private async Task<SMHItemDTO> GetItemDto(Guid itemId)
        {
            var selectItem = ODataHelper.Select<SMHItemDTO>(x => new { x.PageID, x.ItemID, x.ItemName, x.ItemDescription, x.ItemPosition, x.ItemSelector, x.TabContainerId, x.ItemOrder });
            var filterItem = ODataHelper.Filter<SMHItemDTO>(x => x.ItemID == itemId);
            var items = await queryClient.QueryAsync<SMHItemDTO>("SMHItems", selectItem + filterItem);
            return items.FirstOrDefault();
        }

        private async Task<SMHPageDTO> GetPageDto(Guid pageId)
        {
            var selectPage = ODataHelper.Select<SMHPageDTO>(x => new { x.PageID, x.PageName, x.PageURL, x.RoleId });
            var filterPage = ODataHelper.Filter<SMHPageDTO>(x => x.PageID == pageId);
            var pages = await queryClient.QueryAsync<SMHPageDTO>("SMHPages", selectPage + filterPage);
            return pages.FirstOrDefault();
        }

        private async Task<SMHPageModel> GetPageModel(Guid pageId, bool isSysPage)
        {
            var selectPage = ODataHelper.Select<SMHPageDTO>(x => new { x.PageID, x.PageName, x.PageURL, x.Role.RoleID, x.Role.RoleName });
            var filterPage = ODataHelper.Filter<SMHPageDTO>(x => x.PageID == pageId);
            var pages = await queryClient.QueryAsync<SMHPageDTO>("SMHPages", selectPage + filterPage);

            return pages.Select(p => new SMHPageModel
            {
                PageId = p.PageID,
                PageName = p.PageName,
                PageUrl = p.PageURL,
                RoleId = p.Role.RoleID,
                RoleName = p.Role.RoleName,
                IsSystemSMH = isSysPage
            }).ToList().FirstOrDefault();
        }

        private async Task<List<SMHPageModel>> GetPageModelByRole(Guid? roleId, bool isSysPage)
        {
            var selectPage = ODataHelper.Select<SMHPageDTO>(x => new { x.PageID, x.PageName, x.PageURL, x.Role.RoleID, x.Role.RoleName });
            var filterPage = roleId == null
                ? (isSysPage ? ODataHelper.Filter<SMHPageDTO>(x => x.PageURL == _defaultSystemUrl) : ODataHelper.Filter<SMHPageDTO>(x => x.PageURL != _defaultSystemUrl))
                : (isSysPage ? ODataHelper.Filter<SMHPageDTO>(x => x.PageURL == _defaultSystemUrl && x.Role.RoleID == roleId) : ODataHelper.Filter<SMHPageDTO>(x => x.PageURL != _defaultSystemUrl && x.Role.RoleID == roleId));

            var pages = await queryClient.QueryAsync<SMHPageDTO>("SMHPages", selectPage + filterPage);

            return pages.Select(p => new SMHPageModel
            {
                PageId = p.PageID,
                PageName = p.PageName,
                PageUrl = p.PageURL,
                RoleId = p.Role.RoleID,
                RoleName = p.Role.RoleName,
                IsSystemSMH = isSysPage
            }).ToList();
        }

        private static SMHPageDTO PageModelToDto(SMHPageModel page)
        {
            return new SMHPageDTO
            {
                PageID = page.PageId,
                PageName = page.PageName,
                PageURL = page.PageUrl,
                RoleId = page.RoleId
            };
        }

        // GET: Admin/ShowMeHow

        public ActionResult RemoveParamBeforeIndex(Guid? pageId, bool? isSysPage)
        {            
            if (pageId != null && isSysPage != null)
            {
                if (isSysPage.Value)
                {
                    TempData["sysPageId"] = pageId;
                    TempData["tabIndex"] = 1;
                }
                else
                {
                    TempData["pageId"] = pageId;
                    TempData["tabIndex"] = 0;
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Index()
        {
            ViewBag.roles = await GetRoles();            
            return View();
        }

        public async Task<ActionResult> ViewAddPage()
        {
            ViewBag.roles = await GetRoles();
            return PartialView("_AddSmhPage");
        }

        public async Task<ActionResult> ViewAddSysPage()
        {
            ViewBag.roles = await GetRoles();
            return PartialView("_AddSmhSysPage");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddPage(SMHPageDTO page)
        {
            var result = await smhClient.AddSmhPageAsync(page);
            TempData["pageId"] = result.PageID;
            TempData["tabIndex"] = 0;
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddSysPage(SMHPageDTO page)
        {
            page.PageURL = _defaultSystemUrl;
            var result = await smhClient.AddSmhPageAsync(page);
            TempData["sysPageId"] = result.PageID;
            TempData["tabIndex"] = 1;
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> ViewEditPage(Guid pageId)
        {
            var data = await GetPageModel(pageId, false);
            return PartialView("_EditSmhPage", data);
        }

        public async Task<ActionResult> ViewEditSysPage(Guid pageId)
        {
            var data = await GetPageModel(pageId, true);
            return PartialView("_EditSmhPage", data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditPage(SMHPageModel page)
        {
            var pageDTO = PageModelToDto(page);
            await smhClient.EditSmhPageAsync(pageDTO);
            if (page.IsSystemSMH)
            {
                TempData["sysPageId"] = page.PageId;
                TempData["tabIndex"] = 1;
            }
            else
            {
                TempData["pageId"] = page.PageId;
                TempData["tabIndex"] = 0;
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> ViewDeletePage(Guid pageId)
        {
            var data = await GetPageModel(pageId, false);
            return PartialView("_DeleteSmhPage", data);
        }

        public async Task<ActionResult> ViewDeleteSysPage(Guid pageId)
        {
            var data = await GetPageModel(pageId, true);
            return PartialView("_DeleteSmhPage", data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeletePage(SMHPageModel page)
        {
            var pageDTO = PageModelToDto(page);
            await smhClient.DeleteSmhPageAsync(pageDTO);
            if (page.IsSystemSMH)
            {
                TempData["sysPageId"] = null;
                TempData["tabIndex"] = 1;
            }
            else
            {
                TempData["pageId"] = null;
                TempData["tabIndex"] = 0;
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> GetPages(Guid? roleId)
        {
            var list = await GetPageModelByRole(roleId, false);
            var jsonData = new { total = list.Count, list };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetSysPages(Guid? roleId)
        {
            var list = await GetPageModelByRole(roleId, true);

            var jsonData = new { total = list.Count, list };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetItemOnPage(Guid pageId)
        {
            var selectItem = ODataHelper.Select<SMHItemDTO>(x => new { x.PageID, x.ItemID, x.ItemName, x.ItemDescription, x.ItemPosition, x.ItemSelector, x.TabContainerId, x.ItemOrder });
            var filterItem = ODataHelper.Filter<SMHItemDTO>(x => x.PageID == pageId);
            var orderItem = ODataHelper.OrderBy<SMHItemDTO>(x => new { x.ItemOrder });
            var items = await queryClient.QueryAsync<SMHItemDTO>("SMHItems", selectItem + filterItem + orderItem);

            return Json(new { data = items }, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> ViewAddItem(Guid pageId)
        {
            var selectItem = ODataHelper.Select<SMHItemDTO>(x => new { x.PageID, x.ItemID, x.ItemName, x.ItemDescription, x.ItemPosition, x.ItemSelector, x.TabContainerId, x.ItemOrder });
            var filterItem = ODataHelper.Filter<SMHItemDTO>(x => x.PageID == pageId);
            var items = await queryClient.QueryAsync<SMHItemDTO>("SMHItems", selectItem + filterItem);

            var itemsOnPage = (items == null ? 0 : items.Count());
            SMHItemDTO item = new SMHItemDTO { PageID = pageId, ItemOrder = itemsOnPage + 1 };
            return PartialView("_AddSmhItem", item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddItem(SMHItemDTO itemDto)
        {
            var result = await smhClient.AddSmhItemAsync(itemDto);

            var page = await GetPageDto(itemDto.PageID);
            if (page != null)
            {
                if (page.PageURL.Equals(_defaultSystemUrl))
                {
                    TempData["tabIndex"] = 1;
                    TempData["sysPageId"] = page.PageID;
                }
                else
                {
                    TempData["tabIndex"] = 0;
                    TempData["pageId"] = page.PageID;
                }
            }

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> ViewEditItem(Guid itemId)
        {
            return PartialView("_EditSmhItem", await GetItemDto(itemId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditItem(SMHItemDTO itemDto)
        {
            await smhClient.EditSmhItemAsync(itemDto);

            var page = await GetPageDto(itemDto.PageID);
            if (page != null)
            {
                if (page.PageURL.Equals(_defaultSystemUrl))
                {
                    TempData["tabIndex"] = 1;
                    TempData["sysPageId"] = page.PageID;
                }
                else
                {
                    TempData["tabIndex"] = 0;
                    TempData["pageId"] = page.PageID;
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> ViewDeleteItem(Guid itemId)
        {
            return PartialView("_DeleteSmhItem", await GetItemDto(itemId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteItem(SMHItemDTO itemDto)
        {
            await smhClient.DeleteSmhItemAsync(itemDto);

            var page = await GetPageDto(itemDto.PageID);
            if (page != null)
            {
                if (page.PageURL.Equals(_defaultSystemUrl))
                {
                    TempData["tabIndex"] = 1;
                    TempData["sysPageId"] = page.PageID;
                }
                else
                {
                    TempData["tabIndex"] = 0;
                    TempData["pageId"] = page.PageID;
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SaveItemOrder(string listId, bool isSysPage, Guid pageID)
        {
            try
            {

                string[] list = listId.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (list != null)
                {
                    for (int i = 0; i < list.Length; i++)
                    {
                        var itemI = list[i].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (itemI != null && itemI.Length > 1)
                        {
                            var index = itemI[0];
                            var itemId = new Guid(itemI[1]);

                            var itemDto = await GetItemDto(itemId);
                            if (itemDto != null)
                            {
                                itemDto.ItemOrder = int.Parse(index) + 1;
                                await smhClient.EditSmhItemAsync(itemDto);

                            }
                        }
                    }
                }
                this.AddToastMessage("Save successfully", "The order has been changed", ToastType.Success, false);
                var redirectUrl = new UrlHelper(Request.RequestContext).Action("RemoveParamBeforeIndex", "ShowMeHow", new { area = "Admin", pageId = pageID, isSysPage = isSysPage });
                return Json(new { Url = redirectUrl });
            }
            catch (Exception)
            {
                this.AddToastMessage("Save fail", "The order has not been saved", ToastType.Error, false);
                var redirectUrl = new UrlHelper(Request.RequestContext).Action("RemoveParamBeforeIndex", "ShowMeHow", new { area = "Admin", pageId = pageID, isSysPage = isSysPage });
                return Json(new { Url = redirectUrl });
            }
        }
    }
}