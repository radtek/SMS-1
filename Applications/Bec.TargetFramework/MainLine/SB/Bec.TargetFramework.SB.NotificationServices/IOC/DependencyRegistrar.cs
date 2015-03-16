using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Serilog;
using Bec.TargetFramework.SB.Infrastructure;
using Seq;

namespace Bec.TargetFramework.SB.NotificationServices.IOC
{
    using System;
    using System.Configuration;
    using System.Linq;
    using System.Reflection;
    using System.ServiceModel;
    using System.Web.Http;
    using System.Web.Http.SelfHost;

    using Autofac.Integration.Wcf;

    using Bec.TargetFramework.Business.Infrastructure.Interfaces;
    using Bec.TargetFramework.Infrastructure.Caching;
    using Bec.TargetFramework.Infrastructure.CouchBaseCache;
    using Bec.TargetFramework.Infrastructure.Log;
    using Autofac;
    using Autofac.Core;
    using System.Collections.Generic;
    using Autofac.Builder;
    using Bec.TargetFramework.Framework.Configuration;
    using Bec.TargetFramework.Framework.Infrastructure.DependencyManagement;
    using Bec.TargetFramework.Framework.Infrastructure;
    using Bec.TargetFramework.SB.NotificationServices.Controllers;
    using Bec.TargetFramework.SB.NotificationServices.Report;
    using Bec.TargetFramework.Service.Configuration;

    using BrockAllen.MembershipReboot;
    using BrockAllen.MembershipReboot.Ef;
    using BrockAllen.MembershipReboot.WebHost;

    using NServiceBus;
    using NServiceBus.Installation.Environments;
    using Bec.TargetFramework.Infrastructure.Helpers;

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
            // register logger
            builder.RegisterType<DefaultUserAccountRepository>().As<IUserAccountRepository>();
            builder.RegisterType<SamAuthenticationService>().As<AuthenticationService>();
            builder.Register(c => new SerilogLogger(true, false, "NotificationService")).As<ILogger>().SingleInstance();
            builder.Register(c => new CouchBaseCacheClient(c.Resolve<ILogger>())).As<ICacheProvider>().SingleInstance();
            builder.RegisterInstance(new UserAccountService(Bec.TargetFramework.Security.Configuration.MembershipRebootConfig.Create(), new DefaultUserAccountRepository())).As<UserAccountService>();

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

            RegisterService<IAddressLogic>(builder, BuildBaseUrlForServices("AddressLogicService"));
            RegisterService<IUserLogic>(builder, BuildBaseUrlForServices("UserLogicService"));
            RegisterService<IUserAccountAuditLogic>(builder, BuildBaseUrlForServices("UserAccountAuditLogicService"));
            RegisterService<IStateLogic>(builder, BuildBaseUrlForServices("StateLogicService"));
            RegisterService<IRoleLogic>(builder, BuildBaseUrlForServices("RoleLogicService"));
            RegisterService<IResourceLogic>(builder, BuildBaseUrlForServices("ResourceLogicService"));
            RegisterService<IOrganisationUserStateTemplateLogic>(builder, BuildBaseUrlForServices("OrganisationUserStateTemplateLogicService"));
            RegisterService<IOperationLogic>(builder, BuildBaseUrlForServices("OperationLogicService"));
            RegisterService<IGroupLogic>(builder, BuildBaseUrlForServices("GroupLogicService"));
            RegisterService<IClassificationDataLogic>(builder, BuildBaseUrlForServices("ClassificationDataLogicService"));
            RegisterService<IOrganisationLogic>(builder, BuildBaseUrlForServices("OrganisationLogicService"));
            RegisterService<IProductLogic>(builder, BuildBaseUrlForServices("ProductLogicService"));
            RegisterService<IShoppingCartLogic>(builder, BuildBaseUrlForServices("ShoppingCartLogicService"));
            RegisterService<ITransactionOrderLogic>(builder, BuildBaseUrlForServices("TransactionOrderLogicService"));
            RegisterService<IPaymentLogic>(builder, BuildBaseUrlForServices("PaymentLogicService"));
            RegisterService<INotificationLogic>(builder, BuildBaseUrlForServices("NotificationLogicService"));
            RegisterService<IBusLogic>(builder, BuildBaseUrlForServices("BusLogicService"));
            RegisterService<IInvoiceLogic>(builder, BuildBaseUrlForServices("InvoiceLogicService"));
            RegisterService<ITaskLogic>(builder, BuildBaseUrlForServices("TaskLogicService"));
            RegisterService<IDataLogic>(builder, BuildBaseUrlForServices("DataLogicService"));


            builder.Register(c => new StandaloneReportGenerator(c.Resolve<IClassificationDataLogic>())).As<StandaloneReportGenerator>();
        }

        private string BuildBaseUrlForServices(string serviceName)
        {
            string baseUrl = ConfigurationManager.AppSettings["BusinessServiceBaseURL"];

            return baseUrl + serviceName;
        }

        private void RegisterService<T>(ContainerBuilder builder, string url)
        {
            builder.Register(c => new ChannelFactory<T>(
                 Bec.TargetFramework.Infrastructure.WCF.NetTcpBindingConfiguration.GetDefaultNetTcpBinding(),
                 new EndpointAddress(url)))
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

        public bool IsAdapterForIndividualComponents { get { return false; } }
    }
}