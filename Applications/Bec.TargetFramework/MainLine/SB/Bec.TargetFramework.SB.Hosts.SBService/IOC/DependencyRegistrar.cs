﻿using Autofac;
using Autofac.Integration.WebApi;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.CouchBaseCache;
using Bec.TargetFramework.Infrastructure.IOC;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Infrastructure.Serilog;
using Mehdime.Entity;
using System.Configuration;
using System.Reflection;

namespace Bec.TargetFramework.SB.Hosts.SBService.IOC
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
            // register logger
            builder.Register(c => new SerilogLogger(true, false, "TaskService")).As<ILogger>().SingleInstance();
            builder.Register(c => new CouchBaseCacheClient(c.Resolve<ILogger>(),
                ConfigurationManager.AppSettings["couchbase:bucket"],
                ConfigurationManager.AppSettings["couchbase:username"],
                ConfigurationManager.AppSettings["couchbase:password"],
                ConfigurationManager.AppSettings["couchbase:uri"],
                ConfigurationManager.AppSettings["couchbase:connectionTimeout"],
                ConfigurationManager.AppSettings["couchbase:deadTimeout"])).As<ICacheProvider>().SingleInstance();

            builder.RegisterProxyClients("Bec.TargetFramework.Business.Client",
               ConfigurationManager.AppSettings["BusinessServiceBaseURL"]);

            builder.RegisterProxyClients("Bec.TargetFramework.SB.Client",
                ConfigurationManager.AppSettings["SBServiceBaseURL"]);

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly()).PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);

            builder.RegisterType<DbContextScopeFactory>().As<IDbContextScopeFactory>();
        }
    }
}