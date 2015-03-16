using System;
using System.Linq.Expressions;
using Bec.TargetFramework.Data.Infrastructure.Caching;
using System.Threading.Tasks;
using System.Collections.Generic;


// TODO: I want to use the ICanGet<> trait so that they aren't defined in 2 places but I can't because the GetAll is in IRepositoryQueryable and not in here, but it needs to be in ICanGet

namespace Bec.TargetFramework.Data.Infrastructure
{
    /// <summary>
    /// Repository that acesses <typeparamref name="T"/> entities and has a primary key of type <typeparamref name="TKey"/>
    /// </summary>
    /// <typeparam name="T">The entity type that the repository acts on.</typeparam>
    /// <typeparam name="TKey">The type of the primary key.</typeparam>
    public interface IRepository<T, TKey> : IRepositoryBase<T>, IRepositoryQueryable<T>, IRepositoryAggregates<T> where T : class
    {
        IRepositoryConventions Conventions { get; set; }

        /// <summary>
        /// Returns the Type for the entity of this repository.
        /// </summary>
        Type EntityType { get; }

        /// <summary>
        /// Returns the Type for the key of this repository.
        /// </summary>
        Type KeyType { get; }

        /// <summary>
        /// Gets the specified entity of type <typeparamref name="T"/> from the repository by the primary key.
        /// </summary>
        /// <param name="key">The primary key.</param>
        /// <returns>The entity that matches on the primary key</returns>
        T Get(TKey key);
        Task<T> GetAsync(TKey key);

        /// <summary>
        /// Gets the specified entity of type <typeparamref name="T"/> from the repository by the primary key and maps it to the result of type <typeparamref name="TResult"/>.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="key">The primary key.</param>
        /// <param name="selector">The mapping selector that returns the result type.</param>
        /// <returns>The mapped entity based on the selector that matches on the primary key.</returns>
        TResult Get<TResult>(TKey key, Expression<Func<T, TResult>> selector);
        Task<TResult> GetAsync<TResult>(TKey key, Expression<Func<T, TResult>> selector);

        /// <summary>
        /// Returns true if the specified entity of type <typeparamref name="T"/> from the repository by the primary key exists
        /// </summary>
        /// <param name="key">The primary key.</param>
        /// <returns>True if the entity exists, false if it does not</returns>
        bool Exists(TKey key);
        Task<bool> ExistsAsync(TKey key);

        /// <summary>
        /// Returns true if the specified entity of type <typeparamref name="T"/> from the repository by the primary key exists
        /// </summary>
        /// <param name="key">The primary key.</param>
        /// <param name="entity">The entity that was found</param>
        /// <returns>True if the entity exists, false if it does not</returns>
        bool TryGet(TKey key, out T entity);
        Task<bool> TryGetAsync(TKey key);

        /// <summary>
        /// Returns true if the specified entity of type <typeparamref name="T"/> from the repository by the primary key exists
        /// </summary>
        /// <param name="key">The primary key.</param>
        /// <param name="selector">The mapping selector that returns the result type.</param>
        /// <param name="entity">The entity that was found</param>
        /// <returns>True if the entity exists, false if it does not</returns>
        bool TryGet<TResult>(TKey key, Expression<Func<T, TResult>> selector, out TResult entity);
        Task<bool> TryGetAsync<TResult>(TKey key, Expression<Func<T, TResult>> selector);

        /// <summary>
        /// Deletes the specified entity by the primary key.
        /// </summary>
        /// <param name="key">The primary key.</param>
        void Delete(TKey key);

        ICachingStrategy<T, TKey> CachingStrategy { get; set; }

        /// <summary>
        /// Used to get or set whether the cache is currently enabled and being used
        /// </summary>
        bool CachingEnabled { get; set; }

        /// <summary>
        /// Returns true if the cache was used on the very last query that was used (Get, Find, GetAll or FindAll)
        /// </summary>
        bool CacheUsed { get; }

        /// <summary>
        /// Disables caching for all code within the using() block it is called in
        /// </summary>
        /// <returns></returns>
        IDisabledCache DisableCaching();

        /// <summary>
        /// Clears the cache for this particular repository.  All other repositories will still have their caches available. Use Repository.ClearAllCache() to clear the cache for every repository
        /// </summary>
        void ClearCache();

        
    }

    /// <summary>
    /// Defaults to int as the Primary Key
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IRepository<T> : IRepository<T, int> where T : class
    {
    }
}