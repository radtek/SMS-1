﻿
namespace Bec.TargetFramework.Data.Infrastructure.Configuration
{
    public interface IConfigRepositoryFactory
    {
        IRepository<T> GetInstance<T>() where T : class, new();
        IRepository<T, TKey> GetInstance<T, TKey>() where T : class, new();
        ICompoundKeyRepository<T, TKey, TKey2> GetInstance<T, TKey, TKey2>() where T : class, new();
    }

    public abstract class ConfigRepositoryFactory : IConfigRepositoryFactory
    {
        protected IRepositoryConfiguration RepositoryConfiguration;

        protected ConfigRepositoryFactory(IRepositoryConfiguration config)
        {
            RepositoryConfiguration = config;
        }

        public abstract IRepository<T> GetInstance<T>() where T : class, new();
        public abstract IRepository<T, TKey> GetInstance<T, TKey>() where T : class, new();
        public abstract ICompoundKeyRepository<T, TKey, TKey2> GetInstance<T, TKey, TKey2>() where T : class, new();
    }
}
