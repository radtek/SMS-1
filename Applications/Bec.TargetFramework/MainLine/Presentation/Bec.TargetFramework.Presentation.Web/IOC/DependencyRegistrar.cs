using System.Net;
using System.ServiceModel.Description;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Serilog;
using Bec.TargetFramework.Presentation.Web.WCF;
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
 
    using Bec.TargetFramework.Framework.Infrastructure.DependencyManagement;
    using Bec.TargetFramework.Framework.Infrastructure;
    using Bec.TargetFramework.Framework.Configuration;
    using Bec.TargetFramework.Service.Configuration;


    /// <summary>
    /// IOC Configuration - Loads on Startup of Web Application
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Starts the IOC Container
        /// </summary>
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
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

        }

        private string BuildBaseUrlForNotificationServices(string serviceName)
        {
            string baseUrl = ConfigurationManager.AppSettings["NotificationServiceBaseURL"];

            return baseUrl + serviceName;
        }


        private string BuildBaseUrlForWorkflowServices(string serviceName)
        {
            string baseUrl = ConfigurationManager.AppSettings["WorkflowServiceBaseURL"];

            return baseUrl + serviceName;
        }

        private void RegisterService<T>(ContainerBuilder builder, string url)
        {
            builder.Register(c => new ChannelFactory<T>(
                Bec.TargetFramework.Infrastructure.WCF.NetTcpBindingConfiguration.GetDefaultNetTcpBinding(),
                new EndpointAddress(url))).SingleInstance();

            builder.Register(c => c.Resolve<ChannelFactory<T>>().CreateChannel()).As<T>().UseWcfSafeRelease();
        }

        public int Order
        {
            get { return 2; }
        }
    }

    public class SettingsSource : IRegistrationSource
    {
        static readonly MethodInfo BuildMethod = typeof(SettingsSource).GetMethod(
            "BuildRegistration",
            BindingFlags.Static | BindingFlags.NonPublic);

        public IEnumerable<IComponentRegistration> RegistrationsFor(
                Service service,
                Func<Service, IEnumerable<IComponentRegistration>> registrations)
        {
            var ts = service as TypedService;
            if (ts != null && typeof(ISettings).IsAssignableFrom(ts.ServiceType))
            {
                var buildMethod = BuildMethod.MakeGenericMethod(ts.ServiceType);
                yield return (IComponentRegistration)buildMethod.Invoke(null, null);
            }
        }

        static IComponentRegistration BuildRegistration<TSettings>() where TSettings : ISettings, new()
        {
            return RegistrationBuilder
                .ForDelegate((c, p) =>
                {
                    //uncomment the code below if you want load settings per store only when you have two stores installed.
                    //var currentStoreId = c.Resolve<IStoreService>().GetAllStores().Count > 1
                    //    c.Resolve<IStoreContext>().CurrentStore.Id : 0;

                    //although it's better to connect to your database and execute the following SQL:
                    //DELETE FROM [Setting] WHERE [StoreId] > 0
                    return c.Resolve<ISettingService>().LoadSetting<TSettings>();
                })
                .InstancePerHttpRequest()
                .CreateRegistration();
        }

        public bool IsAdapterForIndividualComponents { get { return false; } }
    }
}