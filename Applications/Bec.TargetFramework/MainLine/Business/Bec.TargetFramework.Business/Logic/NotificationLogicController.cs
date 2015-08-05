using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Extensions;
using EnsureThat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business.Logic
{
    [Trace(TraceExceptionsOnly = true)]
    public class NotificationLogicController : LogicBase
    {
        public NotificationLogicController()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notifcationConstructID"></param>
        /// <param name="notificationConstructVersion"></param>
        /// <param name="parentID"></param>
        /// <param name="isRead"></param>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
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

        public async Task SaveNotificationAsync(NotificationDTO dto)
        {
            // we need to save the notification then the recipients
            Ensure.That(dto).IsNotNull();
            // must be recipients
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

                    // process recipients
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

            string cacheKey = organisationNotificationConstructID.ToString() + "_" + versionNumber;

            // using (var cacheClient = this.CacheProvider.CreateCacheClient(Logger))
            //{
            // dto = cacheClient.Get<NotificationConstructDTO>(cacheKey);

            if (dto == null)
            {
                using (var scope = DbContextScopeFactory.CreateReadOnly())
                {
                    // load org construct include module and notification constructs direct
                    var construct = scope.DbContexts.Get<TargetFrameworkEntities>().NotificationConstructs.Include("NotificationConstructParameters").Include("NotificationConstructData").Include("NotificationConstructTargets")
                        .Single(n => n.NotificationConstructID.Equals(organisationNotificationConstructID)
                       && n.IsActive.Equals(true) && n.IsDeleted.Equals(false) && n.NotificationConstructVersionNumber.Equals(versionNumber));

                    dto = NotificationConstructConverter.ToDtoWithRelated(construct, 2);
                }

                //        cacheClient.Add<NotificationConstructDTO>(cacheKey, dto, DateTime.Now.AddDays(1));
            }
            // }

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

        public VDefaultEmailAddressDTO RecipientAddressDetail(Guid? organisationID, Guid? userAccountOrganisationID)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                // load org construct include module and notification constructs direct
                // deterimne users or organisations
                if (organisationID.HasValue)
                    return scope.DbContexts.Get<TargetFrameworkEntities>().VDefaultEmailAddresses.Single(s => s.OrganisationID == organisationID.Value).ToDto();
               else
                    return scope.DbContexts.Get<TargetFrameworkEntities>().VDefaultEmailAddresses.Single(s => s.UserAccountOrganisationID == userAccountOrganisationID.Value).ToDto();
            }
        }

        public List<VNotificationInternalUnreadDTO> GetUnreadNotifications(Guid accountID, string constructName)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                return scope.DbContexts.Get<TargetFrameworkEntities>().VNotificationInternalUnreads.Where(x => x.UserID == accountID).ToDtos();
            }
        }

        public NotificationResultDTO GetTcAndCsText(Guid accountID)
        {
            var unreadDTO = GetUnreadNotifications(accountID, "TcPublic").FirstOrDefault();
            Ensure.That(unreadDTO).IsNotNull();
            var construct = GetNotificationConstruct(unreadDTO.NotificationConstructID, unreadDTO.NotificationConstructVersionNumber);
            string val = ReportHelper.GetReportTextItem(construct, null, "TextContent");
            return new NotificationResultDTO
            {
                NotificationID = unreadDTO.NotificationID,
                NotificationConstructID = unreadDTO.NotificationConstructID,
                NotificationConstructVersionNumber = unreadDTO.NotificationConstructVersionNumber,
                Lines = val.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList()
            };
        }

        public byte[] GetTcAndCsData(Guid notificationConstructID, int versionNumber)
        {
            using (var scope = DbContextScopeFactory.CreateReadOnly())
            {
                var construct = GetNotificationConstruct(notificationConstructID, versionNumber);
                return ReportHelper.GenerateReport(construct, null, NotificationExportFormatIDEnum.PDF);
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
    }
}
