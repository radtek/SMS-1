﻿using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Filters;
using Bec.TargetFramework.Presentation.Web.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using Bec.TargetFramework.Presentation.Web.Models.ToastrNotification;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    public class SupportController : ApplicationControllerBase
    {
        public IQueryLogicClient queryClient { get; set; }
        public IHelpLogicClient helpClient { get; set; }
        public INotificationLogicClient notificationClient { get; set; }

        [ClaimsRequired("Add", "Support", Order = 1000)]
        public async Task<ActionResult> Index(Guid? supportItemId)
        {
            if (supportItemId != null && supportItemId != default(Guid))
            {
                var select = ODataHelper.Select<SupportItemDTO>(x => new { x.SupportItemID, x.IsClosed });
                var filter = ODataHelper.Filter<SupportItemDTO>(x => x.SupportItemID == supportItemId);
                var res = await queryClient.QueryAsync<SupportItemDTO>("SupportItems", select + filter);
                var supportItem = res.FirstOrDefault();
                var isClose = (supportItem != null) && (supportItem.IsClosed);
                TempData["SupportItemId"] = supportItemId;
                TempData["tabIndex"] = isClose ? 1 : 0;
                var pageNumber = await helpClient.GetSupportItemRankAsync(supportItemId.Value, isClose);
                TempData["rowNumber"] = pageNumber;
                TempData["resetSort"] = true;
            }
            return View();
        }
        [ClaimsRequired("Add", "Support", Order = 1000)]
        public async Task<ActionResult> GetSupportItems(string search)
        {
            JObject res = await GetRequests(false, search);
            return Content(res.ToString(Formatting.None), "application/json");
        }
        [ClaimsRequired("Add", "Support", Order = 1000)]
        public async Task<ActionResult> GetClosedSupportItems(string search)
        {
            JObject res = await GetRequests(true, search);
            return Content(res.ToString(Formatting.None), "application/json");
        }
        [ClaimsRequired("Add", "Support", Order = 1000)]
        private async Task<JObject> GetRequests(bool isClosed, string search)
        {
            var select = ODataHelper.Select<SupportItemDTO>(x => new
            {
                x.SupportItemID,
                x.Title,
                x.Description,
                x.CreatedOn,
                cbfn = x.UserAccountOrganisation_CreatedBy.Contact.FirstName,
                cbln = x.UserAccountOrganisation_CreatedBy.Contact.LastName,
                x.IsClosed,
                x.TicketNumber,
                x.Reason,
                x.ClosedOn,
                clbfn = x.UserAccountOrganisation_ClosedBy.Contact.FirstName,
                clbln = x.UserAccountOrganisation_ClosedBy.Contact.LastName,
                x.RequestTypeID,
                x.UserAccountOrganisationID,
                x.Telephone,
                x.UserAccountOrganisation.UserAccount.Email,
                x.UserAccountOrganisation.Contact.Salutation,
                x.UserAccountOrganisation.Contact.FirstName,
                x.UserAccountOrganisation.Contact.LastName
            }, false);
            var where = ODataHelper.Expression<SupportItemDTO>(x => x.IsClosed == isClosed);
            if (!string.IsNullOrEmpty(search))
            {
                search = search.Trim().ToLower();
                int number = 0;
                Int32.TryParse(search, out number);
                where = Expression.And(where, ODataHelper.Expression<SupportItemDTO>(x =>
                    x.TicketNumber == number ||
                    x.Telephone.ToLower().Contains(search) ||
                    x.Title.ToLower().Contains(search) ||
                    x.UserAccountOrganisation.UserAccount.Email.ToLower().Contains(search) ||
                    x.UserAccountOrganisation.Contact.FirstName.ToLower().Contains(search) ||
                    x.UserAccountOrganisation.Contact.LastName.ToLower().Contains(search)
                    ));
            }
            var filter = ODataHelper.Filter(where);
            return await queryClient.QueryAsync("SupportItems", ODataHelper.RemoveParameters(Request) + select + filter);
        }
        [ClaimsRequired("Send", "Support", Order = 1000)]
        public ActionResult ViewAddSupportItem(SupportItemDTO supportItem)
        {
            ViewBag.Email = WebUserHelper.GetWebUserObject(HttpContext).Email;
            ViewBag.UserName = WebUserHelper.GetWebUserObject(HttpContext).UserName;
            return PartialView("_AddSupportItem", supportItem);
        }
        [ClaimsRequired("Send", "Support", Order = 1000)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddSupportItem(SupportItemDTO supportItem)
        {
            try
            {
                var orgId = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
                supportItem.UserAccountOrganisationID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
                supportItem.CreatedBy = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
                
                var supportItemId = await helpClient.CreateSupportItemAsync(orgId, supportItem);
                this.AddToastMessage("Request Message", "The request message sent successfully!", ToastType.Success);
                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return Json(new { result = false, title = "Request Message", message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [ClaimsRequired("Add", "Support", Order = 1000)]
        public async Task<ActionResult> ViewCloseSupportItem(Guid SupportItemId, int pageNumber)
        {
            ViewBag.SupportItemId = SupportItemId;
            ViewBag.pageNumber = pageNumber;
            var select = ODataHelper.Select<SupportItemDTO>(x => new
            {
                x.SupportItemID,
                x.Title,
                x.Reason,
            });
            var filter = ODataHelper.Filter<SupportItemDTO>(x => x.SupportItemID == SupportItemId);
            var res = await queryClient.QueryAsync<SupportItemDTO>("SupportItems", select + filter);
            var supportItem = res.FirstOrDefault();
            return PartialView("_CloseSupportItem", Edit.MakeModel(supportItem));
        }
        [ClaimsRequired("Add", "Support", Order = 1000)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CloseSupportItem(Guid supportItemId)
        {
            try
            {
                var filter = ODataHelper.Filter<SupportItemDTO>(x => x.SupportItemID == supportItemId);
                var data = Edit.fromD(Request.Form,
                    "Reason"
                  );
                data.Add("IsClosed", "true");
                data.Add("ClosedBy", WebUserHelper.GetWebUserObject(HttpContext).UaoID);
                data.Add("ClosedOn", DateTime.Now);
                await queryClient.UpdateGraphAsync("SupportItems", data, filter);
                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return Json(new
                {
                    result = false,
                    title = "Close Support Message Failed",
                    message = ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}