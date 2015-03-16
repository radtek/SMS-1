﻿using System.Runtime.Caching;

namespace Bec.TargetFramework.Data.Infrastructure.Caching
{
    /// <summary>
    /// No caching is done using this provider.
    /// </summary>
    public class NoCachingProvider : ICachingProvider
    {
        public void Set<T>(string key, T value, CacheItemPriority priority = CacheItemPriority.Default, int? cacheTime = null)
        {
            // do nothing
        }

        public void Clear(string key)
        {
            // do nothing
        }

        public bool Exists(string key)
        {
            return false;
        }

        public bool Get<T>(string key, out T value)
        {
            value = default(T);
            return false;
        }

        public int Increment(string key, int defaultValue, int value, CacheItemPriority priority = CacheItemPriority.Default)
        {
            return defaultValue;
        }

        public void Dispose()
        {
            
        }
    }
}
