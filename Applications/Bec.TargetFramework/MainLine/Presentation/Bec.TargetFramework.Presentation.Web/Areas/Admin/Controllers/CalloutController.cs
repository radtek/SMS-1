using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Presentation.Web.Areas.Admin.Models;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Filters;
using Bec.TargetFramework.Presentation.Web.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    [ClaimsRequired("Add", "Callout", Order = 1000)]
    public class CalloutController : ApplicationControllerBase
    {
        public IQueryLogicClient queryClient { get; set; }
        public ICalloutLogicClient calloutClient { get; set; }
        public async Task<ActionResult> Index()
        {
            ViewBag.roles = await GetRoles();
            return View();
        }

        private async Task<List<SelectListItem>> GetRoles()
        {
            var selectRole = ODataHelper.Select<RoleDTO>(x => new
            {
                x.RoleID,
                x.IsActive,
                x.RoleName,
                x.IsDeleted
            }, false);

            var filterRole = ODataHelper.Filter<RoleDTO>(x =>
                !x.IsDeleted && x.IsActive && x.RoleName != "Temporary User" && x.RoleName != "Organisation Branch Administrator"
               );
            var orderbyRole = ODataHelper.OrderBy<RoleDTO>(x => new { x.RoleName });
            var allRoles = (await queryClient.QueryAsync<RoleDTO>("Roles", selectRole + filterRole + orderbyRole)).ToList();
            return allRoles.Select(f => new SelectListItem
            {
                Value = f.RoleID.ToString(),
                Text = f.RoleName
            }).ToList();
        }

        public async Task<ActionResult> GetCallouts(string calloutRoleId)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            var select = ODataHelper.Select<CalloutDTO>(x => new
            {
                x.CalloutID,
                x.IsActive,
                x.Title,
                x.Role.RoleName,
                x.Description,
                x.IsDeleted,
                x.CreatedOn,
                x.ModifiedOn,
                x.Selector,
                x.CreatedBy,
                x.ModifiedBy,
                x.EffectiveOn,
                x.Position,
                x.DisplayOrder
            }, false);

            var where = ODataHelper.Expression<CalloutDTO>(x => !x.IsDeleted);
            Guid roleId = default(Guid);
            Guid.TryParse(calloutRoleId, out roleId);
            if (roleId != default(Guid))
            {
                where = Expression.And(where, ODataHelper.Expression<CalloutDTO>(x => x.RoleID == roleId));
            }
            var filter = ODataHelper.Filter(where);

            JObject res = await queryClient.QueryAsync("Callouts", ODataHelper.RemoveParameters(Request) + select + filter);
            return Content(res.ToString(Formatting.None), "application/json");
        }

        public async Task<ActionResult> ViewAddCallout(CalloutDTO callout)
        {
            ViewBag.roles = await GetRoles();
            return PartialView("_AddCallout", callout);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddCallout(CalloutDTO callout, string calloutRoleId = "")
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            callout.IsActive = true;
            callout.CreatedBy = WebUserHelper.GetWebUserObject(HttpContext).Email;
            TempData["calloutRoleId"] = calloutRoleId;
            TempData["CalloutId"] = await calloutClient.CreateCalloutAsync(callout);
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> ViewEditCallout(Guid CalloutId, int pageNumber = 1, string roleId = "")
        {
            ViewBag.CalloutId = CalloutId;
            ViewBag.pageNumber = pageNumber;
            ViewBag.calloutRoleId = roleId;
            ViewBag.roles = await GetRoles();
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            var select = ODataHelper.Select<CalloutDTO>(x => new
            {
                x.CalloutID,
                x.IsActive,
                x.Title,
                x.Role.RoleName,
                x.Description,
                x.IsDeleted,
                x.RoleID,
                x.EffectiveOn,
                x.DisplayOrder,
                x.Selector,
                x.Position
            });
            var filter = ODataHelper.Filter<CalloutDTO>(x => x.CalloutID == CalloutId);
            var res = await queryClient.QueryAsync<CalloutDTO>("Callouts", select + filter);
            var callout = res.First();
            return PartialView("_EditCallout", Edit.MakeModel(callout));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditCallout(Guid calloutId, int pageNumber = 1, string calloutRoleId = "")
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            try
            {
                var filter = ODataHelper.Filter<CalloutDTO>(x => x.CalloutID == calloutId);
                var data = Edit.fromD(Request.Form,
                    "Description",
                    "Title",
                   "EffectiveOn",
                   "Selector", "Position"
                  );
                data.Add("ModifiedOn", DateTime.Now);
                data.Add("ModifiedBy", WebUserHelper.GetWebUserObject(HttpContext).Email);
                await queryClient.UpdateGraphAsync("Callouts", data, filter);

                var selectCua = ODataHelper.Select<CalloutUserAccountDTO>(x => new
                {
                    x.CalloutUserAccountID
                }, false);
                var filterCuas = ODataHelper.Filter<CalloutUserAccountDTO>(x => x.CalloutID == calloutId);
                var result = await queryClient.QueryAsync<CalloutUserAccountDTO>("CalloutUserAccounts", selectCua + filterCuas);
                var allCuas = result.ToList();
                if (allCuas != null && allCuas.Any())
                {
                    foreach (var item in allCuas)
                    {
                        var cuaId = item.CalloutUserAccountID;
                        var filterCua = ODataHelper.Filter<CalloutUserAccountDTO>(x => x.CalloutUserAccountID == cuaId);
                        data.RemoveAll();
                        data.Add("Visible", "true");
                        await queryClient.UpdateGraphAsync("CalloutUserAccounts", data, filterCua);
                    }
                }
                TempData["CalloutId"] = calloutId;
                TempData["pageNumber"] = pageNumber;
                TempData["calloutRoleId"] = calloutRoleId;
                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    result = false,
                    title = "Edit Callout Failed",
                    message = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<ActionResult> ViewCalloutOrder(Guid RoleId)
        {
            var selectCallout = ODataHelper.Select<CalloutDTO>(x => new
            {
                x.CalloutID,
                x.IsActive,
                x.Title,
                x.EffectiveOn
            }, false);

            var filterCallout = ODataHelper.Filter<CalloutDTO>(x =>
                !x.IsDeleted && x.RoleID == RoleId
               );
            var orderbyCallout = ODataHelper.OrderBy<CalloutDTO>(x => new { x.DisplayOrder });
            var allCallouts = await queryClient.QueryAsync<CalloutDTO>("Callouts", selectCallout + filterCallout + orderbyCallout);

            var calloutModel = new CalloutModel();
            calloutModel.Callouts = allCallouts.ToList();

            return PartialView("_OrderCallout", calloutModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> OrderCallout(string calloutOrderList = "", string calloutRoleId = "")
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            try
            {
                if (!string.IsNullOrWhiteSpace(calloutOrderList))
                {
                    var allCallouts = calloutOrderList.Split(new[] { '?' }, StringSplitOptions.RemoveEmptyEntries);
                    if (allCallouts != null && allCallouts.Any())
                    {
                        foreach (var item in allCallouts)
                        {
                            var tmpCallout = item.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[1];
                            var calloutId = Guid.Parse(tmpCallout);
                            var filter = ODataHelper.Filter<CalloutDTO>(x => x.CalloutID == calloutId);
                            var data = Edit.fromD(Request.Form);
                            data.Add("DisplayOrder", item.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)[0]);
                            await queryClient.UpdateGraphAsync("Callouts", data, filter);
                        }
                    }
                }
                TempData["calloutRoleId"] = calloutRoleId;
                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    result = false,
                    title = "Order Callout Failed",
                    message = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<ActionResult> ViewDeleteCallout(Guid calloutId, string label, string roleId = "")
        {
            ViewBag.calloutId = calloutId;
            ViewBag.calloutRoleId = roleId;
            var select = ODataHelper.Select<CalloutDTO>(x => new
            {
                x.CalloutID,
                x.Title
            });
            var filter = ODataHelper.Filter<CalloutDTO>(x => x.CalloutID == calloutId);
            var res = await queryClient.QueryAsync<CalloutDTO>("Callouts", select + filter);
            var callout = res.First();
            ViewBag.title = callout.Title;
            return PartialView("_DeleteCallout");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteCallout(Guid calloutId, string calloutRoleId = "")
        {
            var filter = ODataHelper.Filter<CalloutDTO>(x => x.CalloutID == calloutId);
            var data = Edit.fromD(Request.Form);
            data.Add("IsDeleted", "true");
            await queryClient.UpdateGraphAsync("Callouts", data, filter);

            var selectCua = ODataHelper.Select<CalloutUserAccountDTO>(x => new
            {
                x.CalloutUserAccountID
            }, false);
            var filterCuas = ODataHelper.Filter<CalloutUserAccountDTO>(x => x.CalloutID == calloutId);
            var result = await queryClient.QueryAsync<CalloutUserAccountDTO>("CalloutUserAccounts", selectCua + filterCuas);
            var allCuas = result.ToList();
            if (allCuas != null && allCuas.Any())
            {
                foreach (var item in allCuas)
                {
                    var cuaId = item.CalloutUserAccountID;
                    var filterCua = ODataHelper.Filter<CalloutUserAccountDTO>(x => x.CalloutUserAccountID == cuaId);
                    data.RemoveAll();
                    data.Add("IsDeleted", "true");
                    await queryClient.UpdateGraphAsync("CalloutUserAccounts", data, filterCua);
                }
            }
            TempData["calloutRoleId"] = calloutRoleId;
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> GetViewedCallouts()
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            var select = ODataHelper.Select<CalloutUserAccountDTO>(x => new
            {
                x.CalloutUserAccountID,
                x.CalloutID,
                x.Callout.Title,
                x.Role.RoleName,
                x.IsDeleted,
                x.CreatedOn,
                x.UserAccount.Email
            }, false);

            var where = ODataHelper.Expression<CalloutDTO>(x => !x.IsDeleted);
            var filter = ODataHelper.Filter(where);

            JObject res = await queryClient.QueryAsync("CalloutUserAccounts", ODataHelper.RemoveParameters(Request) + select + filter);
            return Content(res.ToString(Formatting.None), "application/json");
        }
    }
}