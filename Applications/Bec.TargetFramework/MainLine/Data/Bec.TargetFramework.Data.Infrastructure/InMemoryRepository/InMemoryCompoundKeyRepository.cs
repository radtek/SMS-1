using Bec.TargetFramework.Data.Infrastructure.Caching;

namespace Bec.TargetFramework.Data.Infrastructure.InMemoryRepository
{
    public class InMemoryCompoundKeyRepository<T> : InMemoryCompoundKeyRepositoryBase<T> where T : class, new()
    {
        public InMemoryCompoundKeyRepository(ICompoundKeyCachingStrategy<T> cachingStrategy = null) : base(cachingStrategy)
        {
        }
    }
}