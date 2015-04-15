using Bec.TargetFramework.Hosts.Infrastructure.Interfaces;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Serilog;
using Seq;


namespace BEC.TargetFramework.Workflow.Test.IOC
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
    using Bec.TargetFramework.Service.Configuration;
    using Autofac.Core;
    using System.Collections.Generic;
    using Autofac.Builder;

    using Bec.TargetFramework.Infrastructure.Caching;
    using System.ServiceModel;
    using Autofac.Integration.Wcf;
    using Bec.TargetFramework.Business.Infrastructure.Interfaces;
    using System.Configuration;
    using Bec.TargetFramework.SB.Interfaces;
    using Bec.TargetFramework.Infrastructure.IOC;

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
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();
            builder.RegisterType<DefaultUserAccountRepository>().As<IUserAccountRepository>();
            builder.RegisterType<SamAuthenticationService>().As<AuthenticationService>();
            builder.Register(c => new SerilogLogger(true, false, "WorkflowTest")).As<ILogger>().SingleInstance();
            builder.Register(c => new CouchBaseCacheClient(c.Resolve<ILogger>(),
                ConfigurationManager.AppSettings["couchbase:bucket"],
                ConfigurationManager.AppSettings["couchbase:username"],
                ConfigurationManager.AppSettings["couchbase:password"],
                ConfigurationManager.AppSettings["couchbase:uri"],
                ConfigurationManager.AppSettings["couchbase:connectionTimeout"],
                ConfigurationManager.AppSettings["couchbase:deadTimeout"])).As<ICacheProvider>().SingleInstance();
            builder.RegisterInstance(new UserAccountService(Bec.TargetFramework.Security.Configuration.MembershipRebootConfig.Create(), new DefaultUserAccountRepository())).As<UserAccountService>();

            //// register settings service and all ISettings 
            //RegisterService<ISettingLogic>(builder, BuildBaseUrlForServices("SettingLogicService"));
            //builder.Register(c => new SettingService(c.Resolve<ISettingLogic>())).As<SettingService>();

            //var type = typeof(ISettings);
            //AppDomain.CurrentDomain.GetAssemblies().Where(it => it.FullName.StartsWith("Bec.TargetFramework"))
            //    .SelectMany(s => s.GetTypes())
            //    .Where(p => type.IsAssignableFrom(p) && !p.IsInterface)
            //    .ToList().ForEach(item =>
            //    {
            //        builder.Register(c => c.Resolve<SettingService>().GetType().GetMethod("LoadSetting").MakeGenericMethod(item).Invoke(c.Resolve<SettingService>(), new object[1] { 0 })).As(item);
            //    });

        }
    }

}