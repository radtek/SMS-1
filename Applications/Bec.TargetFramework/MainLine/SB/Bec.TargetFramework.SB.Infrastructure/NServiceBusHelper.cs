using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using NServiceBus;
using NServiceBus.PostgreSQL;
using Bec.TargetFramework.SB.Entities;
using Bec.TargetFramework.Infrastructure;
using NServiceBus.Logging;
using NServiceBus.Serilog.Tracing;
using NServiceBus.Serilog;
using Bec.TargetFramework.Infrastructure.Log;
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

        public static BusConfiguration CreateDefaultStartableBusUsingaAutofacBuilder(IContainer container, bool purgeOnStartup = true,bool traceEnable = false)
        {
            var iocContainer = IocContainerBase.GetIocContainer(AppDomain.CurrentDomain.FriendlyName);

            var iLogger = iocContainer.Resolve<ILogger>();
            iLogger.CreateLogger();

            LogManager.Use<SerilogFactory>();

            BusConfiguration configuration = new BusConfiguration();

            // persistence provider for subscribers, publishers
            configuration.UsePersistence<InMemoryPersistence>();

            configuration.ScaleOut();

            // IOC configuration
            configuration.UseContainer<AutofacBuilder>(s => s.ExistingLifetimeScope(container));
        
            // transport mechanism
            configuration.UseTransport<RabbitMQTransport>().DisableCallbackReceiver();

            configuration.EnableOutbox();
           
            // whether to clean the queues on startup
            configuration.PurgeOnStartup(purgeOnStartup);
            // encryption of messages
            //configuration.RijndaelEncryptionService();
            // whether to use encryption of messages
            configuration.EnableInstallers();

            configuration.SerilogTracingTarget(Serilog.Log.Logger);

            configuration.RegisterComponents(c =>
            {
                c.ConfigureComponent<IncomingOutgoingMessageMutator>(DependencyLifecycle.SingleInstance);
            });

            return configuration;
        }

        public static BusMessageDTO GetBusMessageDto(IDictionary<string, string> headers)
        {
            var dto = new BusMessageDTO
            {
                CorrelationId = Guid.Parse(headers["NServiceBus.CorrelationId"]),
                MessageId = Guid.Parse(headers["NServiceBus.MessageId"]),
                SentOn = DateTime.Now,
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
