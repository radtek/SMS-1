using Bec.TargetFramework.Data.Infrastructure.EfRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Data.Infrastructure
{
    internal interface IProvider
    {
        DbContext DbContext { get; set; }

        IRepository<T, TKey> GetGenericRepository<T, TKey>()
             where T : class, new();

        ICompoundKeyRepository<T, TKey, TKey1> GetGenericRepository<T, TKey, TKey1>()
             where T : class, new();

        T GetCustomRepository<T>() where T : class;

    }

    internal class Provider : IProvider
    {
        private readonly Factory _factory;
        protected Dictionary<Type, object> Repositories { get; private set; }
        public DbContext DbContext { get; set; }

        public Provider()
        {
            _factory = new Factory();
            Repositories = new Dictionary<Type, object>();
        }

        protected virtual IRepository<T,TKey> MakeRepository<T,TKey>(
            Func<DbContext, object> factory, DbContext dbContext) where T : class, new()
        {
            var f = factory ?? _factory.GetRepositoryFactory<T,TKey>();
            if (f == null) throw new NotSupportedException(typeof(EfRepository<T,TKey>).FullName);
            var repo = (EfRepository<T,TKey>)f(dbContext);
            Repositories[typeof(EfRepository<T,TKey>)] = repo;
            return repo;
        }

        protected virtual ICompoundKeyRepository<T,TKey,TKey1> MakeRepository<T,TKey,TKey1>(
            Func<DbContext, object> factory, DbContext dbContext) where T : class, new()
        {
            var f = factory ?? _factory.GetRepositoryFactory<T,TKey,TKey1>();
            if (f == null) throw new NotSupportedException(typeof(EfRepository<T,TKey,TKey1>).FullName);
            var repo = (EfRepository<T,TKey,TKey1>)f(dbContext);
            Repositories[typeof(EfRepository<T,TKey,TKey1>)] = repo;
            return repo;
        }

        protected virtual T MakeRepository<T>(
            Func<DbContext, object> factory, DbContext dbContext)
        {
            var f = factory ?? _factory.GetRepositoryFactory<T>();
            if (f == null) throw new NotSupportedException(typeof(T).FullName);
            var repo = (T)f(dbContext);
            Repositories[typeof(T)] = repo;
            return repo;
        }

        public virtual IRepository<T, TKey> GetCustomRepository<T,TKey>(Func<DbContext, object> factory = null)
            where T : class, new()
        {
            object repoObj;
            Repositories.TryGetValue(typeof(IRepository<T, TKey>), out repoObj);
            if (repoObj != null) { return (IRepository<T, TKey>)repoObj; }
            return MakeRepository<T, TKey>(factory, DbContext);
        }

        public virtual T GetCustomRepository<T>(Func<DbContext, object> factory = null)
            where T : class
        {
            object repoObj;
            Repositories.TryGetValue(typeof(T), out repoObj);
            if (repoObj != null) { return (T)repoObj; }
            return MakeRepository<T>(factory, DbContext);
        }

        public virtual ICompoundKeyRepository<T, TKey, TKey1> GetCustomRepository<T, TKey, TKey1>(Func<DbContext, object> factory = null)
            where T : class, new()
        {
            object repoObj;
            Repositories.TryGetValue(typeof(ICompoundKeyRepository<T, TKey, TKey1>), out repoObj);
            if (repoObj != null) { return (ICompoundKeyRepository<T, TKey, TKey1>)repoObj; }
            return MakeRepository<T, TKey, TKey1>(factory, DbContext);
        }

        public IRepository<T, TKey> GetGenericRepository<T, TKey>() where T : class, new()
        {
            return GetCustomRepository<T, TKey>(
                _factory.GetRepositoryFactoryForEntityType<T,TKey>());
        }

        public T GetCustomRepository<T>() where T : class
        {
            return GetCustomRepository<T>(
                _factory.GetRepositoryFactoryForCustomType<T>());
        }

        public ICompoundKeyRepository<T, TKey, TKey1> GetGenericRepository<T, TKey, TKey1>() where T : class, new()
        {
            return GetCustomRepository<T, TKey, TKey1>(
                _factory.GetRepositoryFactoryForEntityType<T, TKey, TKey1>());
        }

        public void SetRepository<T>(T repository)
        {
            Repositories[typeof(T)] = repository;
        }

    }

    internal class Factory
    {
        private readonly IDictionary<Type, Func<DbContext, object>> _factories;

        public Factory() 
        {
            _factories = new Dictionary<Type, Func<DbContext, object>>();
        }

        public Factory(IDictionary<Type, Func<DbContext, object>> factories)
        {
            _factories = factories;
        }

        public Func<DbContext, object> GetRepositoryFactory<T>()
        {
            Func<DbContext, object> factory;
            _factories.TryGetValue(typeof(T), out factory);
            return factory;
        }

        protected virtual Func<DbContext, object> DefaultEntityRepositoryFactory<T,TKey>()
             where T : class, new()
        {
            return dbContext => new EfRepository<T,TKey>(dbContext);
        }

        protected virtual Func<DbContext, object> DefaultEntityRepositoryFactory<T, TKey, TKey1>()
            where T : class, new()
        {
            return dbContext => new EfRepository<T, TKey, TKey1>(dbContext);
        }

        public Func<DbContext, object> GetRepositoryFactory<T, TKey>() where T : class, new()
        {
            Func<DbContext, object> factory;
            _factories.TryGetValue(typeof(EfRepository<T,TKey>), out factory);
            return factory;
        }

        public Func<DbContext, object> GetRepositoryFactory<T, TKey, TKey1>() where T : class, new()
        {
            Func<DbContext, object> factory;
            _factories.TryGetValue(typeof(EfRepository<T,TKey,TKey1>), out factory);
            return factory;
        }

        public Func<DbContext, object> GetRepositoryFactoryForEntityType<T, TKey>()
             where T : class, new()
 
        {
            return GetRepositoryFactory<T, TKey>() ?? DefaultEntityRepositoryFactory<T, TKey>();
        }

        public Func<DbContext, object> GetRepositoryFactoryForEntityType<T, TKey,TKey1>()
              where T : class, new()
        {
            return GetRepositoryFactory<T, TKey, TKey1>() ?? DefaultEntityRepositoryFactory<T, TKey, TKey1>();
        }

        public Func<DbContext, object> GetRepositoryFactoryForCustomType<T>()
              where T : class
        {
            return GetRepositoryFactory<T>() ?? DefaultRepositoryForCustomType<T>();
        }

        protected virtual Func<DbContext, object> DefaultRepositoryForCustomType<T>()
             where T : class
        {
            return dbContext => Activator.CreateInstance(typeof(T), new object[] { dbContext });
        }
    }
}
