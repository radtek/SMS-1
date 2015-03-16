using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Caching;
using ServiceStack.Redis;
using System.Configuration;
using ServiceStack.Caching;

namespace Bec.TargetFramework.Infrastructure.RedisCache
{
    public class RedisCacheClient : ServiceStack.Redis.RedisClient, ICacheProvider
    {
        private PooledRedisClientManager m_ClientManager;

        public RedisCacheClient()
        {
            if (ConfigurationManager.AppSettings["RedisConnectionString"] == null)
                throw new ArgumentNullException("RedisConnectionString AppSetting is missing from the configuration");

            m_ClientManager = new PooledRedisClientManager(ConfigurationManager.AppSettings["RedisConnectionString"]);
        }

        public ICacheClient CreateCacheClient()
        {
            return m_ClientManager.GetCacheClient();
        }

    }
}
