using System;
using System.Collections.Generic;
using System.Linq;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.SB.Data;
using Bec.TargetFramework.SB.Hosts.SBService.Base;
using Bec.TargetFramework.SB.Interfaces;
using NServiceBus.Pipeline;
using ServiceStack.Text;

namespace Bec.TargetFramework.SB.Hosts.SBService.Logic
{
    using System.Collections.ObjectModel;
    using System.Reflection.Emit;
    using System.Runtime.Remoting.Messaging;

    using Bec.TargetFramework.Aop.Aspects;
    using EnsureThat;
    using Bec.TargetFramework.SB.Entities;
    using Bec.TargetFramework.SB.Entities.Enums;

    [Trace(TraceExceptionsOnly = true)]
    public class BusLogic : LogicBase
    {
        public BusLogic(ILogger logger, ICacheProvider cacheProvider)
            : base(logger, cacheProvider)
        {
        }

        public List<BusEventMessageSubscriberDTO> GetBusEventSubscribers(Guid BusEventId)
        {
            Ensure.That(BusEventId);

            List<BusEventMessageSubscriberDTO> list = new List<BusEventMessageSubscriberDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkCoreEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var fieldQuery =
                    scope.DbContext.BusEvents.Include("BusEventBusEventMessageSubscribers").SingleOrDefault(s => s.BusEventID.Equals(BusEventId));

                Ensure.That(fieldQuery);

                fieldQuery.BusEventBusEventMessageSubscribers.ToList().ForEach(item =>
                {
                    var subscriber =
                        scope.DbContext.BusEventMessageSubscribers.Single(
                            s => s.BusEventMessageSubscriberID.Equals(item.BusEventMessageSubscriberID));

                    list.Add(BusEventMessageSubscriberConverter.ToDto(subscriber));
                });
            }

            return list;
        }

        public BusEventDTO GetBusEventByName(string eventName)
        {
            Ensure.That(eventName);

            BusEventDTO dto = null;

            using (var scope = new UnitOfWorkScope<TargetFrameworkCoreEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var fieldQuery =
                    scope.DbContext.BusEvents.SingleOrDefault(s => s.BusEventName.Equals(eventName));

                Ensure.That(fieldQuery);

                dto = BusEventConverter.ToDto(fieldQuery);
            }

            return dto;
        }

        public List<VBusTaskScheduleDTO> GetBusTaskSchedules()
        {
            var list = new List<VBusTaskScheduleDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkCoreEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var dbList =
                    scope.DbContext.VBusTaskSchedules;

                list = VBusTaskScheduleConverter.ToDtos(dbList);
            }

            return list;
        }

        public VBusTaskScheduleDTO GetBusTaskSchedule(string busTaskName)
        {
            VBusTaskScheduleDTO dto = null;

            using (var scope = new UnitOfWorkScope<TargetFrameworkCoreEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                dto = VBusTaskScheduleConverter.ToDto(scope.DbContext.VBusTaskSchedules.Single(s => s.Name.Equals(busTaskName)));
            }

            return dto;
        }


        public Boolean SaveBusMessage(BusMessageStatusEnum status, String subscriber, String handler, Boolean isScheduledTask, BusMessageDTO messageDto)
        {
            // we need to save the notification then the recipients
            Ensure.That(messageDto);
            // must be recipients
            Ensure.That(messageDto.MessageId);

            bool success = false;

            bool messageExists = false;

            try
            {
                using (var scope = new UnitOfWorkScope<TargetFrameworkCoreEntities>(UnitOfWorkScopePurpose.Reading, this.Logger, false))
                {
                    var messages = scope.DbContext.BusMessages.AsNoTracking().Where(s => s.MessageId.Equals(messageDto.MessageId)).ToList();

                    if (messages.Count > 0)
                        messageExists = true;
                }

                if (!messageExists)
                {
                    if (messageDto.ProcessingMachine == null)
                        messageDto.ProcessingMachine = messageDto.WinIdName;

                    using (var scope = new UnitOfWorkScope<TargetFrameworkCoreEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
                    {
                        if (!isScheduledTask)
                            messageDto.BusMessageTypeID = GetClassificationDataForTypeName("BusMessageTypeID",
                                "Atomic");
                        else
                            messageDto.BusMessageTypeID = GetClassificationDataForTypeName("BusMessageTypeID",
                                "Scheduled");

                        messageDto.BusMessageID = Guid.NewGuid();

                        scope.DbContext.BusMessages.Add(BusMessageConverter.ToEntity(messageDto));

                        if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump()); ;
                    }

                    if(messageDto.BusMessageContents != null)
                    { 
                        using (var scope = new UnitOfWorkScope<TargetFrameworkCoreEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
                        {
                            var busMessage = scope.DbContext.BusMessages.Single(s => s.MessageId.Equals(messageDto.MessageId));

                            // save messageContent
                            var messageContent = new BusMessageContent
                            {
                                BusMessageID = busMessage.BusMessageID,
                                BusMessageContent1 = messageDto.BusMessageContents.First().BusMessageContent1,
                                BusMessageContentType = messageDto.BusMessageContents.First().BusMessageContentType,
                            };

                            scope.DbContext.BusMessageContents.Add(messageContent);

                            if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());
                        }
                    }
                }

                // add status entry
                using (var scope = new UnitOfWorkScope<TargetFrameworkCoreEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
                {

                    var busMessage = scope.DbContext.BusMessages.Single(s => s.MessageId.Equals(messageDto.MessageId));

                    bool hasError = (status == BusMessageStatusEnum.Failed);

                    CreateProcessLog(scope, busMessage.BusMessageID, null, hasError, handler, subscriber, null, null, status);

                    if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex);

                throw;
            }

            
            return success;
        }

        private void CreateProcessLog(UnitOfWorkScope<TargetFrameworkCoreEntities> scope, Guid busMessageId, Guid? parentID, bool hasError, string busMessageHandler, string busMessageSubscriber, string processDetail, string processMessage, BusMessageStatusEnum serviceStatusEnumValue)
        {
            // set status to processing
            var statusType = GetStatusType(scope, StatusTypeEnum.BusMessageProcessLogStatus.GetStringValue(),
                serviceStatusEnumValue.GetStringValue());

            Ensure.That(statusType);

            BusMessageProcessLog log = new BusMessageProcessLog
            {
                CreatedOn = DateTime.Now,
                BusMessageID = busMessageId,
                ParentID = parentID,
                StatusTypeID = statusType.StatusTypeID,
                StatusTypeValueID = statusType.StatusTypeValueID,
                StatusTypeVersionNumber = statusType.StatusTypeVersionNumber,
                IsComplete = false,
                NumberOfRetries = 0,
                ProcessDetail = processDetail,
                ProcessMessage = processMessage,
                BusMessageProcessLogID = Guid.NewGuid(),
                BusMessageHandler = busMessageHandler,
                BusMessageSubscriber = busMessageSubscriber,
                HasError = hasError
            };

            scope.DbContext.BusMessageProcessLogs.Add(log);
        }

        public virtual Boolean HasMessageAlreadyBeenProcessed(String subscriber, String handler, BusMessageDTO messageDto)
        {
            Ensure.That(messageDto).IsNotNull();
            Ensure.That(messageDto.MessageId).IsNot(Guid.Empty);

            bool exists = false;

            using (var scope = new UnitOfWorkScope<TargetFrameworkCoreEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                var messages = scope.DbContext.BusMessages.AsNoTracking().Where(s => s.MessageId.Equals(messageDto.MessageId)).ToList();

                if (messages.Count > 0)
                {
                    // successful message
                    var status = GetStatusType(scope,
                        StatusTypeEnum.BusMessageProcessLogStatus.GetStringValue(),
                        BusMessageStatusEnum.Successful.GetStringValue());
                    var messageID = messages.First().BusMessageID;
                    // now check for received status
                    exists =
                        scope.DbContext.BusMessageProcessLogs.Any(
                            s =>
                                s.BusMessageID.Equals(messageID) && s.StatusTypeValueID == status.StatusTypeValueID && s.StatusTypeID == status.StatusTypeID && s.StatusTypeVersionNumber == status.StatusTypeVersionNumber && s.BusMessageSubscriber.Equals(subscriber) && s.BusMessageHandler.Equals(handler));
                }

            }

            return exists;
        }

    }
}
