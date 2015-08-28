using System.Data.Entity;
using Bec.TargetFramework.Data.Infrastructure.Caching;

namespace Bec.TargetFramework.Data.Infrastructure.EfRepository
{
    public class EfCompoundKeyRepository<T> : EfCompoundKeyRepositoryBase<T> where T : class, new()
    {
        public EfCompoundKeyRepository(DbContext dbContext, ICompoundKeyCachingStrategy<T> cachingStrategy = null) : base(dbContext, cachingStrategy)
        {
        }
    }
}