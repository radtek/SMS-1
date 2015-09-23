using Autofac;
using Bec.TargetFramework.Infrastructure.IOC;
using Mehdime.Entity;

namespace Bec.TargetFramework.TestsService.IOC
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public virtual void Register(ContainerBuilder builder)
        {
            builder.RegisterType<DbContextScopeFactory>().As<IDbContextScopeFactory>();
        }
    }
}