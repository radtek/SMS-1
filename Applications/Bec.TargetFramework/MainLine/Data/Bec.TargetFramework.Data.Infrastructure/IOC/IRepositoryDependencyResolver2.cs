using System;

namespace Bec.TargetFramework.Data.Infrastructure.Ioc
{
    public interface IRepositoryDependencyResolver
    {
        T Resolve<T>();

        object Resolve(Type type);
    }
}