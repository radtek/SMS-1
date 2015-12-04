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
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public IEnumerable<Guid> GetNotificationOrganisationUsers(Guid orgID)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations.Where(x =>
                    !x.UserAccount.IsDeleted &&
                    x.OrganisationID == orgID &&
                    !x.UserAccount.IsTemporaryAccount &&
                    x.UserAccount.IsLoginAllowed).Select(x => x.UserAccountOrganisationID).ToList();
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
                            IsSystemMessage = true
                        };

                        scope.DbContexts.Get<TargetFrameworkEntities>().Conversations.Add(conv);
                    }

                    dto.ConversationID = conv.ConversationID;
                    // overwrite the recipients
                    dto.NotificationRecipients = new List<NotificationRecipientDTO> { notificationRecipient };

                    await SaveNotificationAsync(dto);
                }
                await scope.SaveChangesAsync();
            }
        }

        public async Task SaveNotificationAsync(NotificationDTO dto)
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
                    n.NotificationConstructVersionNumber.Equals(versionNumber));

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

        public List<VConversationDTO> GetLatestUnreadConversations(Guid userAccountOrganisationId, int count)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var conversations = scope.DbContexts.Get<TargetFrameworkEntities>().VConversations
                    .Where(x => x.Unread > 0 && x.UserAccountOrganisationID == userAccountOrganisationId)
                    .OrderByDescending(x => x.Latest)
                    .Take(count);

                return conversations.ToDtos();
            }
        }

        public int GetUnreadConversationsCount(Guid userAccountOrganisationId)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().VConversations
                    .Where(x => x.Unread > 0 && x.UserAccountOrganisationID == userAccountOrganisationId)
                    .Count();
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
            var unreadDTO = GetUnreadNotifications(accountID, NotificationConstructEnum.TcPublic, NotificationConstructEnum.TcFirmConveyancing).FirstOrDefault();
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

        public async Task MarkAcceptedAsync(Guid notificationID)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                foreach (var nu in scope.DbContexts.Get<TargetFrameworkEntities>().VNotificationInternalUnreads.Where(x => x.NotificationID == notificationID))
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

        public async Task PublishNewInternalMessagesNotificationEvent(int count, Guid organisationId, NotificationConstructEnum notificationConstructEnum)
        {
            var commonSettings = Settings.GetSettings().AsSettings<CommonSettings>();
            var notificationConstructName = notificationConstructEnum.GetStringValue();
            var filteredRecipientUaoIds = new List<Guid>();

            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var notificationResourceTypeId = ResourceTypeIDEnum.Notification.GetIntValue();
                var operationName = OperationEnum.View.ToString();
                filteredRecipientUaoIds =
                    (from nc in scope.DbContexts.Get<TargetFrameworkEntities>().NotificationConstructs
                     join ncc in scope.DbContexts.Get<TargetFrameworkEntities>().NotificationConstructClaims on nc.NotificationConstructID equals ncc.NotificationConstructID
                     join r in scope.DbContexts.Get<TargetFrameworkEntities>().Resources on ncc.ResourceID equals r.ResourceID
                     join o in scope.DbContexts.Get<TargetFrameworkEntities>().Operations on ncc.OperationID equals o.OperationID
                     join orc in scope.DbContexts.Get<TargetFrameworkEntities>().OrganisationRoleClaims on new { r.ResourceID, o.OperationID } equals new { ResourceID = orc.ResourceID.Value, OperationID = orc.OperationID.Value }
                     join orgr in scope.DbContexts.Get<TargetFrameworkEntities>().OrganisationRoles on orc.OrganisationRoleID equals orgr.OrganisationRoleID
                     join uaor in scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisationRoles on orc.OrganisationRoleID equals uaor.OrganisationRoleID
                     join uao in scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations on uaor.UserAccountOrganisationID equals uao.UserAccountOrganisationID
                     where
                         uao.OrganisationID == organisationId &&
                         r.ResourceTypeID == notificationResourceTypeId &&
                         o.OperationName == operationName &&
                         nc.Name == notificationConstructName
                     select uao.UserAccountOrganisationID).ToList();
            }

            var newInternalMessagesNotificationDTO = new NewInternalMessagesNotificationDTO
            {
                Count = count,
                ProductName = commonSettings.ProductName,
                NotificationRecipientDtos = filteredRecipientUaoIds
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

        public async Task<Guid> CreateConversation(Guid orgID, Guid uaoID, ActivityType? activityTypeID, Guid? activityID, string subject, string message, Guid[] participantsUaoIDs)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                await CheckCanCreateMessage(orgID, activityTypeID, activityID, participantsUaoIDs);

                var conv = new Conversation { ConversationID = Guid.NewGuid(), Subject = subject };
                if (activityID.HasValue && activityTypeID.HasValue)
                {
                    conv.ActivityID = activityID;
                    conv.ActivityType = activityTypeID.Value.GetIntValue();
                }

                conv.ConversationParticipants = new List<ConversationParticipant>();
                conv.ConversationParticipants.Add(new ConversationParticipant { UserAccountOrganisationID = uaoID });
                foreach (var p in participantsUaoIDs) conv.ConversationParticipants.Add(new ConversationParticipant { UserAccountOrganisationID = p });

                scope.DbContexts.Get<TargetFrameworkEntities>().Conversations.Add(conv);

                await Reply(uaoID, conv.ConversationID, message, participantsUaoIDs);

                await scope.SaveChangesAsync();
                return conv.ConversationID;
            }
        }

        public async Task ReplyToConversation(Guid uaoID, Guid conversationID, string message)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var p = scope.DbContexts.Get<TargetFrameworkEntities>().ConversationParticipants
                    .Where(x => x.ConversationID == conversationID)
                    .Select(x => x.UserAccountOrganisationID);

                //if (!p.Contains(uaoID)) throw new Exception("Cannot reply to conversation");
                var notSender = p.Where(x => x != uaoID).ToArray();

                await Reply(uaoID, conversationID, message, notSender);
                await scope.SaveChangesAsync();
            }
        }

        public async Task MarkAsRead(Guid uaoID, Guid conversationID)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                foreach (var nr in scope.DbContexts.Get<TargetFrameworkEntities>().NotificationRecipients
                    .Where(x => x.Notification.ConversationID == conversationID && x.UserAccountOrganisationID == uaoID && !(x.IsAccepted ?? false)))
                {
                    nr.IsAccepted = true;
                    nr.AcceptedDate = DateTime.Now;
                }
                await scope.SaveChangesAsync();
            }
        }

        private async Task Reply(Guid senderUaoID, Guid conversationID, string message, Guid[] recipients)
        {
            using (var scope = DbContextScopeFactory.Create())
            {
                var construct = GetLatestNotificationConstructIdFromName("Message");
                var n = new NotificationDTO
                {
                    CreatedByUserAccountOrganisationID = senderUaoID,
                    DateSent = DateTime.Now,
                    NotificationConstructID = construct.NotificationConstructID,
                    NotificationConstructVersionNumber = construct.NotificationConstructVersionNumber,
                    NotificationData = JsonHelper.SerializeData(new { Message = message }),
                    ConversationID = conversationID
                };

                n.NotificationRecipients = new List<NotificationRecipientDTO>(recipients.Select(x => new NotificationRecipientDTO { UserAccountOrganisationID = x }));

                await SaveNotificationAsync(n);
                await scope.SaveChangesAsync();
            }
        }

        private async Task CheckCanCreateMessage(Guid orgID, ActivityType? activityTypeID, Guid? activityID, Guid[] participantsUaoIDs)
        {
            bool valid = true;

            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                if (!activityTypeID.HasValue || !activityID.HasValue)
                {
                    //limit to org
                    foreach (var p in participantsUaoIDs)
                    {
                        var uao = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations.SingleOrDefault(x => x.UserAccountOrganisationID == p);
                        if (uao == null || uao.OrganisationID != orgID)
                        {
                            valid = false;
                            break;
                        }
                    }
                }
                else
                {
                    switch (activityTypeID.Value)
                    {
                        case ActivityType.SmsTransaction:
                            var tx = scope.DbContexts.Get<TargetFrameworkEntities>().SmsTransactions.SingleOrDefault(x => x.SmsTransactionID == activityID.Value);
                            if (tx == null) valid = false;

                            var validPersonalUaoIDs = tx.SmsUserAccountOrganisationTransactions
                                .Select(x => x.UserAccountOrganisationID).ToList();
                            var validOrganisationUaoIds = scope.DbContexts.Get<TargetFrameworkEntities>().UserAccountOrganisations
                                .Where(x => x.OrganisationID == tx.OrganisationID && x.IsActive)
                                .Select(x => x.UserAccountOrganisationID)
                                .ToList();
                            foreach (var u in participantsUaoIDs)
                                if (!validPersonalUaoIDs.Contains(u) && !validOrganisationUaoIds.Contains(u))
                                    valid = false;
                            break;
                    }
                }
            }

            if (!valid) throw new Exception("Cannot create conversation");
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

                return messages.GroupJoin(reads, x => x.NotificationID, x => x.NotificationID, (x, y) => new MessageDTO
                    {
                        IsReadByCurrentUser = x.CreatedByUserAccountOrganisationID == uaoId || y.Any(c => c.UserAccountOrganisationID == uaoId),
                        Message = x,
                        Reads = y
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
    }
}
