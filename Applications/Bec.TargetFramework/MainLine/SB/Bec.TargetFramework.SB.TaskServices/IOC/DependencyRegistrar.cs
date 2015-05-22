
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Serilog;
using Bec.TargetFramework.SB.Entities;
using Bec.TargetFramework.SB.Infrastructure;
using Bec.TargetFramework.SB.Interfaces;
using Bec.TargetFramework.Service.Configuration;
using NServiceBus.ObjectBuilder.Common.Config;
using Seq;
using Bec.TargetFramework.Infrastructure.IOC;
using Bec.TargetFramework.SB.Infrastructure.Quartz.Module;

namespace Bec.TargetFramework.SB.TaskServices.IOC
{
    using System;
    using System.Configuration;
    using System.Linq;
    using System.Reflection;
    using System.ServiceModel;

    using Autofac.Integration.Wcf;
    using Autofac.Integration.WebApi;

    using Bec.TargetFramework.Infrastructure.Caching;
    using Bec.TargetFramework.Infrastructure.CouchBaseCache;
    using Bec.TargetFramework.Infrastructure.Log;
    using Autofac;
    using Autofac.Core;
    using System.Collections.Generic;
    using Autofac.Builder;
 
    using BrockAllen.MembershipReboot;
    using BrockAllen.MembershipReboot.Ef;
    using BrockAllen.MembershipReboot.WebHost;

    using NServiceBus;
    using NServiceBus.Installation.Environments;
    using Bec.TargetFramework.Infrastructure.Helpers;
    using Bec.TargetFramework.Business.Client.Interfaces;
    using Bec.TargetFramework.Infrastructure.Settings;
    using Bec.TargetFramework.SB.NotificationServices.Report;

    /// <summary>
    /// IOC Configuration - Loads on Startup of Web Application
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Starts the IOC Container
        /// </summary>
        public virtual void Register(ContainerBuilder builder)
        {
            // register logger
            builder.Register(c => new SerilogLogger(true, false, "TaskService")).As<ILogger>().SingleInstance();
            builder.Register(c => new CouchBaseCacheClient(c.Resolve<ILogger>(),
                ConfigurationManager.AppSettings["couchbase:bucket"],
                ConfigurationManager.AppSettings["couchbase:username"],
                ConfigurationManager.AppSettings["couchbase:password"],
                ConfigurationManager.AppSettings["couchbase:uri"],
                ConfigurationManager.AppSettings["couchbase:connectionTimeout"],
                ConfigurationManager.AppSettings["couchbase:deadTimeout"])).As<ICacheProvider>().SingleInstance();
           
            
            builder.RegisterProxyClients("Bec.TargetFramework.Business.Client",
                ConfigurationManager.AppSettings["BusinessServiceBaseURL"]);

            builder.RegisterProxyClients("Bec.TargetFramework.SB.Client",
                ConfigurationManager.AppSettings["SBServiceBaseURL"]);

            builder.Register(c => new SettingService(c.Resolve<ISettingsLogicClient>())).As<SettingService>();

            var type = typeof(ISettings);
            AllAssemblies.Matching("Bec.TargetFramework")
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface)
                .ToList().ForEach(item =>
                {
                    builder.Register(c => c.Resolve<SettingService>().GetType().GetMethod("LoadSetting").MakeGenericMethod(item).Invoke(c.Resolve<SettingService>(), new object[1] { 0 })).As(item);
                });

            builder.Register(c => new StandaloneReportGenerator(c.Resolve<IClassificationDataLogicClient>())).As<StandaloneReportGenerator>();

            // Quartz Setup
            builder.RegisterModule(new QuartzAutofacFactoryModule());
            builder.RegisterModule(
                new QuartzAutofacJobsModule(Assembly.Load("Bec.TargetFramework.SB.Infrastructure.Quartz"))); 
        }
    }
}