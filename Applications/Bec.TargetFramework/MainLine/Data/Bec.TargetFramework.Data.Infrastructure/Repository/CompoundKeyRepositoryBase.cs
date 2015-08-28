using System;
using System.Collections;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Bec.TargetFramework.Data.Infrastructure.Caching;
using Bec.TargetFramework.Data.Infrastructure.Helpers;
using Bec.TargetFramework.Data.Infrastructure.Queries;
using Bec.TargetFramework.Data.Infrastructure.Specifications;
using Bec.TargetFramework.Data.Infrastructure.Transactions;
using Bec.TargetFramework.Infrastructure.Log;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Bec.TargetFramework.Data.Infrastructure
{
    public abstract partial class CompoundKeyRepositoryBase<T> : ICompoundKeyRepository<T> where T : class
    {
        // the caching strategy used
        private ICompoundKeyCachingStrategy<T> _cachingStrategy;

        // the query manager uses the caching strategy to determine if it should check the cache or run the query
        private CompoundKeyQueryManager<T> _queryManager;

        // just the type name, used to find the primary key if it is [TypeName]Id
        private readonly string _typeName;
        protected string TypeName
        {
            get { return _typeName; }
        }

        public bool CacheUsed
        {
            get { return _queryManager.CacheUsed; }
        }

        public IBatch<T> BeginBatch()
        {
            // Return the privately scoped batch via the publicly available interface. 
            // This ensures that a repository alone can initiate a new batch.
            return new Batch(this);
        }

        private bool BatchMode { get; set; }

        protected CompoundKeyRepositoryBase(ICompoundKeyCachingStrategy<T> cachingStrategy = null)
        {
            CachingStrategy = cachingStrategy ?? new NoCompoundKeyCachingStrategy<T>();
            _typeName = typeof(T).Name;
        }

        public ICompoundKeyCachingStrategy<T> CachingStrategy
        {
            get { return _cachingStrategy; }
            set
            {
                _cachingStrategy = value ?? new NoCompoundKeyCachingStrategy<T>();
                _queryManager = new CompoundKeyQueryManager<T>(_cachingStrategy);
            }
        }

        public abstract IQueryable<T> AsQueryable();

        // These are the actual implementation that the derived class needs to implement
        protected abstract IQueryable<T> GetAllQuery();
        protected abstract IQueryable<T> GetAllQuery(IQueryOptions<T> queryOptions);

        public IEnumerable<T> GetAll()
        {
            return GetAll(null);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await GetAllAsync(null);
        }

        public IEnumerable<T> GetAll(IQueryOptions<T> queryOptions)
        {
            return _queryManager.ExecuteGetAll(
                () => GetAllQuery(queryOptions).ToList(),
                null,
                queryOptions
                );
        }

        public async Task<IEnumerable<T>> GetAllAsync(IQueryOptions<T> queryOptions)
        {
            return await GetAllQuery(queryOptions).ToListAsync();
        }

        public IEnumerable<TResult> GetAll<TResult>(Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions = null)
        {
            if (selector == null) throw new ArgumentNullException("selector");

            return _queryManager.ExecuteGetAll(
                () => GetAllQuery(queryOptions).Select(selector).ToList(),
                selector,
                queryOptions
                );
        }

        public async Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions = null)
        {
            if (selector == null) throw new ArgumentNullException("selector");

            return await GetAllQuery(queryOptions).Select(selector).ToListAsync();
        }

        public abstract IRepositoryQueryable<TResult> Join<TJoinKey, TInner, TResult>(IRepositoryQueryable<TInner> innerRepository, Expression<Func<T, TJoinKey>> outerKeySelector, Expression<Func<TInner, TJoinKey>> innerKeySelector, Expression<Func<T, TInner, TResult>> resultSelector)
            where TInner : class
            where TResult : class;

        // These are the actual implementation that the derived class needs to implement
        protected abstract T GetQuery(params object[] keys);
        protected abstract Task<T> GetQueryAsync(params object[] keys);

        public T Get(params object[] keys)
        {
            return _queryManager.ExecuteGet(
                () => GetQuery(keys),
                null,
                keys
                );
        }

        public async Task<T> GetAsync(params object[] keys)
        {
            return await GetQueryAsync(keys);
        }

        public TResult Get<TResult>(Expression<Func<T, TResult>> selector, params object[] keys)
        {
            if (selector == null) throw new ArgumentNullException("selector");

            return _queryManager.ExecuteGet(
                () =>
                {
                    var result = GetQuery(keys);
                    if (result == null)
                        return default(TResult);

                    var results = new[] { result };
                    return results.AsQueryable().Select(selector).First();
                },
                selector,
                keys
                );
        }

        public async Task<TResult> GetAsync<TResult>(Expression<Func<T, TResult>> selector, params object[] keys)
        {
            if (selector == null) throw new ArgumentNullException("selector");

            var result = await GetQueryAsync(keys);

            return result == null ? default(TResult) : new[] { result }.AsQueryable().Select(selector).First();
        }

        public bool Exists(params object[] keys)
        {
            T entity;
            return TryGet(out entity, keys);
        }

        public async Task<bool> ExistsAsync(params object[] keys)
        {
            return await TryGetAsync(keys);
        }

        public bool TryGet(out T entity, params object[] keys)
        {
            entity = default(T);

            try
            {
                entity = Get(keys);
                return entity != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> TryGetAsync(params object[] keys)
        {
            object entity = null;

            try
            {
                entity = await GetAsync(keys);
                return entity != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        // These are the actual implementation that the derived class needs to implement
        protected abstract IQueryable<T> FindAllQuery(ISpecification<T> criteria);
        protected abstract IQueryable<T> FindAllQuery(ISpecification<T> criteria, IQueryOptions<T> queryOptions);

        public IEnumerable<T> FindAll(ISpecification<T> criteria, IQueryOptions<T> queryOptions = null)
        {
            if (criteria == null) throw new ArgumentNullException("criteria");

            return _queryManager.ExecuteFindAll(
                () => FindAllQuery(criteria, queryOptions).ToList(),
                criteria,
                null,
                queryOptions
                );
        }

        public async Task<IEnumerable<T>> FindAllAsync(ISpecification<T> criteria, IQueryOptions<T> queryOptions = null)
        {
            if (criteria == null) return await GetAllAsync(queryOptions);

            return await FindAllQuery(criteria, queryOptions).ToListAsync();
        }

        public IEnumerable<TResult> FindAll<TResult>(ISpecification<T> criteria, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions = null)
        {
            if (criteria == null) throw new ArgumentNullException("criteria");

            return _queryManager.ExecuteFindAll(
                () => FindAllQuery(criteria, queryOptions).Select(selector).ToList(),
                criteria,
                selector,
                queryOptions
                );
        }

        public async Task<IEnumerable<TResult>> FindAllAsync<TResult>(ISpecification<T> criteria, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions = null)
        {
            if (criteria == null) return await GetAllAsync(selector, queryOptions);

            return await FindAllQuery(criteria, queryOptions).Select(selector).ToListAsync();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate, IQueryOptions<T> queryOptions = null)
        {
            if (predicate == null) throw new ArgumentNullException("predicate");

            return FindAll(new Specification<T>(predicate), queryOptions);
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate, IQueryOptions<T> queryOptions = null)
        {
            if (predicate == null) return await GetAllAsync(queryOptions);

            return await FindAllAsync(new Specification<T>(predicate), queryOptions);
        }

        public IEnumerable<TResult> FindAll<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions = null)
        {
            if (predicate == null) throw new ArgumentNullException("predicate");
            if (selector == null) throw new ArgumentNullException("selector");

            return FindAll(new Specification<T>(predicate), selector, queryOptions);
        }

        public async Task<IEnumerable<TResult>> FindAllAsync<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions = null)
        {
            if (selector == null) throw new ArgumentNullException("selector");
            if (predicate == null) return await GetAllAsync(selector, queryOptions);

            return await FindAllAsync(new Specification<T>(predicate), selector, queryOptions);
        }

        // These are the actual implementation that the derived class needs to implement
        protected abstract T FindQuery(ISpecification<T> criteria);
        protected abstract T FindQuery(ISpecification<T> criteria, IQueryOptions<T> queryOptions);
        protected abstract Task<T> FindQueryAsync(ISpecification<T> criteria);
        protected abstract Task<T> FindQueryAsync(ISpecification<T> criteria, IQueryOptions<T> queryOptions);

        public T Find(ISpecification<T> criteria, IQueryOptions<T> queryOptions = null)
        {
            if (criteria == null) throw new ArgumentNullException("criteria");

            return _queryManager.ExecuteFind(
                () => FindQuery(criteria, queryOptions),
                criteria,
                null,
                null
                );
        }

        public async Task<T> FindAsync(ISpecification<T> criteria, IQueryOptions<T> queryOptions = null)
        {
            if (criteria == null) throw new ArgumentNullException("criteria");

            return await FindQueryAsync(criteria, queryOptions);
        }

        public TResult Find<TResult>(ISpecification<T> criteria, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions = null)
        {
            if (criteria == null) throw new ArgumentNullException("criteria");
            if (selector == null) throw new ArgumentNullException("selector");

            return _queryManager.ExecuteFind(
                () =>
                {
                    var result = FindQuery(criteria, queryOptions);
                    if (result == null)
                        return default(TResult);

                    var results = new[] { result };
                    return results.AsQueryable().Select(selector).First();
                },
                criteria,
                selector,
                null
                );
        }

        public async Task<TResult> FindAsync<TResult>(ISpecification<T> criteria, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions = null)
        {
            if (criteria == null) throw new ArgumentNullException("criteria");
            if (selector == null) throw new ArgumentNullException("selector");

            var result = await FindQueryAsync(criteria, queryOptions);
            if (result == null)
                return default(TResult);

            var results = new[] { result };
            return results.AsQueryable().Select(selector).First();
        }

        public bool Exists(ISpecification<T> criteria)
        {
            T entity;
            return TryFind(criteria, out entity);
        }

        public async Task<bool> ExistsAsync(ISpecification<T> criteria)
        {
            return await TryFindAsync(criteria);
        }

        public bool TryFind(ISpecification<T> criteria, out T entity)
        {
            return TryFind(criteria, (IQueryOptions<T>)null, out entity);
        }

        public async Task<bool> TryFindAsync(ISpecification<T> criteria)
        {
            return await TryFindAsync(criteria, (IQueryOptions<T>)null);
        }

        public bool TryFind(ISpecification<T> criteria, IQueryOptions<T> queryOptions, out T entity)
        {
            entity = null;

            try
            {
                entity = Find(criteria, queryOptions);
                return entity != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> TryFindAsync(ISpecification<T> criteria, IQueryOptions<T> queryOptions)
        {
            object entity = null;

            try
            {
                entity = await FindAsync(criteria, queryOptions);
                return entity != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool TryFind<TResult>(ISpecification<T> criteria, Expression<Func<T, TResult>> selector, out TResult entity)
        {
            return TryFind(criteria, selector, null, out entity);
        }

        public async Task<bool> TryFindAsync<TResult>(ISpecification<T> criteria, Expression<Func<T, TResult>> selector)
        {
            return await TryFindAsync(criteria, selector, null);
        }

        public bool TryFind<TResult>(ISpecification<T> criteria, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions, out TResult entity)
        {
            entity = default(TResult);

            try
            {
                entity = Find(criteria, selector, queryOptions);
                return !entity.Equals(default(TResult));
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> TryFindAsync<TResult>(ISpecification<T> criteria, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions)
        {
            object entity = null;

            try
            {
                entity = await FindAsync(criteria, selector, queryOptions);
                return (entity != null);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public T Find(Expression<Func<T, bool>> predicate, IQueryOptions<T> queryOptions = null)
        {
            if (predicate == null) throw new ArgumentNullException("predicate");

            return Find(new Specification<T>(predicate), queryOptions);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate, IQueryOptions<T> queryOptions = null)
        {
            if (predicate == null) throw new ArgumentNullException("predicate");

            return await FindAsync(new Specification<T>(predicate), queryOptions);
        }

        public TResult Find<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions = null)
        {
            if (predicate == null) throw new ArgumentNullException("predicate");
            if (selector == null) throw new ArgumentNullException("selector");

            return Find(new Specification<T>(predicate), selector, queryOptions);
        }

        public async Task<TResult> FindAsync<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions = null)
        {
            if (predicate == null) throw new ArgumentNullException("predicate");
            if (selector == null) throw new ArgumentNullException("selector");

            return await FindAsync(new Specification<T>(predicate), selector, queryOptions);
        }

        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            T entity;
            return TryFind(predicate, out entity);
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
          
            return await TryFindAsync(predicate);
        }

        public bool TryFind(Expression<Func<T, bool>> predicate, out T entity)
        {
            return TryFind(predicate, (IQueryOptions<T>)null, out entity);
        }

        public async Task<bool> TryFindAsync(Expression<Func<T, bool>> predicate)
        {
            return await TryFindAsync(predicate, (IQueryOptions<T>)null);
        }

        public bool TryFind(Expression<Func<T, bool>> predicate, IQueryOptions<T> queryOptions, out T entity)
        {
            entity = null;

            try
            {
                entity = Find(predicate, queryOptions);
                return entity != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> TryFindAsync(Expression<Func<T, bool>> predicate, IQueryOptions<T> queryOptions)
        {
            object entity = null;

            try
            {
                entity = await FindAsync(predicate, queryOptions);
                return (entity != null);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool TryFind<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, out TResult entity)
        {
            return TryFind(predicate, selector, null, out entity);
        }

        public async Task<bool> TryFindAsync<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector)
        {
            return await TryFindAsync(predicate, selector, null);
        }

        public bool TryFind<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions, out TResult entity)
        {
            entity = default(TResult);

            try
            {
                entity = Find(predicate, selector, queryOptions);
                return !entity.Equals(default(TResult));
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> TryFindAsync<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions)
        {
            object entity = null;
            try
            {
                entity = await FindAsync(predicate, selector, queryOptions);
                return (entity != null);
            }
            catch (Exception)
            {
                return false;
            }
        }

        // This is the actual implementation that the derived class needs to implement
        protected abstract void AddItem(T entity);

        public void Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            ProcessAdd(entity, BatchMode);
        }

        // used from the Add method above and the Save below for the batch save
        private void ProcessAdd(T entity, bool batchMode)
        {
            AddItem(entity);
            if (batchMode) return;

            Save();

            object[] keys;
            if (GetPrimaryKeys(entity, out keys))
                _queryManager.OnItemAdded(keys, entity);
        }

        public void Add(IEnumerable<T> entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");

            foreach (var entity in entities)
            {
                Add(entity);
            }
        }

        // This is the actual implementation that the derived class needs to implement
        protected abstract void DeleteItem(T entity);

        public void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            ProcessDelete(entity, BatchMode);
        }

        // used from the Delete method above and the Save below for the batch save
        private void ProcessDelete(T entity, bool batchMode)
        {
            DeleteItem(entity);
            if (batchMode) return;

            Save();

            object[] keys;
            if (GetPrimaryKeys(entity, out keys))
                _queryManager.OnItemDeleted(keys, entity);
        }

        public void Delete(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Delete(entity);
            }
        }

        public void Delete(params object[] keys)
        {
            var entity = Get(keys);

            if (entity == null) throw new ArgumentException("No entity exists with these keys.", "keys");

            Delete(entity);
        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {
            Delete(new Specification<T>(predicate));
        }

        public void Delete(ISpecification<T> criteria)
        {
            Delete(FindAll(criteria));
        }

        // This is the actual implementation that the derived class needs to implement
        protected abstract void UpdateItem(T entity);

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            ProcessUpdate(entity, BatchMode);
        }

        // used from the Update method above and the Save below for the batch save
        private void ProcessUpdate(T entity, bool batchMode)
        {
            UpdateItem(entity);
            if (batchMode) return;

            Save();

            object[] keys;
            if (GetPrimaryKeys(entity, out keys))
                _queryManager.OnItemUpdated(keys, entity);
        }

        public void Update(IEnumerable<T> entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");

            foreach (var entity in entities)
            {
                Update(entity);
            }
        }

        protected abstract void SaveChanges();
        protected abstract Task SaveChangesAsync();

        private void Save()
        {
            SaveChanges();

            _queryManager.OnSaveExecuted();
        }

        private async Task SaveAsync()
        {
            await SaveChangesAsync();

            _queryManager.OnSaveExecuted();
        }


        public abstract void Dispose();

        protected virtual bool GetPrimaryKeys(T entity, out object[] keys)
        {
            keys = null;
            var propInfo = GetPrimaryKeyPropertyInfo();

            // if there is no property that matches then return false
            if (propInfo == null)
                return false;

            keys = propInfo.Select(info => info.GetValue(entity, null)).ToArray();

            return true;
        }

        protected virtual bool SetPrimaryKey(T entity, object[] keys)
        {
            var propInfo = GetPrimaryKeyPropertyInfo();

            // if there is no property that matches then return false
            if (propInfo == null || keys == null || propInfo.Length != keys.Length)
                return false;

            var i = 0;
            foreach (var key in keys)
            {
                propInfo[i].SetValue(entity, key, null);
                i++;
            }

            return true;
        }

        protected virtual ISpecification<T> ByPrimaryKeySpecification(object[] keys)
        {
            var propInfo = GetPrimaryKeyPropertyInfo();
            if (propInfo == null || keys == null || propInfo.Length != keys.Length)
                return null;

            ISpecification<T> specification = null;
            var parameter = Expression.Parameter(typeof(T), "x");

            var i = 0;
            foreach (var lambda in keys.Select(key => Expression.Lambda<Func<T, bool>>(
                        Expression.Equal(
                            Expression.PropertyOrField(parameter, propInfo[i].Name),
                            Expression.Constant(key)
                        ),
                        parameter
                    ))
                )
            {
                specification = specification == null ? new Specification<T>(lambda) : specification.And(lambda);
                i++;
            }

            return specification;
        }

        protected PropertyInfo[] GetPrimaryKeyPropertyInfo()
        {
            var type = typeof(T);

            return type.GetProperties().Where(x => x.HasAttribute<RepositoryPrimaryKeyAttribute>()).OrderBy(x => x.GetOneAttribute<RepositoryPrimaryKeyAttribute>().Order).ToArray();
        }

        private List<EntityError> m_EntityErrors = new List<EntityError>();

        public List<EntityError> EntityErrors
        {
            get { return m_EntityErrors; }
            set { m_EntityErrors = value; }
        }

        public bool HasEntityErrors
        {
            get
            {
                if (m_EntityErrors == null)
                    return false;

                return (m_EntityErrors.Count > 0);
            }
        }

        private ILogger m_Logger;

        public ILogger Logger
        {
            get { return m_Logger; }
            set { m_Logger = value; }
        }

        public bool IsInScope
        {
            get { return m_IsInScope; }
            set { m_IsInScope = value; }
        }

        private bool m_IsInScope = false;

        public bool TurnOffTracking
        {
            get { return m_TurnOffTracking; }
            set { m_TurnOffTracking = value; }
        }

        private bool m_TurnOffTracking = false;
    }

    public abstract partial class CompoundKeyRepositoryBase<T, TKey, TKey2> : ICompoundKeyRepository<T, TKey, TKey2> where T : class
    {
        // the caching strategy used
        private ICompoundKeyCachingStrategy<T, TKey, TKey2> _cachingStrategy;

        // the query manager uses the caching strategy to determine if it should check the cache or run the query
        private CompoundKeyQueryManager<T, TKey, TKey2> _queryManager;

        // just the type name, used to find the primary key if it is [TypeName]Id
        private readonly string _typeName;
        protected string TypeName
        {
            get { return _typeName; }
        }

        public bool CacheUsed
        {
            get { return _queryManager.CacheUsed; }
        }

        public IBatch<T> BeginBatch()
        {
            // Return the privately scoped batch via the publicly available interface. 
            // This ensures that a repository alone can initiate a new batch.
            return new Batch(this);
        }

        private bool BatchMode { get; set; }

        protected CompoundKeyRepositoryBase(ICompoundKeyCachingStrategy<T, TKey, TKey2> cachingStrategy = null)
        {
            if (typeof(T) == typeof(TKey))
            {
                // this check is mainly because of the overloaded Delete methods Delete(T) and Delete(TKey), ambiguous reference if the generics are the same
                throw new InvalidOperationException("The repository type and the primary key type can not be the same.");
            }

            CachingStrategy = cachingStrategy ?? new NoCachingStrategy<T, TKey, TKey2>();
            _typeName = typeof(T).Name;
        }

        public ICompoundKeyCachingStrategy<T, TKey, TKey2> CachingStrategy
        {
            get { return _cachingStrategy; }
            set
            {
                _cachingStrategy = value ?? new NoCachingStrategy<T, TKey, TKey2>();
                _queryManager = new CompoundKeyQueryManager<T, TKey, TKey2>(_cachingStrategy);
            }
        }

        public abstract IQueryable<T> AsQueryable();

        // These are the actual implementation that the derived class needs to implement
        protected abstract IQueryable<T> GetAllQuery();
        protected abstract IQueryable<T> GetAllQuery(IQueryOptions<T> queryOptions);

        public IEnumerable<T> GetAll()
        {
            return GetAll(null);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await GetAllAsync(null);
        }

        public IEnumerable<T> GetAll(IQueryOptions<T> queryOptions)
        {
            return _queryManager.ExecuteGetAll(
                () => GetAllQuery(queryOptions).ToList(),
                null,
                queryOptions
                );
        }

        public async Task<IEnumerable<T>> GetAllAsync(IQueryOptions<T> queryOptions)
        {
            return await GetAllQuery(queryOptions).ToListAsync();
        }

        public IEnumerable<TResult> GetAll<TResult>(Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions = null)
        {
            if (selector == null) throw new ArgumentNullException("selector");

            return _queryManager.ExecuteGetAll(
                () => GetAllQuery(queryOptions).Select(selector).ToList(),
                selector,
                queryOptions
                );
        }

        public async Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions = null)
        {
            if (selector == null) throw new ArgumentNullException("selector");

            return await GetAllQuery(queryOptions).Select(selector).ToListAsync();
        }

        // These are the actual implementation that the derived class needs to implement
        protected abstract T GetQuery(TKey key, TKey2 key2);
        protected abstract Task<T> GetQueryAsync(TKey key, TKey2 key2);

        public abstract IRepositoryQueryable<TResult> Join<TJoinKey, TInner, TResult>(IRepositoryQueryable<TInner> innerRepository, Expression<Func<T, TJoinKey>> outerKeySelector, Expression<Func<TInner, TJoinKey>> innerKeySelector, Expression<Func<T, TInner, TResult>> resultSelector)
            where TInner : class
            where TResult : class;

        public T Get(TKey key, TKey2 key2)
        {
            return _queryManager.ExecuteGet(
                () => GetQuery(key, key2),
                null,
                key,
                key2
                );
        }

        public async Task<T> GetAsync(TKey key, TKey2 key2)
        {
            return await GetQueryAsync(key, key2);
        }

        public TResult Get<TResult>(TKey key, TKey2 key2, Expression<Func<T, TResult>> selector)
        {
            if (selector == null) throw new ArgumentNullException("selector");

            return _queryManager.ExecuteGet(
                () =>
                {
                    var result = GetQuery(key, key2);
                    if (result == null)
                        return default(TResult);

                    var results = new[] { result };
                    return results.AsQueryable().Select(selector).First();
                },
                selector,
                key,
                key2
                );
        }

        public async Task<TResult> GetAsync<TResult>(TKey key, TKey2 key2, Expression<Func<T, TResult>> selector)
        {
            if (selector == null) throw new ArgumentNullException("selector");

            var result = await GetQueryAsync(key, key2);

            if (result == null)
                return default(TResult);

            var results = new[] { result };
            return results.AsQueryable().Select(selector).First();
        }

        public bool Exists(TKey key, TKey2 key2)
        {
            T entity;
            return TryGet(key, key2, out entity);
        }

        public async Task<bool> ExistsAsync(TKey key, TKey2 key2)
        {
            
            return await TryGetAsync(key, key2);
        }

        public bool TryGet(TKey key, TKey2 key2, out T entity)
        {
            entity = default(T);

            try
            {
                entity = Get(key, key2);
                return entity != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> TryGetAsync(TKey key, TKey2 key2)
        {
            object entity = null;

            try
            {
                entity = await GetAsync(key, key2);
                return entity != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool TryGet<TResult>(TKey key, TKey2 key2, Expression<Func<T, TResult>> selector, out TResult entity)
        {
            entity = default(TResult);

            try
            {
                entity = Get(key, key2, selector);
                return !entity.Equals(default(TResult));
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> TryGetAsync<TResult>(TKey key, TKey2 key2, Expression<Func<T, TResult>> selector)
        {
            object entity = null;

            try
            {
                entity = await GetAsync(key, key2, selector);
                return !entity.Equals(default(TResult));
            }
            catch (Exception)
            {
                return false;
            }
        }

        // These are the actual implementation that the derived class needs to implement
        protected abstract IQueryable<T> FindAllQuery(ISpecification<T> criteria);
        protected abstract IQueryable<T> FindAllQuery(ISpecification<T> criteria, IQueryOptions<T> queryOptions);

        public IEnumerable<T> FindAll(ISpecification<T> criteria, IQueryOptions<T> queryOptions = null)
        {
            if (criteria == null) throw new ArgumentNullException("criteria");

            return _queryManager.ExecuteFindAll(
                () => FindAllQuery(criteria, queryOptions).ToList(),
                criteria,
                null,
                queryOptions
                );
        }

        public async Task<IEnumerable<T>> FindAllAsync(ISpecification<T> criteria, IQueryOptions<T> queryOptions = null)
        {
            if (criteria == null) return await GetAllAsync(queryOptions);

            return await FindAllQuery(criteria, queryOptions).ToListAsync();
        }

        public IEnumerable<TResult> FindAll<TResult>(ISpecification<T> criteria, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions = null)
        {
            if (criteria == null) throw new ArgumentNullException("criteria");

            return _queryManager.ExecuteFindAll(
                () => FindAllQuery(criteria, queryOptions).Select(selector).ToList(),
                criteria,
                selector,
                queryOptions
                );
        }

        public async Task<IEnumerable<TResult>> FindAllAsync<TResult>(ISpecification<T> criteria, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions = null)
        {
            if (criteria == null) return await GetAllAsync(selector, queryOptions);

            return await FindAllQuery(criteria, queryOptions).Select(selector).ToListAsync();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate, IQueryOptions<T> queryOptions = null)
        {
            if (predicate == null) throw new ArgumentNullException("predicate");

            return FindAll(new Specification<T>(predicate), queryOptions);
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate, IQueryOptions<T> queryOptions = null)
        {
            if (predicate == null) return await GetAllAsync(queryOptions);

            return await FindAllAsync(new Specification<T>(predicate), queryOptions);
        }

        public IEnumerable<TResult> FindAll<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions = null)
        {
            if (predicate == null) throw new ArgumentNullException("predicate");
            if (selector == null) throw new ArgumentNullException("selector");

            return FindAll(new Specification<T>(predicate), selector, queryOptions);
        }

        public async Task<IEnumerable<TResult>> FindAllAsync<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions = null)
        {
            if (selector == null) throw new ArgumentNullException("selector");
            if (predicate == null) return await GetAllAsync(selector, queryOptions);

            return await FindAllAsync(new Specification<T>(predicate), selector, queryOptions);
        }

        // These are the actual implementation that the derived class needs to implement
        protected abstract T FindQuery(ISpecification<T> criteria);
        protected abstract T FindQuery(ISpecification<T> criteria, IQueryOptions<T> queryOptions);
        protected abstract Task<T> FindQueryAsync(ISpecification<T> criteria);
        protected abstract Task<T> FindQueryAsync(ISpecification<T> criteria, IQueryOptions<T> queryOptions);

        public T Find(ISpecification<T> criteria, IQueryOptions<T> queryOptions = null)
        {
            if (criteria == null) throw new ArgumentNullException("criteria");

            return _queryManager.ExecuteFind(
                () => FindQuery(criteria, queryOptions),
                criteria,
                null,
                null
                );
        }

        public async Task<T> FindAsync(ISpecification<T> criteria, IQueryOptions<T> queryOptions = null)
        {
            if (criteria == null) throw new ArgumentNullException("criteria");

            return await FindQueryAsync(criteria, queryOptions);
        }

        public TResult Find<TResult>(ISpecification<T> criteria, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions = null)
        {
            if (criteria == null) throw new ArgumentNullException("criteria");
            if (selector == null) throw new ArgumentNullException("selector");

            return _queryManager.ExecuteFind(
                () =>
                {
                    var result = FindQuery(criteria, queryOptions);
                    if (result == null)
                        return default(TResult);

                    var results = new[] { result };
                    return results.AsQueryable().Select(selector).First();
                },
                criteria,
                selector,
                null
                );
        }

        public async Task<TResult> FindAsync<TResult>(ISpecification<T> criteria, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions = null)
        {
            if (criteria == null) throw new ArgumentNullException("criteria");
            if (selector == null) throw new ArgumentNullException("selector");

            var result = await FindQueryAsync(criteria, queryOptions);
            if (result == null)
                return default(TResult);

            var results = new[] { result };
            return results.AsQueryable().Select(selector).First();
        }

        public bool Exists(ISpecification<T> criteria)
        {
            T entity;
            return TryFind(criteria, out entity);
        }


        public async Task<bool> ExistsAsync(ISpecification<T> criteria)
        {
          
            return await TryFindAsync(criteria);
        }

        public bool TryFind(ISpecification<T> criteria, out T entity)
        {
            return TryFind(criteria, (IQueryOptions<T>)null, out entity);
        }

        public async Task<bool> TryFindAsync(ISpecification<T> criteria)
        {
            return await TryFindAsync(criteria, (IQueryOptions<T>)null);
        }

        public bool TryFind(ISpecification<T> criteria, IQueryOptions<T> queryOptions, out T entity)
        {
            entity = null;

            try
            {
                entity = Find(criteria, queryOptions);
                return entity != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> TryFindAsync(ISpecification<T> criteria, IQueryOptions<T> queryOptions)
        {
            object entity = null;

            try
            {
                entity = await FindAsync(criteria, queryOptions);
                return entity != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool TryFind<TResult>(ISpecification<T> criteria, Expression<Func<T, TResult>> selector, out TResult entity)
        {
            return TryFind(criteria, selector, null, out entity);
        }

        public async Task<bool> TryFindAsync<TResult>(ISpecification<T> criteria, Expression<Func<T, TResult>> selector)
        {
            return await TryFindAsync(criteria, selector, null);
        }

        public bool TryFind<TResult>(ISpecification<T> criteria, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions, out TResult entity)
        {
            entity = default(TResult);

            try
            {
                entity = Find(criteria, selector, queryOptions);
                return !entity.Equals(default(TResult));
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> TryFindAsync<TResult>(ISpecification<T> criteria, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions)
        {
            object entity = null;

            try
            {
                entity = await FindAsync(criteria, selector, queryOptions);
                return (entity != null);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public T Find(Expression<Func<T, bool>> predicate, IQueryOptions<T> queryOptions = null)
        {
            if (predicate == null) throw new ArgumentNullException("predicate");

            return Find(new Specification<T>(predicate), queryOptions);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate, IQueryOptions<T> queryOptions = null)
        {
            if (predicate == null) throw new ArgumentNullException("predicate");

            return await FindAsync(new Specification<T>(predicate), queryOptions);
        }

        public TResult Find<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions = null)
        {
            if (predicate == null) throw new ArgumentNullException("predicate");
            if (selector == null) throw new ArgumentNullException("selector");

            return Find(new Specification<T>(predicate), selector, queryOptions);
        }

        public async Task<TResult> FindAsync<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions = null)
        {
            if (predicate == null) throw new ArgumentNullException("predicate");
            if (selector == null) throw new ArgumentNullException("selector");

            return await FindAsync(new Specification<T>(predicate), selector, queryOptions);
        }

        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            T entity;
            return TryFind(predicate, out entity);
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
            
            return await TryFindAsync(predicate);
        }

        public bool TryFind(Expression<Func<T, bool>> predicate, out T entity)
        {
            return TryFind(predicate, (IQueryOptions<T>)null, out entity);
        }

        public async Task<bool> TryFindAsync(Expression<Func<T, bool>> predicate)
        {
            return await TryFindAsync(predicate, (IQueryOptions<T>)null);
        }

        public bool TryFind(Expression<Func<T, bool>> predicate, IQueryOptions<T> queryOptions, out T entity)
        {
            entity = null;

            try
            {
                entity = Find(predicate, queryOptions);
                return entity != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> TryFindAsync(Expression<Func<T, bool>> predicate, IQueryOptions<T> queryOptions)
        {
            object entity = null;

            try
            {
                entity = await FindAsync(predicate, queryOptions);
                return (entity != null);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool TryFind<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, out TResult entity)
        {
            return TryFind(predicate, selector, null, out entity);
        }

        public async Task<bool> TryFindAsync<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector)
        {
            return await TryFindAsync(predicate, selector, null);
        }

        public bool TryFind<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions, out TResult entity)
        {
            entity = default(TResult);

            try
            {
                entity = Find(predicate, selector, queryOptions);
                return !entity.Equals(default(TResult));
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> TryFindAsync<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions)
        {
            object entity = null;
            try
            {
                entity = await FindAsync(predicate, selector, queryOptions);
                return (entity != null);
            }
            catch (Exception)
            {
                return false;
            }
        }

        // This is the actual implementation that the derived class needs to implement
        protected abstract void AddItem(T entity);

        public void Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            ProcessAdd(entity, BatchMode);
        }

        // used from the Add method above and the Save below for the batch save
        private void ProcessAdd(T entity, bool batchMode)
        {
            AddItem(entity);
            if (batchMode) return;

            if (!IsInScope)
                Save();

            TKey key;
            TKey2 key2;
            if (GetPrimaryKey(entity, out key, out key2))
                _queryManager.OnItemAdded(key, key2, entity);
        }

        public void Add(IEnumerable<T> entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");

            foreach (var entity in entities)
            {
                Add(entity);
            }
        }

        // This is the actual implementation that the derived class needs to implement
        protected abstract void DeleteItem(T entity);

        public void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            ProcessDelete(entity, BatchMode);
        }

        // used from the Delete method above and the Save below for the batch save
        private void ProcessDelete(T entity, bool batchMode)
        {
            DeleteItem(entity);
            if (batchMode) return;

            if (!IsInScope)
                Save();

            TKey key;
            TKey2 key2;
            if (GetPrimaryKey(entity, out key, out key2))
                _queryManager.OnItemDeleted(key, key2, entity);
        }

        public void Delete(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Delete(entity);
            }
        }

        public void Delete(TKey key, TKey2 key2)
        {
            var entity = Get(key, key2);

            if (entity == null) throw new ArgumentException("No entity exists with this key.", "key");

            Delete(entity);
        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {
            Delete(new Specification<T>(predicate));
        }

        public void Delete(ISpecification<T> criteria)
        {
            Delete(FindAll(criteria));
        }

        // This is the actual implementation that the derived class needs to implement
        protected abstract void UpdateItem(T entity);

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            ProcessUpdate(entity, BatchMode);
        }

        // used from the Update method above and the Save below for the batch save
        private void ProcessUpdate(T entity, bool batchMode)
        {
            UpdateItem(entity);
            if (batchMode) return;

            if (!IsInScope)
                Save();

            TKey key;
            TKey2 key2;
            if (GetPrimaryKey(entity, out key, out key2))
                _queryManager.OnItemUpdated(key, key2, entity);
        }

        public void Update(IEnumerable<T> entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");

            foreach (var entity in entities)
            {
                Update(entity);
            }
        }

        protected abstract void SaveChanges();

        protected abstract Task SaveChangesAsync();

        private void Save()
        {
            SaveChanges();

            _queryManager.OnSaveExecuted();
        }

        private async Task SaveAsync()
        {
            await SaveChangesAsync();

            _queryManager.OnSaveExecuted();
        }


        public abstract void Dispose();

        protected virtual bool GetPrimaryKey(T entity, out TKey key, out TKey2 key2)
        {
            key = default(TKey);
            key2 = default(TKey2);

            var propInfo = GetPrimaryKeyPropertyInfo();

            // if there is no property that matches then return false
            if (propInfo == null || propInfo.Length != 2)
                return false;

            key = (TKey)propInfo[0].GetValue(entity, null);
            key2 = (TKey2)propInfo[1].GetValue(entity, null);

            return true;
        }

        protected virtual bool SetPrimaryKey(T entity, TKey key, TKey2 key2)
        {
            var propInfo = GetPrimaryKeyPropertyInfo();

            // if there is no property that matches then return false
            if (propInfo == null || propInfo.Length != 2)
                return false;

            propInfo[0].SetValue(entity, key, null);
            propInfo[1].SetValue(entity, key2, null);

            return true;
        }

        protected virtual ISpecification<T> ByPrimaryKeySpecification(TKey key, TKey2 key2)
        {
            var propInfo = GetPrimaryKeyPropertyInfo();
            if (propInfo == null || propInfo.Length != 2)
                return null;

            var parameter = Expression.Parameter(typeof(T), "x");
            var lambda = Expression.Lambda<Func<T, bool>>(
                    Expression.Equal(
                        Expression.PropertyOrField(parameter, propInfo[0].Name),
                        Expression.Constant(key)
                    ),
                    parameter
                );
            var lambda2 = Expression.Lambda<Func<T, bool>>(
                    Expression.Equal(
                        Expression.PropertyOrField(parameter, propInfo[1].Name),
                        Expression.Constant(key2)
                    ),
                    parameter
                );

            return new Specification<T>(lambda).And(lambda2);
        }

        protected PropertyInfo[] GetPrimaryKeyPropertyInfo()
        {
            var type = typeof(T);

            return type.GetProperties().Where(x => x.HasAttribute<RepositoryPrimaryKeyAttribute>()).OrderBy(x => x.GetOneAttribute<RepositoryPrimaryKeyAttribute>().Order).ToArray();
        }

        private List<EntityError> m_EntityErrors = new List<EntityError>();

        public List<EntityError> EntityErrors
        {
            get { return m_EntityErrors; }
            set { m_EntityErrors = value; }
        }

        public bool HasEntityErrors
        {
            get
            {
                if (m_EntityErrors == null)
                    return false;

                return (m_EntityErrors.Count > 0);
            }
        }

        private ILogger m_Logger;

        public ILogger Logger
        {
            get { return m_Logger; }
            set { m_Logger = value; }
        }

        public bool IsInScope
        {
            get { return m_IsInScope; }
            set { m_IsInScope = value; }
        }

        private bool m_IsInScope = false;

        public bool TurnOffTracking
        {
            get { return m_TurnOffTracking; }
            set { m_TurnOffTracking = value; }
        }

        private bool m_TurnOffTracking = false;
    }

    public abstract partial class CompoundKeyRepositoryBase<T, TKey, TKey2, TKey3> : ICompoundKeyRepository<T, TKey, TKey2, TKey3> where T : class
    {
        // the caching strategy used
        private ICompoundKeyCachingStrategy<T, TKey, TKey2, TKey3> _cachingStrategy;

        // the query manager uses the caching strategy to determine if it should check the cache or run the query
        private CompoundKeyQueryManager<T, TKey, TKey2, TKey3> _queryManager;

        // just the type name, used to find the primary key if it is [TypeName]Id
        private readonly string _typeName;
        protected string TypeName
        {
            get { return _typeName; }
        }

        public bool CacheUsed
        {
            get { return _queryManager.CacheUsed; }
        }

        public IBatch<T> BeginBatch()
        {
            // Return the privately scoped batch via the publicly available interface. 
            // This ensures that a repository alone can initiate a new batch.
            return new Batch(this);
        }

        private bool BatchMode { get; set; }

        protected CompoundKeyRepositoryBase(ICompoundKeyCachingStrategy<T, TKey, TKey2, TKey3> cachingStrategy = null)
        {
            if (typeof(T) == typeof(TKey))
            {
                // this check is mainly because of the overloaded Delete methods Delete(T) and Delete(TKey), ambiguous reference if the generics are the same
                throw new InvalidOperationException("The repository type and the primary key type can not be the same.");
            }

            CachingStrategy = cachingStrategy ?? new NoCachingStrategy<T, TKey, TKey2, TKey3>();
            _typeName = typeof(T).Name;
        }

        public ICompoundKeyCachingStrategy<T, TKey, TKey2, TKey3> CachingStrategy
        {
            get { return _cachingStrategy; }
            set
            {
                _cachingStrategy = value ?? new NoCachingStrategy<T, TKey, TKey2, TKey3>();
                _queryManager = new CompoundKeyQueryManager<T, TKey, TKey2, TKey3>(_cachingStrategy);
            }
        }

        public abstract IQueryable<T> AsQueryable();

        // These are the actual implementation that the derived class needs to implement
        protected abstract IQueryable<T> GetAllQuery();
        protected abstract IQueryable<T> GetAllQuery(IQueryOptions<T> queryOptions);

        public IEnumerable<T> GetAll()
        {
            return GetAll(null);
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await GetAllAsync(null);
        }

        public IEnumerable<T> GetAll(IQueryOptions<T> queryOptions)
        {
            return _queryManager.ExecuteGetAll(
                () => GetAllQuery(queryOptions).ToList(),
                null,
                queryOptions
                );
        }


        public async Task<IEnumerable<T>> GetAllAsync(IQueryOptions<T> queryOptions)
        {
            return await GetAllQuery(queryOptions).ToListAsync();
        }

        public IEnumerable<TResult> GetAll<TResult>(Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions = null)
        {
            if (selector == null) throw new ArgumentNullException("selector");

            return _queryManager.ExecuteGetAll(
                () => GetAllQuery(queryOptions).Select(selector).ToList(),
                selector,
                queryOptions
                );
        }


        public async Task<IEnumerable<TResult>> GetAllAsync<TResult>(Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions = null)
        {
            if (selector == null) throw new ArgumentNullException("selector");

            return await GetAllQuery(queryOptions).Select(selector).ToListAsync();
        }

        // These are the actual implementation that the derived class needs to implement
        protected abstract T GetQuery(TKey key, TKey2 key2, TKey3 key3);
        protected abstract Task<T> GetQueryAsync(TKey key, TKey2 key2, TKey3 key3);

        public abstract IRepositoryQueryable<TResult> Join<TJoinKey, TInner, TResult>(IRepositoryQueryable<TInner> innerRepository, Expression<Func<T, TJoinKey>> outerKeySelector, Expression<Func<TInner, TJoinKey>> innerKeySelector, Expression<Func<T, TInner, TResult>> resultSelector)
            where TInner : class
            where TResult : class;

        public T Get(TKey key, TKey2 key2, TKey3 key3)
        {
            return _queryManager.ExecuteGet(
                () => GetQuery(key, key2, key3),
                null,
                key,
                key2,
                key3
                );
        }

        public async Task<T> GetAsync(TKey key, TKey2 key2, TKey3 key3)
        {
            return await GetQueryAsync(key, key2, key3);
        }

        public TResult Get<TResult>(TKey key, TKey2 key2, TKey3 key3, Expression<Func<T, TResult>> selector)
        {
            if (selector == null) throw new ArgumentNullException("selector");

            return _queryManager.ExecuteGet(
                () =>
                {
                    var result = GetQuery(key, key2, key3);
                    if (result == null)
                        return default(TResult);

                    var results = new[] { result };
                    return results.AsQueryable().Select(selector).First();
                },
                selector,
                key,
                key2,
                key3
                );
        }

        public async Task<TResult> GetAsync<TResult>(TKey key, TKey2 key2, TKey3 key3, Expression<Func<T, TResult>> selector)
        {
            if (selector == null) throw new ArgumentNullException("selector");

            // get the full entity, possibly from cache
            var result = await GetQueryAsync(key, key2, key3);

            // return the entity with the selector applied to it
            return result == null ? default(TResult) : new[] { result }.AsQueryable().Select(selector).First();
        }

        public bool Exists(TKey key, TKey2 key2, TKey3 key3)
        {
            T entity;
            return TryGet(key, key2, key3, out entity);
        }


        public async Task<bool> ExistsAsync(TKey key, TKey2 key2, TKey3 key3)
        {
            
            return await TryGetAsync(key, key2, key3);
        }

        public bool TryGet(TKey key, TKey2 key2, TKey3 key3, out T entity)
        {
            entity = default(T);

            try
            {
                entity = Get(key, key2, key3);
                return entity != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> TryGetAsync(TKey key, TKey2 key2, TKey3 key3)
        {
            object entity = null;

            try
            {
                entity = await GetAsync(key, key2, key3);
                return entity != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool TryGet<TResult>(TKey key, TKey2 key2, TKey3 key3, Expression<Func<T, TResult>> selector, out TResult entity)
        {
            entity = default(TResult);

            try
            {
                entity = Get(key, key2, key3, selector);
                return !entity.Equals(default(TResult));
            }
            catch (Exception)
            {
                return false;
            }
        }


        public async Task<bool> TryGetAsync<TResult>(TKey key, TKey2 key2, TKey3 key3, Expression<Func<T, TResult>> selector)
        {
            object entity = null;

            try
            {
                entity = await GetAsync(key, key2, key3, selector);
                return (entity != null);
            }
            catch (Exception)
            {
                return false;
            }
        }

        // These are the actual implementation that the derived class needs to implement
        protected abstract IQueryable<T> FindAllQuery(ISpecification<T> criteria);
        protected abstract IQueryable<T> FindAllQuery(ISpecification<T> criteria, IQueryOptions<T> queryOptions);

        public IEnumerable<T> FindAll(ISpecification<T> criteria, IQueryOptions<T> queryOptions = null)
        {
            if (criteria == null) throw new ArgumentNullException("criteria");

            return _queryManager.ExecuteFindAll(
                () => FindAllQuery(criteria, queryOptions).ToList(),
                criteria,
                null,
                queryOptions
                );
        }


        public async Task<IEnumerable<T>> FindAllAsync(ISpecification<T> criteria, IQueryOptions<T> queryOptions = null)
        {
            if (criteria == null) return await GetAllAsync(queryOptions);

            return await FindAllQuery(criteria, queryOptions).ToListAsync();
        }

        public IEnumerable<TResult> FindAll<TResult>(ISpecification<T> criteria, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions = null)
        {
            if (criteria == null) throw new ArgumentNullException("criteria");

            return _queryManager.ExecuteFindAll(
                () => FindAllQuery(criteria, queryOptions).Select(selector).ToList(),
                criteria,
                selector,
                queryOptions
                );
        }


        public async Task<IEnumerable<TResult>> FindAllAsync<TResult>(ISpecification<T> criteria, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions = null)
        {
            if (criteria == null) return await GetAllAsync(selector, queryOptions);

            return await FindAllQuery(criteria, queryOptions).Select(selector).ToListAsync();
        }

        public IEnumerable<T> FindAll(Expression<Func<T, bool>> predicate, IQueryOptions<T> queryOptions = null)
        {
            if (predicate == null) throw new ArgumentNullException("predicate");

            return FindAll(new Specification<T>(predicate), queryOptions);
        }


        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate, IQueryOptions<T> queryOptions = null)
        {
            if (predicate == null) return await GetAllAsync(queryOptions);

            return await FindAllAsync(new Specification<T>(predicate), queryOptions);
        }

        public IEnumerable<TResult> FindAll<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions = null)
        {
            if (predicate == null) throw new ArgumentNullException("predicate");
            if (selector == null) throw new ArgumentNullException("selector");

            return FindAll(new Specification<T>(predicate), selector, queryOptions);
        }


        public async Task<IEnumerable<TResult>> FindAllAsync<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions = null)
        {
            if (selector == null) throw new ArgumentNullException("selector");
            if (predicate == null) return await GetAllAsync(selector, queryOptions);

            return await FindAllAsync(new Specification<T>(predicate), selector, queryOptions);
        }

        // These are the actual implementation that the derived class needs to implement
        protected abstract T FindQuery(ISpecification<T> criteria);
        protected abstract T FindQuery(ISpecification<T> criteria, IQueryOptions<T> queryOptions);
        protected abstract Task<T> FindQueryAsync(ISpecification<T> criteria);
        protected abstract Task<T> FindQueryAsync(ISpecification<T> criteria, IQueryOptions<T> queryOptions);

        public T Find(ISpecification<T> criteria, IQueryOptions<T> queryOptions = null)
        {
            if (criteria == null) throw new ArgumentNullException("criteria");

            return _queryManager.ExecuteFind(
                () => FindQuery(criteria, queryOptions),
                criteria,
                null,
                null
                );
        }


        public async Task<T> FindAsync(ISpecification<T> criteria, IQueryOptions<T> queryOptions = null)
        {
            if (criteria == null) throw new ArgumentNullException("criteria");

            return await FindQueryAsync(criteria, queryOptions);
        }

        public TResult Find<TResult>(ISpecification<T> criteria, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions = null)
        {
            if (criteria == null) throw new ArgumentNullException("criteria");
            if (selector == null) throw new ArgumentNullException("selector");

            return _queryManager.ExecuteFind(
                () =>
                {
                    var result = FindQuery(criteria, queryOptions);
                    if (result == null)
                        return default(TResult);

                    var results = new[] { result };
                    return results.AsQueryable().Select(selector).First();
                },
                criteria,
                selector,
                null
                );
        }


        public async Task<TResult> FindAsync<TResult>(ISpecification<T> criteria, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions = null)
        {
            if (criteria == null) throw new ArgumentNullException("criteria");
            if (selector == null) throw new ArgumentNullException("selector");

            var result = await FindQueryAsync(criteria, queryOptions);
            if (result == null)
                return default(TResult);

            var results = new[] { result };
            return results.AsQueryable().Select(selector).First();
        }

        public bool Exists(ISpecification<T> criteria)
        {
            T entity;
            return TryFind(criteria, out entity);
        }
        public async Task<bool> ExistsAsync(ISpecification<T> criteria)
        {
           
            return await TryFindAsync(criteria);
        }

        public bool TryFind(ISpecification<T> criteria, out T entity)
        {
            return TryFind(criteria, (IQueryOptions<T>)null, out entity);
        }
        public async Task<bool> TryFindAsync(ISpecification<T> criteria)
        {
            return await TryFindAsync(criteria, (IQueryOptions<T>)null);
        }

        public bool TryFind(ISpecification<T> criteria, IQueryOptions<T> queryOptions, out T entity)
        {
            entity = null;

            try
            {
                entity = Find(criteria, queryOptions);
                return entity != null;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public async Task<bool> TryFindAsync(ISpecification<T> criteria, IQueryOptions<T> queryOptions)
        {
            object entity = null;

            try
            {
                entity = await FindAsync(criteria, queryOptions);
                return entity != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool TryFind<TResult>(ISpecification<T> criteria, Expression<Func<T, TResult>> selector, out TResult entity)
        {
            return TryFind(criteria, selector, null, out entity);
        }
        public async Task<bool> TryFindAsync<TResult>(ISpecification<T> criteria, Expression<Func<T, TResult>> selector)
        {
            return await TryFindAsync(criteria, selector, null);
        }

        public bool TryFind<TResult>(ISpecification<T> criteria, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions, out TResult entity)
        {
            entity = default(TResult);

            try
            {
                entity = Find(criteria, selector, queryOptions);
                return !entity.Equals(default(TResult));
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> TryFindAsync<TResult>(ISpecification<T> criteria, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions)
        {
            object entity = null;

            try
            {
                entity = await FindAsync(criteria, selector, queryOptions);
                return (entity != null);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public T Find(Expression<Func<T, bool>> predicate, IQueryOptions<T> queryOptions = null)
        {
            if (predicate == null) throw new ArgumentNullException("predicate");

            return Find(new Specification<T>(predicate), queryOptions);
        }



        public async Task<T> FindAsync(Expression<Func<T, bool>> predicate, IQueryOptions<T> queryOptions = null)
        {
            if (predicate == null) throw new ArgumentNullException("predicate");

            return await FindAsync(new Specification<T>(predicate), queryOptions);
        }

        public TResult Find<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions = null)
        {
            if (predicate == null) throw new ArgumentNullException("predicate");
            if (selector == null) throw new ArgumentNullException("selector");

            return Find(new Specification<T>(predicate), selector, queryOptions);
        }


        public async Task<TResult> FindAsync<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions = null)
        {
            if (predicate == null) throw new ArgumentNullException("predicate");
            if (selector == null) throw new ArgumentNullException("selector");

            return await FindAsync(new Specification<T>(predicate), selector, queryOptions);
        }

        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            T entity;
            return TryFind(predicate, out entity);
        }

        public async Task<bool> ExistsAsync(Expression<Func<T, bool>> predicate)
        {
           
            return await TryFindAsync(predicate);
        }

        public bool TryFind(Expression<Func<T, bool>> predicate, out T entity)
        {
            return TryFind(predicate, (IQueryOptions<T>)null, out entity);
        }

        public async Task<bool> TryFindAsync(Expression<Func<T, bool>> predicate)
        {
            return await TryFindAsync(predicate, (IQueryOptions<T>)null);
        }

        public bool TryFind(Expression<Func<T, bool>> predicate, IQueryOptions<T> queryOptions, out T entity)
        {
            entity = null;

            try
            {
                entity = Find(predicate, queryOptions);
                return entity != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> TryFindAsync(Expression<Func<T, bool>> predicate, IQueryOptions<T> queryOptions)
        {
            object entity = null;

            try
            {
                entity = await FindAsync(predicate, queryOptions);
                return (entity != null);
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool TryFind<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, out TResult entity)
        {
            return TryFind(predicate, selector, null, out entity);
        }

        public async Task<bool> TryFindAsync<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector)
        {
            return await TryFindAsync(predicate, selector, null);
        }

        public bool TryFind<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions, out TResult entity)
        {
            entity = default(TResult);

            try
            {
                entity = Find(predicate, selector, queryOptions);
                return !entity.Equals(default(TResult));
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> TryFindAsync<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions)
        {
            object entity = null;
            try
            {
                entity = await FindAsync(predicate, selector, queryOptions);
                return (entity != null);
            }
            catch (Exception)
            {
                return false;
            }
        }

        // This is the actual implementation that the derived class needs to implement
        protected abstract void AddItem(T entity);

        public void Add(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            ProcessAdd(entity, BatchMode);
        }

        // used from the Add method above and the Save below for the batch save
        private void ProcessAdd(T entity, bool batchMode)
        {
            AddItem(entity);
            if (batchMode) return;

            Save();

            TKey key;
            TKey2 key2;
            TKey3 key3;
            if (GetPrimaryKey(entity, out key, out key2, out key3))
                _queryManager.OnItemAdded(key, key2, key3, entity);
        }

        public void Add(IEnumerable<T> entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");

            foreach (var entity in entities)
            {
                Add(entity);
            }
        }

        // This is the actual implementation that the derived class needs to implement
        protected abstract void DeleteItem(T entity);

        public void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            ProcessDelete(entity, BatchMode);
        }

        // used from the Delete method above and the Save below for the batch save
        private void ProcessDelete(T entity, bool batchMode)
        {
            DeleteItem(entity);
            if (batchMode) return;

            Save();

            TKey key;
            TKey2 key2;
            TKey3 key3;
            if (GetPrimaryKey(entity, out key, out key2, out key3))
                _queryManager.OnItemDeleted(key, key2, key3, entity);
        }

        public void Delete(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Delete(entity);
            }
        }

        public void Delete(TKey key, TKey2 key2, TKey3 key3)
        {
            var entity = Get(key, key2, key3);

            if (entity == null) throw new ArgumentException("No entity exists with these keys.", "key");

            Delete(entity);
        }

        public void Delete(Expression<Func<T, bool>> predicate)
        {
            Delete(new Specification<T>(predicate));
        }

        public void Delete(ISpecification<T> criteria)
        {
            Delete(FindAll(criteria));
        }

        // This is the actual implementation that the derived class needs to implement
        protected abstract void UpdateItem(T entity);

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            ProcessUpdate(entity, BatchMode);
        }

        // used from the Update method above and the Save below for the batch save
        private void ProcessUpdate(T entity, bool batchMode)
        {
            UpdateItem(entity);
            if (batchMode) return;

            Save();

            TKey key;
            TKey2 key2;
            TKey3 key3;
            if (GetPrimaryKey(entity, out key, out key2, out key3))
                _queryManager.OnItemUpdated(key, key2, key3, entity);
        }

        public void Update(IEnumerable<T> entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");

            foreach (var entity in entities)
            {
                Update(entity);
            }
        }

        protected abstract void SaveChanges();
        protected abstract Task SaveChangesAsync();

        private void Save()
        {
            SaveChanges();

            _queryManager.OnSaveExecuted();
        }


        private async Task SaveAsync()
        {
            await SaveChangesAsync();

            _queryManager.OnSaveExecuted();
        }


        public abstract void Dispose();

        protected virtual bool GetPrimaryKey(T entity, out TKey key, out TKey2 key2, out TKey3 key3)
        {
            key = default(TKey);
            key2 = default(TKey2);
            key3 = default(TKey3);

            var propInfo = GetPrimaryKeyPropertyInfo();

            // if there is no property that matches then return false
            if (propInfo == null || propInfo.Length != 3)
                return false;

            key = (TKey)propInfo[0].GetValue(entity, null);
            key2 = (TKey2)propInfo[1].GetValue(entity, null);
            key3 = (TKey3)propInfo[2].GetValue(entity, null);

            return true;
        }

        protected virtual bool SetPrimaryKey(T entity, TKey key, TKey2 key2, TKey3 key3)
        {
            var propInfo = GetPrimaryKeyPropertyInfo();

            // if there is no property that matches then return false
            if (propInfo == null || propInfo.Length != 3)
                return false;

            propInfo[0].SetValue(entity, key, null);
            propInfo[1].SetValue(entity, key2, null);
            propInfo[2].SetValue(entity, key3, null);

            return true;
        }

        protected virtual ISpecification<T> ByPrimaryKeySpecification(TKey key, TKey2 key2, TKey3 key3)
        {
            var propInfo = GetPrimaryKeyPropertyInfo();
            if (propInfo == null || propInfo.Length != 3)
                return null;

            var parameter = Expression.Parameter(typeof(T), "x");
            var lambda = Expression.Lambda<Func<T, bool>>(
                    Expression.Equal(
                        Expression.PropertyOrField(parameter, propInfo[0].Name),
                        Expression.Constant(key)
                    ),
                    parameter
                );
            var lambda2 = Expression.Lambda<Func<T, bool>>(
                    Expression.Equal(
                        Expression.PropertyOrField(parameter, propInfo[1].Name),
                        Expression.Constant(key2)
                    ),
                    parameter
                );
            var lambda3 = Expression.Lambda<Func<T, bool>>(
                    Expression.Equal(
                        Expression.PropertyOrField(parameter, propInfo[2].Name),
                        Expression.Constant(key3)
                    ),
                    parameter
                );

            return new Specification<T>(lambda).And(lambda2).And(lambda3);
        }

        protected PropertyInfo[] GetPrimaryKeyPropertyInfo()
        {
            var type = typeof(T);

            return type.GetProperties().Where(x => x.HasAttribute<RepositoryPrimaryKeyAttribute>()).OrderBy(x => x.GetOneAttribute<RepositoryPrimaryKeyAttribute>().Order).ToArray();
        }

        private List<EntityError> m_EntityErrors = new List<EntityError>();

        public List<EntityError> EntityErrors
        {
            get { return m_EntityErrors; }
            set { m_EntityErrors = value; }
        }

        public bool HasEntityErrors
        {
            get
            {
                if (m_EntityErrors == null)
                    return false;

                return (m_EntityErrors.Count > 0);
            }
        }

        private ILogger m_Logger;

        public ILogger Logger
        {
            get { return m_Logger; }
            set { m_Logger = value; }
        }

        public bool IsInScope
        {
            get { return m_IsInScope; }
            set { m_IsInScope = value; }
        }

        private bool m_IsInScope = false;

        public bool TurnOffTracking
        {
            get { return m_TurnOffTracking; }
            set { m_TurnOffTracking = value; }
        }

        private bool m_TurnOffTracking = false;
    }
}
