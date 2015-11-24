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

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    public class MessagesController : ApplicationControllerBase
    {
        public INotificationLogicClient NotificationClient { get; set; }
        public IQueryLogicClient QueryClient { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetConversations(int page, int pageSize)
        {
            var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;

            var select = ODataHelper.Select<VConversationDTO>(x => new { x.ConversationID, x.Subject, x.Latest, x.Unread });
            var filter = ODataHelper.Filter<VConversationDTO>(x => x.UserAccountOrganisationID == uaoId);
            var order = ODataHelper.OrderBy<VConversationDTO>(x => new { x.Latest }) + " desc";
            var result = await QueryClient.QueryAsync<VConversationDTO>("VConversations", ODataHelper.RemoveParameters(Request) + select + filter + order + ODataHelper.PageFilter(page, pageSize));
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetConversationsActivity(ActivityType activityType, Guid activityId, int page, int pageSize)
        {
            var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            int at = activityType.GetIntValue();
            var select = ODataHelper.Select<VConversationActivityDTO>(x => new { x.ConversationID, x.Subject, x.Latest });
            var filter = ODataHelper.Filter<VConversationActivityDTO>(x => x.ActivityID == activityId && x.ActivityType == at);
            var order = ODataHelper.OrderBy<VConversationDTO>(x => new { x.Latest }) + " desc";
            var result = await QueryClient.QueryAsync<VConversationActivityDTO>("VConversations", ODataHelper.RemoveParameters(Request) + select + filter + order + ODataHelper.PageFilter(page, pageSize));
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetMessages(Guid conversationId, int page, int pageSize)
        {
            var select = ODataHelper.Select<NotificationDTO>(x => new
            {
                x.DateSent,
                x.NotificationData,
                x.UserAccountOrganisation.UserAccount.Email,
                Recipients = x.NotificationRecipients.Select(y => new { y.UserAccountOrganisationID, y.IsAccepted, y.UserAccountOrganisation.Organisation.OrganisationType.Name, y.UserAccountOrganisation.UserAccount.Email })
            });
            var filter = ODataHelper.Filter<NotificationDTO>(x => x.ConversationID == conversationId);
            var order = ODataHelper.OrderBy<NotificationDTO>(x => new { x.DateSent }) + " desc";

            var result = await QueryClient.QueryAsync<NotificationDTO>("Notifications", ODataHelper.RemoveParameters(Request) + select + filter + order + ODataHelper.PageFilter(page, pageSize));

            var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            NotificationClient.MarkAsRead(uaoId, conversationId);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetParticipants(Guid activityId)
        {
            var orgID = HttpContext.GetWebUserObject().OrganisationID;
            var select = ODataHelper.Select<SmsUserAccountOrganisationTransactionDTO>(x => new
            {
                x.UserAccountOrganisationID,
            });

            var buyerTypeID = UserAccountOrganisationTransactionType.Buyer.GetIntValue();
            var filter = ODataHelper.Filter<SmsUserAccountOrganisationTransactionDTO>(x =>
                x.SmsTransaction.OrganisationID == orgID && x.SmsTransactionID == activityId && x.SmsUserAccountOrganisationTransactionTypeID == buyerTypeID);

            var result = await QueryClient.QueryAsync<SmsUserAccountOrganisationTransactionDTO>("SmsUserAccountOrganisationTransactions", ODataHelper.RemoveParameters(Request) + select + filter);
            var recip = result.First();

            return Json(recip, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Reply(Guid conversationId, string message)
        {
            var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            await NotificationClient.ReplyToConversationAsync(uaoId, conversationId, message);

            return Json("ok");
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ClaimsRequired("View", "SmsTransaction", Order = 1001)]
        public async Task<ActionResult> CreateConversation(CreateConversationDTO addConversationDto)
        {
            try
            {
                var orgID = HttpContext.GetWebUserObject().OrganisationID;
                var uaoID = HttpContext.GetWebUserObject().UaoID;

                await NotificationClient.CreateConversationAsync(orgID, uaoID, ActivityType.SmsTransaction, addConversationDto.ActivityId, addConversationDto.Subject, addConversationDto.Message, addConversationDto.ParticipantUaoIds.ToArray());

                TempData["SmsTransactionID"] = addConversationDto.ActivityId;
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