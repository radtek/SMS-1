using Autofac.Integration.Wcf;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Serilog;
using Bec.TargetFramework.SB.Infrastructure;
using Seq;

namespace Bec.TargetFramework.Hosts.BusinessService.IOC
{
    using System;
    using System.Linq;

    using Bec.TargetFramework.Data;

    using BrockAllen.MembershipReboot;
    using BrockAllen.MembershipReboot.Ef;
    using BrockAllen.MembershipReboot.WebHost;
    using System.Reflection;
    using Bec.TargetFramework.Infrastructure.Log;
    using Autofac;
    using Bec.TargetFramework.Data.Infrastructure;
    using System.Data.Entity.Infrastructure.Interception;
    using Autofac.Core;
    using System.Collections.Generic;
    using Autofac.Builder;
    using Bec.TargetFramework.Infrastructure.Caching;
    using System.ServiceModel;
    using Bec.TargetFramework.Business.Logic;
    using Bec.TargetFramework.Service.Configuration;
    using Bec.TargetFramework.Entities.Settings;
    using NServiceBus;
    using NServiceBus.Installation.Environments;
    using NServiceBus.Logging;
    using Bec.TargetFramework.Infrastructure.Helpers;
    using Bec.TargetFramework.Infrastructure.CouchBaseCache;
    using System.Configuration;
    using Bec.TargetFramework.Infrastructure.IOC;
    using Bec.TargetFramework.Infrastructure.Settings;
    using Bec.TargetFramework.SB.Interfaces;

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
            builder.RegisterType<DefaultUserAccountRepository>().As<IUserAccountRepository>();
            builder.RegisterType<SamAuthenticationService>().As<AuthenticationService>();
            builder.Register(c => new SerilogLogger(true, false, "BusinessService")).As<ILogger>().SingleInstance();
            builder.Register(c => new CouchBaseCacheClient(c.Resolve<ILogger>(),
                ConfigurationManager.AppSettings["couchbase:bucket"],
                ConfigurationManager.AppSettings["couchbase:username"],
                ConfigurationManager.AppSettings["couchbase:password"],
                ConfigurationManager.AppSettings["couchbase:uri"],
                ConfigurationManager.AppSettings["couchbase:connectionTimeout"],
                ConfigurationManager.AppSettings["couchbase:deadTimeout"])).As<ICacheProvider>().SingleInstance();
            builder.RegisterInstance(new UserAccountService(Bec.TargetFramework.Security.Configuration.MembershipRebootConfig.Create(), new DefaultUserAccountRepository())).As<UserAccountService>();

            builder.Register(c => new SettingLogic(c.Resolve<ILogger>(), c.Resolve<ICacheProvider>()))
                .As<SettingLogic>();

            builder.Register(c => new SettingServiceLocal(c.Resolve<SettingLogic>())).As<SettingServiceLocal>();

            var type = typeof(ISettings);
            AppDomain.CurrentDomain.GetAssemblies().Where(s => s.FullName.StartsWith("Bec.TargetFramework"))
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface)
                .ToList().ForEach(item =>
                {
                    builder.Register(c => c.Resolve<SettingServiceLocal>().GetType().GetMethod("LoadSetting").MakeGenericMethod(item).Invoke(c.Resolve<SettingServiceLocal>(), new object[1] { 0 })).As(item);
                });

            builder.Register(c => new DataLogic(c.Resolve<ILogger>()
                           , c.Resolve<ICacheProvider>(), c.Resolve<CommonSettings>())).As<DataLogic>();

            builder.Register(c => new UserLogic(c.Resolve<UserAccountService>()
                           , c.Resolve<AuthenticationService>(), c.Resolve<DataLogic>(), c.Resolve<ILogger>(), c.Resolve<ICacheProvider>(), c.Resolve<IEventPublishClient>())).As<UserLogic>();

            builder.Register(c => new NotificationLogic(c.Resolve<ILogger>()
                          , c.Resolve<ICacheProvider>())).As<NotificationLogic>();

            builder.Register(c => new OrganisationLogic(c.Resolve<UserAccountService>()
                            , c.Resolve<AuthenticationService>()
                            , c.Resolve<ILogger>()
                            , c.Resolve<ICacheProvider>()
                            , c.Resolve<CommonSettings>(),
                            c.Resolve<UserLogic>(),
                            c.Resolve<DataLogic>(),
                            c.Resolve<IEventPublishClient>(),
                            c.Resolve<NotificationLogic>())).As<OrganisationLogic>();

            builder.RegisterProxyClients("Bec.TargetFramework.SB.Client",
                ConfigurationManager.AppSettings["SBServiceBaseURL"]);
        }



    }

}