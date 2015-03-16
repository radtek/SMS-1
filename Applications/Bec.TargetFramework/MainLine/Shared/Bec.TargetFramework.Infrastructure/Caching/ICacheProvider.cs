
using ServiceStack.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Infrastructure.Caching
{
    using Bec.TargetFramework.Infrastructure.Log;

    public interface ICacheProvider : ICacheClient
    {
        ICacheClient CreateCacheClient(ILogger logger);

        bool Add<T>(string key, T value, DateTime expiresAt);

        object Get(string key);
    }
}
