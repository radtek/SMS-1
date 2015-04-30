using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Log;
using NServiceBus;
using NServiceBus.Logging;
using NServiceBus.MessageMutator;
using NServiceBus.Unicast;
using NServiceBus.Unicast.Subscriptions;
using NServiceBus.Unicast.Subscriptions.MessageDrivenSubscriptions;
using ServiceStack.Text;
using Bec.TargetFramework.SB.Interfaces;
using Bec.TargetFramework.SB.Entities;
using Bec.TargetFramework.SB.Entities.Enums;

namespace Bec.TargetFramework.SB.Infrastructure
{
    public class IncomingOutgoingMessageMutator : IMutateTransportMessages
    {
        public  ILog m_Logger {get;set;}
        public IBusLogicClient m_BusLogic { get; set; }

        public IBus m_Bus { get; set; }


        public IncomingOutgoingMessageMutator()
        {
            m_Logger = NServiceBus.Logging.LogManager.GetLogger("NServiceBusLogger");
        }

        void IMutateIncomingTransportMessages.MutateIncoming(TransportMessage transportMessage)
        {
            if (m_BusLogic == null)
                m_BusLogic = (m_Bus as UnicastBus).Builder.Build<IBusLogicClient>();

            if (transportMessage.Headers.ContainsKey("Source"))
            {
                var dto = NServiceBusHelper.GetBusMessageDto(transportMessage.Headers);

                BusMessageContentDTO messageContent = new BusMessageContentDTO();
                messageContent.BusMessageContent1 = transportMessage.Body;
                messageContent.BusMessageHeader = transportMessage.ToJson();

                dto.MessageSentFrom = dto.ProcessingMachine;
                dto.Source = dto.ProcessingMachine;

                if (dto.ProcessingMachine == null)
                    dto.ProcessingMachine = dto.WinIdName;

                if (transportMessage.Headers.ContainsKey("ParentID"))
                    dto.ParentID = Guid.Parse(transportMessage.Headers["ParentID"]);

                if (transportMessage.Headers.ContainsKey("MessageType"))
                    messageContent.BusMessageContentType = transportMessage.Headers["MessageType"];
                else
                    messageContent.BusMessageContentType = "";

                dto.BusMessageContents = new List<BusMessageContentDTO>();
                dto.BusMessageContents.Add(messageContent);

                m_BusLogic.SaveBusMessage(BusMessageStatusEnum.Received, "Mutator", "Mutate", false, dto);
            }
        }

        void IMutateOutgoingTransportMessages.MutateOutgoing(NServiceBus.Unicast.Messages.LogicalMessage logicalMessage, TransportMessage transportMessage)
        {
            if (m_BusLogic == null)
                m_BusLogic = (m_Bus as UnicastBus).Builder.Build<IBusLogicClient>();
                

            if (transportMessage.Headers.ContainsKey("Source"))
            {
                var dto = NServiceBusHelper.GetBusMessageDto(transportMessage.Headers);

                BusMessageContentDTO messageContent = new BusMessageContentDTO();
                messageContent.BusMessageContent1 = transportMessage.Body;
                messageContent.BusMessageHeader = transportMessage.ToJson();

                dto.MessageSentFrom = dto.ProcessingMachine;
                dto.Source = dto.ProcessingMachine;

                if (dto.ProcessingMachine == null)
                    dto.ProcessingMachine = dto.WinIdName;

                if (transportMessage.Headers.ContainsKey("ParentID"))
                    dto.ParentID = Guid.Parse(transportMessage.Headers["ParentID"]);

                if (transportMessage.Headers.ContainsKey("MessageType"))
                    messageContent.BusMessageContentType = transportMessage.Headers["MessageType"];
                else
                    messageContent.BusMessageContentType = "";

                dto.BusMessageContents = new List<BusMessageContentDTO>();
                dto.BusMessageContents.Add(messageContent);

                m_BusLogic.SaveBusMessage( BusMessageStatusEnum.Sent, "Mutator", "Mutate", false,dto);
            }
        }
    }
}
