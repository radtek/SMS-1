using Autofac;

namespace Bec.TargetFramework.Infrastructure.IOC
{
    public interface IDependencyRegistrar
    {
        void Register(ContainerBuilder builder);
    }
}
