using Autofac;
using Autofac.Integration.Mvc;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.CouchBaseCache;
using Bec.TargetFramework.Infrastructure.IOC;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Infrastructure.Serilog;
using Bec.TargetFramework.Presentation.Web.Areas.Admin.Controllers;
using BrockAllen.MembershipReboot;
using BrockAllen.MembershipReboot.WebHost;
using Serilog.Extras.Web;
using System.Configuration;
using System.Reflection;

namespace BEC.TargetFramework.Presentation.Web.IOC
{
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

            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).InstancePerRequest();
            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinderProvider();
            builder.RegisterType<SamAuthenticationService>().As<AuthenticationService>();
            builder.Register(c => new SerilogLogger(true, true, "TFWebApplication")).As<ILogger>().SingleInstance();
            builder.Register(c => new CouchBaseCacheClient(c.Resolve<ILogger>(),
                ConfigurationManager.AppSettings["couchbase:bucket"],
                ConfigurationManager.AppSettings["couchbase:username"],
                ConfigurationManager.AppSettings["couchbase:password"],
                ConfigurationManager.AppSettings["couchbase:uri"],
                ConfigurationManager.AppSettings["couchbase:connectionTimeout"],
                ConfigurationManager.AppSettings["couchbase:deadTimeout"])).As<ICacheProvider>().SingleInstance();

            builder.RegisterInstance(Bec.TargetFramework.Security.Configuration.MembershipRebootConfig.Create());
            builder.RegisterType<UserAccountService>().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).InstancePerRequest();

            builder.RegisterProxyClients("Bec.TargetFramework.Business.Client",
               ConfigurationManager.AppSettings["BusinessServiceBaseURL"]);

            builder.RegisterType<MessagesNotificationsController>().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).InstancePerLifetimeScope();
        }
    }
}