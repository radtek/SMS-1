using System.Net;
using System.ServiceModel.Description;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Serilog;
using Enyim.Caching.Configuration;
using Serilog.Extras.Web;

namespace BEC.TargetFramework.Presentation.Web.IOC
{
    using System;
    using System.Linq;
    using System.Web;

    using Bec.TargetFramework.Infrastructure.CouchBaseCache;
    using Bec.TargetFramework.Workflow.Interfaces;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using BrockAllen.MembershipReboot;
    using BrockAllen.MembershipReboot.Ef;
    using System.Web.Mvc;
    using BrockAllen.MembershipReboot.WebHost;
    using System.Reflection;
    using Bec.TargetFramework.Infrastructure.Log;
    using Autofac;
    using Autofac.Integration.Mvc;
    using System.Data.Entity.Infrastructure.Interception;
   
    using Autofac.Core;
    using System.Collections.Generic;
    using Autofac.Builder;
    using Bec.TargetFramework.Infrastructure.Caching;
    using System.ServiceModel;
    using Autofac.Integration.Wcf;
    using System.Configuration;
    using Bec.TargetFramework.Service.Configuration;
    using Bec.TargetFramework.Infrastructure.IOC;
    using NServiceBus;
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
            // disable lifycycle tracing
            ApplicationLifecycleModule.IsEnabled = false;

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();
            builder.RegisterType<DefaultUserAccountRepository>().As<IUserAccountRepository>();
            builder.RegisterType<SamAuthenticationService>().As<AuthenticationService>();
            builder.Register(c => new SerilogLogger(true, true, "TFWebApplication")).As<ILogger>().SingleInstance();
            builder.Register(c => new CouchBaseCacheClient(c.Resolve<ILogger>())).As<ICacheProvider>().SingleInstance();
            builder.RegisterInstance(new UserAccountService(Bec.TargetFramework.Security.Configuration.MembershipRebootConfig.Create(), new DefaultUserAccountRepository())).As<UserAccountService>();

            builder.RegisterProxyClients("Bec.TargetFramework.Business.Client",
               ConfigurationManager.AppSettings["BusinessServiceBaseURL"]);

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