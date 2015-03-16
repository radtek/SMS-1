using Bec.TargetFramework.Data.Infrastructure.Configuration;

namespace Bec.TargetFramework.Data.Infrastructure.Caching
{
    public class NoCachingStrategyConfiguration : CachingStrategyConfiguration
    {
        public NoCachingStrategyConfiguration(string name)
        {
            Name = name;
            Factory = typeof (NoCachingConfigCachingStrategyFactory);
        }
    }
}
