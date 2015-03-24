using Bec.TargetFramework.Infrastructure.Serilog;

namespace Bec.TargetFramework.Analysis.Test.IOC
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
            builder.Register(c => new CouchBaseCacheClient()).As<ICacheProvider>().SingleInstance();
            
            // register all logic classes
            var logicClasses = Assembly.Load("Bec.TargetFramework.Analysis");
            builder.RegisterAssemblyTypes(logicClasses);


            builder.Register(c => new MortgageApplicationLogic(c.Resolve<ILogger>(), c.Resolve<ICacheProvider>())).As<IMortgageApplicationLogic>();
        }

        public int Order
        {
            get { return 2; }
        }
    }
}