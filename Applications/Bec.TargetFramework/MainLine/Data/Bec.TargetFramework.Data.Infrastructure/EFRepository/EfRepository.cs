﻿using System;
using System.Data.Entity;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Data.Infrastructure.Caching;

namespace Bec.TargetFramework.Data.Infrastructure.EfRepository
{
    public class EfRepository<T, TKey, TKey2> : EfCompoundKeyRepositoryBase<T, TKey, TKey2> where T : class, new()
    {
        public EfRepository(DbContext dbContext, ICompoundKeyCachingStrategy<T, TKey, TKey2> cachingStrategy = null)
            : base(dbContext, cachingStrategy)
        {
        }
    }

    public class EfCompoundKeyRepository<T> : EfCompoundKeyRepositoryBase<T> where T : class, new()
    {
        public EfCompoundKeyRepository(DbContext dbContext, ICompoundKeyCachingStrategy<T> cachingStrategy = null)
            : base(dbContext, cachingStrategy)
        {
        }
    }

    /// <summary>
    /// Entity Framework repository layer
    /// </summary>
    /// <typeparam name="T">The Entity type</typeparam>
    /// <typeparam name="TKey">The type of the primary key.</typeparam>
    public class EfRepository<T, TKey> : EfRepositoryBase<T, TKey> where T : class, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ef5Repository&lt;T, TKey&gt;"/> class.
        /// </summary>
        /// <param name="dbContext">The Entity Framework DbContext.</param>
        /// <param name="cachingStrategy">The caching strategy to use.  Defaults to <see cref="NoCachingStrategy&lt;T, TKey&gt;" /></param>
        public EfRepository(DbContext dbContext, ICachingStrategy<T, TKey> cachingStrategy = null) : base(dbContext, cachingStrategy)
        {
            if (dbContext == null) throw new ArgumentNullException("dbContext");
        }
    }

    /// <summary>
    /// Entity Framework repository layer
    /// </summary>
    /// <typeparam name="T">The Entity type</typeparam>
    public class EfRepository<T> : EfRepositoryBase<T, int>, IRepository<T> where T : class, new()
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Ef5Repository&lt;T&gt;"/> class.
        /// </summary>
        /// <param name="dbContext">The Entity Framework DbContext.</param>
        /// <param name="cachingStrategy">The caching strategy to use.  Defaults to <see cref="NoCachingStrategy&lt;T, TKey&gt;" /></param>
        public EfRepository(DbContext dbContext, ICachingStrategy<T, int> cachingStrategy = null) : base(dbContext, cachingStrategy)
        {
            if (dbContext == null) throw new ArgumentNullException("dbContext");
        }
    }
}
