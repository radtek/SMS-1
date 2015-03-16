using System;

namespace Bec.TargetFramework.Data.Infrastructure.Ioc
{
    public interface IRepositoryIocContainer
    {
        T GetInstance<T>();
        object GetInstance(Type type);
    }
}