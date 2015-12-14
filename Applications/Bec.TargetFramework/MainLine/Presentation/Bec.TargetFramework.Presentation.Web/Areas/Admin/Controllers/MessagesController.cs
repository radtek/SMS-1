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
using System.Web;
using System.IO;

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
            if (!await CanAccessConversation(convID)) return -1;

            var uaoID = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            return await NotificationClient.GetConversationRankAsync(uaoID, convID);
        }

        public async Task<ActionResult> GetConversations(ActivityType? activityType, Guid? activityId)
        {
            var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            var take = Request["$top"] == null ? 0 : int.Parse(Request["$top"]);
            var skip = Request["$skip"] == null? 0 : int.Parse(Request["$skip"]);
            var res = await NotificationClient.GetConversationsAsync(uaoId, activityType, activityId, take, skip);

            foreach (var r in res.Items)
            {
                if (r.ActivityType != null)
                {
                    ActivityType at = (ActivityType)r.ActivityType;
                    r.LinkDescription = at.GetStringValue();
                    switch ((ActivityType)r.ActivityType)
                    {
                        case ActivityType.BankAccount:
                            if (ClaimsHelper.UserHasClaim("View", "BankAccount"))
                                r.Link = Url.Action("Index", "Account", new { Area = "BankAccount", selectedBankAccountId = r.ActivityID });
                            break;
                        case ActivityType.SmsTransaction:
                            if (ClaimsHelper.UserHasClaim("View", "SmsTransaction"))
                                r.Link = Url.Action("Index", "Transaction", new { Area = "SmsTransaction", selectedTransactionID = r.ActivityID });
                            break;
                    }
                }
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetConversationsActivity(ActivityType activityType, Guid activityId)
        {
            var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            var orgId = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            var take = Request["$top"] == null ? 0 : int.Parse(Request["$top"]);
            var skip = Request["$skip"] == null ? 0 : int.Parse(Request["$skip"]);
            var res = await NotificationClient.GetConversationsActivityAsync(uaoId, orgId, activityType, activityId, take, skip);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetMessages(Guid conversationId, int page, int pageSize)
        {
            //if (!await CanAccessConversation(conversationId)) return NotAuthorised();

            var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;

            var data = await NotificationClient.GetMessagesAsync(conversationId, uaoId, page, pageSize);
            NotificationClient.MarkAsRead(uaoId, conversationId);

            foreach (var item in data)
            {
                foreach (var file in item.Files)
                {
                    file.Link = Url.Action("DownloadFile", "Messages", new { area = "Admin", fileID = file.FileID });
                }
            }

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetParticipants(Guid conversationId)
        {
            //if (!await CanAccessConversation(conversationId)) return NotAuthorised();

            var professionalOrganisationTypeId = OrganisationTypeEnum.Professional.GetIntValue();
            var select = ODataHelper.Select<ConversationParticipantDTO>(x => new
            {
                x.UserAccountOrganisationID,
                x.UserAccountOrganisation.Contact.FirstName,
                x.UserAccountOrganisation.Contact.LastName,
                x.UserAccountOrganisation.Organisation.OrganisationTypeID,
                Names = x.UserAccountOrganisation.Organisation.OrganisationDetails.Select(y => new { y.Name })
            });
            var filter = ODataHelper.Filter<ConversationParticipantDTO>(x => x.ConversationID == conversationId);
            var data = await QueryClient.QueryAsync<ConversationParticipantDTO>("ConversationParticipants", select + filter);

            var dtos = data.Select(x => new ParticipantDTO {
                FirstName = x.UserAccountOrganisation.Contact.FirstName,
                LastName = x.UserAccountOrganisation.Contact.LastName,
                IsProfessionalOrganisation = x.UserAccountOrganisation.Organisation.OrganisationTypeID == professionalOrganisationTypeId,
                OrganisationName = x.UserAccountOrganisation.Organisation.OrganisationDetails.First().Name
            });
            return Json(dtos, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetRecipients(ActivityType activityType, Guid activityId)
        {
            if (!await CanAccessConversationInActivity(activityId, activityType)) return NotAuthorised();

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

                    var result = await QueryClient.QueryAsync<VSafeSendRecipientDTO>("VSafeSendRecipients", select + filter);

                    return Json(result, JsonRequestBehavior.AllowGet);
            }
            return NotAuthorised();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Reply(Guid conversationId, string message)
        {
            if (!await CanReply(conversationId)) return NotAuthorised();            

            var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            await NotificationClient.ReplyToConversationAsync(uaoId, conversationId, message);

            return Json("ok");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateConversation(CreateConversationDTO addConversationDto)
        {
            if (!await CanAccessConversationInActivity(addConversationDto.ActivityId, addConversationDto.ActivityType)) return NotAuthorised();

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




        //access control

        private ActionResult NotAuthorised()
        {
            Response.StatusCode = 403;
            return Json(new AjaxRequestErrorDTO { RedirectUrl = Url.Action("Denied", "App", new { Area = "" }), HasRedirectUrl = true }, JsonRequestBehavior.AllowGet);
        }

        public async Task<bool> CanReply(Guid conversationId)
        {
            return await checkAccess(conversationId, true);
        }

        public async Task<bool> CanAccessConversation(Guid conversationId)
        {
            return await checkAccess(conversationId, false);
        }

        private async Task<bool> checkAccess(Guid conversationId, bool reply)
        {
            var orgId = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;

            // get conversation
            var selectConv = ODataHelper.Select<ConversationDTO>(x => new { x.ActivityID, x.ActivityType });
            var filterConv = ODataHelper.Filter<ConversationDTO>(x => x.ConversationID == conversationId);
            var resultConv = await QueryClient.QueryAsync<ConversationDTO>("Conversations", selectConv + filterConv);
            var conversation = resultConv.FirstOrDefault();

            if (reply && conversation.ActivityType.HasValue && !checkReply((ActivityType)conversation.ActivityType)) return false;

            // get participants
            var select = ODataHelper.Select<ConversationParticipantDTO>(x => new { x.UserAccountOrganisationID, x.UserAccountOrganisation.OrganisationID });
            var filter = ODataHelper.Filter<ConversationParticipantDTO>(x => x.ConversationID == conversationId);
            var participants = await QueryClient.QueryAsync<ConversationParticipantDTO>("ConversationParticipants", select + filter);

            if (!participants.Any(x => x.UserAccountOrganisation.OrganisationID == orgId)) return false;

            if (conversation.ActivityType.HasValue &&
                !await CanAccessConversationInActivity(conversation.ActivityID, (ActivityType)conversation.ActivityType)) return false;

            return true;
        }

        private bool checkReply(ActivityType activityType)
        {
            switch (activityType)
            {
                case ActivityType.SmsTransaction: return true;
            }
            return false;
        }

        private async Task<bool> CanAccessConversationInActivity(Guid? activityId, ActivityType activityType)
        {
            var orgId = WebUserHelper.GetWebUserObject(HttpContext).OrganisationID;
            var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;

            // get current user's organisation
            var select = ODataHelper.Select<OrganisationDTO>(x => new { x.OrganisationTypeID });
            var filter = ODataHelper.Filter<OrganisationDTO>(x => x.OrganisationID == orgId);
            var result = await QueryClient.QueryAsync<OrganisationDTO>("Organisations", select + filter);
            var org = result.FirstOrDefault();

            switch (activityType)
            {
                case ActivityType.SmsTransaction:
                    // get transaction for conversation
                    var selectTx = ODataHelper.Select<SmsTransactionDTO>(x => new { x.OrganisationID });
                    var filterTx = ODataHelper.Filter<SmsTransactionDTO>(x => x.SmsTransactionID == activityId);
                    var resultTx = await QueryClient.QueryAsync<SmsTransactionDTO>("SmsTransactions", selectTx + filterTx);
                    var tx = resultTx.FirstOrDefault();

                    switch ((OrganisationTypeEnum)org.OrganisationTypeID)
                    {
                        case OrganisationTypeEnum.Personal:
                            // get transaction UAOT
                            var selectTxUaot = ODataHelper.Select<SmsUserAccountOrganisationTransactionDTO>(x => new { x.UserAccountOrganisationID });
                            var filterTxUaot = ODataHelper.Filter<SmsUserAccountOrganisationTransactionDTO>(x => x.SmsTransactionID == activityId && x.UserAccountOrganisationID == uaoId);
                            var resultTxUaot = await QueryClient.QueryAsync<SmsUserAccountOrganisationTransactionDTO>("SmsUserAccountOrganisationTransactions", selectTxUaot + filterTxUaot);
                            var txUaot = resultTxUaot.FirstOrDefault();

                            return txUaot != null && ClaimsAuthorization.CheckAccess("View", "MyTransactions");
                        case OrganisationTypeEnum.Professional:
                            return tx.OrganisationID == orgId && ClaimsAuthorization.CheckAccess("View", "SmsTransaction");
                    }
                    break;
                case ActivityType.BankAccount:
                    // get bank account for conversation
                    var selectBa = ODataHelper.Select<OrganisationBankAccountDTO>(x => new { x.OrganisationID });
                    var filterBa = ODataHelper.Filter<OrganisationBankAccountDTO>(x => x.OrganisationBankAccountID == activityId);
                    var resultBa = await QueryClient.QueryAsync<OrganisationBankAccountDTO>("OrganisationBankAccounts", selectBa + filterBa);
                    var ba = resultBa.FirstOrDefault();
                    return ba.OrganisationID == orgId && ClaimsAuthorization.CheckAccess("View", "BankAccount");
            }

            return false;
        }

        public async Task<string> UploadFile()
        {
            try
            {
                var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
                foreach (string fileName in Request.Files)
                {
                    HttpPostedFileBase file = Request.Files[fileName];
                    if (file != null && file.ContentLength > 0)
                    {
                        using (BinaryReader reader = new BinaryReader(file.InputStream))
                        {
                            byte[] data = new byte[file.InputStream.Length];
                            reader.Read(data, 0, (int)file.InputStream.Length);
                            FileDTO f = new FileDTO { ParentID = uaoId, Name = file.FileName, Type = file.ContentType, Data = data };
                            await NotificationClient.UploadFileAsync(f);
                        }
                    }
                }
                
                return "OK";
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                return "Failed";
            }
        }

        public async Task ClearUploads()
        {
            var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            await NotificationClient.ClearUnusedFilesAsync(uaoId);
        }

        public async Task<object> DownloadFile(Guid fileID)
        {
            var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            var file = await NotificationClient.DownloadFileAsync(uaoId, fileID);
            var ext = System.IO.Path.GetExtension(file.Name);
            return File(file.Data, file.Type, file.Name);
        }

        public async Task RemovePendingUpload(string filename)
        {
            var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            await NotificationClient.RemovePendingUploadAsync(uaoId, filename);
        }

    }
}