using Autofac;
using Bec.TargetFramework.Infrastructure.IOC;

namespace Bec.TargetFramework.Business.IOC
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder)
        {
            new TargetFramework.Infrastructure.Reporting.IOC.DependencyRegistrar().Register(builder);
        }
    }
}