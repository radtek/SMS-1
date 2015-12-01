﻿using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Business.Client.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Presentation.Web.Base;
using Bec.TargetFramework.Presentation.Web.Filters;
using Bec.TargetFramework.Presentation.Web.Helpers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Bec.TargetFramework.Security;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    public class MessagesController : ApplicationControllerBase
    {
        public INotificationLogicClient NotificationClient { get; set; }
        public IQueryLogicClient QueryClient { get; set; }

        public ActionResult Index(Guid? conversationId)
        {
            ViewBag.ConversationId = conversationId;
            return View();
        }

        public async Task<int> GetConversationRank(Guid convID)
        {
            var uaoID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            return await NotificationClient.GetConversationRankAsync(uaoID, convID);
        }

        public async Task<ActionResult> GetConversations()
        {
            var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;

            var select = ODataHelper.Select<VConversationDTO>(x => new { x.ConversationID, x.Subject, x.Latest, x.Unread });
            var filter = ODataHelper.Filter<VConversationDTO>(x => x.UserAccountOrganisationID == uaoId);
            var order = ODataHelper.OrderBy<VConversationDTO>(x => new { x.Latest }) + " desc";
            JObject res = await QueryClient.QueryAsync("VConversations", ODataHelper.RemoveParameters(Request) + select + filter + order);
            return Content(res.ToString(Formatting.None), "application/json");
        }

        public async Task<ActionResult> GetConversationsActivity(ActivityType activityType, Guid activityId)
        {
            var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            int at = activityType.GetIntValue();
            var select = ODataHelper.Select<VConversationActivityDTO>(x => new { x.ConversationID, x.Subject, x.Latest });
            var filter = ODataHelper.Filter<VConversationActivityDTO>(x => x.ActivityID == activityId && x.ActivityType == at);
            var order = ODataHelper.OrderBy<VConversationActivityDTO>(x => new { x.Latest }) + " desc";
            JObject res = await QueryClient.QueryAsync("VConversationActivities", ODataHelper.RemoveParameters(Request) + select + filter + order);
            return Content(res.ToString(Formatting.None), "application/json");
        }

        public async Task<ActionResult> GetMessages(Guid conversationId, int page, int pageSize)
        {
            var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;

            var data = await NotificationClient.GetMessagesAsync(conversationId, uaoId, page, pageSize);
            NotificationClient.MarkAsRead(uaoId, conversationId);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetParticipants(ActivityType activityType, Guid activityId)
        {
            var orgID = HttpContext.GetWebUserObject().OrganisationID;

            switch (activityType)
            {
                case ActivityType.SmsTransaction:

                    if (!ClaimsAuthorization.CheckAccess("View", "SmsTransaction")) break;

                    var select = ODataHelper.Select<SmsUserAccountOrganisationTransactionDTO>(x => new { x.UserAccountOrganisationID });
                    var buyerTypeID = UserAccountOrganisationTransactionType.Buyer.GetIntValue();
                    var filter = ODataHelper.Filter<SmsUserAccountOrganisationTransactionDTO>(x => x.SmsTransaction.OrganisationID == orgID && x.SmsTransactionID == activityId && x.SmsUserAccountOrganisationTransactionTypeID == buyerTypeID);

                    var result = await QueryClient.QueryAsync<SmsUserAccountOrganisationTransactionDTO>("SmsUserAccountOrganisationTransactions", ODataHelper.RemoveParameters(Request) + select + filter);
                    var recip = result.First();

                    return Json(recip, JsonRequestBehavior.AllowGet);
            }
            return NotAuthorised();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Reply(Guid conversationId, string message)
        {
            var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            await NotificationClient.ReplyToConversationAsync(uaoId, conversationId, message);

            return Json("ok");
        }


        private ActionResult NotAuthorised()
        {
            Response.StatusCode = 403;
            return Json(new AjaxRequestErrorDTO { RedirectUrl = Url.Action("Denied", "App", new { Area = "" }), HasRedirectUrl = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateConversation(CreateConversationDTO addConversationDto)
        {
            switch (addConversationDto.ActivityType)
            {
                case ActivityType.SmsTransaction:
                    TempData["SmsTransactionID"] = addConversationDto.ActivityId;
                    if (!ClaimsAuthorization.CheckAccess("View", "SmsTransaction")) return NotAuthorised();
                    break;
                default: return NotAuthorised();
            }

            try
            {
                var orgID = HttpContext.GetWebUserObject().OrganisationID;
                var uaoID = HttpContext.GetWebUserObject().UaoID;
                await NotificationClient.CreateConversationAsync(orgID, uaoID, addConversationDto.ActivityType, addConversationDto.ActivityId, addConversationDto.Subject, addConversationDto.Message, addConversationDto.ParticipantUaoIds.ToArray());
                return Json(new { result = true }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    result = false,
                    title = "Adding Conversation Failed",
                    message = ex.Message,
                    activityId = addConversationDto.ActivityId
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}