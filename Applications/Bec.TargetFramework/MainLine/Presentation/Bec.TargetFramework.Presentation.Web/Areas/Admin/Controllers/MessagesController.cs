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

        public async Task<ActionResult> GetConversations(Guid? activityId)
        {
            var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;

            var select = ODataHelper.Select<VConversationDTO>(x => new
            {
                x.ConversationID, 
                x.Subject, 
                x.MostRecentDate, 
                x.MostRecentEmail, 
                x.MostRecentMessage, 
                x.FirstUnreadDate, 
                x.FirstUnreadEmail, 
                x.FirstUnreadMessage
            });

            string filter;
            if (activityId.HasValue)
            {
                filter = ODataHelper.Filter<VConversationDTO>(x => x.ActivityID == activityId);
            }
            else
            {
                filter = ODataHelper.Filter<VConversationDTO>(x => x.UserAccountOrganisationID == uaoId);
            }
            
            JObject result = await QueryClient.QueryAsync("VConversations", ODataHelper.RemoveParameters(Request) + select + filter);
            return Content(result.ToString(Formatting.None), "application/json");
        }

        public async Task<ActionResult> GetMessages(Guid conversationId)
        {
            var select = ODataHelper.Select<NotificationDTO>(x => new
            {
                x.DateSent,
                x.NotificationData,
                x.UserAccountOrganisation.UserAccount.Email,
                Recipients = x.NotificationRecipients.Select(y => new { y.UserAccountOrganisationID, y.IsAccepted })
            });
            var filter = ODataHelper.Filter<NotificationDTO>(x => x.ConversationID == conversationId);
            var order = ODataHelper.OrderBy<NotificationDTO>(x => new { x.DateSent });

            JObject result = await QueryClient.QueryAsync("Notifications", ODataHelper.RemoveParameters(Request) + select + filter + order);

            var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            NotificationClient.MarkAsRead(uaoId, conversationId);

            return Content(result.ToString(Formatting.None), "application/json");
        }

        public async Task Create(Guid uaoID, ActivityType? activityTypeID, Guid? activityID, string subject, string message, Guid[] participantsUaoIDs)
        {
            var orgID = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            await NotificationClient.CreateConversationAsync(orgID, uaoID, activityTypeID, activityID, subject, message, participantsUaoIDs);
        }

        public async Task Reply(Guid uaoID, Guid conversationID, string message)
        {
            await NotificationClient.ReplyToConversationAsync(uaoID, conversationID, message);
        }

        [ClaimsRequired("View", "SmsTransaction", Order = 1001)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Reply(Guid conversationId, string message)
        {
            var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            await NotificationClient.ReplyToConversationAsync(uaoId, conversationId, message);

            return Json("ok");
        }

        [ClaimsRequired("View", "SmsTransaction", Order = 1001)]
        public async Task<ActionResult> ViewCreateConversation(Guid activityId, int pageNumber)
        {
            var orgID = HttpContext.GetWebUserObject().OrganisationID;
            var select = ODataHelper.Select<SmsUserAccountOrganisationTransactionDTO>(x => new
            {
                x.UserAccountOrganisationID,
            });

            var buyerTypeID = UserAccountOrganisationTransactionType.Buyer.GetIntValue();
            var filter = ODataHelper.Filter<SmsUserAccountOrganisationTransactionDTO>(x =>
                x.SmsTransaction.OrganisationID == orgID && x.SmsTransactionID == activityId && x.SmsUserAccountOrganisationTransactionTypeID == buyerTypeID);

            dynamic result = await QueryClient.QueryAsync("SmsUserAccountOrganisationTransactions", ODataHelper.RemoveParameters(Request) + select + filter);
            var model = new CreateConversationDTO
            {
                ActivityId = activityId,
                ParticipantUaoIds = new List<Guid> { Guid.Parse((string)result.Items.First.UserAccountOrganisationID) }
            };
            ViewBag.pageNumber = pageNumber;
            return PartialView("_CreateConversation", model);
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