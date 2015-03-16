using Bec.TargetFramework.Data.Infrastructure.Caching;

namespace Bec.TargetFramework.Data.Infrastructure.CacheRepository
{
    public class CacheCompoundKeyRepository<T> : CacheCompoundKeyRepositoryBase<T> where T : class, new()
    {
        public CacheCompoundKeyRepository(string prefix, ICompoundKeyCachingStrategy<T> cachingStrategy = null) : base(prefix, cachingStrategy)
        {
        }
    }
}