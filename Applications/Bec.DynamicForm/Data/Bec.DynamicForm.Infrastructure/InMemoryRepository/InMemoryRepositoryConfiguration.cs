using Bec.TargetFramework.Data.Infrastructure.Configuration;

namespace Bec.TargetFramework.Data.Infrastructure.InMemoryRepository
{
    public class InMemoryRepositoryConfiguration : RepositoryConfiguration
    {
        public InMemoryRepositoryConfiguration(string name, string cachingStrategy=null, string cachingProvider=null)
            : base(name)
        {
            CachingStrategy = cachingStrategy;
            CachingProvider = cachingProvider;
            Factory = typeof(InMemoryConfigRepositoryFactory);
        }
    }
}
