using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
//Bec.TargetFramework.Entities
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Infrastructure.Log;
using NHibernate.Hql.Ast.ANTLR;
using ServiceStack.Text;

namespace Bec.TargetFramework.Business.Logic
{
    using System.Collections.ObjectModel;
    using System.Reflection.Emit;
    using System.Runtime.Remoting.Messaging;

    using Bec.TargetFramework.Aop.Aspects;
    using Bec.TargetFramework.Entities;

    using Omu.ValueInjecter;
    using EnsureThat;

    [Trace(TraceExceptionsOnly = true)]
    public class NotificationLogic : LogicBase, INotificationLogic
    {
        public NotificationLogic(ILogger logger, ICacheProvider cacheProvider)
            : base(logger, cacheProvider)
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
        public bool HasNotificationAlreadyBeenSentInTheLastTimePeriod(Guid? uaoID,Guid? organisationId, Guid notifcationConstructID,
            int notificationConstructVersion,Guid? notificationParentID,bool isRead, TimeSpan sentInLast)
        {
            bool exists = false;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var sentAfter = DateTime.Now.Subtract(sentInLast);

                var notifiationStatusQuery =
                    scope.DbContext.VNotificationRecipientStatus.Where(
                        s => s.IsSent.Equals(true) && s.IsRead.HasValue && s.IsRead.Value.Equals(isRead)
                             && s.NotificationConstructID.Equals(notifcationConstructID)
                             && s.NotificationConstructVersionNumber.Equals(notificationConstructVersion));

                if (uaoID.HasValue)
                    notifiationStatusQuery = notifiationStatusQuery.Where(s => s.UserAccountOrganisationID.Equals(uaoID.Value));

                if(organisationId.HasValue)
                    notifiationStatusQuery = notifiationStatusQuery.Where(s => s.OrganisationID.HasValue &&  s.OrganisationID.Value.Equals(organisationId.Value));

                if (notificationParentID.HasValue)
                    notifiationStatusQuery = notifiationStatusQuery.Where(s => s.ParentID.HasValue && s.ParentID.Value.Equals(notificationParentID.Value));

                notifiationStatusQuery = notifiationStatusQuery.Where(s => s.DateSent >= sentAfter);

                exists = notifiationStatusQuery.Any();
            }

            return exists;
        }

        public bool SaveNotification(NotificationDTO dto)
        {
            bool success = false;

            // we need to save the notification then the recipients
            Ensure.That(dto).IsNotNull();
            // must be recipients
            Ensure.That(dto.NotificationRecipients).IsNotNull();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                var notification = NotificationConverter.ToEntity(dto);

                notification.NotificationID = Guid.NewGuid();

                var recpList = new List<NotificationRecipient>();

                dto.NotificationRecipients.ForEach(
                    item =>
                        {
                            var recipient = NotificationRecipientConverter.ToEntity(item);
                            
                            recipient.NotificationID = notification.NotificationID;
                            recipient.NotificationRecipientID = Guid.NewGuid();

                            scope.DbContext.NotificationRecipients.Add(recipient);

                            // process recipients
                            List<NotificationRecipientLog> logs = new List<NotificationRecipientLog>();

                            if(item.NotificationRecipientLogs != null)
                                item.NotificationRecipientLogs.ForEach(nl =>
                                    {
                                        var log = NotificationRecipientLogConverter.ToEntity(nl);

                                        log.NotificationRecipientID = recipient.NotificationRecipientID;
                                        log.CreatedOn = DateTime.Now;
                                        log.NotificationRecipientLogID = Guid.NewGuid();

                                        scope.DbContext.NotificationRecipientLogs.Add(log);
                                    });

                            recipient.NotificationRecipientLogs = logs;

                            recpList.Add(recipient);
                        });

                notification.NotificationRecipients = recpList;

                scope.DbContext.Notifications.Add(notification);

                if (!scope.Save())
                    throw new Exception(scope.EntityErrors.Dump());
                else
                    success = true;
            }

            return success;
        }

        public List<VNotificationConstructGroupDTO> GetNotificationGroupConstructs(Guid userTypeID,
            int organisationTypeID, NotificationGroupTypeIDEnum enumValue)
        {
            List<VNotificationConstructGroupDTO> data = new List<VNotificationConstructGroupDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger)
                )
            {
                var notificationGroupEnumValue = enumValue.GetStringValue();

                data.AddRange(VNotificationConstructGroupConverter.ToDtos(scope.DbContext.VNotificationConstructGroups.Where(s => s.GroupName.Equals(notificationGroupEnumValue)
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
                    using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
                    {
                        // load org construct include module and notification constructs direct
                        var construct = scope.DbContext.NotificationConstructs.Include("NotificationConstructParameters").Include("NotificationConstructData").Include("NotificationConstructTargets")
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
        public List<VNotificationWithUAOVerificationCodeDTO> GetAllUserNotificationsForUserWithNotificationGroupNotAccepted(
            Guid userAccountOrganisationID, Guid userTypeID, int organisationTypeId, NotificationGroupTypeIDEnum groupEnumValue)
        {
            List<VNotificationWithUAOVerificationCodeDTO> dtos = new List<VNotificationWithUAOVerificationCodeDTO>();

            string enumValue = groupEnumValue.GetStringValue();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var termsAndConditions = scope.DbContext.VNotificationWithUAOVerificationCodes.Where(s => s.IsActive
                                                                                       && !s.IsDeleted
                                                                                      &&
                             (!string.IsNullOrEmpty(s.GroupName) && s.GroupName.Equals(enumValue))
                             && s.UserAccountOrganisationID.Equals(userAccountOrganisationID)
                             && s.UserTypeID.Equals(userTypeID)
                             && s.OrganisationTypeID.Equals(organisationTypeId)
                             && (s.GroupName != null && s.GroupName.Equals(enumValue))
                             );
                dtos = VNotificationWithUAOVerificationCodeConverter.ToDtos(termsAndConditions);
            }

            return dtos;
        }

        public NotificationConstructDTO GetLatestNotificationConstructIdFromName(string name)
        {
            Ensure.That(name).IsNotNullOrEmpty();

            NotificationConstructDTO dto = null;

            if (dto == null)
            {
                using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
                {
                    // load org construct include module and notification constructs direct
                    var construct = scope.DbContext.NotificationConstructs
                        .Where(n => n.Name.Equals(name) 
                       && n.IsActive.Equals(true) && n.IsDeleted.Equals(false)).OrderByDescending(s => s.NotificationConstructVersionNumber).First();

                    dto = NotificationConstructConverter.ToDto(construct);
                }
            }

            return dto;
        }

        public VNotificationConstructDTO GetNotificationConstructViewData(Guid organisationNotificationConstructID, int versionNumber)
        {

            Ensure.That(organisationNotificationConstructID).IsNot(Guid.Empty);

            VNotificationConstructDTO dto = null;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                // load org construct include module and notification constructs direct
                var construct = scope.DbContext.VNotificationConstructs.Single(n => n.NotificationConstructID.Equals(organisationNotificationConstructID)
                   && n.IsActive.Equals(true) && n.IsDeleted.Equals(false) && n.NotificationConstructVersionNumber.Equals(versionNumber));

                dto = VNotificationConstructConverter.ToDto(construct);
            }

            return dto;
        }

        public List<VDefaultEmailAddressDTO> GetRecipientAddressDetails(List<NotificationRecipientDTO> recipients )
        {
            List<VDefaultEmailAddressDTO> list = new List<VDefaultEmailAddressDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                // load org construct include module and notification constructs direct
                // deterimne users or organisations
                if(recipients.Any(s => s.OrganisationID.HasValue))
                {
                    List<Guid> orgIds = recipients.Where(w => w.OrganisationID.HasValue).Select(o =>  o.OrganisationID.Value).ToList();
                    list = VDefaultEmailAddressConverter.ToDtos(scope.DbContext.VDefaultEmailAddresses.Where(s => orgIds.Contains(s.OrganisationID)));
                }
                    
                else
                {
                    List<Guid> orgIds = recipients.Where(w => w.UserAccountOrganisationID.HasValue).Select(o => o.UserAccountOrganisationID.Value).ToList();

                     list = VDefaultEmailAddressConverter.ToDtos(scope.DbContext.VDefaultEmailAddresses.Where(s => orgIds.Contains(s.UserAccountOrganisationID)));
            }
                }
                   

            return list;
        }
    }
}
