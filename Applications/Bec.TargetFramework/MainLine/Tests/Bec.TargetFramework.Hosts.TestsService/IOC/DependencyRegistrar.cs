using Autofac;
using Autofac.Integration.WebApi;
using Bec.TargetFramework.Infrastructure.IOC;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Infrastructure.Serilog;
using NServiceBus;
using System.Linq;

namespace Bec.TargetFramework.Hosts.TestsService.IOC
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder)
        {
            builder.Register(c => new SerilogLogger(true, false, "TestsService")).As<ILogger>().SingleInstance();
            var assembly = AllAssemblies.Matching("Bec.TargetFrameWork.TestsService").First();
            builder.RegisterApiControllers(assembly).AsSelf().AsImplementedInterfaces().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).InstancePerRequest();

            // project dependencies
            new Bec.TargetFramework.TestsService.IOC.DependencyRegistrar().Register(builder);
        }
    }
}