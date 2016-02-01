using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Presentation.Web.Areas.Admin.Models;
using Bec.TargetFramework.Presentation.Web.Filters;
using Bec.TargetFramework.Presentation.Web.Helpers;
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

        // GET: Admin/ShowMeHow
        public async Task<ActionResult> Index()
        {
            var select = ODataHelper.Select<RoleDTO>(x => new { x.RoleID, x.RoleName });
            var roles = await queryClient.QueryAsync<RoleDTO>("Roles", select);
            ViewBag.roles = roles.Select(x => new SelectListItem { Text = x.RoleName, Value = x.RoleID.ToString() }).ToList();
            return View();
        }

        public async Task<ActionResult> ViewAddPage()
        {
            var select = ODataHelper.Select<RoleDTO>(x => new { x.RoleID, x.RoleName });
            var roles = await queryClient.QueryAsync<RoleDTO>("Roles", select);
            ViewBag.roles = roles.Select(x => new SelectListItem { Text = x.RoleName, Value = x.RoleID.ToString() }).ToList();
            return PartialView("_AddSmhPage");
        }

        public async Task<ActionResult> ViewAddSysPage()
        {
            var select = ODataHelper.Select<RoleDTO>(x => new { x.RoleID, x.RoleName });
            var roles = await queryClient.QueryAsync<RoleDTO>("Roles", select);
            ViewBag.roles = roles.Select(x => new SelectListItem { Text = x.RoleName, Value = x.RoleID.ToString() }).ToList();
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
            var selectPage = ODataHelper.Select<SMHPageDTO>(x => new { x.PageID, x.PageName, x.PageURL, x.RoleId });
            var filterPage = ODataHelper.Filter<SMHPageDTO>(x => x.PageID == pageId);
            var pages = await queryClient.QueryAsync<SMHPageDTO>("SMHPages", selectPage + filterPage);

            var select = ODataHelper.Select<RoleDTO>(x => new { x.RoleID, x.RoleName });
            var roles = await queryClient.QueryAsync<RoleDTO>("Roles", select);
            var data = pages.Join(roles, p => p.RoleId, r => r.RoleID
                , (p, r) => new SMHPageModel
                {
                    PageId = p.PageID,
                    PageName = p.PageName,
                    PageUrl = p.PageURL,
                    RoleId = p.RoleId.Value,
                    RoleName = r.RoleName,
                    IsSystemSMH = false
                }).ToList().FirstOrDefault();
            return PartialView("_EditSmhPage", data);
        }

        public async Task<ActionResult> ViewEditSysPage(Guid pageId)
        {
            var selectPage = ODataHelper.Select<SMHPageDTO>(x => new { x.PageID, x.PageName, x.PageURL, x.RoleId });
            var filterPage = ODataHelper.Filter<SMHPageDTO>(x => x.PageID == pageId);
            var pages = await queryClient.QueryAsync<SMHPageDTO>("SMHPages", selectPage + filterPage);

            var select = ODataHelper.Select<RoleDTO>(x => new { x.RoleID, x.RoleName });
            var roles = await queryClient.QueryAsync<RoleDTO>("Roles", select);
            var data = pages.Join(roles, p => p.RoleId, r => r.RoleID
                , (p, r) => new SMHPageModel
                {
                    PageId = p.PageID,
                    PageName = p.PageName,
                    PageUrl = p.PageURL,
                    RoleId = p.RoleId.Value,
                    RoleName = r.RoleName,
                    IsSystemSMH = true
                }).ToList().FirstOrDefault();
            return PartialView("_EditSmhPage", data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditPage(SMHPageModel page)
        {
            var pageDTO = new SMHPageDTO
            {
                PageID = page.PageId,
                PageName = page.PageName,
                PageURL = page.PageUrl,
                RoleId = page.RoleId
            };
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
            var selectPage = ODataHelper.Select<SMHPageDTO>(x => new { x.PageID, x.PageName, x.PageURL, x.RoleId });
            var filterPage = ODataHelper.Filter<SMHPageDTO>(x => x.PageID == pageId);
            var pages = await queryClient.QueryAsync<SMHPageDTO>("SMHPages", selectPage + filterPage);

            var select = ODataHelper.Select<RoleDTO>(x => new { x.RoleID, x.RoleName });
            var roles = await queryClient.QueryAsync<RoleDTO>("Roles", select);
            var data = pages.Join(roles, p => p.RoleId, r => r.RoleID
                , (p, r) => new SMHPageModel
                {
                    PageId = p.PageID,
                    PageName = p.PageName,
                    PageUrl = p.PageURL,
                    RoleId = p.RoleId.Value,
                    RoleName = r.RoleName,
                    IsSystemSMH = false
                }).ToList().FirstOrDefault();
            return PartialView("_DeleteSmhPage", data);
        }

        public async Task<ActionResult> ViewDeleteSysPage(Guid pageId)
        {
            var selectPage = ODataHelper.Select<SMHPageDTO>(x => new { x.PageID, x.PageName, x.PageURL, x.RoleId });
            var filterPage = ODataHelper.Filter<SMHPageDTO>(x => x.PageID == pageId);
            var pages = await queryClient.QueryAsync<SMHPageDTO>("SMHPages", selectPage + filterPage);

            var select = ODataHelper.Select<RoleDTO>(x => new { x.RoleID, x.RoleName });
            var roles = await queryClient.QueryAsync<RoleDTO>("Roles", select);
            var data = pages.Join(roles, p => p.RoleId, r => r.RoleID
                , (p, r) => new SMHPageModel
                {
                    PageId = p.PageID,
                    PageName = p.PageName,
                    PageUrl = p.PageURL,
                    RoleId = p.RoleId.Value,
                    RoleName = r.RoleName,
                    IsSystemSMH = true
                }).ToList().FirstOrDefault();
            return PartialView("_DeleteSmhPage", data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeletePage(SMHPageModel page)
        {
            var pageDTO = new SMHPageDTO
            {
                PageID = page.PageId,
                PageName = page.PageName,
                PageURL = page.PageUrl,
                RoleId = page.RoleId
            };
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

        public async Task<ActionResult> GetPages()
        {
            var selectPage = ODataHelper.Select<SMHPageDTO>(x => new { x.PageID, x.PageName, x.PageURL, x.RoleId });
            var filterPage = ODataHelper.Filter<SMHPageDTO>(x => x.PageURL != _defaultSystemUrl);
            var pages = await queryClient.QueryAsync<SMHPageDTO>("SMHPages", selectPage + filterPage);

            var selectRoles = ODataHelper.Select<RoleDTO>(x => new { x.RoleID, x.RoleName });
            var roles = await queryClient.QueryAsync<RoleDTO>("Roles", selectRoles);

            var list = pages.Join(roles, p => p.RoleId, r => r.RoleID
                , (p, r) => new SMHPageModel
                        {
                            PageId = p.PageID,
                            PageName = p.PageName,
                            PageUrl = p.PageURL,
                            RoleId = p.RoleId.Value,
                            RoleName = r.RoleName,
                            IsSystemSMH = false
                        }).ToList();

            //var res = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(list, Formatting.None));            
            //return Content(res, "application/json");
            var jsonData = new { total = list.Count, list };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetSysPages()
        {
            var selectPage = ODataHelper.Select<SMHPageDTO>(x => new { x.PageID, x.PageName, x.PageURL, x.RoleId });
            var filterPage = ODataHelper.Filter<SMHPageDTO>(x => x.PageURL == _defaultSystemUrl);
            var pages = await queryClient.QueryAsync<SMHPageDTO>("SMHPages", selectPage + filterPage);

            var selectRoles = ODataHelper.Select<RoleDTO>(x => new { x.RoleID, x.RoleName });
            var roles = await queryClient.QueryAsync<RoleDTO>("Roles", selectRoles);

            var list = pages.Join(roles, p => p.RoleId, r => r.RoleID
                , (p, r) => new SMHPageModel
                {
                    PageId = p.PageID,
                    PageName = p.PageName,
                    PageUrl = p.PageURL,
                    RoleId = p.RoleId.Value,
                    RoleName = r.RoleName,
                    IsSystemSMH = true
                }).ToList();

            //var res = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(list, Formatting.None));            
            //return Content(res, "application/json");
            var jsonData = new { total = list.Count, list };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetItemOnPage(Guid pageId)
        {
            var selectItem = ODataHelper.Select<SMHItemDTO>(x => new { x.PageID, x.ItemID, x.ItemName, x.ItemDescription, x.ItemPosition, x.ItemSelector, x.TabContainerId, x.ItemOrder });
            var filterItem = ODataHelper.Filter<SMHItemDTO>(x => x.PageID == pageId);
            var orderItem = ODataHelper.OrderBy<SMHItemDTO>(x => new { x.ItemOrder });
            var items = await queryClient.QueryAsync<SMHItemDTO>("SMHItems", selectItem + filterItem + orderItem);

            var res = await Task.Factory.StartNew(() => JsonConvert.SerializeObject(items, Formatting.None));
            //return Content(res, "application/json");
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
            var pageId = itemDto.PageID;
            var selectPage = ODataHelper.Select<SMHPageDTO>(x => new { x.PageID, x.PageName, x.PageURL, x.RoleId });
            var filterPage = ODataHelper.Filter<SMHPageDTO>(x => x.PageID == pageId);
            var pages = await queryClient.QueryAsync<SMHPageDTO>("SMHPages", selectPage + filterPage);

            if (pages != null && pages.Count() > 0)
            {
                var page = pages.FirstOrDefault();
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
            }

            //var index = TempData["tabIndex"];
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> ViewEditItem(Guid itemId)
        {
            var selectItem = ODataHelper.Select<SMHItemDTO>(x => new { x.PageID, x.ItemID, x.ItemName, x.ItemDescription, x.ItemPosition, x.ItemSelector, x.TabContainerId, x.ItemOrder });
            var filterItem = ODataHelper.Filter<SMHItemDTO>(x => x.ItemID == itemId);
            var items = await queryClient.QueryAsync<SMHItemDTO>("SMHItems", selectItem + filterItem);

            return PartialView("_EditSmhItem", items.FirstOrDefault());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditItem(SMHItemDTO itemDto)
        {
            await smhClient.EditSmhItemAsync(itemDto);

            var pageId = itemDto.PageID;
            var selectPage = ODataHelper.Select<SMHPageDTO>(x => new { x.PageID, x.PageName, x.PageURL, x.RoleId });
            var filterPage = ODataHelper.Filter<SMHPageDTO>(x => x.PageID == pageId);
            var pages = await queryClient.QueryAsync<SMHPageDTO>("SMHPages", selectPage + filterPage);

            if (pages != null && pages.Count() > 0)
            {
                var page = pages.FirstOrDefault();
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
            }
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> ViewDeleteItem(Guid itemId)
        {
            var selectItem = ODataHelper.Select<SMHItemDTO>(x => new { x.PageID, x.ItemID, x.ItemName, x.ItemDescription, x.ItemPosition, x.ItemSelector, x.TabContainerId, x.ItemOrder });
            var filterItem = ODataHelper.Filter<SMHItemDTO>(x => x.ItemID == itemId);
            var items = await queryClient.QueryAsync<SMHItemDTO>("SMHItems", selectItem + filterItem);

            return PartialView("_DeleteSmhItem", items.FirstOrDefault());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteItem(SMHItemDTO itemDto)
        {
            await smhClient.DeleteSmhItemAsync(itemDto);

            var pageId = itemDto.PageID;
            var selectPage = ODataHelper.Select<SMHPageDTO>(x => new { x.PageID, x.PageName, x.PageURL, x.RoleId });
            var filterPage = ODataHelper.Filter<SMHPageDTO>(x => x.PageID == pageId);
            var pages = await queryClient.QueryAsync<SMHPageDTO>("SMHPages", selectPage + filterPage);

            if (pages != null && pages.Count() > 0)
            {
                var page = pages.FirstOrDefault();
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
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SaveItemOrder(string listId)
        {
            try
            {
                string[] list = listId.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                if (list != null && list.Length > 0)
                {
                    for (int i = 0; i < list.Length; i++)
                    {
                        var itemI = list[i].Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (itemI != null && itemI.Length > 1)
                        {
                            var index = itemI[0];
                            var itemId = new Guid(itemI[1]);

                            var selectItem = ODataHelper.Select<SMHItemDTO>(x => new { x.PageID, x.ItemID, x.ItemName, x.ItemDescription, x.ItemPosition, x.ItemSelector, x.TabContainerId, x.ItemOrder });
                            var filterItem = ODataHelper.Filter<SMHItemDTO>(x => x.ItemID == itemId);
                            var items = await queryClient.QueryAsync<SMHItemDTO>("SMHItems", selectItem + filterItem);
                            var itemDto = items.FirstOrDefault();
                            if (itemDto != null)
                            {
                                itemDto.ItemOrder = int.Parse(index) + 1;
                                await smhClient.EditSmhItemAsync(itemDto);
                            }
                        }
                    }
                }
                return Json(new { data = "OK" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                return Json(new { data = "Not OK" }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}