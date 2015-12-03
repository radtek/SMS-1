using Bec.TargetFramework.Infrastructure.Extensions;
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
using System.Linq.Expressions;

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

        public async Task<ActionResult> GetConversations(ActivityType? activityType, Guid? activityId)
        {
            var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            var select = ODataHelper.Select<VConversationDTO>(x => new { x.ConversationID, x.Subject, x.Latest, x.Unread, x.ActivityID, x.ActivityType, x.IsSystemMessage });
            var filterExpression = ODataHelper.Expression<VConversationDTO>(x => x.UserAccountOrganisationID == uaoId);
            if (activityType.HasValue && activityId.HasValue)
            {
                var activityTypeId = activityType.GetIntValue();
                var activityFilter = ODataHelper.Expression<VConversationDTO>(x => x.ActivityID == activityId && x.ActivityType == activityTypeId);
                filterExpression = Expression.And(filterExpression, activityFilter);
            }
            var filter = ODataHelper.Filter(filterExpression);

            var order = ODataHelper.OrderBy<VConversationDTO>(x => new { x.Latest }) + " desc";
            JObject res = await QueryClient.QueryAsync("VConversations", ODataHelper.RemoveParameters(Request) + select + filter + order);

            foreach (dynamic r in res["Items"])
            {
                if (r.ActivityType != null)
                {
                    ActivityType at = (ActivityType)r.ActivityType;
                    r.LinkDescription = at.GetStringValue();
                    switch ((ActivityType)r.ActivityType)
                    {
                        case ActivityType.BankAccount:
                            r.Link = Url.Action("Index", "Account", new { Area = "BankAccount", selectedBankAccountId = r.ActivityID });
                            break;
                        case ActivityType.SmsTransaction:
                            r.Link = Url.Action("Index", "Transaction", new { Area = "SmsTransaction" });
                            break;
                    }
                }
            }
            return Content(res.ToString(Formatting.None), "application/json");
        }

        public async Task<ActionResult> GetConversationsActivity(ActivityType activityType, Guid activityId)
        {
            var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            int at = activityType.GetIntValue();
            var select = ODataHelper.Select<VConversationActivityDTO>(x => new { x.ConversationID, x.Subject, x.Latest, x.IsSystemMessage });
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

        public async Task<ActionResult> GetRecipients(ActivityType activityType, Guid activityId)
        {
            var orgID = HttpContext.GetWebUserObject().OrganisationID;
            var uaoID = HttpContext.GetWebUserObject().UaoID;

            switch (activityType)
            {
                case ActivityType.SmsTransaction:
                    var select = ODataHelper.Select<VSafeSendRecipientDTO>(x => new
                    {
                        x.UserAccountOrganisationID,
                        x.FirstName,
                        x.LastName,
                        x.OrganisationName
                    });
                    var filter = ODataHelper.Filter<VSafeSendRecipientDTO>(x =>
                        x.SmsTransactionID == activityId &&
                        x.UserAccountOrganisationID != uaoID);

                    var result = await QueryClient.QueryAsync<VSafeSendRecipientDTO>("VSafeSendRecipients", ODataHelper.RemoveParameters(Request) + select + filter);

                    return Json(result, JsonRequestBehavior.AllowGet);
            }
            return NotAuthorised();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Reply(Guid conversationId, string message)
        {
            if (!await CanReply(conversationId))
            {
                return NotAuthorised();
            }

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
            if (!await CanAccessConversationInActivity(addConversationDto.ActivityId, addConversationDto.ActivityType))
            {
                return NotAuthorised();
            }

            try
            {
                var orgID = HttpContext.GetWebUserObject().OrganisationID;
                var uaoID = HttpContext.GetWebUserObject().UaoID;
                await NotificationClient.CreateConversationAsync(orgID, uaoID, addConversationDto.ActivityType, addConversationDto.ActivityId, addConversationDto.Subject, addConversationDto.Message, addConversationDto.RecipientUaoIds.ToArray());
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

        public async Task<bool> CanReply(Guid conversationId)
        {
            var orgId = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;

            // get conversation
            var selectConv = ODataHelper.Select<ConversationDTO>(x => new { x.ActivityID, x.ActivityType });
            var filterConv = ODataHelper.Filter<ConversationDTO>(x => x.ConversationID == conversationId);
            var resultConv = await QueryClient.QueryAsync<ConversationDTO>("Conversations", ODataHelper.RemoveParameters(Request) + selectConv + filterConv);
            var conversation = resultConv.FirstOrDefault();

            return await CanAccessConversationInActivity(conversation.ActivityID, (ActivityType)conversation.ActivityType);
        }

        public async Task<bool> CanAccessConversationInActivity(Guid? activityId, ActivityType activityType)
        {
            var orgId = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;

            // get current user's organisation
            var select = ODataHelper.Select<OrganisationDTO>(x => new { x.OrganisationTypeID });
            var filter = ODataHelper.Filter<OrganisationDTO>(x => x.OrganisationID == orgId);
            var result = await QueryClient.QueryAsync<OrganisationDTO>("Organisations", ODataHelper.RemoveParameters(Request) + select + filter);
            var org = result.FirstOrDefault();

            switch (activityType)
            {
                case ActivityType.SmsTransaction:
                    // get transaction for conversation
                    var selectTx = ODataHelper.Select<SmsTransactionDTO>(x => new { x.SmsTransactionID, x.OrganisationID });
                    var filterTx = ODataHelper.Filter<SmsTransactionDTO>(x => x.SmsTransactionID == activityId);
                    var resultTx = await QueryClient.QueryAsync<SmsTransactionDTO>("SmsTransactions", ODataHelper.RemoveParameters(Request) + selectTx + filterTx);
                    var tx = resultTx.FirstOrDefault();

                    switch ((OrganisationTypeEnum)org.OrganisationTypeID)
                    {
                        case OrganisationTypeEnum.Personal:
                            // get transaction UAOT
                            var transactionId = tx.SmsTransactionID;
                            var selectTxUaot = ODataHelper.Select<SmsUserAccountOrganisationTransactionDTO>(x => new { x.UserAccountOrganisationID });
                            var filterTxUaot = ODataHelper.Filter<SmsUserAccountOrganisationTransactionDTO>(x => x.SmsTransactionID == transactionId && x.UserAccountOrganisationID == uaoId);
                            var resultTxUaot = await QueryClient.QueryAsync<SmsUserAccountOrganisationTransactionDTO>("SmsUserAccountOrganisationTransactions", ODataHelper.RemoveParameters(Request) + selectTxUaot + filterTxUaot);
                            var txUaot = resultTxUaot.FirstOrDefault();

                            return ClaimsAuthorization.CheckAccess("View", "MyTransactions") && txUaot != null;
                        case OrganisationTypeEnum.Professional:
                            return ClaimsAuthorization.CheckAccess("View", "SmsTransaction") && tx.OrganisationID == orgId;
                    }
                    break;
            }

            return false;
        }
    }
}