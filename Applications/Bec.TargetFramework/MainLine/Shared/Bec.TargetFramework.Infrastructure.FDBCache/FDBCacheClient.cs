using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Caching;
using ServiceStack.Redis;
using System.Configuration;
using ServiceStack.CacheAccess;
using FoundationDB.Client;
using System.Threading;

namespace Bec.TargetFramework.Infrastructure.RedisCache
{
    public class FDBCacheClient : ICacheClient,ICacheProvider
    {
        private CancellationTokenSource m_CancellationSource;
        private CancellationToken m_CancellationToken;
        private string m_PartitionName = "TargetFramework";

        //private PooledRedisClientManager m_ClientManager;

        public FDBCacheClient()
        {
            //if (ConfigurationManager.AppSettings["RedisConnectionString"] == null)
            //    throw new ArgumentNullException("RedisConnectionString AppSetting is missing from the configuration");

            m_CancellationSource = new CancellationTokenSource();
            m_CancellationToken = m_CancellationSource.Token;
        }

        private async Task<bool> AddItemToCache<T>(string key, T value, TimeSpan expiresIn)
        {
            using(var db = await Fdb.OpenAsync())
            {
                var location = db.Partition(m_PartitionName);

                using(var tr = db.BeginTransaction(m_CancellationToken))
                {
                    tr.Set().Set(location.Pack(key),)
                }

            }

        }

        public bool Add<T>(string key, T value, TimeSpan expiresIn)
        {
            Func<CancellationToken, bool> code = (CancellationToken ct) =>
                {
                    

                    return false;
                };

            Task<bool> task = Task<bool>.Factory.StartNew(() => code(m_CancellationToken), m_CancellationToken);

            task.Wait();

            return task.Result;
        }

        public bool Add<T>(string key, T value, DateTime expiresAt)
        {
            throw new NotImplementedException();
        }

        public bool Add<T>(string key, T value)
        {
            throw new NotImplementedException();
        }

        public long Decrement(string key, uint amount)
        {
            throw new NotImplementedException();
        }

        public void FlushAll()
        {
            throw new NotImplementedException();
        }

        public T Get<T>(string key)
        {
            throw new NotImplementedException();
        }

        public IDictionary<string, T> GetAll<T>(IEnumerable<string> keys)
        {
            throw new NotImplementedException();
        }

        public long Increment(string key, uint amount)
        {
            throw new NotImplementedException();
        }

        public bool Remove(string key)
        {
            throw new NotImplementedException();
        }

        public void RemoveAll(IEnumerable<string> keys)
        {
            throw new NotImplementedException();
        }

        public bool Replace<T>(string key, T value, TimeSpan expiresIn)
        {
            throw new NotImplementedException();
        }

        public bool Replace<T>(string key, T value, DateTime expiresAt)
        {
            throw new NotImplementedException();
        }

        public bool Replace<T>(string key, T value)
        {
            throw new NotImplementedException();
        }

        public bool Set<T>(string key, T value, TimeSpan expiresIn)
        {
            throw new NotImplementedException();
        }

        public bool Set<T>(string key, T value, DateTime expiresAt)
        {
            throw new NotImplementedException();
        }

        public bool Set<T>(string key, T value)
        {
            throw new NotImplementedException();
        }

        public void SetAll<T>(IDictionary<string, T> values)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
