using System;
using System.Collections.Generic;
using System.Configuration;
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
using Bec.TargetFramework.Infrastructure.IOC;
using EnsureThat;
using RabbitMQ.Client;

namespace Bec.TargetFramework.SB.Infrastructure
{
    public class NServiceBusHelper
    {
        public static BusConfiguration CreateDefaultStartableBusUsingaAutofacBuilder(ILifetimeScope lifetimeScope, bool purgeOnStartup = true,bool traceEnable = false)
        {
            var iLogger = lifetimeScope.Resolve<ILogger>();
            iLogger.CreateLogger();

            LogManager.Use<SerilogFactory>();

            BusConfiguration configuration = new BusConfiguration();

            Ensure.That(ConfigurationManager.AppSettings["nservicebus:endPointName"]).IsNotNullOrWhiteSpace();

            configuration.EndpointName(ConfigurationManager.AppSettings["nservicebus:endPointName"]);

            if (ConfigurationManager.AppSettings["nservicebus:purgeQueuesOnStartup"] != null)
                purgeOnStartup = bool.Parse(ConfigurationManager.AppSettings["nservicebus:purgeQueuesOnStartup"]);

            if (ConfigurationManager.AppSettings["nservicebus:messageConventionNamespace"] != null)
            {
                configuration.Conventions()
               .DefiningEventsAs(p => p.Namespace != null && p.Namespace.StartsWith(ConfigurationManager.AppSettings["nservicebus:messageConventionNamespace"])
                   && p.Namespace.EndsWith(ConfigurationManager.AppSettings["nservicebus:messageConventionNamespaceEndEvent"]))
               .DefiningCommandsAs(p => p.Namespace != null && p.Namespace.StartsWith(ConfigurationManager.AppSettings["nservicebus:messageConventionNamespace"])
                   && p.Namespace.EndsWith(ConfigurationManager.AppSettings["nservicebus:messageConventionNamespaceEndCommand"]));
            }

            // persistence provider for subscribers, publishers
            configuration.UsePersistence<InMemoryPersistence>();

            configuration.UseSerialization<JsonSerializer>();

            // IOC configuration
            configuration.UseContainer<AutofacBuilder>(s => s.ExistingLifetimeScope(lifetimeScope));
        
            // transport mechanism
            configuration.UseTransport<RabbitMQTransport>().DisableCallbackReceiver();

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
