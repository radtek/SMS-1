using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.SB.Data;
using Bec.TargetFramework.SB.Entities;
using Bec.TargetFramework.SB.Entities.Enums;
using Bec.TargetFramework.SB.Hosts.SBService.Helpers;
using EnsureThat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bec.TargetFramework.SB.Hosts.SBService.Logic
{
    [Trace(TraceExceptionsOnly = true)]
    public class BusLogicController : LogicBase
    {
        public BusLogicController()
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

        public async Task<bool> SaveBusMessageAsync(BusMessageStatusEnum status, String subscriber, String handler, Boolean isScheduledTask, BusMessageDTO messageDto)
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
                            messageDto.BusMessageTypeID = LogicHelper.GetClassificationDataForTypeName(scope, "BusMessageTypeID", "Atomic");
                        else
                            messageDto.BusMessageTypeID = LogicHelper.GetClassificationDataForTypeName(scope, "BusMessageTypeID", "Scheduled");

                        messageDto.BusMessageID = Guid.NewGuid();

                        scope.DbContext.BusMessages.Add(BusMessageConverter.ToEntity(messageDto));

                        await scope.SaveAsync();
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

                            await scope.SaveAsync();
                        }
                    }
                }

                // add status entry
                using (var scope = new UnitOfWorkScope<TargetFrameworkCoreEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
                {
                    var busMessage = scope.DbContext.BusMessages.Single(s => s.MessageId.Equals(messageDto.MessageId));

                    bool hasError = (status == BusMessageStatusEnum.Failed);

                    await CreateProcessLog(busMessage.BusMessageID, null, hasError, handler, subscriber, null, null, status);

                    await scope.SaveAsync();
                }

            }
            catch (Exception ex)
            {
                Logger.Error(ex);

                throw;
            }

            
            return success;
        }

        private async Task CreateProcessLog(Guid busMessageId, Guid? parentID, bool hasError, string busMessageHandler, string busMessageSubscriber, string processDetail, string processMessage, BusMessageStatusEnum serviceStatusEnumValue)
        {
            using (var scope = new UnitOfWorkScope<TargetFrameworkCoreEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                // set status to processing
                var statusType = LogicHelper.GetStatusType(scope, StatusTypeEnum.BusMessageProcessLogStatus.GetStringValue(), serviceStatusEnumValue.GetStringValue());

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
                await scope.SaveAsync();
            }
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
                    var status = LogicHelper.GetStatusType(scope,
                        StatusTypeEnum.BusMessageProcessLogStatus.GetStringValue(),
                        BusMessageStatusEnum.Successful.GetStringValue());
                    var messageID = messages.First().BusMessageID;
                    // now check for received status
                    exists = scope.DbContext.BusMessageProcessLogs.Any(s =>
                        s.BusMessageID.Equals(messageID) &&
                        s.StatusTypeValueID == status.StatusTypeValueID &&
                        s.StatusTypeID == status.StatusTypeID &&
                        s.StatusTypeVersionNumber == status.StatusTypeVersionNumber &&
                        s.BusMessageSubscriber.Equals(subscriber) &&
                        s.BusMessageHandler.Equals(handler));
                }
            }

            return exists;
        }

    }
}
