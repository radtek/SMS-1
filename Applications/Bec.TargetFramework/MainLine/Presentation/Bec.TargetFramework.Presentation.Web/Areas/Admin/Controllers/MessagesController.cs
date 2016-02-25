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
using System.Security.Cryptography;
using System.Text;

namespace Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers
{
    public class MessagesController : ApplicationControllerBase
    {
        public INotificationLogicClient NotificationClient { get; set; }
        public IFileLogicClient FileClient { get; set; }
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
            var skip = Request["$skip"] == null ? 0 : int.Parse(Request["$skip"]);
            var res = await NotificationClient.GetConversationsAsync(uaoId, activityType, activityId, take, skip);

            foreach (var conversationDto in res.Items)
            {
                SetConversationLinkIfNeeded(conversationDto);
            }
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        private void SetConversationLinkIfNeeded(VConversationDTO conversationDto)
        {
            if (conversationDto.ActivityType != null)
            {
                var activityType = (ActivityType)conversationDto.ActivityType;
                conversationDto.LinkDescription = activityType.GetStringValue();
                switch ((ActivityType)conversationDto.ActivityType)
                {
                    case ActivityType.BankAccount:
                        if (ClaimsHelper.UserHasClaim("View", "BankAccount"))
                        {
                            conversationDto.Link = Url.Action("Index", "Account", new { Area = "BankAccount", selectedBankAccountId = conversationDto.ActivityID });
                        }
                        break;
                    case ActivityType.SmsTransaction:
                        if (ClaimsHelper.UserHasClaim("View", "SmsTransaction"))
                        {
                            conversationDto.Link = Url.Action("Index", "Transaction", new { Area = "SmsTransaction", selectedTransactionID = conversationDto.ActivityID });
                        }
                        else if (ClaimsHelper.UserHasClaim("View", "MyTransactions"))
                        {
                            conversationDto.Link = Url.Action("Index", "SafeBuyer", new { Area = "Buyer", selectedTransactionId = conversationDto.ActivityID });
                        }
                        break;
                }
            }
        }

        public async Task<ActionResult> GetConversationsActivity(ActivityType activityType, Guid activityId)
        {
            var wc = WebUserHelper.GetWebUserObject(HttpContext);
            var take = Request["$top"] == null ? 0 : int.Parse(Request["$top"]);
            var skip = Request["$skip"] == null ? 0 : int.Parse(Request["$skip"]);
            var res = await NotificationClient.GetConversationsActivityAsync(wc.UaoID, wc.OrganisationTypeName, wc.OrganisationID, activityType, activityId, take, skip);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetMessages(Guid conversationId, int page, int pageSize)
        {
            if (!await CanAccessConversation(conversationId)) return NotAuthorised();

            var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;

            var data = await NotificationClient.GetMessagesAsync(conversationId, uaoId, page, pageSize);
            NotificationClient.MarkAsRead(uaoId, conversationId);

            foreach (var item in data)
            {
                foreach (var file in item.Files)
                {
                    file.Link = Url.Action("DownloadFile", "Messages", new { area = "Admin", fileID = file.FileID, parentID = file.ParentID });
                }
            }

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetParticipants(Guid conversationId)
        {
            if (!await CanAccessConversation(conversationId)) return NotAuthorised();

            var professionalOrganisationTypeId = OrganisationTypeEnum.Professional.GetIntValue();
            var select = ODataHelper.Select<ConversationParticipantDTO>(x => new
            {
                x.UserAccountOrganisation.Contact.FirstName,
                x.UserAccountOrganisation.Contact.LastName,
                x.UserAccountOrganisation.Organisation.OrganisationTypeID,
                Names = x.UserAccountOrganisation.Organisation.OrganisationDetails.Select(y => new { y.Name })
            });
            var filter = ODataHelper.Filter<ConversationParticipantDTO>(x => x.ConversationID == conversationId);
            var data = await QueryClient.QueryAsync<ConversationParticipantDTO>("ConversationParticipants", select + filter);

            var selectF = ODataHelper.Select<ConversationSafeSendGroupParticipantDTO>(x => new
            {
                x.SafeSendGroup.Name,
                Names = x.Organisation.OrganisationDetails.Select(y => new { y.Name })
            });
            var filterF = ODataHelper.Filter<ConversationSafeSendGroupParticipantDTO>(x => x.ConversationID == conversationId);
            var dataF = await QueryClient.QueryAsync<ConversationSafeSendGroupParticipantDTO>("ConversationSafeSendGroupParticipants", selectF + filterF);

            //then: ui changes (from drop down if applicable)
            //then: GetRecipients lender <--> conveyancer + ui

            var dtos = data.Select(x => new ParticipantDTO
            {
                FirstName = x.UserAccountOrganisation.Contact.FirstName,
                LastName = x.UserAccountOrganisation.Contact.LastName,
                IsProfessionalOrganisation = x.UserAccountOrganisation.Organisation.OrganisationTypeID == professionalOrganisationTypeId,
                OrganisationName = x.UserAccountOrganisation.Organisation.OrganisationDetails.First().Name
            }).Concat(dataF.Select(x => new ParticipantDTO
            {
                IsSafeSendGroup = true,
                FirstName = x.SafeSendGroup.Name,
                OrganisationName = x.Organisation.OrganisationDetails.First().Name
            }));
            return Json(dtos, JsonRequestBehavior.AllowGet);
        }

        public async Task<ActionResult> GetRecipients(ActivityType activityType, Guid activityId)
        {
            if (!await CanAccessConversationInActivity(activityId, activityType, false, true)) return NotAuthorised();

            var uaoID = HttpContext.GetWebUserObject().UaoID;
            var ret = await NotificationClient.GetActivityRecipientsAsync(uaoID, activityType, activityId);
            return Json(ret, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> Reply(string fromHash, Guid conversationId, Guid attachmentsID, string message)
        {
            if (!await CanReply(conversationId)) return NotAuthorised();

            var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            await NotificationClient.ReplyToConversationAsync(fromHash, uaoId, conversationId, attachmentsID, message);

            return Json("ok");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public async Task<ActionResult> CreateConversation(CreateConversationDTO addConversationDto)
        {
            if (!await CanAccessConversationInActivity(addConversationDto.ActivityId, addConversationDto.ActivityType, false, true)) return NotAuthorised();

            try
            {
                var orgID = HttpContext.GetWebUserObject().OrganisationID;
                var uaoID = HttpContext.GetWebUserObject().UaoID;
                await NotificationClient.CreateConversationAsync(addConversationDto.FromHash, uaoID, addConversationDto.AttachmentsID, addConversationDto.ActivityType, addConversationDto.ActivityId, addConversationDto.Subject, addConversationDto.Message, false, addConversationDto.RecipientHashes.ToArray());
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
            var wc = WebUserHelper.GetWebUserObject(HttpContext);
            var uaoID = wc.UaoID;
            var orgId = wc.OrganisationID;
            var orgTypeName = wc.OrganisationTypeName;

            // get conversation
            var selectConv = ODataHelper.Select<ConversationDTO>(x => new { x.ActivityID, x.ActivityType, x.IsSystemMessage });
            var filterConv = ODataHelper.Filter<ConversationDTO>(x => x.ConversationID == conversationId);
            var resultConv = await QueryClient.QueryAsync<ConversationDTO>("Conversations", selectConv + filterConv);
            var conversation = resultConv.FirstOrDefault();

            if (reply && conversation.ActivityType.HasValue && !checkReply((ActivityType)conversation.ActivityType)) return false;

            // get participants
            var select = ODataHelper.Select<ConversationParticipantDTO>(x => new {x.UserAccountOrganisationID, x.UserAccountOrganisation.OrganisationID });
            var filter = ODataHelper.Filter<ConversationParticipantDTO>(x => x.ConversationID == conversationId);
            var participants = await QueryClient.QueryAsync<ConversationParticipantDTO>("ConversationParticipants", select + filter);

            switch (orgTypeName)
            {
                case "Professional":
                    //anyone in org
                    if (!participants.Any(x => x.UserAccountOrganisation.OrganisationID == orgId)) return false;
                    break;
                case "Lender":
                    //exact uao or in SafeSendGroup
                    var selectF = ODataHelper.Select<ConversationSafeSendGroupParticipantDTO>(x => new { x.OrganisationID, uaos = x.SafeSendGroup.UserAccountOrganisationSafeSendGroups.Select(y => new { y.UserAccountOrganisationID, y.UserAccountOrganisation.OrganisationID }) });
                    var filterF = ODataHelper.Filter<ConversationSafeSendGroupParticipantDTO>(x => x.ConversationID == conversationId);
                    var participantsF = await QueryClient.QueryAsync<ConversationSafeSendGroupParticipantDTO>("ConversationSafeSendGroupParticipants", selectF + filterF);
                    if (!participants.Any(x => x.UserAccountOrganisationID == uaoID) && !participantsF.Any(x => x.OrganisationID == orgId && x.SafeSendGroup.UserAccountOrganisationSafeSendGroups.Any(y => y.UserAccountOrganisationID == uaoID && y.UserAccountOrganisation.OrganisationID == orgId))) return false;
                    break;
                default:
                    //only exact uao
                    if (!participants.Any(x => x.UserAccountOrganisationID == uaoID)) return false;
                    break;
            }
            if (conversation.ActivityType.HasValue &&
                !await CanAccessConversationInActivity(conversation.ActivityID, (ActivityType)conversation.ActivityType, conversation.IsSystemMessage, reply)) return false;

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

        private async Task<bool> CanAccessConversationInActivity(Guid? activityId, ActivityType activityType, bool isSystemMessage, bool reply)
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
                    var selectTx = ODataHelper.Select<SmsTransactionDTO>(x => new { x.OrganisationID, x.InvoiceID, x.LenderName });
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
                            if (!CanAccessSmsTransactionConversation(tx, isSystemMessage, reply)) return false;
                            return txUaot != null && ClaimsAuthorization.CheckAccess("View", "MyTransactions");
                        case OrganisationTypeEnum.Professional:
                            return tx.OrganisationID == orgId && ClaimsAuthorization.CheckAccess("View", "SmsTransaction");
                        case OrganisationTypeEnum.Lender:
                            //get lender
                            var lenderName = tx.LenderName;
                            var selectLender = ODataHelper.Select<LenderDTO>(x => new { x.LenderID });
                            var filterLender = ODataHelper.Filter<LenderDTO>(x => x.OrganisationID == orgId && x.Name == lenderName);
                            var resultLender = (await QueryClient.QueryAsync<LenderDTO>("Lenders", selectLender + filterLender)).FirstOrDefault();
                            return resultLender != null && ClaimsAuthorization.CheckAccess("View", "SmsTransactionsOverview");
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

        private bool CanAccessSmsTransactionConversation(SmsTransactionDTO tx, bool isSystemMessage, bool reply)
        {
            if (reply)
            {
                return tx.InvoiceID.HasValue;
            }
            else
            {
                return tx.InvoiceID.HasValue || isSystemMessage;
            }
        }

        public async Task<string> UploadFile(Guid id, HttpPostedFileBase file)
        {
            string name = null;
            try
            {
                var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;

                if (file != null && file.ContentLength > 0)
                {
                    name = Path.GetFileName(file.FileName);
                    using (BinaryReader reader = new BinaryReader(file.InputStream))
                    {
                        byte[] data = new byte[file.InputStream.Length];
                        reader.Read(data, 0, (int)file.InputStream.Length);
                        FileDTO f = new FileDTO { ParentID = id, UserAccountOrganisationID = uaoId, Temporary = true, Name = name, Type = file.ContentType, Data = data };
                        var res = await FileClient.UploadFileAsync(f);
                        switch (res.Result)
                        {
                            case nClam.ClamScanResults.Clean:
                                if (HttpContext.Response.ClientDisconnectedToken.IsCancellationRequested)
                                    await RemovePendingUpload(id, name);
                                return FormatMessage("{0}: uploaded", name);
                            case nClam.ClamScanResults.VirusDetected:
                                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                                return FormatMessage("Virus detected: {0}", name);
                        }
                    }
                }

                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                return FormatMessage("Failed: {0}", name ?? "(No file)");
            }
            catch (Exception)
            {
                Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
                return FormatMessage("Failed: {0}", name ?? "(No file)");
            }
        }

        private string FormatMessage(string message, string filename)
        {
            return JObject.FromObject(new { Message = string.Format(message, filename), FileName = filename }).ToString();
        }

        public async Task<object> DownloadFile(Guid fileID, Guid parentID)
        {
            var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;

            var select = ODataHelper.Select<NotificationDTO>(x => new { x.ConversationID });
            var filter = ODataHelper.Filter<NotificationDTO>(x => x.NotificationID == parentID);
            var message = (await QueryClient.QueryAsync<NotificationDTO>("Notifications", select + filter)).FirstOrDefault();

            if (!await CanAccessConversation(message.ConversationID.Value)) return NotAuthorised();
            var file = await FileClient.DownloadFileAsync(fileID, parentID);
            var ext = System.IO.Path.GetExtension(file.Name);
            return File(file.Data, file.Type, file.Name);
        }

        public async Task RemovePendingUpload(Guid id, string filename)
        {
            var uaoId = WebUserHelper.GetWebUserObject(HttpContext).UaoID;
            await FileClient.RemovePendingUploadAsync(uaoId, id, filename);
        }

        public async Task<ActionResult> GetUserSafeSendGroups()
        {
            var wc = WebUserHelper.GetWebUserObject(HttpContext);
            var ret = await NotificationClient.GetUserSafeSendGroupsAsync(wc.UaoID, wc.OrganisationID);
            return Json(ret, JsonRequestBehavior.AllowGet);
        }

    }
}