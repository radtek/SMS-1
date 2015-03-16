using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Bec.TargetFramework.Data.Infrastructure.Queries;
using Bec.TargetFramework.Data.Infrastructure.Specifications;

namespace Bec.TargetFramework.Data.Infrastructure.Caching
{
    public interface ICompoundKeyCachingStrategyBase<T>
    {
        bool TryGetAllResult<TResult>(IQueryOptions<T> queryOptions, Expression<Func<T, TResult>> selector, out IEnumerable<TResult> result);

        void SaveGetAllResult<TResult>(IQueryOptions<T> queryOptions, Expression<Func<T, TResult>> selector, IEnumerable<TResult> result);

        bool TryFindAllResult<TResult>(ISpecification<T> criteria, IQueryOptions<T> queryOptions, Expression<Func<T, TResult>> selector, out IEnumerable<TResult> result);

        void SaveFindAllResult<TResult>(ISpecification<T> criteria, IQueryOptions<T> queryOptions, Expression<Func<T, TResult>> selector, IEnumerable<TResult> result);

        bool TryFindResult<TResult>(ISpecification<T> criteria, IQueryOptions<T> queryOptions, Expression<Func<T, TResult>> selector, out TResult result);

        void SaveFindResult<TResult>(ISpecification<T> criteria, IQueryOptions<T> queryOptions, Expression<Func<T, TResult>> selector, TResult result);

        void Save();

        string FullCachePrefix { get; }

        void ClearAll();

        ICachingProvider CachingProvider { get; set; }
    }
}