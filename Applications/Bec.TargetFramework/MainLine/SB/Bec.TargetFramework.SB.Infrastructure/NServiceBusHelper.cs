using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
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
using NServiceBus.Config;
using NServiceBus.Config.ConfigurationSource;
using NServiceBus.Features;
using NServiceBus.Persistence;
using NServiceBus.Persistence.ExtendedInMemory;
using RabbitMQ.Client;

namespace Bec.TargetFramework.SB.Infrastructure
{
    public class NServiceBusHelper
    {
        public static BusConfiguration CreateDefaultStartableBusUsingaAutofacBuilder(ILifetimeScope lifetimeScope,  bool purgeOnStartup = true,bool traceEnable = false)
        {
            var iLogger = lifetimeScope.Resolve<ILogger>();

            iLogger.CreateLogger();

            LogManager.Use<SerilogFactory>();

            BusConfiguration configuration = new BusConfiguration();

            #if DEBUG
                var endpointName = ConfigurationManager.AppSettings["nservicebus:endPointName"];
                ConfigurationManager.AppSettings["nservicebus:endPointName"] = Environment.UserName + "_" + endpointName ;
            #endif

            configuration.CustomConfigurationSource(new ConfigurationSource());

            if (ConfigurationManager.AppSettings["nservicebus:endPointName"] != null)
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

            // enable installers
            configuration.EnableInstallers();

            // using RabbitMq disabled transactions
            configuration.DisableFeature<NServiceBus.Features.TimeoutManager>();
            configuration.Transactions().Disable();

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

    public class ConfigurationSource : IConfigurationSource
    {
        public T GetConfiguration<T>() where T : class, new()
        {
            if (typeof(T) == typeof(UnicastBusConfig))
            {
                //read from existing config 
                var config = (UnicastBusConfig)ConfigurationManager
                    .GetSection(typeof(UnicastBusConfig).Name);
                if (config == null)
                {
                    //create new config if it doesn't exist
                    config = new UnicastBusConfig
                    {
                        MessageEndpointMappings = new MessageEndpointMappingCollection()
                    };
                }

                var collection = new MessageEndpointMappingCollection();

                config.MessageEndpointMappings.OfType<MessageEndpointMapping>().ToList().ForEach(s =>
                {
                    collection.Add(
                    new MessageEndpointMapping
                    {
                        AssemblyName = s.AssemblyName,
                        TypeFullName = s.TypeFullName,
                        Endpoint = ConfigurationManager.AppSettings["nservicebus:endPointName"]
                    });
                });

                // update endpoint name in mappings
                config = new UnicastBusConfig
                {
                    MessageEndpointMappings = collection
                };

                return config as T;
            }

            // To in app.config for other sections not defined in this method, otherwise return null.
            return ConfigurationManager.GetSection(typeof(T).Name) as T;
        }
    }
}
