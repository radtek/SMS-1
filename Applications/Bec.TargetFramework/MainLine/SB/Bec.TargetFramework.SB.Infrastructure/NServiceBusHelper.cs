using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using NServiceBus;
using Bec.TargetFramework.Entities;

namespace Bec.TargetFramework.SB.Infrastructure
{
    public class NServiceBusHelper
    {
        public static Configure CreateDefaultStartableBus()
        {
            //Configure..ScaleOut(s => s.UseSingleBrokerQueue());

            //return
            //    Configure.With(
            //        AllAssemblies.Matching("Bec.TargetFramework.SB.").And("NServiceBus."))
            //        .DefaultBuilder()
            //        .UseTransport<NServiceBus.SqlServer>()
            //        .UnicastBus()
            //        .RunHandlersUnderIncomingPrincipal(false)
            //        .RijndaelEncryptionService();

            return null;
        }

        public static Configure CreateDefaultStartableBusUsingaAutofacBuilder(IContainer container)
        {
            //Configure.ScaleOut(s => s.UseSingleBrokerQueue());

            //return
            //    Configure.With(
            //        AllAssemblies.Matching("Bec.TargetFramework.SB.").And("NServiceBus."))
            //        .AutofacBuilder(container)
            //        .UseTransport<NServiceBus.SqlServer>()
            //        .UnicastBus()
            //        .RunHandlersUnderIncomingPrincipal(false)
            //        .RijndaelEncryptionService();

            return null;
        }

        public static BusMessageDTO GetBusMessageDto(IDictionary<string, string> headers)
        {
            var dto = new BusMessageDTO
            {
                CorrelationId = Guid.Parse(headers["NServiceBus.CorrelationId"]),
                MessageId = Guid.Parse(headers["NServiceBus.MessageId"]),
                TimeSent = DateTime.Now,
                EnclosedMessageTypes = headers["NServiceBus.EnclosedMessageTypes"],
                ProcessingStarted = DateTime.Now
            };

            if (headers.ContainsKey("WinIdName"))
                dto.WinIdName = headers["WinIdName"];

            if (headers.ContainsKey("NServiceBus.OriginatingMachine"))
                dto.WinIdName = headers["NServiceBus.OriginatingMachine"];

            if (headers.ContainsKey("Source"))
                dto.Source = headers["Source"];

            if (headers.ContainsKey("ParentID"))
                dto.ParentID = Guid.Parse(headers["ParentID"]);

            if (headers.ContainsKey("ServiceType"))
                dto.ProcessingMachine = headers["ServiceType"];

            if (headers.ContainsKey("EventReference"))
                dto.EventReference = headers["EventReference"];

            return dto;
        }
    }
}
