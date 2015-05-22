using Autofac.Integration.Wcf;
using Bec.TargetFramework.Business.Product.Processor;
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
    using Bec.TargetFramework.Business.Services;
    using Bec.TargetFramework.Business.Infrastructure;
    using Bec.TargetFramework.Business.Infrastructure.Interfaces;
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
    using Bec.TargetFramework.SB.NotificationServices.Report;

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
                .As<ISettingLogic>();

            builder.Register(c => new SettingServiceLocal(c.Resolve<ISettingLogic>())).As<SettingServiceLocal>();

            var type = typeof(ISettings);
            AllAssemblies.Matching("Bec.TargetFramework")
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsInterface)
                .ToList().ForEach(item =>
                {
                    builder.Register(c => c.Resolve<SettingServiceLocal>().GetType().GetMethod("LoadSetting").MakeGenericMethod(item).Invoke(c.Resolve<SettingServiceLocal>(), new object[1] { 0 })).As(item);
                });

            // register all logic classes
            var logicClasses = Assembly.Load("Bec.TargetFramework.Business");
            builder.RegisterAssemblyTypes(logicClasses);

            builder.Register(c => new DataLogicService(c.Resolve<ILogger>()
                           , c.Resolve<ICacheProvider>(), c.Resolve<CommonSettings>())).As<IDataLogic>();

            builder.Register(c => new ValidationLogicService(c.Resolve<ILogger>()
                          , c.Resolve<ICacheProvider>())).As<IValidationLogic>();

            builder.Register(c => new UserLogicService(c.Resolve<UserAccountService>()
                           , c.Resolve<AuthenticationService>(), c.Resolve<IDataLogic>(), c.Resolve<ILogger>(), c.Resolve<ICacheProvider>())).As<IUserLogic>();

            builder.Register(c => new NotificationLogicService(c.Resolve<ILogger>()
                          , c.Resolve<ICacheProvider>()
                          , c.Resolve<StandaloneReportGenerator>())).As<INotificationLogic>();

            // reference first to load assemblies
            builder.Register(c => new OrganisationLogicService(c.Resolve<UserAccountService>()
                            , c.Resolve<AuthenticationService>()
                            , c.Resolve<ILogger>()
                            , c.Resolve<ICacheProvider>()
                            , c.Resolve<CommonSettings>(), 
                            c.Resolve<IUserLogic>(), 
                            c.Resolve<IDataLogic>(),
                            c.Resolve<Bec.TargetFramework.SB.Interfaces.IEventPublishClient>(),
                            c.Resolve<INotificationLogic>())).As<IOrganisationLogic>();

            builder.Register(c => new ProductLogicService( c.Resolve<ILogger>()
                            , c.Resolve<ICacheProvider>(),c.Resolve<DeductionLogic>())).As<IProductLogic>();

            builder.Register(c => new ProductPricingProcessor(c.Resolve<ILogger>(), c.Resolve<IProductLogic>()))
                .As<ProductPricingProcessor>();

            AppDomain.CurrentDomain.GetAssemblies()
                .Where(s => s.FullName.Contains("Bec.TargetFramework"))
                .SelectMany(s => s.GetTypes())
                .Where(p => !p.IsInterface && !p.Name.Contains("BusLogic") && p.Name.Contains("LogicService") && !p.Name.Contains("OrganisationLogic") && !p.Name.Contains("InvoiceLogic") && !p.Name.Contains("ProductLogic") && !p.Name.Contains("PaymentLogic") && !p.Name.Contains("ShoppingCartLogic")
                 && !p.Name.Contains("TransactionOrderLogic") && !p.Name.Contains("UserLogic") && !p.Name.Contains("NotificationLogic") && !p.Name.StartsWith("DataLogic") && !p.Name.StartsWith("ExperianIDCheckLogic"))
                .ToList().ForEach(item =>
                {
                    // check type implements interface
                    if(item.GetInterfaces().Contains(typeof(IBusinessLogicService)))
                    {
                        Type interfaceType = item.GetInterfaces().Where(it => it.Name.Contains("I" + item.Name.Replace("Service", ""))).First();

                        if (item.GetConstructors().First().GetParameters().Count() == 2)
                        {
                            builder.Register(c => Activator.CreateInstance(item, new object[] {   c.Resolve<ILogger>()
                            , c.Resolve<ICacheProvider>() })).As(new Type[] { interfaceType });
                        }
                        else
                        {
                            builder.Register(c => Activator.CreateInstance(item, new object[] {  c.Resolve<UserAccountService>()
                            , c.Resolve<AuthenticationService>()
                            , c.Resolve<ILogger>()
                            , c.Resolve<ICacheProvider>() })).As(new Type[] { interfaceType });
                        }
                    }
                });

         
            builder.Register(c => new ShoppingCartLogicService(c.Resolve<ILogger>()
                           , c.Resolve<ICacheProvider>(), c.Resolve<DeductionLogic>(), c.Resolve<IProductLogic>(), c.Resolve<ProductPricingProcessor>())).As<IShoppingCartLogic>();

            builder.Register(
             c =>
                 new InvoiceLogic(c.Resolve<ILogger>(), c.Resolve<ICacheProvider>(),
                     c.Resolve<IClassificationDataLogic>())).As<IInvoiceLogic>();


            builder.Register(c => new CartPricingProcessor(c.Resolve<ILogger>(), c.Resolve<IProductLogic>(), c.Resolve<IShoppingCartLogic>(), c.Resolve<ProductPricingProcessor>()))
    .As<CartPricingProcessor>();

            builder.Register(c => new TransactionOrderLogicService(c.Resolve<ILogger>()
                           , c.Resolve<ICacheProvider>(), c.Resolve<IShoppingCartLogic>(), c.Resolve<IProductLogic>(), c.Resolve<ProductPricingProcessor>(), c.Resolve<CartPricingProcessor>())).As<ITransactionOrderLogic>();

            builder.Register(c => new PaymentLogicService(c.Resolve<ILogger>()
                           , c.Resolve<ICacheProvider>(), c.Resolve<PaymentSettings>())).As<IPaymentLogic>();

            builder.Register(c => new ExperianIDCheckLogicService(c.Resolve<ILogger>()
                           , c.Resolve<ICacheProvider>(), c.Resolve<ExperianIDCheckSettings>())).As<IExperianIDCheckLogic>();

            builder.Register(c => new ExperianBWALogicService(c.Resolve<ILogger>()
                           , c.Resolve<ICacheProvider>(), c.Resolve<ExperianIDCheckSettings>())).As<IExperianBWALogic>();

            builder.Register(c => new StandaloneReportGenerator()).As<StandaloneReportGenerator>();

            builder.RegisterProxyClients("Bec.TargetFramework.SB.Client",
                ConfigurationManager.AppSettings["SBServiceBaseURL"]);
        }



    }

}