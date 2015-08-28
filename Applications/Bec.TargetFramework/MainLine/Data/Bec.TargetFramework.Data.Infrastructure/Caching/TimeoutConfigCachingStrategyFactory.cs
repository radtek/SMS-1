﻿using System;
using System.Configuration;
using Bec.TargetFramework.Data.Infrastructure.Configuration;

namespace Bec.TargetFramework.Data.Infrastructure.Caching
{
    public class TimeoutConfigCachingStrategyFactory : ConfigCachingStrategyFactory
    {
        public TimeoutConfigCachingStrategyFactory(ICachingStrategyConfiguration config)
            : base(config)
        {
        }

        public override ICachingStrategy<T, TKey> GetInstance<T, TKey>()
        {
            int timeout;
            if (!Int32.TryParse(CachingStrategyConfiguration["timeout"], out timeout))
            {

                throw new ConfigurationErrorsException("The timeout attribute is required in order to use the TimeoutCachingStrategy via the configuration file.");
            }

            return new TimeoutCachingStrategy<T, TKey>(timeout)
                       {
                           MaxResults = CachingStrategyConfiguration.MaxResults
                       };
        }

        public override ICompoundKeyCachingStrategy<T, TKey, TKey2> GetInstance<T, TKey, TKey2>()
        {
            int timeout;
            if (!Int32.TryParse(CachingStrategyConfiguration["timeout"], out timeout))
            {

                throw new ConfigurationErrorsException("The timeout attribute is required in order to use the TimeoutCachingStrategy via the configuration file.");
            }

            return new TimeoutCachingStrategy<T, TKey, TKey2>(timeout)
                       {
                           MaxResults = CachingStrategyConfiguration.MaxResults
                       };
        }
    }
}
