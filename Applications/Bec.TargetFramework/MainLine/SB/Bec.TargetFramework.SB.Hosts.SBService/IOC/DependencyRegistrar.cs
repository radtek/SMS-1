using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Serilog;
using Bec.TargetFramework.SB.Client.Clients;
using Bec.TargetFramework.SB.Entities;
using Bec.TargetFramework.Service.Configuration;
using NServiceBus.ObjectBuilder.Common.Config;

namespace Bec.TargetFramework.SB.Hosts.SBService.IOC
{
    using System;
    using System.Configuration;
    using System.Linq;
    using System.Reflection;

    using Autofac.Integration.WebApi;

    using Bec.TargetFramework.Infrastructure.Caching;
    using Bec.TargetFramework.Infrastructure.CouchBaseCache;
    using Bec.TargetFramework.Infrastructure.Log;
    using Autofac;
    using Autofac.Core;
    using System.Collections.Generic;
    using Autofac.Builder;


    using NServiceBus;
    using NServiceBus.Installation.Environments;
    using Bec.TargetFramework.Infrastructure.Helpers;
    using Bec.TargetFramework.SB.Hosts.SBService.Logic;
    using Bec.TargetFramework.SB.Interfaces;
    using Bec.TargetFramework.Infrastructure.IOC;
    using Bec.TargetFramework.Infrastructure.Settings;
    using Bec.TargetFramework.Business.Client.Interfaces;

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

            builder.Register(c => new SBSettings()).As<SBSettings>().SingleInstance();
            
            builder.RegisterProxyClients("Bec.TargetFramework.Business.Client",
               ConfigurationManager.AppSettings["BusinessServiceBaseURL"]);

            builder.RegisterProxyClients("Bec.TargetFramework.SB.Client",
                ConfigurationManager.AppSettings["SBServiceBaseURL"]);

            builder.RegisterType<SettingService>().As<SettingService>().InstancePerLifetimeScope();

            var type = typeof(ISettings);
            AllAssemblies.Matching("Bec.TargetFramework")
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface)
                .ToList().ForEach(item =>
                {
                    builder.Register(c => c.Resolve<SettingService>().GetType().GetMethod("LoadSetting").MakeGenericMethod(item).Invoke(c.Resolve<SettingService>(), new object[1] { 0 })).As(item).InstancePerLifetimeScope();
                });

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).InstancePerRequest();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).InstancePerRequest();
        }
    }
}