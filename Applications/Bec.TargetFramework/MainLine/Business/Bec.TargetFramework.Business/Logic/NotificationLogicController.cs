using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.DTO.Notification;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Infrastructure.Helpers;
using Bec.TargetFramework.Infrastructure.Reporting.Generators;
using Bec.TargetFramework.Infrastructure.Settings;
using Bec.TargetFramework.SB.Client.Interfaces;
using Bec.TargetFramework.SB.Entities;
using Bec.TargetFramework.Security;
using EnsureThat;
using Mehdime.Entity;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business.Logic
{
    [Trace(TraceExceptionsOnly = true)]
    public class NotificationLogicController : LogicBase
    {
        public TFSettingsLogicController Settings { get; set; }
        public StandaloneReportGenerator StandaloneReportGenerator { get; set; }
        public IEventPublishLogicClient EventPublishClient { get; set; }

        public bool HasNotificationAlreadyBeenSentInTheLastTimePeriod(Guid? uaoID, Guid? organisationId, Guid notifcationConstructID,
            int notificationConstructVersion, Guid? notificationParentID, bool isRead, TimeSpan sentInLast)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var sentAfter = DateTime.Now.Subtract(sentInLast);

                var notificationStatusQuery =
                    scope.DbContexts.Get<TargetFrameworkEntities>().VNotificationRecipientStatus.Where(
                        s => s.IsSent.Equals(true) && s.IsRead.HasValue && s.IsRead.Value.Equals(isRead)
                             && s.NotificationConstructID.Equals(notifcationConstructID)
                             && s.NotificationConstructVersionNumber.Equals(notificationConstructVersion));

                if (uaoID.HasValue)
                    notificationStatusQuery = notificationStatusQuery.Where(s => s.UserAccountOrganisationID.Equals(uaoID.Value));

                if (organisationId.HasValue)
                    notificationStatusQuery = notificationStatusQuery.Where(s => s.OrganisationID.HasValue && s.OrganisationID.Value.Equals(organisationId.Value));

                if (notificationParentID.HasValue)
                    notificationStatusQuery = notificationStatusQuery.Where(s => s.ParentID.HasValue && s.ParentID.Value.Equals(notificationParentID.Value));

                notificationStatusQuery = notificationStatusQuery.Where(s => s.DateSent >= sentAfter);

                return notificationStatusQuery.Any();
            }
        }

        public IEnumerable<Guid> GetNotificationOrganisationUaoIds(Guid orgID, string rolename)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var ret = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations.Where(x =>
                    !x.UserAccount.IsDeleted &&
                    x.OrganisationID == orgID &&
                    !x.UserAccount.IsTemporaryAccount &&
                    x.UserAccount.IsLoginAllowed);
                if (!string.IsNullOrWhiteSpace(rolename))
                    ret = ret.Where(x => x.UserAccountOrganisationRoles.Any(y => y.OrganisationRole.RoleName == rolename));
                return ret.Select(x => x.UserAccountOrganisationID).ToList();
            }
        }

        public async Task SaveNotificationConversationAsync(NotificationDTO dto, Guid? activityID, ActivityType? activityType)
        {
            if (activityID.HasValue && activityType.HasValue)
            {
                await SaveConversationWithNotificatino(dto, activityID, activityType);
            }
            else
            {
                await SaveNotificationAsync(dto);
            }
        }

        private async Task SaveConversationWithNotificatino(NotificationDTO dto, Guid? activityID, ActivityType? activityType)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var nc = scope.DbContexts.Get<TargetFrameworkEntities>().NotificationConstructs.Single(x => x.NotificationConstructID == dto.NotificationConstructID && x.NotificationConstructVersionNumber == dto.NotificationConstructVersionNumber);
                var at = activityType.GetIntValue();
                var recipients = dto.NotificationRecipients;

                foreach (var notificationRecipient in recipients)
                {
                    var conv = scope.DbContexts.Get<TargetFrameworkEntities>().Conversations
                        .Where(x => x.Subject == nc.NotificationSubject && x.ActivityID == activityID && x.ActivityType == at)
                        .ToList()
                        .FirstOrDefault(x => x.ConversationParticipants.All(y => y.UserAccountOrganisationID == notificationRecipient.UserAccountOrganisationID));

                    if (conv == null)
                    {
                        conv = new Conversation
                        {
                            ConversationID = Guid.NewGuid(),
                            Subject = nc.NotificationSubject,
                            ActivityID = activityID,
                            ActivityType = activityType.GetIntValue(),
                            ConversationParticipants = new List<ConversationParticipant> { new ConversationParticipant { UserAccountOrganisationID = notificationRecipient.UserAccountOrganisationID.Value } },
                            IsSystemMessage = true,
                            Latest = dto.DateSent
                        };

                        scope.DbContexts.Get<TargetFrameworkEntities>().Conversations.Add(conv);
                    }
                    else
                    {
                        conv.Latest = dto.DateSent;
                    }

                    dto.ConversationID = conv.ConversationID;
                    // overwrite the recipients
                    dto.NotificationRecipients = new List<NotificationRecipientDTO> { notificationRecipient };

                    await SaveNotificationAsync(dto);
                }

                await SendExternalNotification(recipients.Select(x => x.UserAccountOrganisationID.Value));
                await scope.SaveChangesAsync();
            }
        }

        public async Task<Guid> SaveNotificationAsync(NotificationDTO dto)
        {
            Ensure.That(dto).IsNotNull();
            Ensure.That(dto.NotificationRecipients).IsNotNull();

            using (var scope = DbContextScopeFactory.Create())
            {
                var notification = NotificationConverter.ToEntity(dto);
                notification.NotificationID = Guid.NewGuid();
                var recpList = new List<NotificationRecipient>();

                foreach (var item in dto.NotificationRecipients)
                {
                    var recipient = item.ToEntity();
                    recipient.NotificationID = notification.NotificationID;
                    recipient.NotificationRecipientID = Guid.NewGuid();
                    scope.DbContexts.Get<TargetFrameworkEntities>().NotificationRecipients.Add(recipient);

                    if (item.NotificationRecipientLogs != null)
                    {
                        foreach (var nl in item.NotificationRecipientLogs)
                        {
                            var log = NotificationRecipientLogConverter.ToEntity(nl);
                            log.NotificationRecipientID = recipient.NotificationRecipientID;
                            log.CreatedOn = DateTime.Now;
                            log.NotificationRecipientLogID = Guid.NewGuid();
                            scope.DbContexts.Get<TargetFrameworkEntities>().NotificationRecipientLogs.Add(log);
                        }
                    }
                    recpList.Add(recipient);
                }

                notification.NotificationRecipients = recpList;
                scope.DbContexts.Get<TargetFrameworkEntities>().Notifications.Add(notification);

                await scope.SaveChangesAsync();

                return notification.NotificationID;
            }
        }

        public List<VNotificationConstructGroupDTO> GetNotificationGroupConstructs(Guid userTypeID, int organisationTypeID, NotificationGroupTypeIDEnum enumValue)
        {
            List<VNotificationConstructGroupDTO> data = new List<VNotificationConstructGroupDTO>();

            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var notificationGroupEnumValue = enumValue.GetStringValue();

                data.AddRange(VNotificationConstructGroupConverter.ToDtos(scope.DbContexts.Get<TargetFrameworkEntities>().VNotificationConstructGroups.Where(s => s.GroupName.Equals(notificationGroupEnumValue)
                    && s.OrganisationTypeID.HasValue && s.OrganisationTypeID.Value.Equals(organisationTypeID)
                    && s.UserTypeID.HasValue && s.UserTypeID.Value.Equals(userTypeID))));
            }

            return data;
        }

        public NotificationConstructDTO GetNotificationConstruct(Guid organisationNotificationConstructID, int versionNumber)
        {
            Ensure.That(organisationNotificationConstructID).IsNot(Guid.Empty);

            NotificationConstructDTO dto = null;
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                // load org construct include module and notification constructs direct
                var construct = scope.DbContexts.Get<TargetFrameworkEntities>().NotificationConstructs
                .Include("NotificationConstructParameters")
                .Include("NotificationConstructData")
                .Include("NotificationConstructTargets")
                .Single(n =>
                    n.NotificationConstructID.Equals(organisationNotificationConstructID) &&
                    n.IsActive.Equals(true) &&
                    n.IsDeleted.Equals(false) &&
                    n.NotificationConstructVersionNumber.Equals(versionNumber) &&
                    n.Name != "Message");

                dto = construct.ToDtoWithRelated(2);
            }

            return dto;
        }

        [EnsureArgumentAspect]
        public List<VNotificationWithUAOVerificationCodeDTO> GetAllUserNotificationsForUserWithNotificationGroupNotAccepted(Guid userAccountOrganisationID, Guid userTypeID, int organisationTypeId, NotificationGroupTypeIDEnum groupEnumValue)
        {
            string enumValue = groupEnumValue.GetStringValue();

            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().VNotificationWithUAOVerificationCodes.Where(s =>
                    s.IsActive && !s.IsDeleted && (!string.IsNullOrEmpty(s.GroupName) && s.GroupName.Equals(enumValue))
                    && s.UserAccountOrganisationID.Equals(userAccountOrganisationID)
                    && s.UserTypeID.Equals(userTypeID)
                    && s.OrganisationTypeID.Equals(organisationTypeId)
                    && (s.GroupName != null && s.GroupName.Equals(enumValue))).ToDtos();
            }
        }

        public NotificationConstructDTO GetLatestNotificationConstructIdFromName(string name)
        {
            Ensure.That(name).IsNotNullOrEmpty();

            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                // load org construct include module and notification constructs direct
                return scope.DbContexts.Get<TargetFrameworkEntities>().NotificationConstructs.Where(n => n.Name.Equals(name) && n.IsActive && !n.IsDeleted)
                    .OrderByDescending(s => s.NotificationConstructVersionNumber)
                    .First()
                    .ToDto();
            }
        }

        public VNotificationConstructDTO GetNotificationConstructViewData(Guid organisationNotificationConstructID, int versionNumber)
        {
            Ensure.That(organisationNotificationConstructID).IsNot(Guid.Empty);

            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                // load org construct include module and notification constructs direct
                return scope.DbContexts.Get<TargetFrameworkEntities>().VNotificationConstructs
                    .Single(n => n.NotificationConstructID.Equals(organisationNotificationConstructID) && n.IsActive && !n.IsDeleted && n.NotificationConstructVersionNumber == versionNumber)
                    .ToDto();
            }
        }

        public IEnumerable<VDefaultEmailAddressDTO> RecipientAddressDetail(Guid? organisationID, Guid? userAccountOrganisationID)
        {
            if (!organisationID.HasValue && !userAccountOrganisationID.HasValue)
            {
                throw new ArgumentException("Either organisationID or userAccountOrganisationID is required.");
            }
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                // load org construct include module and notification constructs direct
                // deterimne users or organisations
                var query = scope.DbContexts.Get<TargetFrameworkEntities>().VDefaultEmailAddresses.AsQueryable();
                if (organisationID.HasValue)
                {
                    query = query.Where(s => s.OrganisationID == organisationID.Value);
                }
                else
                {
                    query = query.Where(s => s.UserAccountOrganisationID == userAccountOrganisationID.Value);
                }

                return query.ToDtos();
            }
        }

        public List<ConversationDTO> GetLatestUnreadConversations(Guid userAccountOrganisationId, int count)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var ret = scope.DbContexts.Get<TargetFrameworkEntities>().NotificationRecipients
                    .Where(x => x.IsAccepted == false && x.UserAccountOrganisationID == userAccountOrganisationId && x.Notification.ConversationID != null)
                    .GroupBy(x => x.Notification.Conversation)
                    .OrderByDescending(x => x.Key.Latest)
                    .Take(count)
                    .Select(x => x.Key);
                return ret.ToDtos();
            }
        }

        public int GetUnreadConversationsCount(Guid userAccountOrganisationId)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var ret = scope.DbContexts.Get<TargetFrameworkEntities>().NotificationRecipients
                    .Where(x => x.IsAccepted == false && x.UserAccountOrganisationID == userAccountOrganisationId && x.Notification.ConversationID != null)
                    .GroupBy(x => x.Notification.Conversation);

                return ret.Count();
            }
        }

        public List<VNotificationViewOnlyUaoDTO> GetInternal(Guid userAccountOrganisationId)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var notifications = scope.DbContexts.Get<TargetFrameworkEntities>().VNotificationViewOnlyUaos
                    .Where(x => x.IsInternal && x.UserAccountOrganisationID == userAccountOrganisationId)
                    .OrderByDescending(x => x.DateSent);

                return notifications.ToDtos();
            }
        }

        public NotificationContentDTO GetNotificationContent(Guid notificationId, Guid userAccountOrganisationId, NotificationExportFormatIDEnum notificationExportFormat)
        {
            VNotificationViewOnlyUaoDTO notificationDto;
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var notification = scope.DbContexts.Get<TargetFrameworkEntities>().VNotificationViewOnlyUaos
                    .FirstOrDefault(
                        x =>
                            x.NotificationID == notificationId &&
                            x.UserAccountOrganisationID == userAccountOrganisationId);

                if (notification == null)
                {
                    throw new InvalidOperationException(string.Format("The notification {0} was not found for this user.", notificationId));
                }

                notificationDto = notification.ToDto();
            }

            Ensure.That(notificationDto).IsNotNull();

            var notificationContentDto = GetNotificationContentFromCacheSetIfNotExists(notificationDto, notificationExportFormat);
            return notificationContentDto;
        }

        private NotificationContentDTO GetNotificationContentFromCacheSetIfNotExists(VNotificationViewOnlyUaoDTO notificationDto, NotificationExportFormatIDEnum notificationExportFormat)
        {
            NotificationContentDTO notificationContentDto;
            string key = string.Format("NotificationContent-{0}-{1}", notificationDto.NotificationID, notificationExportFormat.GetStringValue());
            using (var cacheClient = this.CacheProvider.CreateCacheClient(Logger))
            {
                notificationContentDto = cacheClient.Get<NotificationContentDTO>(key);
                if (notificationContentDto == null)
                {
                    var construct = GetNotificationConstruct(notificationDto.NotificationConstructID, notificationDto.NotificationConstructVersionNumber);
                    var notificationData = JsonHelper.DeserializeData<NotificationDictionaryDTO>(notificationDto.NotificationData);
                    var reportByteArray = StandaloneReportGenerator.GenerateReport(construct, notificationData, notificationExportFormat);

                    notificationContentDto = new NotificationContentDTO
                    {
                        Content = reportByteArray,
                        NotificationSubject = notificationDto.NotificationSubject,
                        DateSent = notificationDto.DateSent
                    };
                    cacheClient.Set(key, notificationContentDto, DateTime.MaxValue);
                }
            }
            return notificationContentDto;
        }

        public List<VNotificationInternalUnreadDTO> GetUnreadNotifications(Guid userId, [System.Web.Http.FromUri]params NotificationConstructEnum[] types)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var undreadNotifications = scope.DbContexts.Get<TargetFrameworkEntities>().VNotificationInternalUnreads
                    .Where(x => x.UserID == userId);
                if (types.Length > 0)
                {
                    var notificationConstructName = types.Select(x => x.GetStringValue());
                    undreadNotifications = undreadNotifications
                        .Where(n => notificationConstructName.Contains(n.Name))
                        .OrderByDescending(x => x.DateSent);
                }

                return undreadNotifications.ToDtos();
            }
        }

        public NotificationResultDTO GetTcAndCsText(Guid accountID)
        {
            var unreadDTO = GetUnreadNotifications(accountID, NotificationConstructEnum.TcPublic, NotificationConstructEnum.TcFirmConveyancing, NotificationConstructEnum.TcMortgageBroker, NotificationConstructEnum.TcLender).FirstOrDefault();
            if (unreadDTO == null) return null;
            var construct = GetNotificationConstruct(unreadDTO.NotificationConstructID, unreadDTO.NotificationConstructVersionNumber);
            string val = StandaloneReportGenerator.GetReportTextItem(construct, null, "TextContent");
            return new NotificationResultDTO
            {
                NotificationID = unreadDTO.NotificationID,
                NotificationConstructID = unreadDTO.NotificationConstructID,
                NotificationConstructVersionNumber = unreadDTO.NotificationConstructVersionNumber,
                Lines = val.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList()
            };
        }

        public byte[] RetrieveNotificationConstructData(Guid notificationConstructID, int versionNumber, DTOMap data)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                NotificationDictionaryDTO dict = null;
                if (data != null) dict = data.ToNotificationDictionaryDTO();
                var construct = GetNotificationConstruct(notificationConstructID, versionNumber);
                return StandaloneReportGenerator.GenerateReport(construct, dict, NotificationExportFormatIDEnum.PDF);
            }
        }

        public async Task MarkAcceptedAsync(Guid notificationID, Guid userID)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                foreach (var nu in scope.DbContexts.Get<TargetFrameworkEntities>().VNotificationInternalUnreads.Where(x => x.NotificationID == notificationID && x.UserID == userID))
                {
                    var nr = scope.DbContexts.Get<TargetFrameworkEntities>().NotificationRecipients.Single(x => x.NotificationRecipientID == nu.NotificationRecipientID);
                    nr.IsAccepted = true;
                    nr.AcceptedDate = DateTime.Now;
                }
                await scope.SaveChangesAsync();
            }
        }

        public async Task UpdateEventStatusAsync(Guid eventStatusID, string status, string recipients, string subject, string body)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var es = scope.DbContexts.Get<TargetFrameworkEntities>().EventStatus.SingleOrDefault(x => x.EventStatusID == eventStatusID);
                if (es != null)
                {
                    es.Status = status;
                    es.Recipients = recipients;
                    es.Subject = subject;
                    es.Body = body;
                    await scope.SaveChangesAsync();
                }
            }
        }

        public List<EventStatusDTO> GetEventStatus(string eventName, string eventReference)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().EventStatus.Where(x => x.EventName == eventName && x.EventReference == eventReference).ToDtos();
            }
        }

        public async Task PublishNewInternalMessagesNotificationEvent(IEnumerable<Guid> recipientUaoIds)
        {
            var commonSettings = Settings.GetSettings().AsSettings<CommonSettings>();
            var newInternalMessagesNotificationDTO = new NewInternalMessagesNotificationDTO
            {
                ProductName = commonSettings.ProductName,
                NotificationRecipientDtos = recipientUaoIds
                    .Select(x => new NotificationRecipientDTO { UserAccountOrganisationID = x })
                    .ToList()
            };

            string payLoad = JsonHelper.SerializeData(new object[] { newInternalMessagesNotificationDTO });
            var eventPayloadDto = new EventPayloadDTO
            {
                EventName = NotificationConstructEnum.NewInternalMessages.GetStringValue(),
                EventSource = AppDomain.CurrentDomain.FriendlyName,
                EventReference = "0003",
                PayloadAsJson = payLoad
            };

            await EventPublishClient.PublishEventAsync(eventPayloadDto);
        }

        public async Task<Guid> CreateConversation(string fromHash, Guid uaoID, Guid attachmentsID, ActivityType? activityTypeID, Guid? activityID, string subject, string message, bool isSystemMessage, string[] participantHashes)
        {
            var date = DateTime.Now;
            var conversationId = Guid.NewGuid();

            //do not currently support conversations outside of activities
            if (!activityTypeID.HasValue || !activityID.HasValue) throw new Exception("Cannot create conversation");
            var from = GetSender(fromHash, uaoID); 
            var recip = GetActivityRecipients(uaoID, activityTypeID.Value, activityID.Value);
            var participants = recip.Join(participantHashes, x => x.Hash, y => y, (a, b) => a);

            if (participantHashes.Length != participants.Count()) throw new Exception("Cannot create conversation");
            using (var scope = DbContextScopeFactory.Create())
            {
                var conv = new Conversation { ConversationID = conversationId, Subject = subject, Latest = date, IsSystemMessage = isSystemMessage };
                if (activityID.HasValue && activityTypeID.HasValue)
                {
                    conv.ActivityID = activityID;
                    conv.ActivityType = activityTypeID.Value.GetIntValue();
                }

                conv.ConversationParticipants = new List<ConversationParticipant>();
                conv.ConversationSafeSendGroupParticipants = new List<ConversationSafeSendGroupParticipant>();

                if (from.IsSafeSendGroup)
                    conv.ConversationSafeSendGroupParticipants.Add(new ConversationSafeSendGroupParticipant { OrganisationID = from.OrganisationID, SafeSendGroupID = from.Value });
                else
                    conv.ConversationParticipants.Add(new ConversationParticipant { UserAccountOrganisationID = uaoID });

                foreach (var p in participants)
                {
                    if (p.IsSafeSendGroup)
                        conv.ConversationSafeSendGroupParticipants.Add(new ConversationSafeSendGroupParticipant { OrganisationID = p.OrganisationID, SafeSendGroupID = p.RelatedID });
                    else
                        conv.ConversationParticipants.Add(new ConversationParticipant { UserAccountOrganisationID = p.RelatedID });
                }

                scope.DbContexts.Get<TargetFrameworkEntities>().Conversations.Add(conv);
                await scope.SaveChangesAsync();
            }
            
            await Reply(from, uaoID, attachmentsID, conversationId, message, participants, date);
            return conversationId;
        }

        public async Task ReplyToConversation(string fromHash, Guid uaoID, Guid conversationID, Guid attachmentsID, string message)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var recipients = scope.DbContexts.Get<TargetFrameworkEntities>().ConversationParticipants
                    .Where(x => x.ConversationID == conversationID)
                    .Select(x => new VSafeSendRecipientDTO { IsSafeSendGroup = false, RelatedID = x.UserAccountOrganisationID, OrganisationID = Guid.Empty });

                recipients = recipients.Concat(scope.DbContexts.Get<TargetFrameworkEntities>().ConversationSafeSendGroupParticipants
                    .Where(x => x.ConversationID == conversationID)
                    .Select(x => new VSafeSendRecipientDTO { IsSafeSendGroup = true, RelatedID = x.SafeSendGroupID, OrganisationID = x.OrganisationID })
                    );

                var from = GetSender(fromHash, uaoID);
                await Reply(from, uaoID, attachmentsID, conversationID, message, recipients, DateTime.Now);

                await scope.SaveChangesAsync();
            }
        }

        public async Task MarkAsRead(Guid uaoID, Guid conversationID)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                foreach (var nr in scope.DbContexts.Get<TargetFrameworkEntities>().NotificationRecipients
                    .Where(x => x.Notification.ConversationID == conversationID && x.UserAccountOrganisationID == uaoID && x.IsAccepted == false))
                {
                    nr.IsAccepted = true;
                    nr.AcceptedDate = DateTime.Now;
                }
                await scope.SaveChangesAsync();
            }
        }

        private async Task Reply(CreateConversationRecipientDTO from, Guid senderUaoID, Guid attachmentsID, Guid conversationID, string message, IEnumerable<VSafeSendRecipientDTO> recipients, DateTime dateSent)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var conversation = scope.DbContexts.Get<TargetFrameworkEntities>().Conversations.SingleOrDefault(x => x.ConversationID == conversationID);
                conversation.Latest = dateSent;
                var construct = GetLatestNotificationConstructIdFromName("Message");
                var n = new NotificationDTO
                {
                    CreatedByUserAccountOrganisationID = senderUaoID,
                    DateSent = dateSent,
                    NotificationConstructID = construct.NotificationConstructID,
                    NotificationConstructVersionNumber = construct.NotificationConstructVersionNumber,
                    NotificationData = JsonHelper.SerializeData(new { Message = message }),
                    ConversationID = conversationID
                };

                if (from == null) throw new Exception("Illegal sender");
                if (from.IsSafeSendGroup) n.CreatedBySafeSendGroupID = from.Value;

                var uaoRecipients = recipients.Where(x => !x.IsSafeSendGroup).Select(x => x.RelatedID);
                foreach (var group in recipients.Where(x => x.IsSafeSendGroup).GroupBy(x => x.OrganisationID).Select(x => new { Org = x.Key, SafeSendGroups = x.Select(y => y.RelatedID).ToList() }))
                {
                    var safeSendGroupUaoIDs = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisationSafeSendGroups
                        .Where(x => x.UserAccountOrganisation.OrganisationID == group.Org && group.SafeSendGroups.Contains(x.SafeSendGroupID))
                        .Select(x => x.UserAccountOrganisationID);
                    uaoRecipients = uaoRecipients.Concat(safeSendGroupUaoIDs);
                }

                uaoRecipients = uaoRecipients.Where(x => x != senderUaoID);

                n.NotificationRecipients = new List<NotificationRecipientDTO>(uaoRecipients.Select(x => new NotificationRecipientDTO { UserAccountOrganisationID = x }));

                var ret = await SaveNotificationAsync(n);
                await SendExternalNotification(uaoRecipients);
                scope.DbContexts.Get<TargetFrameworkEntities>().FnAttachUpload(senderUaoID, attachmentsID, ret);

                await scope.SaveChangesAsync();
            }
        }

        private CreateConversationRecipientDTO GetSender(string fromHash, Guid senderUaoID)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                    var orgId = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations.Single(x => x.UserAccountOrganisationID == senderUaoID).OrganisationID;
                    var safeSendGroups = GetUserSafeSendGroups(senderUaoID, orgId);
                    if (fromHash != null)
                        return safeSendGroups.SingleOrDefault(x => x.Hash == fromHash);
                    else
                        return safeSendGroups.FirstOrDefault(x => !x.IsSafeSendGroup && x.Value == senderUaoID);
            }
        }

        private async Task SendExternalNotification(IEnumerable<Guid> recipientUaoIds)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var notLoggedInRecipientUaoIds = new List<Guid>();
                foreach (var recipient in recipientUaoIds)
                {
                    var uao = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations
                        .SingleOrDefault(x =>
                            x.UserAccountOrganisationID == recipient &&
                            x.IsActive == true &&
                            x.UserAccount.IsLoginAllowed == true &&
                            x.UserAccount.IsActive == true);
                    if (uao == null)
                    {
                        continue;
                    }

                    var lastLoginSession = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountLoginSessions
                        .Where(x => x.UserAccountID == uao.UserID)
                        .OrderByDescending(x => x.UserLoginDate)
                        .FirstOrDefault();

                    if (ShouldSendNotificationToRecipient(lastLoginSession))
                    {
                        notLoggedInRecipientUaoIds.Add(recipient);
                    }
                }
                await PublishNewInternalMessagesNotificationEvent(notLoggedInRecipientUaoIds);
            }
        }

        private bool ShouldSendNotificationToRecipient(UserAccountLoginSession lastLoginSession)
        {
            var sessionExpiredTime = DateTime.Now.AddMinutes(-15);
            return lastLoginSession == null || (lastLoginSession.UserHasLoggedOut ?? false) || lastLoginSession.UserLoginDate <= sessionExpiredTime;
        }

        public List<VSafeSendRecipientDTO> GetActivityRecipients(Guid senderUaoID, ActivityType activityTypeID, Guid activityID)
        {
            var safeSendName = OrganisationSettingName.SafeSendEnabled.ToString();
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var org = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations.Single(x => x.UserAccountOrganisationID == senderUaoID).Organisation;
                var ret = scope.DbContexts.Get<TargetFrameworkEntities>().VSafeSendRecipients.Where(x => x.SmsTransactionID == activityID && (x.IsSafeSendGroup || x.RelatedID != senderUaoID));
                
                switch (org.OrganisationType.Name)
                {
                    case "Personal":
                        ret = ret.Where(x => x.OrganisationTypeName != "Lender");
                        break;
                    case "Lender":
                        ret = ret.Where(x => x.OrganisationTypeName != "Personal" && x.OrganisationTypeName != "Lender");
                        break;
                    case "Professional":
                        var purchased = scope.DbContexts.Get<TargetFrameworkEntities>().SmsTransactions.Any(x => x.SmsTransactionID == activityID && x.InvoiceID != null);                        
                        var setting = scope.DbContexts.Get<TargetFrameworkEntities>().OrganisationSettings.Where(x => x.OrganisationID == org.OrganisationID && x.Name == safeSendName).FirstOrDefault();
                        var enabled = setting != null && bool.Parse(setting.Value) == true;
                        if (!enabled || !purchased) ret = ret.Where(x => x.OrganisationTypeName != "Personal");
                        break;
                }
                ret = ret.OrderBy(x => x.IsSafeSendGroup).ThenByDescending(x => x.OrganisationName).ThenBy(x => x.LastName);
                var ret2 = ret.ToDtos();
                foreach (var item in ret2) item.Hash = string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(item.OrganisationID.ToString() + item.RelatedID.ToString())).Select(c => c.ToString("x2")));
                return ret2;
            }
        }

        public IEnumerable<MessageDTO> GetMessages(Guid conversationId, Guid uaoId, int page, int pageSize)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var messages = scope.DbContexts.Get<TargetFrameworkEntities>().VMessages
                    .Where(x => x.ConversationID == conversationId)
                    .OrderByDescending(x => x.DateSent)
                    .Skip(page * pageSize)
                    .Take(pageSize).ToDtos();
                var nids = messages.Select(m => m.NotificationID);
                var reads = scope.DbContexts.Get<TargetFrameworkEntities>().VMessageReads.Where(x => nids.Contains(x.NotificationID)).ToDtos();

                var files = scope.DbContexts.Get<TargetFrameworkEntities>().Files.Where(x => nids.Contains(x.ParentID)).Select(x => new MessageFileDTO { Name = x.Name, FileID = x.FileID, ParentID = x.ParentID }).ToList();

                var readMessages = messages.GroupJoin(reads, x => x.NotificationID, x => x.NotificationID, (x, y) => new MessageDTO
                {
                    IsReadByCurrentUser = x.CreatedByUserAccountOrganisationID == uaoId || y.Any(c => c.UserAccountOrganisationID == uaoId),
                    Message = x,
                    Reads = y
                });

                return readMessages.GroupJoin(files, x => x.Message.NotificationID, x => x.ParentID, (x, y) => new MessageDTO
                {
                    IsReadByCurrentUser = x.IsReadByCurrentUser,
                    Message = x.Message,
                    Reads = x.Reads,
                    Files = y
                });
            }
        }

        public int GetConversationRank(Guid uaoID, Guid convID)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().FnConversationRank(uaoID, convID).Value;
            }
        }

        public ConversationResultDTO<VConversationDTO> GetConversations(Guid uaoId, ActivityType? activityType, Guid? activityId, int take, int skip)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                long count;
                var items = scope.DbContexts.Get<TargetFrameworkEntities>().VConversations.Where(x => x.UserAccountOrganisationID == uaoId);
                if (activityType.HasValue && activityId.HasValue)
                {
                    var activityTypeId = activityType.GetIntValue();
                    items = items.Where(x => x.ActivityID == activityId && x.ActivityType == activityTypeId && x.IsSystemMessage == false);
                    count = items.LongCount();
                }
                else
                {
                    count = scope.DbContexts.Get<TargetFrameworkEntities>().ConversationParticipants.Where(x => x.UserAccountOrganisationID == uaoId).LongCount();
                }
                items = items.OrderByDescending(x => x.Latest).Skip(skip).Take(take);
                var ret = items.ToDtos();
                var convs = ret.Select(x => x.ConversationID);
                var q = scope.DbContexts.Get<TargetFrameworkEntities>().VConversationUnreads.Where(x => x.UserAccountOrganisationID == uaoId && convs.Contains(x.ConversationID));
                var unreads = q.ToDictionary(x => x.ConversationID, x => x.UnreadCount);

                foreach (var item in ret)
                {
                    item.Unread = unreads.ContainsKey(item.ConversationID) && unreads[item.ConversationID] > 0;
                }
                return new ConversationResultDTO<VConversationDTO> { Items = ret, Count = count };
            }
        }

        public ConversationResultDTO<FnGetConversationActivityResultDTO> GetConversationsActivity(Guid uaoID, string userOrgTypeName, Guid orgID, ActivityType activityType, Guid activityId, int take, int skip)
        {
            int at = activityType.GetIntValue();

            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var count = scope.DbContexts.Get<TargetFrameworkEntities>().FnGetConversationActivityCount(orgID, at, activityId, userOrgTypeName, uaoID).Value;

                var ret = scope.DbContexts.Get<TargetFrameworkEntities>().FnGetConversationActivity(orgID, at, activityId, take, skip, userOrgTypeName, uaoID).ToDtos();
                var convs = ret.Select(x => x.ConversationID);
                var q = scope.DbContexts.Get<TargetFrameworkEntities>().VConversationUnreads.Where(x => x.UserAccountOrganisationID == uaoID && convs.Contains(x.ConversationID));
                var unreads = q.ToDictionary(x => x.ConversationID, x => x.UnreadCount);

                foreach (var item in ret)
                {
                    item.Unread = unreads.ContainsKey(item.ConversationID.Value) && unreads[item.ConversationID.Value] > 0;
                }
                return new ConversationResultDTO<FnGetConversationActivityResultDTO> { Items = ret, Count = count };
            }
        }

        public List<CreateConversationRecipientDTO> GetUserSafeSendGroups(Guid uaoId, Guid orgId)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var uao = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations.Single(x => x.UserAccountOrganisationID == uaoId);
                var safeSendGroups = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisationSafeSendGroups.Where(x => x.UserAccountOrganisationID == uaoId);

                List<CreateConversationRecipientDTO> ret = new List<CreateConversationRecipientDTO>();
                ret.Add(new CreateConversationRecipientDTO { Value = uaoId, Display = uao.Contact.FirstName + " " + uao.Contact.LastName });
                ret.AddRange(safeSendGroups.Select(x => new CreateConversationRecipientDTO { IsSafeSendGroup = true, OrganisationID = orgId, Value = x.SafeSendGroupID, Display = x.SafeSendGroup.Name + " (Safe Send Group)" }));

                foreach (var item in ret) item.Hash = string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(item.OrganisationID.ToString() + item.Value.ToString())).Select(c => c.ToString("x2")));
                return ret;
            }
        }

    }
}
