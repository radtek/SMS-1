using Bec.TargetFramework.Infrastructure.Serilog;

namespace Bec.TargetFramework.Hosts.AnalysisService.IOC
{
    using Autofac;
    using Bec.TargetFramework.Analysis;
    using Bec.TargetFramework.Analysis.Interfaces;
    using Bec.TargetFramework.Framework.Infrastructure;
    using Bec.TargetFramework.Framework.Infrastructure.DependencyManagement;
    using Bec.TargetFramework.Infrastructure.Caching;
    using Bec.TargetFramework.Infrastructure.CouchBaseCache;
    using Bec.TargetFramework.Infrastructure.Log;
    using System;
    using System.Linq;
    using System.Reflection;

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
            builder.Register(c => new SerilogLogger(true, false, "AnalysisService")).As<ILogger>().SingleInstance();
            builder.Register(c => new CouchBaseCacheClient(c.Resolve<ILogger>())).As<ICacheProvider>().SingleInstance();
            
            // register all logic classes
            var logicClasses = Assembly.Load("Bec.TargetFramework.Analysis");
            builder.RegisterAssemblyTypes(logicClasses);

            AppDomain.CurrentDomain.GetAssemblies()
                .Where(s => s.FullName.Contains("Bec.TargetFramework"))
                .SelectMany(s => s.GetTypes())
                .Where(p => !p.IsInterface && !p.Name.Contains("BusLogic") && p.Name.Contains("LogicService") && !p.Name.Contains("OrganisationLogic") && !p.Name.Contains("InvoiceLogic") && !p.Name.Contains("ProductLogic") && !p.Name.Contains("PaymentLogic") && !p.Name.Contains("ShoppingCartLogic")
                 && !p.Name.Contains("TransactionOrderLogic") && !p.Name.Contains("UserLogic") && !p.Name.StartsWith("DataLogic") && !p.Name.StartsWith("ExperianIDCheckLogic"))
                .ToList().ForEach(item =>
                {
                    // check type implements interface
                    if (item.GetInterfaces().Contains(typeof(IAnalysisLogicService)))
                    {
                        Type interfaceType = item.GetInterfaces().Where(it => it.Name.Contains("I" + item.Name.Replace("Service", ""))).First();

                        if (item.GetConstructors().First().GetParameters().Count() == 2)
                        {
                            builder.Register(c => Activator.CreateInstance(item, new object[] {   c.Resolve<ILogger>()
                            , c.Resolve<ICacheProvider>() })).As(new Type[] { interfaceType });
                        }
                        
                    }
                });

            builder.Register(c => new MortgageApplicationLogic(c.Resolve<ILogger>(), c.Resolve<ICacheProvider>())).As<IMortgageApplicationLogic>();
        }

        public int Order
        {
            get { return 2; }
        }
    }
}