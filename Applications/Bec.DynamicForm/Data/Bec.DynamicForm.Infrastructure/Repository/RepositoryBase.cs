using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Bec.TargetFramework.Data.Infrastructure.Caching;
using Bec.TargetFramework.Data.Infrastructure.FetchStrategies;
using Bec.TargetFramework.Data.Infrastructure.Helpers;
using Bec.TargetFramework.Data.Infrastructure.Queries;
using Bec.TargetFramework.Data.Infrastructure.Specifications;
using Bec.TargetFramework.Data.Infrastructure.Transactions;
using System.Threading.Tasks;
using System.Data.Entity;
using Bec.TargetFramework.Infrastructure.Log;

namespace Bec.TargetFramework.Data.Infrastructure
{
    public abstract partial class RepositoryBase<T, TKey> : IRepository<T, TKey> where T : class
    {
        // the caching strategy used
        private ICachingStrategy<T, TKey> _cachingStrategy;
        
        // the query manager uses the caching strategy to determine if it should check the cache or run the query
        protected QueryManager<T, TKey> QueryManager;

        private readonly Type _entityType;

        protected RepositoryBase(ICachingStrategy<T, TKey> cachingStrategy = null,ILogger logger = null)
        {
            if (typeof(T) == typeof(TKey))
            {
                // this check is mainly because of the overloaded Delete methods Delete(T) and Delete(TKey), ambiguous reference if the generics are the same
                throw new InvalidOperationException("The repository type and the primary key type can not be the same.");
            }

            Conventions = new RepositoryConventions();
            CachingStrategy = cachingStrategy ?? new NoCachingStrategy<T, TKey>(); // sets QueryManager as well
            // the CachePrefix is set to the default convention in the CachingStrategyBase class, the user to override when passing in an already created CachingStrategy class

            _entityType = typeof(T);
            _typeName = _entityType.Name;
            m_Logger = logger;
        }

        // conventions
        public IRepositoryConventions Conventions { get; set; }

        public Type EntityType
        {
            get { return typeof (T); }
        }
        
        public Type KeyType
        {
            get { return typeof(TKey); }
        }

        // just the type name, used to find the primary key if it is [TypeName]Id
        private readonly string _typeName;
        protected string TypeName
        {
            get { return _typeName; }
        }
        
        public bool CacheUsed
        {
            get { return QueryManager.CacheUsed; }
        }

        public IBatch<T> BeginBatch()
        {
            // Return the privately scoped batch via the publicly available interface. 
            // This ensures that a repository alone can initiate a new batch.
            return new Batch(this);
        }

        public IDisabledCache DisableCaching()
        {
            // Return the privately scoped batch via the publicly available interface. 
            // This ensures that a repository alone can initiate a new batch.
            return new DisabledCache(this);
        }

        public void ClearCache()
        {
            CachingStrategy.ClearAll();
        }
      
        private bool BatchMode { get; set; }

        public ICachingStrategy<T, TKey> CachingStrategy 
        {
            get { return _cachingStrategy; } 
            set
            {
                _cachingStrategy = value ?? new NoCachingStrategy<T, TKey>();

                // make sure we keep the curent caching enabled status
                var cachingEnabled = QueryManager == null || QueryManager.CacheEnabled;
                QueryManager = new QueryManager<T, TKey>(_cachingStrategy) {CacheEnabled = cachingEnabled};
            }
        } 

        public bool CachingEnabled
        {
            get { return QueryManager.CacheEnabled; }
            set { QueryManager.CacheEnabled = value; }
        }

        protected abstract IQueryable<T> BaseQuery(IFetchStrategy<T> fetchStrategy = null);

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
            return QueryManager.ExecuteGetAll(
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

            return QueryManager.ExecuteGetAll(
                () =>  GetAllQuery(queryOptions).Select(selector).ToList(),
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
        protected abstract T GetQuery(TKey key);
        protected abstract Task<T> GetQueryAsync(TKey key);

        public abstract IRepositoryQueryable<TResult> Join<TJoinKey, TInner, TResult>(IRepositoryQueryable<TInner> innerRepository, Expression<Func<T, TJoinKey>> outerKeySelector, Expression<Func<TInner, TJoinKey>> innerKeySelector, Expression<Func<T, TInner, TResult>> resultSelector)
            where TInner : class
            where TResult : class;

        public T Get(TKey key)
        {
            return QueryManager.ExecuteGet(
                () => GetQuery(key),
                key
                );
        }

        public async Task<T> GetAsync(TKey key)
        {
            return await GetQueryAsync(key);
        }

        public TResult Get<TResult>(TKey key, Expression<Func<T, TResult>> selector)
        {
            if (selector == null) throw new ArgumentNullException("selector");

            // get the full entity, possibly from cache
            var result = QueryManager.ExecuteGet(
                () => GetQuery(key),
                key
                );

            // return the entity with the selector applied to it
            return result == null ? default(TResult) : new[] { result }.AsQueryable().Select(selector).First();
        }

        public async Task<TResult> GetAsync<TResult>(TKey key, Expression<Func<T, TResult>> selector)
        {
            if (selector == null) throw new ArgumentNullException("selector");

            // get the full entity, possibly from cache
            var result = await GetQueryAsync(key);

            // return the entity with the selector applied to it
            return result == null ? default(TResult) : new[] { result }.AsQueryable().Select(selector).First();
        }

        public bool Exists(TKey key)
        {
            T entity;
            return TryGet(key, out entity);
        }

        public async Task<bool> ExistsAsync(TKey key)
        {
            T entity;
            return await TryGetAsync(key);
        }

        public bool TryGet(TKey key, out T entity)
        {
            entity = default(T);

            try
            {
                entity = Get(key);
                return entity != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> TryGetAsync(TKey key)
        {
            object entity = null;

            try
            {
                entity = await GetAsync(key);
                return entity != null;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool TryGet<TResult>(TKey key, Expression<Func<T, TResult>> selector, out TResult entity)
        {
            entity = default(TResult);

            try
            {
                entity = Get(key, selector);
                return entity.Equals(default(TResult));
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> TryGetAsync<TResult>(TKey key, Expression<Func<T, TResult>> selector)
        {
            object entity = null;

            try
            {
                entity = await GetAsync(key, selector);
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
            if (criteria == null) return GetAll(queryOptions);

            return QueryManager.ExecuteFindAll(
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
            if (criteria == null) return GetAll(selector, queryOptions);

            return QueryManager.ExecuteFindAll(
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
            if (predicate == null) return GetAll(queryOptions);

            return FindAll(new Specification<T>(predicate), queryOptions);
        }

        public async Task<IEnumerable<T>> FindAllAsync(Expression<Func<T, bool>> predicate, IQueryOptions<T> queryOptions = null)
        {
            if (predicate == null) return await GetAllAsync(queryOptions);

            return await FindAllAsync(new Specification<T>(predicate), queryOptions);
        }

        public IEnumerable<TResult> FindAll<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector, IQueryOptions<T> queryOptions = null)
        {
            if (selector == null) throw new ArgumentNullException("selector");
            if (predicate == null) return GetAll(selector, queryOptions);

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

            return QueryManager.ExecuteFind(
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

            return QueryManager.ExecuteFind(
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
            T entity;
            return await TryFindAsync(criteria);
        }

        public bool TryFind(ISpecification<T> criteria, out T entity)
        {
            return TryFind(criteria, ( IQueryOptions<T>)null, out entity);
        }

        public async Task<bool> TryFindAsync(ISpecification<T> criteria)
        {
            return await TryFindAsync(criteria, (IQueryOptions<T>) null);
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
            T entity;
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

        // TODO: allowing ordering of grouped results
        public IEnumerable<TResult> GroupBy<TGroupKey, TResult>(Expression<Func<T, TGroupKey>> keySelector, Expression<Func<IGrouping<TGroupKey, T>, TResult>> resultSelector)
        {
            return GroupBy((ISpecification<T>)null, keySelector, resultSelector);
        }

        public virtual IEnumerable<TResult> GroupBy<TGroupKey, TResult>(ISpecification<T> criteria, Expression<Func<T, TGroupKey>> keySelector, Expression<Func<IGrouping<TGroupKey, T>, TResult>> resultSelector)
        {
            return QueryManager.ExecuteGroup(
                () =>
                {
                    var query = criteria == null ? BaseQuery() : BaseQuery().Where(criteria.Predicate);

                    //                            if (queryOptions != null)
                    //                                query = queryOptions.Apply(query);

                    return query.GroupBy(keySelector).OrderBy(x => x.Key).Select(resultSelector).ToList();
                },
                keySelector,
                resultSelector,
                criteria
                );
        }

        public IEnumerable<TResult> GroupBy<TGroupKey, TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TGroupKey>> keySelector, Expression<Func<IGrouping<TGroupKey, T>, TResult>> resultSelector)
        {
            return GroupBy(predicate == null ? null : new Specification<T>(predicate), keySelector, resultSelector);
        }

        public long LongCount()
        {
            return LongCount((ISpecification<T>)null);
        }

        public virtual long LongCount(ISpecification<T> criteria)
        {
            return QueryManager.ExecuteLongCount(
                () => criteria == null ? BaseQuery().LongCount() : BaseQuery().LongCount(criteria.Predicate),
                criteria
                );
        }

        public long LongCount(Expression<Func<T, bool>> predicate)
        {
            return LongCount(predicate == null ? null : new Specification<T>(predicate));
        }

        public int Count()
        {
            return Count((ISpecification<T>)null);
        }

        public virtual int Count(ISpecification<T> criteria)
        {
            return QueryManager.ExecuteCount(
                () => criteria == null ? BaseQuery().Count() : BaseQuery().Count(criteria.Predicate),
                criteria
                );
        }

        public int Count(Expression<Func<T, bool>> predicate)
        {
            return Count(predicate == null ? null : new Specification<T>(predicate));
        }

        public int Sum(Expression<Func<T, int>> selector)
        {
            return Sum((ISpecification<T>)null, selector);
        }

        public virtual int Sum(ISpecification<T> criteria, Expression<Func<T, int>> selector)
        {
            return QueryManager.ExecuteSum(
                () => criteria == null ? BaseQuery().Sum(selector) : BaseQuery().Where(criteria.Predicate).Sum(selector),
                selector,
                criteria
                );
        }

        public int Sum(Expression<Func<T, bool>> predicate, Expression<Func<T, int>> selector)
        {
            return Sum(predicate == null ? null : new Specification<T>(predicate), selector);
        }

        public int? Sum(Expression<Func<T, int?>> selector)
        {
            return Sum((ISpecification<T>)null, selector);
        }

        public virtual int? Sum(ISpecification<T> criteria, Expression<Func<T, int?>> selector)
        {
            return QueryManager.ExecuteSum(
                () => criteria == null ? BaseQuery().Sum(selector) : BaseQuery().Where(criteria.Predicate).Sum(selector),
                selector,
                criteria
                );
        }

        public int? Sum(Expression<Func<T, bool>> predicate, Expression<Func<T, int?>> selector)
        {
            return Sum(predicate == null ? null : new Specification<T>(predicate), selector);
        }

        public long Sum(Expression<Func<T, long>> selector)
        {
            return Sum((ISpecification<T>)null, selector);
        }

        public virtual long Sum(ISpecification<T> criteria, Expression<Func<T, long>> selector)
        {
            return QueryManager.ExecuteSum(
                () => criteria == null ? BaseQuery().Sum(selector) : BaseQuery().Where(criteria.Predicate).Sum(selector),
                selector,
                criteria
                );
        }

        public long Sum(Expression<Func<T, bool>> predicate, Expression<Func<T, long>> selector)
        {
            return Sum(predicate == null ? null : new Specification<T>(predicate), selector);
        }

        public long? Sum(Expression<Func<T, long?>> selector)
        {
            return Sum((ISpecification<T>)null, selector);
        }

        public virtual long? Sum(ISpecification<T> criteria, Expression<Func<T, long?>> selector)
        {
            return QueryManager.ExecuteSum(
                () => criteria == null ? BaseQuery().Sum(selector) : BaseQuery().Where(criteria.Predicate).Sum(selector),
                selector,
                criteria
                );
        }

        public long? Sum(Expression<Func<T, bool>> predicate, Expression<Func<T, long?>> selector)
        {
            return Sum(predicate == null ? null : new Specification<T>(predicate), selector);
        }

        public decimal Sum(Expression<Func<T, decimal>> selector)
        {
            return Sum((ISpecification<T>)null, selector);
        }

        public virtual decimal Sum(ISpecification<T> criteria, Expression<Func<T, decimal>> selector)
        {
            return QueryManager.ExecuteSum(
                () => criteria == null ? BaseQuery().Sum(selector) : BaseQuery().Where(criteria.Predicate).Sum(selector),
                selector,
                criteria
                );
        }

        public decimal Sum(Expression<Func<T, bool>> predicate, Expression<Func<T, decimal>> selector)
        {
            return Sum(predicate == null ? null : new Specification<T>(predicate), selector);
        }

        public decimal? Sum(Expression<Func<T, decimal?>> selector)
        {
            return Sum((ISpecification<T>)null, selector);
        }

        public virtual decimal? Sum(ISpecification<T> criteria, Expression<Func<T, decimal?>> selector)
        {
            return QueryManager.ExecuteSum(
                () => criteria == null ? BaseQuery().Sum(selector) : BaseQuery().Where(criteria.Predicate).Sum(selector),
                selector,
                criteria
                );
        }

        public decimal? Sum(Expression<Func<T, bool>> predicate, Expression<Func<T, decimal?>> selector)
        {
            return Sum(predicate == null ? null : new Specification<T>(predicate), selector);
        }

        public double Sum(Expression<Func<T, double>> selector)
        {
            return Sum((ISpecification<T>)null, selector);
        }

        public virtual double Sum(ISpecification<T> criteria, Expression<Func<T, double>> selector)
        {
            return QueryManager.ExecuteSum(
                () => criteria == null ? BaseQuery().Sum(selector) : BaseQuery().Where(criteria.Predicate).Sum(selector),
                selector,
                criteria
                );
        }

        public double Sum(Expression<Func<T, bool>> predicate, Expression<Func<T, double>> selector)
        {
            return Sum(predicate == null ? null : new Specification<T>(predicate), selector);
        }

        public double? Sum(Expression<Func<T, double?>> selector)
        {
            return Sum((ISpecification<T>)null, selector);
        }

        public virtual double? Sum(ISpecification<T> criteria, Expression<Func<T, double?>> selector)
        {
            return QueryManager.ExecuteSum(
                () => criteria == null ? BaseQuery().Sum(selector) : BaseQuery().Where(criteria.Predicate).Sum(selector),
                selector,
                criteria
                );
        }

        public double? Sum(Expression<Func<T, bool>> predicate, Expression<Func<T, double?>> selector)
        {
            return Sum(predicate == null ? null : new Specification<T>(predicate), selector);
        }

        public float Sum(Expression<Func<T, float>> selector)
        {
            return Sum((ISpecification<T>)null, selector);
        }

        public virtual float Sum(ISpecification<T> criteria, Expression<Func<T, float>> selector)
        {
            return QueryManager.ExecuteSum(
                () => criteria == null ? BaseQuery().Sum(selector) : BaseQuery().Where(criteria.Predicate).Sum(selector),
                selector,
                criteria
                );
        }

        public float Sum(Expression<Func<T, bool>> predicate, Expression<Func<T, float>> selector)
        {
            return Sum(predicate == null ? null : new Specification<T>(predicate), selector);
        }

        public float? Sum(Expression<Func<T, float?>> selector)
        {
            return Sum((ISpecification<T>)null, selector);
        }

        public virtual float? Sum(ISpecification<T> criteria, Expression<Func<T, float?>> selector)
        {
            return QueryManager.ExecuteSum(
                () => criteria == null ? BaseQuery().Sum(selector) : BaseQuery().Where(criteria.Predicate).Sum(selector),
                selector,
                criteria
                );
        }

        public float? Sum(Expression<Func<T, bool>> predicate, Expression<Func<T, float?>> selector)
        {
            return Sum(predicate == null ? null : new Specification<T>(predicate), selector);
        }

        public double Average(Expression<Func<T, int>> selector)
        {
            return Average((ISpecification<T>)null, selector);
        }

        public virtual double Average(ISpecification<T> criteria, Expression<Func<T, int>> selector)
        {
            return QueryManager.ExecuteAverage(
                () => criteria == null ? BaseQuery().Average(selector) : BaseQuery().Where(criteria.Predicate).Average(selector),
                selector,
                criteria
                );
        }

        public double Average(Expression<Func<T, bool>> predicate, Expression<Func<T, int>> selector)
        {
            return Average(predicate == null ? null : new Specification<T>(predicate), selector);
        }

        public double? Average(Expression<Func<T, int?>> selector)
        {
            return Average((ISpecification<T>)null, selector);
        }

        public virtual double? Average(ISpecification<T> criteria, Expression<Func<T, int?>> selector)
        {
            return QueryManager.ExecuteAverage(
                () => criteria == null ? BaseQuery().Average(selector) : BaseQuery().Where(criteria.Predicate).Average(selector),
                selector,
                criteria
                );
        }

        public double? Average(Expression<Func<T, bool>> predicate, Expression<Func<T, int?>> selector)
        {
            return Average(predicate == null ? null : new Specification<T>(predicate), selector);
        }

        public double Average(Expression<Func<T, long>> selector)
        {
            return Average((ISpecification<T>)null, selector);
        }

        public virtual double Average(ISpecification<T> criteria, Expression<Func<T, long>> selector)
        {
            return QueryManager.ExecuteAverage(
                () => criteria == null ? BaseQuery().Average(selector) : BaseQuery().Where(criteria.Predicate).Average(selector),
                selector,
                criteria
                );
        }

        public double Average(Expression<Func<T, bool>> predicate, Expression<Func<T, long>> selector)
        {
            return Average(predicate == null ? null : new Specification<T>(predicate), selector);
        }

        public double? Average(Expression<Func<T, long?>> selector)
        {
            return Average((ISpecification<T>)null, selector);
        }

        public virtual double? Average(ISpecification<T> criteria, Expression<Func<T, long?>> selector)
        {
            return QueryManager.ExecuteAverage(
                () => criteria == null ? BaseQuery().Average(selector) : BaseQuery().Where(criteria.Predicate).Average(selector),
                selector,
                criteria
                );
        }

        public double? Average(Expression<Func<T, bool>> predicate, Expression<Func<T, long?>> selector)
        {
            return Average(predicate == null ? null : new Specification<T>(predicate), selector);
        }

        public decimal Average(Expression<Func<T, decimal>> selector)
        {
            return Average((ISpecification<T>)null, selector);
        }

        public virtual decimal Average(ISpecification<T> criteria, Expression<Func<T, decimal>> selector)
        {
            return QueryManager.ExecuteAverage(
                () => criteria == null ? BaseQuery().Average(selector) : BaseQuery().Where(criteria.Predicate).Average(selector),
                selector,
                criteria
                );
        }

        public decimal Average(Expression<Func<T, bool>> predicate, Expression<Func<T, decimal>> selector)
        {
            return Average(predicate == null ? null : new Specification<T>(predicate), selector);
        }

        public decimal? Average(Expression<Func<T, decimal?>> selector)
        {
            return Average((ISpecification<T>)null, selector);
        }

        public virtual decimal? Average(ISpecification<T> criteria, Expression<Func<T, decimal?>> selector)
        {
            return QueryManager.ExecuteAverage(
                () => criteria == null ? BaseQuery().Average(selector) : BaseQuery().Where(criteria.Predicate).Average(selector),
                selector,
                criteria
                );
        }

        public decimal? Average(Expression<Func<T, bool>> predicate, Expression<Func<T, decimal?>> selector)
        {
            return Average(predicate == null ? null : new Specification<T>(predicate), selector);
        }

        public double Average(Expression<Func<T, double>> selector)
        {
            return Average((ISpecification<T>)null, selector);
        }

        public virtual double Average(ISpecification<T> criteria, Expression<Func<T, double>> selector)
        {
            return QueryManager.ExecuteAverage(
                () => criteria == null ? BaseQuery().Average(selector) : BaseQuery().Where(criteria.Predicate).Average(selector),
                selector,
                criteria
                );
        }

        public double Average(Expression<Func<T, bool>> predicate, Expression<Func<T, double>> selector)
        {
            return Average(predicate == null ? null : new Specification<T>(predicate), selector);
        }

        public double? Average(Expression<Func<T, double?>> selector)
        {
            return Average((ISpecification<T>)null, selector);
        }

        public virtual double? Average(ISpecification<T> criteria, Expression<Func<T, double?>> selector)
        {
            return QueryManager.ExecuteAverage(
                () => criteria == null ? BaseQuery().Average(selector) : BaseQuery().Where(criteria.Predicate).Average(selector),
                selector,
                criteria
                );
        }

        public double? Average(Expression<Func<T, bool>> predicate, Expression<Func<T, double?>> selector)
        {
            return Average(predicate == null ? null : new Specification<T>(predicate), selector);
        }

        public float Average(Expression<Func<T, float>> selector)
        {
            return Average((ISpecification<T>)null, selector);
        }

        public virtual float Average(ISpecification<T> criteria, Expression<Func<T, float>> selector)
        {
            return QueryManager.ExecuteAverage(
                () => criteria == null ? BaseQuery().Average(selector) : BaseQuery().Where(criteria.Predicate).Average(selector),
                selector,
                criteria
                );
        }

        public float Average(Expression<Func<T, bool>> predicate, Expression<Func<T, float>> selector)
        {
            return Average(predicate == null ? null : new Specification<T>(predicate), selector);
        }

        public float? Average(Expression<Func<T, float?>> selector)
        {
            return Average((ISpecification<T>)null, selector);
        }

        public virtual float? Average(ISpecification<T> criteria, Expression<Func<T, float?>> selector)
        {
            return QueryManager.ExecuteAverage(
                () => criteria == null ? BaseQuery().Average(selector) : BaseQuery().Where(criteria.Predicate).Average(selector),
                selector,
                criteria
                );
        }

        public float? Average(Expression<Func<T, bool>> predicate, Expression<Func<T, float?>> selector)
        {
            return Average(predicate == null ? null : new Specification<T>(predicate), selector);
        }

        public TResult Min<TResult>(Expression<Func<T, TResult>> selector)
        {
            return Min((ISpecification<T>)null, selector);
        }

        public virtual TResult Min<TResult>(ISpecification<T> criteria, Expression<Func<T, TResult>> selector)
        {
            return QueryManager.ExecuteMin(
                () => criteria == null ? BaseQuery().Min(selector) : BaseQuery().Where(criteria.Predicate).Min(selector),
                selector,
                criteria
                );
        }

        public TResult Min<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector)
        {
            return Min(predicate == null ? null : new Specification<T>(predicate), selector);
        }

        public TResult Max<TResult>(Expression<Func<T, TResult>> selector)
        {
            return Max((ISpecification<T>)null, selector);
        }

        public virtual TResult Max<TResult>(ISpecification<T> criteria, Expression<Func<T, TResult>> selector)
        {
            return QueryManager.ExecuteMax(
                () => criteria == null ? BaseQuery().Max(selector) : BaseQuery().Where(criteria.Predicate).Max(selector),
                selector,
                criteria
                );
        }

        public TResult Max<TResult>(Expression<Func<T, bool>> predicate, Expression<Func<T, TResult>> selector)
        {
            return Max(predicate == null ? null : new Specification<T>(predicate), selector);
        }

        public IDictionary<TGroupKey, int> GroupCount<TGroupKey>(Expression<Func<T, TGroupKey>> selector)
        {
            return GroupCount((ISpecification<T>)null, selector);
        }

        public virtual IDictionary<TGroupKey, int> GroupCount<TGroupKey>(ISpecification<T> criteria, Expression<Func<T, TGroupKey>> selector)
        {
            return GroupBy(criteria, selector, x => new { x.Key, Count = x.Count() }).ToDictionary(x => x.Key, x => x.Count);
        }

        public IDictionary<TGroupKey, int> GroupCount<TGroupKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TGroupKey>> selector)
        {
            return GroupCount(predicate == null ? null : new Specification<T>(predicate), selector);
        }

        public IDictionary<TGroupKey, long> GroupLongCount<TGroupKey>(Expression<Func<T, TGroupKey>> selector)
        {
            return GroupLongCount((ISpecification<T>)null, selector);
        }

        public virtual IDictionary<TGroupKey, long> GroupLongCount<TGroupKey>(ISpecification<T> criteria, Expression<Func<T, TGroupKey>> selector)
        {
            return GroupBy(criteria, selector, x => new { x.Key, Count = x.LongCount() }).ToDictionary(x => x.Key, x => x.Count);
        }

        public IDictionary<TGroupKey, long> GroupLongCount<TGroupKey>(Expression<Func<T, bool>> predicate, Expression<Func<T, TGroupKey>> selector)
        {
            return GroupLongCount(predicate == null ? null : new Specification<T>(predicate), selector);
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

            if (IsInScope) return;
            Save();

            TKey key;
            if (GetPrimaryKey(entity, out key))
                QueryManager.OnItemAdded(key, entity);
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
            if (IsInScope) return;

            Save();

            TKey key;
            if (GetPrimaryKey(entity, out key))
                QueryManager.OnItemDeleted(key, entity);
        }


        public void Delete(IEnumerable<T> entities)
        {
            foreach (var entity in entities)
            {
                Delete(entity);
            }
        }

        public void Delete(TKey key)
        {
            var entity = Get(key);

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
            if (IsInScope) return;
            Save();

            TKey key;
            if (GetPrimaryKey(entity, out key))
                QueryManager.OnItemUpdated(key, entity);
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
            
            QueryManager.OnSaveExecuted(); 
        }

        private async Task SaveAsync()
        {
            await SaveChangesAsync();

            QueryManager.OnSaveExecuted();
        }

        
        public abstract void Dispose();

        protected virtual bool GetPrimaryKey(T entity, out TKey key) 
        {
            key = default(TKey);

            var propInfo = GetPrimaryKeyPropertyInfo();

            // if there is no property that matches then return false
            if (propInfo == null)
                return false;

           key = (TKey) propInfo.GetValue(entity, null);
           
           return true;
        }

        protected virtual bool SetPrimaryKey(T entity, TKey key)
        {
            var propInfo = GetPrimaryKeyPropertyInfo();

            // if there is no property that matches then return false
            if (propInfo == null)
                return false;

            propInfo.SetValue(entity, key, null);

            return true;
        }

        protected virtual ISpecification<T> ByPrimaryKeySpecification(TKey key)
        {
            var propInfo = GetPrimaryKeyPropertyInfo();

            var parameter = Expression.Parameter(typeof (T), "x");
            var lambda = Expression.Lambda<Func<T, bool>>(
                    Expression.Equal(
                        Expression.PropertyOrField(parameter, propInfo.Name), 
                        Expression.Constant(key)
                    ),
                    parameter
                );

            return new Specification<T>(lambda);
        }

        protected virtual PropertyInfo GetPrimaryKeyPropertyInfo()
        {
            // checks for properties in this order that match TKey type
            //  1) RepositoryPrimaryKeyAttribute
            //  2) Id
            //  3) [Type Name]Id
            var type = typeof(T);
            var pkType = typeof(TKey);
            var tupleKey = Tuple.Create(type, pkType);

            // check the static cache, this means that the reflection is only done the first time this repository type is used
            //  big performance gain from this - over 3 times faster after first load
            if (InternalCache.PrimaryKeyMapping.ContainsKey(tupleKey))
            {
                return InternalCache.PrimaryKeyMapping[tupleKey];
            }

            var propertyName = Conventions.GetPrimaryKeyName(type);

            if (String.IsNullOrEmpty(propertyName)) return null;

            var propInfo = type.GetProperty(propertyName);
            propInfo = propInfo == null || propInfo.PropertyType != pkType ? null : propInfo;

            InternalCache.PrimaryKeyMapping[tupleKey] = propInfo;
            return propInfo;
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
                if(m_EntityErrors == null)
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
