using System;
using System.Web;
using Serilog.Web.Extensions.Enrichers.Infrastructure;

namespace Serilog.Web.Extensions.Enrichers
{
    public class HttpContextCacheEnricher : NamedKeyBasedWithDefaultValueHttpContextEnricherBase
    {
        public const string DefaultPropertyValue = "N/A";

        public HttpContextCacheEnricher(string keyName, object defaultValue = null,
            string propertyName = null, Func<HttpContextBase> httpContextGetter = null)
            : base(keyName, defaultValue ?? DefaultPropertyValue, propertyName, httpContextGetter)
        {
        }

        protected override object GetValueByKey(HttpContextBase httpContext, string key)
        {
            var cache = httpContext.Cache;
            return (cache != null) ? cache[key] : null;
        }
    }
}