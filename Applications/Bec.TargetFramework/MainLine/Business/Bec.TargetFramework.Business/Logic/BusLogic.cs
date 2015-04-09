using System;
using System.Collections.Generic;
using System.Linq;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
//Bec.TargetFramework.Entities
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Infrastructure.Log;
using BrockAllen.MembershipReboot;
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
    public class BusLogic : LogicBase, IBusLogic
    {
        private IClassificationDataLogic m_CLogic;

        public BusLogic(ILogger logger, ICacheProvider cacheProvider, IClassificationDataLogic cLogic)
            : base(logger, cacheProvider)
        {
            m_CLogic = cLogic;
        }

        public List<TFEventMessageSubscriberDTO> GetTFEventSubscribers(Guid tfEventId)
        {
            Ensure.That(tfEventId);

            List<TFEventMessageSubscriberDTO> list = new List<TFEventMessageSubscriberDTO>();

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
            {
                //var fieldQuery =
                //    scope.DbContext.Bus.Include("BusEventMessageSubscribers").SingleOrDefault(s => s.TFEventID.Equals(tfEventId));

                //Ensure.That(fieldQuery);

                //fieldQuery.TFEventMessageSubscribers.ToList().ForEach(item =>
                //{
                //    list.Add(TFEventMessageSubscriberConverter.ToDto(item));
                //});
            }

            return list;
        }


        public bool SaveBusMessage(BusMessageDTO messageDto, BusMessageStatusEnum status, string subscriber, string handler, bool isScheduledTask = false)
        {
            // we need to save the notification then the recipients
            Ensure.That(messageDto);
            // must be recipients
            Ensure.That(messageDto.MessageId);

            bool success = false;

            bool messageExists = false;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger, false))
            {
                var messages = scope.DbContext.BusMessages.AsNoTracking().Where(s => s.MessageId.Equals(messageDto.MessageId)).ToList();

                if (messages.Count > 0)
                    messageExists = true;
            }

            if (!messageExists)
            {
                using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
                {
                    if (!isScheduledTask)
                        messageDto.BusMessageTypeID = m_CLogic.GetClassificationDataForTypeName("BusMessageTypeID",
                            "Atomic");
                    else
                        messageDto.BusMessageTypeID = m_CLogic.GetClassificationDataForTypeName("BusMessageTypeID",
                            "Scheduled");

                    messageDto.BusMessageID = Guid.NewGuid();

                    scope.DbContext.BusMessages.Add(BusMessageConverter.ToEntity(messageDto));

                    if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());;
                }

                using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
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

            // add status entry
            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Writing, this.Logger, true))
            {
                
                var busMessage = scope.DbContext.BusMessages.Single(s => s.MessageId.Equals(messageDto.MessageId));

                bool hasError = (status == BusMessageStatusEnum.Failed);

                BusMessageHelper.CreateProcessLog(scope,busMessage.BusMessageID,null,hasError,handler,subscriber,null,null,status);

                if (!scope.Save()) throw new Exception(scope.EntityErrors.Dump());
            }

            return success;
        }

        public bool HasMessageAlreadyBeenProcessed(BusMessageDTO messageDto,string subscriber, string handler)
        {
            Ensure.That(messageDto).IsNotNull();
            Ensure.That(messageDto.MessageId).IsNot(Guid.Empty);

            bool exists = false;

            using (var scope = new UnitOfWorkScope<TargetFrameworkEntities>(UnitOfWorkScopePurpose.Reading, this.Logger))
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
