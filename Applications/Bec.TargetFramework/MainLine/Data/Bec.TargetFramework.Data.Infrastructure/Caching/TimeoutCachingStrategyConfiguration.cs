using Bec.TargetFramework.Data.Infrastructure.Configuration;

namespace Bec.TargetFramework.Data.Infrastructure.Caching
{
    public class TimeoutCachingStrategyConfiguration : CachingStrategyConfiguration
    {
        public TimeoutCachingStrategyConfiguration(string name, int timeoutInSeconds)
            : this(name, timeoutInSeconds, null)
        {
        }

        public TimeoutCachingStrategyConfiguration(string name, int timeoutInSeconds, int? maxResults)
        {
            Name = name;
            Timeout = timeoutInSeconds;
            MaxResults = maxResults;
            Factory = typeof(TimeoutConfigCachingStrategyFactory);
        }

        public int Timeout
        {
            set { Attributes["timeout"] = value.ToString(); }
        }
    }
}
