using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Log;
using EnsureThat;

namespace Bec.TargetFramework.Analysis
{
    public class LogicBase
    {
        public LogicBase(ILogger logger, ICacheProvider cacheProvider)
        {
            Ensure.That(logger);
            Ensure.That(cacheProvider);

            this.m_Logger = logger;
            this.m_CacheProvider = cacheProvider;
        }

        public ILogger Logger
        {
            get
            {
                return this.m_Logger;
            }
        }

        public ICacheProvider CacheProvider
        {
            get
            {
                return this.m_CacheProvider;
            }
        }

        private ILogger m_Logger { get; set; }

        private ICacheProvider m_CacheProvider { get; set; }
    }
}
