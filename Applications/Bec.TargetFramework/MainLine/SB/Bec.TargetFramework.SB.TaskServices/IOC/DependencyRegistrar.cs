﻿using Autofac.Extras.Quartz;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Serilog;
using Bec.TargetFramework.SB.Client.Clients;
using Bec.TargetFramework.SB.Entities;
using Bec.TargetFramework.SB.Infrastructure;
using Bec.TargetFramework.SB.Interfaces;
using Bec.TargetFramework.Service.Configuration;
using Bec.TargetFramework.Workflow.Interfaces;
using NServiceBus.ObjectBuilder.Common.Config;
using Seq;
using Bec.TargetFramework.Infrastructure.IOC;

namespace Bec.TargetFramework.SB.TaskServices.IOC
{
    using System;
    using System.Configuration;
    using System.Linq;
    using System.Reflection;
    using System.ServiceModel;

    using Autofac.Integration.Wcf;
    using Autofac.Integration.WebApi;

    using Bec.TargetFramework.Business.Infrastructure.Interfaces;
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
            builder.Register(c => new CouchBaseCacheClient(c.Resolve<ILogger>())).As<ICacheProvider>().SingleInstance();
            builder.RegisterModule(new QuartzAutofacFactoryModule());
            builder.RegisterModule(
                new QuartzAutofacJobsModule(Assembly.Load("Bec.TargetFramework.SB.TaskHandlers"))); 
            
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
        }
    }
}