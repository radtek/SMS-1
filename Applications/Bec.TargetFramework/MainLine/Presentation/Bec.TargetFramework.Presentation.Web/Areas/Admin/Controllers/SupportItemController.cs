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
using Bec.TargetFramework.Presentation.Web.Models.ToastrNotification;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    public class SupportItemController : ApplicationControllerBase
    {
        public IQueryLogicClient queryClient { get; set; }
        public ISupportLogicClient supportClient { get; set; }
        public INotificationLogicClient notificationClient { get; set; }

        [ClaimsRequired("Add", "SupportItem", Order = 1000)]
        public ActionResult Index()
        {
            return View();
        }
        [ClaimsRequired("Add", "SupportItem", Order = 1000)]
        public async Task<ActionResult> GetSupportItems()
        {
            JObject res = await GetRequests(false);
            return Content(res.ToString(Formatting.None), "application/json");
        }
        [ClaimsRequired("Add", "SupportItem", Order = 1000)]
        public async Task<ActionResult> GetClosedSupportItems()
        {
            JObject res = await GetRequests(true);
            return Content(res.ToString(Formatting.None), "application/json");
        }
        [ClaimsRequired("Add", "SupportItem", Order = 1000)]
        private async Task<JObject> GetRequests(bool isClosed)
        {
            var select = ODataHelper.Select<SupportItemDTO>(x => new
            {
                x.SupportItemID,
                x.Title,
                x.Description,
                x.CreatedOn,
                x.CreatedBy,
                x.IsClosed,
                x.TicketNumber,
                x.Reason,
                x.ClosedOn,
                x.ClosedBy,
                x.RequestTypeID,
                x.UserAccountOrganisationID,
                x.Telephone,
                x.UserAccountOrganisation.UserAccount.Email,
                x.UserAccountOrganisation.Contact.Salutation,
                x.UserAccountOrganisation.Contact.FirstName,
                x.UserAccountOrganisation.Contact.LastName
            }, false);
            var where = ODataHelper.Expression<SupportItemDTO>(x => x.IsClosed == isClosed);
            var filter = ODataHelper.Filter(where);
            return await queryClient.QueryAsync("SupportItems", ODataHelper.RemoveParameters(Request) + select + filter);
        }
        [ClaimsRequired("Send", "SupportItem", Order = 1000)]
        public ActionResult ViewAddSupportItem(SupportItemDTO supportItem)
        {
            ViewBag.Email = WebUserHelper.GetWebUserObject(HttpContext).Email;
            ViewBag.UserName = WebUserHelper.GetWebUserObject(HttpContext).UserName; 
            return PartialView("_AddSupportItem", supportItem);
        }
        [ClaimsRequired("Send", "SupportItem", Order = 1000)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddSupportItem(SupportItemDTO supportItem)
        {
            try
            {
                supportItem.UserAccountOrganisationID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
                supportItem.CreatedBy = WebUserHelper.GetWebUserObject(HttpContext).Email;
                var supportItemId = await supportClient.CreateSupportItemAsync(supportItem);
                this.AddToastMessage("Request Message", "The request message sent successfully!", ToastType.Success, false);
                var addConversation = new CreateConversationDTO()
                {
                    ActivityType = ActivityType.SupportMessage,
                    ActivityId = supportItemId,
                    Subject = supportItem.Title,
                    Message = supportItem.Description,
                    RecipientUaoIds = new List<Guid>() { }
                };
                var res = CreateConversation(addConversation);
                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                return Json(new { result = false, title = "Request Message", message =  ex.Message}, JsonRequestBehavior.AllowGet);
            }
           
        }
        [ClaimsRequired("Add", "SupportItem", Order = 1000)]
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
        [ClaimsRequired("Add", "SupportItem", Order = 1000)]
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
                data.Add("ClosedBy", WebUserHelper.GetWebUserObject(HttpContext).Email);
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

        async Task<bool> CreateConversation(CreateConversationDTO addConversationDto)
        {
            try
            {
                var orgID = HttpContext.GetWebUserObject().OrganisationID;
                var uaoID = HttpContext.GetWebUserObject().UaoID;
                await notificationClient.CreateConversationAsync(orgID, uaoID, addConversationDto.AttachmentsID, addConversationDto.ActivityType, addConversationDto.ActivityId, addConversationDto.Subject, addConversationDto.Message, addConversationDto.RecipientUaoIds.ToArray());
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}