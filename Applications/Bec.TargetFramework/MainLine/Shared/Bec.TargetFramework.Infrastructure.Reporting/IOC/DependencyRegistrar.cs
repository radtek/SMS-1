using Autofac;
using Bec.TargetFramework.Infrastructure.IOC;
using Bec.TargetFramework.Infrastructure.Reporting.Generators;

namespace Bec.TargetFramework.Infrastructure.Reporting.IOC
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder)
        {
            builder.Register(c => new StandaloneReportGenerator()).As<StandaloneReportGenerator>();
        }
    }
}