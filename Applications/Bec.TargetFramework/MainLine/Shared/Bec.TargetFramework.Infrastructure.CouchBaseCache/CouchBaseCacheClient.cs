﻿using Bec.TargetFramework.Infrastructure.Caching;
using Couchbase;
using ServiceStack.Caching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Omu.ValueInjecter;

namespace Bec.TargetFramework.Infrastructure.CouchBaseCache
{
    using Bec.TargetFramework.Infrastructure.Log;

    using Enyim.Caching.Memcached;
    using Enyim.Caching.Memcached.Results.Helpers;

    using ServiceStack.Common;
    using Couchbase.Configuration;

    public sealed class CouchBaseCacheClient : ICacheClient,ICacheProvider
    {
        /// <summary>
        /// Memcached Config
        /// </summary>
        private CouchbaseClient m_Client;

        private ILogger m_Logger;
        private CouchbaseClientConfiguration m_config;

        private CouchBaseCacheClient(ILogger logger, CouchbaseClientConfiguration config)
        {
            m_Logger = logger;
            m_Client = new CouchbaseClient(config);
        }

        public CouchBaseCacheClient(ILogger logger, string bucket, string username, string password, string uri, string connectionTimeout, string deadTimeout)
        {
            var config = new CouchbaseClientConfiguration
            {
                Bucket = bucket,
                Username = username,
                BucketPassword = password
            };
            config.Urls.Add(new Uri(uri));
            config.SocketPool.ConnectionTimeout = TimeSpan.Parse(connectionTimeout);
            config.SocketPool.DeadTimeout = TimeSpan.Parse(deadTimeout);

            m_Logger = logger;
            m_Client = new CouchbaseClient(config);
        }

        public ICacheClient CreateCacheClient(ILogger logger)
        {
            return new CouchBaseCacheClient(logger, m_config);
        }

        public bool Add<T>(string key, T value, TimeSpan expiresIn)
        {
            var result = m_Client.ExecuteStore(StoreMode.Add, key, value, expiresIn);

            if (!result.Success)
            {
                m_Logger.Error(new TargetFrameworkLogDTO
                {
                    Exception = result.Exception,
                    Message = "Error caching:" + key
                });
            }
            return result.Success;
        }

        public bool Add<T>(string key, T value, DateTime expiresAt)
        {
            var result = m_Client.ExecuteStore(StoreMode.Add, key, value, expiresAt);

            if (!result.Success)
            {
                m_Logger.Error(new TargetFrameworkLogDTO
                {
                    Exception = result.Exception,
                    Message = "Error caching:" + key
                });
            }
            return result.Success;
        }

        public bool Add<T>(string key, T value)
        {
            var result = m_Client.ExecuteStore(StoreMode.Add, key, value);

            if (!result.Success)
            {
                m_Logger.Error(new TargetFrameworkLogDTO
                {
                    Exception = result.Exception,
                    Message = "Error caching:" + key
                });
            }
            return result.Success;
        }

        public long Decrement(string key, uint amount)
        {
            throw new NotImplementedException();
        }

        public void FlushAll()
        {
            m_Client.FlushAll();
        }

        public T Get<T>(string key)
        {
            var result = m_Client.ExecuteGet<T>(key);

            if (!result.Success && result.StatusCode != 1) //key not found
            {
                m_Logger.Error(new TargetFrameworkLogDTO
                {
                    Exception = result.Exception,
                    Message = "Error caching:" + key
                });

                return result.Value;
            }

            return result.Value;
        }

        public object Get(string key)
        {
            var result = m_Client.ExecuteGet(key);

            if (!result.Success && result.StatusCode != 1) //key not found
            {
                m_Logger.Error(new TargetFrameworkLogDTO
                {
                    Exception = result.Exception,
                    Message = "Error caching:" + key
                });

                return result.Value;
            }

            return result.Value;
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
            var result = m_Client.ExecuteRemove(key);

            if (!result.Success)
            {
                m_Logger.Error(new TargetFrameworkLogDTO
                {
                    Exception = result.Exception,
                    Message = "Error caching:" + key
                });
            }

            return result.Success;
        }

        public void RemoveAll(IEnumerable<string> keys)
        {
        }

        public bool Replace<T>(string key, T value, TimeSpan expiresIn)
        {
            var result = m_Client.ExecuteStore(StoreMode.Replace, key, value, expiresIn);

            if (!result.Success)
            {
                m_Logger.Error(new TargetFrameworkLogDTO
                {
                    Exception = result.Exception,
                    Message = "Error caching:" + key
                });
            }
            return result.Success;
        }

        public bool Replace<T>(string key, T value, DateTime expiresAt)
        {
            var result = m_Client.ExecuteStore(StoreMode.Replace, key, value, expiresAt);


            if (!result.Success)
            {
                m_Logger.Error(new TargetFrameworkLogDTO
                {
                    Exception = result.Exception,
                    Message = "Error caching:" + key
                });
            }
            return result.Success;
        }

        public bool Replace<T>(string key, T value)
        {
            var result = m_Client.ExecuteStore(StoreMode.Replace, key, value);


            if (!result.Success)
            {
                m_Logger.Error(new TargetFrameworkLogDTO
                {
                    Exception = result.Exception,
                    Message = "Error caching:" + key
                });
            }
            return result.Success;
        }

        public bool Set<T>(string key, T value, TimeSpan expiresIn)
        {
            var result = m_Client.ExecuteStore(StoreMode.Set, key, value, expiresIn);


            if (!result.Success)
            {
                m_Logger.Error(new TargetFrameworkLogDTO
                {
                    Exception = result.Exception,
                    Message = "Error caching:" + key
                });
            }
            return result.Success;
        }

        public bool Set<T>(string key, T value, DateTime expiresAt)
        {
            var result = m_Client.ExecuteStore(StoreMode.Set, key, value, expiresAt);


            if (!result.Success)
            {
                m_Logger.Error(new TargetFrameworkLogDTO
                {
                    Exception = result.Exception,
                    Message = "Error caching:" + key
                });
            }
            return result.Success;
        }

        public bool Set<T>(string key, T value)
        {
            var result = m_Client.ExecuteStore(StoreMode.Set, key, value);

            if (!result.Success)
            {
                m_Logger.Error(new TargetFrameworkLogDTO
                                   {
                                       Exception = result.Exception,
                                       Message = "Error caching:" + key
                                   });
            }

            return result.Success;
        }

        public void SetAll<T>(IDictionary<string, T> values)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            m_Client.Dispose();
        }
    }
}
