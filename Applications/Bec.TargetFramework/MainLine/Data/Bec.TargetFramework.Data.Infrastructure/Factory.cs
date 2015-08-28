using System;
using System.Collections.Generic;
using System.Data.Entity;
using Bec.TargetFramework.Data.Infrastructure.EfRepository;

namespace Bec.TargetFramework.Data.Infrastructure
{
    internal class Factory
    {
        private readonly IDictionary<Type, Func<DbContext, object>> _factories;

        public Factory() 
        {
            this._factories = new Dictionary<Type, Func<DbContext, object>>();
        }

        public Factory(IDictionary<Type, Func<DbContext, object>> factories)
        {
            this._factories = factories;
        }

        public Func<DbContext, object> GetRepositoryFactory<T>()
        {
            Func<DbContext, object> factory;
            this._factories.TryGetValue(typeof(T), out factory);
            return factory;
        }

        protected virtual Func<DbContext, object> DefaultEntityRepositoryFactory<T, TKey>()
            where T : class, new()
        {
            return dbContext => new EfRepository<T, TKey>(dbContext);
        }

        protected virtual Func<DbContext, object> DefaultEntityRepositoryFactory<T, TKey, TKey1>()
            where T : class, new()
        {
            return dbContext => new EfRepository<T, TKey, TKey1>(dbContext);
        }

        public Func<DbContext, object> GetRepositoryFactory<T, TKey>() where T : class, new()
        {
            Func<DbContext, object> factory;
            this._factories.TryGetValue(typeof(EfRepository<T, TKey>), out factory);
            return factory;
        }

        public Func<DbContext, object> GetRepositoryFactory<T, TKey, TKey1>() where T : class, new()
        {
            Func<DbContext, object> factory;
            this._factories.TryGetValue(typeof(EfRepository<T, TKey, TKey1>), out factory);
            return factory;
        }

        public Func<DbContext, object> GetRepositoryFactoryForEntityType<T, TKey>()
            where T : class, new()
        {
            return this.GetRepositoryFactory<T, TKey>() ?? this.DefaultEntityRepositoryFactory<T, TKey>();
        }

        public Func<DbContext, object> GetRepositoryFactoryForEntityType<T, TKey, TKey1>()
            where T : class, new()
        {
            return this.GetRepositoryFactory<T, TKey, TKey1>() ?? this.DefaultEntityRepositoryFactory<T, TKey, TKey1>();
        }

        public Func<DbContext, object> GetRepositoryFactoryForCustomType<T>()
            where T : class
        {
            return this.GetRepositoryFactory<T>() ?? this.DefaultRepositoryForCustomType<T>();
        }

        protected virtual Func<DbContext, object> DefaultRepositoryForCustomType<T>()
            where T : class
        {
            return dbContext => Activator.CreateInstance(typeof(T), new object[] { dbContext });
        }
    }
}