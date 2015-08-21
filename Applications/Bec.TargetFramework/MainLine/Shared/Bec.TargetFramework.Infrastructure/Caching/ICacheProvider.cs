using Bec.TargetFramework.Infrastructure.Log;
using ServiceStack.Caching;
using System;

namespace Bec.TargetFramework.Infrastructure.Caching
{
    public interface ICacheProvider : ICacheClient
    {
        ICacheClient CreateCacheClient(ILogger logger);

        bool Add<T>(string key, T value, DateTime expiresAt);

        object Get(string key);
    }
}
