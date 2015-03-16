using Bec.TargetFramework.Data.Infrastructure.Configuration;

namespace Bec.TargetFramework.Data.Infrastructure.Caching
{
    public class InMemoryConfigCachingProviderFactory : ConfigCachingProviderFactory
    {
        public InMemoryConfigCachingProviderFactory(ICachingProviderConfiguration config)
            : base(config) 
        {
        }

        public override ICachingProvider GetInstance()
        {
            return new InMemoryCachingProvider();
        }
    }
}
