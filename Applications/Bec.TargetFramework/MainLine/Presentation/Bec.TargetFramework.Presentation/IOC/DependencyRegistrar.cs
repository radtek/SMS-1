using System.Net;
using System.ServiceModel.Description;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Serilog;
using Bec.TargetFramework.UI.Web.WCF;
using Enyim.Caching.Configuration;
using Seq;
using Serilog.Extras.Web;

namespace BEC.TargetFramework.Presentation.IOC
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
    using Bec.TargetFramework.Framework.Configuration;
    using Bec.TargetFramework.Framework.Infrastructure.DependencyManagement;
    using Bec.TargetFramework.Framework.Infrastructure;
    using Bec.TargetFramework.Infrastructure.Caching;
    using System.ServiceModel;
    using Autofac.Integration.Wcf;
    using Bec.TargetFramework.Business.Infrastructure.Interfaces;
    using System.Configuration;
    using Bec.TargetFramework.UI.Web.Base;


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

            // register settings service and all ISettings 
            RegisterService<ISettingLogic>(builder, BuildBaseUrlForServices("SettingLogicService"));
            builder.Register(c => new SettingService(c.Resolve<ISettingLogic>())).As<SettingService>();

            var type = typeof(ISettings);
            AppDomain.CurrentDomain.GetAssemblies().Where(it => it.FullName.StartsWith("Bec.TargetFramework"))
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface)
                .ToList().ForEach(item =>
                {
                    builder.Register(c => c.Resolve<SettingService>().GetType().GetMethod("LoadSetting").MakeGenericMethod(item).Invoke(c.Resolve<SettingService>(), new object[1] { 0 })).As(item);
                });

            RegisterService<IDataLogic>(builder, BuildBaseUrlForServices("DataLogicService"));
            RegisterService<IValidationLogic>(builder, BuildBaseUrlForServices("ValidationLogicService"));
            RegisterService<IAddressLogic>(builder, BuildBaseUrlForServices("AddressLogicService"));
            RegisterService<IUserLogic>(builder, BuildBaseUrlForServices("UserLogicService"));
            RegisterService<IUserAccountAuditLogic>(builder, BuildBaseUrlForServices("UserAccountAuditLogicService"));
            RegisterService<IStateLogic>(builder, BuildBaseUrlForServices("StateLogicService"));
            RegisterService<IRoleLogic>(builder, BuildBaseUrlForServices("RoleLogicService"));
            RegisterService<IResourceLogic>(builder, BuildBaseUrlForServices("ResourceLogicService"));
            RegisterService<IOrganisationUserStateTemplateLogic>(builder, BuildBaseUrlForServices("OrganisationUserStateTemplateLogicService"));
            RegisterService<IOperationLogic>(builder, BuildBaseUrlForServices("OperationLogicService"));
            RegisterService<IGroupLogic>(builder,BuildBaseUrlForServices("GroupLogicService"));
            RegisterService<IClassificationDataLogic>(builder, BuildBaseUrlForServices("ClassificationDataLogicService"));
            RegisterService<IOrganisationLogic>(builder,BuildBaseUrlForServices("OrganisationLogicService"));
            RegisterService<IWorkflowProcessService>(builder, this.BuildBaseUrlForWorkflowServices("WorkflowProcessService"));
            //RegisterService<INotificationDataService>(builder, BuildBaseUrlForNotificationServices("NotificationDataService"));
            RegisterService<IBusLogic>(builder, BuildBaseUrlForServices("BusLogicService"));
            RegisterService<IProductLogic>(builder, BuildBaseUrlForServices("ProductLogicService"));
            RegisterService<IShoppingCartLogic>(builder, BuildBaseUrlForServices("ShoppingCartLogicService"));
            RegisterService<ITransactionOrderLogic>(builder, BuildBaseUrlForServices("TransactionOrderLogicService"));
            RegisterService<IPaymentLogic>(builder, BuildBaseUrlForServices("PaymentLogicService"));
            RegisterService<INotificationLogic>(builder, BuildBaseUrlForServices("NotificationLogicService"));
            RegisterService<ITaskLogic>(builder, BuildBaseUrlForServices("TaskLogicService"));
            RegisterService<IInvoiceLogic>(builder, BuildBaseUrlForServices("InvoiceLogicService"));

            //builder.Register(c => new FieldDetailsAndValidationsContainerDTO(c.Resolve<IDataLogic>().LoadUIDetails())).SingleInstance();
        }

        private string BuildBaseUrlForNotificationServices(string serviceName)
        {
            string baseUrl = ConfigurationManager.AppSettings["NotificationServiceBaseURL"];

            return baseUrl + serviceName;
        }

        private string BuildBaseUrlForServices(string serviceName)
        {
            string baseUrl = ConfigurationManager.AppSettings["BusinessServiceBaseURL"];

            return baseUrl + serviceName;
        }

        private string BuildBaseUrlForWorkflowServices(string serviceName)
        {
            string baseUrl = ConfigurationManager.AppSettings["WorkflowServiceBaseURL"];

            return baseUrl + serviceName;
        }

        private void RegisterService<T>(ContainerBuilder builder, string url)
        {
            var channelFactory = new ChannelFactory<T>(
                Bec.TargetFramework.Infrastructure.WCF.NetTcpBindingConfiguration.GetDefaultNetTcpBinding(),
                new EndpointAddress(url));

            channelFactory.Endpoint.Behaviors.Add(new EndpointBehavior());

            builder.Register(c => channelFactory)
                 .SingleInstance();

            builder.Register(c => c.Resolve<ChannelFactory<T>>().CreateChannel())
              .UseWcfSafeRelease();
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