using System;
using System.Web;
using Bec.TargetFramework.Infrastructure.Serilog.Enricher.Infrastructure;

namespace Serilog.Web.Extensions.Enrichers
{
    public class HttpRuntimeCacheEnricher : NamedKeyBasedWithDefaultValueEnricherBase
    {
        public const string DefaultPropertyValue = "N/A";

        public HttpRuntimeCacheEnricher(string keyName, object defaultValue = null, string propertyName = null)
            : base(keyName, defaultValue, propertyName)
        {
        }

        protected override object GetValueByKey(string key)
        {
            object value = HttpRuntime.Cache[key];
            return value;
        }
    }
}