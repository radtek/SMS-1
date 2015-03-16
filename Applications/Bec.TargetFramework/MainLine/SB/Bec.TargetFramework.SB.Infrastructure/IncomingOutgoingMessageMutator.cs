using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure.Log;
using NHibernate;
using NServiceBus;
using NServiceBus.MessageMutator;
using Bec.TargetFramework.Entities;
using NServiceBus.Unicast.Subscriptions;
using NServiceBus.Unicast.Subscriptions.MessageDrivenSubscriptions;
using ServiceStack.Text;

namespace Bec.TargetFramework.SB.Infrastructure
{
    public class IncomingOutgoingMessageMutator : IMutateOutgoingTransportMessages,IMutateIncomingTransportMessages
    {
        public  ILogger m_Logger {get;set;}
        public IBusLogic m_BusLogic { get; set; }

        public IncomingOutgoingMessageMutator()
        {
            m_Logger = Configure.Instance.Builder.Build<ILogger>();
            m_BusLogic = Configure.Instance.Builder.Build<IBusLogic>();
        }

        public void MutateOutgoing(object[] messages, TransportMessage transportMessage)
        {
            if (transportMessage.Headers.ContainsKey("Source"))
            {
                var dto = NServiceBusHelper.GetBusMessageDto(transportMessage.Headers);

                BusMessageContentDTO messageContent= new BusMessageContentDTO();
                messageContent.BusMessageContent1 = transportMessage.Body;
                messageContent.BusMessageHeader = transportMessage.ToJson();

                dto.MessageSentFrom = dto.ProcessingMachine;
                dto.Source = dto.ProcessingMachine;

                if (transportMessage.Headers.ContainsKey("ParentID"))
                    dto.ParentID = Guid.Parse(transportMessage.Headers["ParentID"]);

                if (transportMessage.Headers.ContainsKey("MessageType"))
                    messageContent.BusMessageContentType = transportMessage.Headers["MessageType"];
                else
                    messageContent.BusMessageContentType = "";

                dto.BusMessageContents = new List<BusMessageContentDTO>();
                dto.BusMessageContents.Add(messageContent);


                if(dto.ProcessingMachine.Equals("Task"))
                    m_BusLogic.SaveBusMessage(dto, BusMessageStatusEnum.Sent, "Mutator", "Mutate", true);
                else
                    m_BusLogic.SaveBusMessage(dto, BusMessageStatusEnum.Sent, "Mutator", "Mutate", false);
            }
        }

        public void MutateIncoming(TransportMessage transportMessage)
        {
            // change status to received
            if (transportMessage.Headers.ContainsKey("Source"))
            {
                var dto = NServiceBusHelper.GetBusMessageDto(transportMessage.Headers);

                BusMessageContentDTO messageContent = new BusMessageContentDTO();
                messageContent.BusMessageContent1 = transportMessage.Body;
                messageContent.BusMessageHeader = transportMessage.ToJson();

                dto.MessageSentFrom = dto.ProcessingMachine;
                dto.Source = dto.ProcessingMachine;

                if (transportMessage.Headers.ContainsKey("ParentID"))
                    dto.ParentID = Guid.Parse(transportMessage.Headers["ParentID"]);

                if (transportMessage.Headers.ContainsKey("MessageType"))
                    messageContent.BusMessageContentType = transportMessage.Headers["MessageType"];
                else
                    messageContent.BusMessageContentType = "";

                dto.BusMessageContents = new List<BusMessageContentDTO>();
                dto.BusMessageContents.Add(messageContent);

                if (dto.ProcessingMachine.Equals("Task"))
                    m_BusLogic.SaveBusMessage(dto, BusMessageStatusEnum.Received, "Mutator", "Mutate", true);
                else
                    m_BusLogic.SaveBusMessage(dto, BusMessageStatusEnum.Received, "Mutator", "Mutate", false);
            }
               
          
        }
    }
}
