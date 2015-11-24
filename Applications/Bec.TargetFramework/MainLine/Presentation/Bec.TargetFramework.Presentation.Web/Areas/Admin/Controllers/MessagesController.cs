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
            var result = await QueryClient.QueryAsync<VConversationDTO>("VConversations", select + filter + order + ODataHelper.PageFilter(page, pageSize));
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetConversationsActivity(ActivityType activityType, Guid activityId, int page, int pageSize)
        {
            var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            int at = activityType.GetIntValue();
            var select = ODataHelper.Select<VConversationActivityDTO>(x => new { x.ConversationID, x.Subject, x.Latest });
            var filter = ODataHelper.Filter<VConversationActivityDTO>(x => x.ActivityID == activityId && x.ActivityType == at);
            var order = ODataHelper.OrderBy<VConversationDTO>(x => new { x.Latest }) + " desc";
            var result = await QueryClient.QueryAsync<VConversationActivityDTO>("VConversations", select + filter + order + ODataHelper.PageFilter(page, pageSize));
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetMessages(Guid conversationId, int page, int pageSize)
        {
            var select = ODataHelper.Select<VMessageDTO>(x => new
            {
                x.NotificationID,
                x.DateSent,
                x.Message,
                x.Email,
                x.FirstName,
                x.LastName,
                x.UserType,
                x.OrganisationType
            });
            var filter = ODataHelper.Filter<VMessageDTO>(x => x.ConversationID == conversationId);
            var order = ODataHelper.OrderBy<VMessageDTO>(x => new { x.DateSent }) + " desc";
            var messages = await QueryClient.QueryAsync<VMessageDTO>("VMessages", select + filter + order + ODataHelper.PageFilter(page, pageSize));

            var rSelect = ODataHelper.Select<VMessageReadDTO>(x => new { x.NotificationID, x.IsAccepted, x.AcceptedDate, x.Email, x.FirstName, x.LastName });
            var rFilter = ODataHelper.Filter<VMessageReadDTO>(x => x.ConversationID == conversationId);
            var reads = await QueryClient.QueryAsync<VMessageReadDTO>("VMessageReads", rSelect + rFilter);

            var data = messages.GroupJoin(reads, x => x.NotificationID, x => x.NotificationID, (x, y) => new { Message = x, Reads = y });

            var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            NotificationClient.MarkAsRead(uaoId, conversationId);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Reply(Guid conversationId, string message)
        {
            var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            await NotificationClient.ReplyToConversationAsync(uaoId, conversationId, message);

            return Json("ok");
        }

        public async Task<ActionResult> ViewCreateConversation(ActivityType activityType, Guid activityId, int pageNumber)
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

                    var model = new CreateConversationDTO
                    {
                        ActivityType = activityType,
                        ActivityId = activityId,
                        ParticipantUaoIds = new List<Guid> { recip.UserAccountOrganisationID }
                    };
                    ViewBag.pageNumber = pageNumber;
                    return PartialView("_CreateConversation", model);
            }

            return NotAuthorised();
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