using System;
using System.Collections.Generic;
using System.Data.Entity;
using Bec.TargetFramework.Data.Infrastructure.EfRepository;

namespace Bec.TargetFramework.Data.Infrastructure
{
    internal class Provider : IProvider
    {
        private readonly Factory _factory;

        protected Dictionary<Type, object> Repositories { get; private set; }

        public DbContext DbContext { get; set; }

        public Provider()
        {
            this._factory = new Factory();
            this.Repositories = new Dictionary<Type, object>();
        }

        protected virtual IRepository<T, TKey> MakeRepository<T, TKey>(
            Func<DbContext, object> factory, DbContext dbContext) where T : class, new()
        {
            var f = factory ?? this._factory.GetRepositoryFactory<T, TKey>();
            if (f == null)
            {
                throw new NotSupportedException(typeof(EfRepository<T, TKey>).FullName);
            }
            var repo = (EfRepository<T, TKey>)f(dbContext);
            this.Repositories[typeof(EfRepository<T, TKey>)] = repo;
            return repo;
        }

        protected virtual ICompoundKeyRepository<T, TKey, TKey1> MakeRepository<T, TKey, TKey1>(
            Func<DbContext, object> factory, DbContext dbContext) where T : class, new()
        {
            var f = factory ?? this._factory.GetRepositoryFactory<T, TKey, TKey1>();
            if (f == null)
            {
                throw new NotSupportedException(typeof(EfRepository<T, TKey, TKey1>).FullName);
            }
            var repo = (EfRepository<T, TKey, TKey1>)f(dbContext);
            this.Repositories[typeof(EfRepository<T, TKey, TKey1>)] = repo;
            return repo;
        }

        protected virtual T MakeRepository<T>(
            Func<DbContext, object> factory, DbContext dbContext)
        {
            var f = factory ?? this._factory.GetRepositoryFactory<T>();
            if (f == null)
            {
                throw new NotSupportedException(typeof(T).FullName);
            }
            var repo = (T)f(dbContext);
            this.Repositories[typeof(T)] = repo;
            return repo;
        }

        public virtual IRepository<T, TKey> GetCustomRepository<T, TKey>(Func<DbContext, object> factory = null)
            where T : class, new()
        {
            object repoObj;
            this.Repositories.TryGetValue(typeof(IRepository<T, TKey>), out repoObj);
            if (repoObj != null)
            {
                return (IRepository<T, TKey>)repoObj;
            }
            return this.MakeRepository<T, TKey>(factory, DbContext);
        }

        public virtual T GetCustomRepository<T>(Func<DbContext, object> factory = null)
            where T : class
        {
            object repoObj;
            this.Repositories.TryGetValue(typeof(T), out repoObj);
            if (repoObj != null)
            {
                return (T)repoObj;
            }
            return this.MakeRepository<T>(factory, DbContext);
        }

        public virtual ICompoundKeyRepository<T, TKey, TKey1> GetCustomRepository<T, TKey, TKey1>(Func<DbContext, object> factory = null)
            where T : class, new()
        {
            object repoObj;
            this.Repositories.TryGetValue(typeof(ICompoundKeyRepository<T, TKey, TKey1>), out repoObj);
            if (repoObj != null)
            {
                return (ICompoundKeyRepository<T, TKey, TKey1>)repoObj;
            }
            return this.MakeRepository<T, TKey, TKey1>(factory, DbContext);
        }

        public IRepository<T, TKey> GetGenericRepository<T, TKey>() where T : class, new()
        {
            return this.GetCustomRepository<T, TKey>(
                _factory.GetRepositoryFactoryForEntityType<T, TKey>());
        }

        public T GetCustomRepository<T>() where T : class
        {
            return this.GetCustomRepository<T>(
                _factory.GetRepositoryFactoryForCustomType<T>());
        }

        public ICompoundKeyRepository<T, TKey, TKey1> GetGenericRepository<T, TKey, TKey1>() where T : class, new()
        {
            return this.GetCustomRepository<T, TKey, TKey1>(
                _factory.GetRepositoryFactoryForEntityType<T, TKey, TKey1>());
        }

        public void SetRepository<T>(T repository)
        {
            this.Repositories[typeof(T)] = repository;
        }
    }
}