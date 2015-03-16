using Autofac.Integration.Wcf;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Serilog;
using Bec.TargetFramework.SB.Infrastructure;
using Seq;
using Bec.TargetFramework.Business.Services;

namespace Bec.TargetFramework.Hosts.WorkflowService.IOC
{
    using System;
    using System.Linq;
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
    using Bec.TargetFramework.Framework.Configuration;
    using Bec.TargetFramework.Framework.Infrastructure.DependencyManagement;
    using Bec.TargetFramework.Framework.Infrastructure;
    using Bec.TargetFramework.Infrastructure.Caching;
    using System.ServiceModel;
    using Bec.TargetFramework.Business.Infrastructure;
    using Bec.TargetFramework.Business.Infrastructure.Interfaces;
    using Bec.TargetFramework.Workflow.Scheduler;
    using Bec.TargetFramework.Workflow.Providers;
    using Bec.TargetFramework.Workflow.Base;
    using Bec.TargetFramework.Workflow.Engine;
    using Bec.TargetFramework.Workflow.Logic;
    using Bec.TargetFramework.Workflow.Interfaces;
    using Bec.TargetFramework.Service.Configuration;
    using Bec.TargetFramework.Hosts.WorkflowService.Services;
    using NServiceBus;
    using NServiceBus.Installation.Environments;
    using Bec.TargetFramework.Infrastructure.Helpers;
    using Bec.TargetFramework.Infrastructure.CouchBaseCache;
    using Bec.TargetFramework.Business.Logic;
    using System.Configuration;

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
            builder.Register(c => new SerilogLogger(true, false, "WorkflowService")).As<ILogger>().SingleInstance();
            builder.Register(c => new CouchBaseCacheClient(c.Resolve<ILogger>())).As<ICacheProvider>().SingleInstance();

            // register settings
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

            builder.Register(c => new SettingService(c.Resolve<ISettingLogic>())).As<SettingService>();

            // register scheduler
            builder.RegisterType<WorkflowTaskScheduler>().As<WorkflowTaskScheduler>().SingleInstance();

            // register db providers
            builder.RegisterType<DbWorkflowProvider>().As<DbWorkflowProvider>().SingleInstance();
            builder.RegisterType<DbWorkflowTemplateProvider>().As<DbWorkflowTemplateProvider>().SingleInstance();
            builder.RegisterType<DbWorkflowInstanceProvider>().As<DbWorkflowInstanceProvider>().SingleInstance();

            // register container
            builder.RegisterType<WorkflowContainerBase>().As<IWorkflowContainer>().SingleInstance();

            builder.RegisterType<WorkflowEngine>().As<WorkflowEngine>().SingleInstance();

            builder.RegisterType<WorkflowInstanceLogic>().As<WorkflowInstanceLogic>().SingleInstance();
            //builder.RegisterType<ClassificationDataLogic>().As<IClassificationDataLogic>().SingleInstance();
            builder.RegisterInstance(new UserAccountService(Bec.TargetFramework.Security.Configuration.MembershipRebootConfig.Create(), new DefaultUserAccountRepository())).As<UserAccountService>();


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
            RegisterService<ITaskLogic>(builder, BuildBaseUrlForServices("TaskLogicService"));
            RegisterService<IDataLogic>(builder, BuildBaseUrlForServices("DataLogicService"));
            RegisterService<IWorkflowProcessService>(builder, this.BuildBaseUrlForWorkflowServices("WorkflowProcessService"));

            builder.RegisterAssemblyTypes(Assembly.Load("Bec.TargetFramework.Workflow"));
        }
        private string BuildBaseUrlForWorkflowServices(string serviceName)
        {
            string baseUrl = ConfigurationManager.AppSettings["WorkflowServiceBaseURL"];

            return baseUrl + serviceName;
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