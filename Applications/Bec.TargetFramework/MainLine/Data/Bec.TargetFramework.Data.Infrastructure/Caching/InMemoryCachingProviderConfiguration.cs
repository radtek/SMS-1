using Bec.TargetFramework.Data.Infrastructure.Configuration;

namespace Bec.TargetFramework.Data.Infrastructure.Caching
{
    public class InMemoryCachingProviderConfiguration : CachingProviderConfiguration
    {
        public InMemoryCachingProviderConfiguration(string name)
        {
            Name = name;
            Factory = typeof (InMemoryConfigCachingProviderFactory);
        }
    }
}
