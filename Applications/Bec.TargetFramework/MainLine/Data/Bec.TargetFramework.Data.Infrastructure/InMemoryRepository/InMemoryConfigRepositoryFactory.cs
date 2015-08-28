using Bec.TargetFramework.Data.Infrastructure.Configuration;
using Bec.TargetFramework.Data.Infrastructure;

namespace Bec.TargetFramework.Data.Infrastructure.InMemoryRepository
{
    public class InMemoryConfigRepositoryFactory : ConfigRepositoryFactory
    {
        public InMemoryConfigRepositoryFactory(IRepositoryConfiguration config)
            : base(config)
        {
        }

        public override IRepository<T> GetInstance<T>()
        {
            return new InMemoryRepository<T>();
        }

        public override IRepository<T, TKey> GetInstance<T, TKey>()
        {
            return new InMemoryRepository<T, TKey>();
        }

        public override ICompoundKeyRepository<T, TKey, TKey2> GetInstance<T, TKey, TKey2>()
        {
            return new InMemoryRepository<T, TKey, TKey2>();
        }
    }
}
