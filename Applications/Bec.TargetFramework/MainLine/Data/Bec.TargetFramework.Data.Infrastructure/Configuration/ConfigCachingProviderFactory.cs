using Bec.TargetFramework.Data.Infrastructure.Caching;

namespace Bec.TargetFramework.Data.Infrastructure.Configuration
{
    public interface IConfigCachingProviderFactory
    {
        ICachingProvider GetInstance();
    }

    public abstract class ConfigCachingProviderFactory : IConfigCachingProviderFactory
    {
        protected ICachingProviderConfiguration CachingProviderConfiguration;

        protected ConfigCachingProviderFactory(ICachingProviderConfiguration config)
        {
            CachingProviderConfiguration = config;
        }

        public abstract ICachingProvider GetInstance();
    }
}
