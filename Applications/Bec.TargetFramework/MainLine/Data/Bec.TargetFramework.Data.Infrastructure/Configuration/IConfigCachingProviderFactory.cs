using Bec.TargetFramework.Data.Infrastructure.Caching;

namespace Bec.TargetFramework.Data.Infrastructure.Configuration
{
    public interface IConfigCachingProviderFactory
    {
        ICachingProvider GetInstance();
    }
}