using Autofac;
using Autofac.Integration.WebApi;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.CouchBaseCache;
using Bec.TargetFramework.Infrastructure.IOC;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Infrastructure.Serilog;
using BrockAllen.MembershipReboot;
using BrockAllen.MembershipReboot.WebHost;
using Mehdime.Entity;
using nClam;
using NServiceBus;
using System.Configuration;
using System.Linq;

namespace Bec.TargetFramework.Hosts.BusinessService.IOC
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder)
        {
            builder.Register(c => new ClamClient(
                ConfigurationManager.AppSettings["ClamAVServer"],
                int.Parse(ConfigurationManager.AppSettings["ClamAVServerPort"])));

            builder.RegisterType<SamAuthenticationService>().As<AuthenticationService>();
            builder.Register(c => new SerilogLogger(true, false, "BusinessService")).As<ILogger>().SingleInstance();
            builder.Register(c => new CouchBaseCacheClient(c.Resolve<ILogger>(),
                ConfigurationManager.AppSettings["couchbase:bucket"],
                ConfigurationManager.AppSettings["couchbase:username"],
                ConfigurationManager.AppSettings["couchbase:password"],
                ConfigurationManager.AppSettings["couchbase:uri"],
                ConfigurationManager.AppSettings["couchbase:connectionTimeout"],
                ConfigurationManager.AppSettings["couchbase:deadTimeout"])).As<ICacheProvider>().SingleInstance();

            builder.RegisterInstance(Bec.TargetFramework.Security.Configuration.MembershipRebootConfig.Create());
            builder.RegisterType<UserAccountService>().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).InstancePerRequest();

            builder.RegisterProxyClients("Bec.TargetFramework.SB.Client",
                ConfigurationManager.AppSettings["SBServiceBaseURL"]);

            var assembly = AllAssemblies.Matching("Bec.TargetFrameWork.Business").First();
            builder.RegisterApiControllers(assembly).AsSelf().AsImplementedInterfaces().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).InstancePerRequest();

            builder.RegisterType<UserNameService>().InstancePerRequest();

            builder.RegisterType<DbContextScopeFactory>().As<IDbContextScopeFactory>();

            // project dependencies
            new Business.IOC.DependencyRegistrar().Register(builder);
        }
    }
}