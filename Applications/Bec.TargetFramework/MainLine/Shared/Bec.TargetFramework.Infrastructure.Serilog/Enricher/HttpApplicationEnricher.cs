using System;
using System.Web;
using Serilog.Web.Extensions.Enrichers.Infrastructure;

namespace Serilog.Web.Extensions.Enrichers
{
    public class HttpApplicationEnricher : NamedKeyBasedWithDefaultValueHttpContextEnricherBase
    {
        public const string DefaultPropertyValue = "N/A";

        public HttpApplicationEnricher(string keyName, object defaultValue = null,
            string propertyName = null, Func<HttpContextBase> httpContextGetter = null)
            : base(keyName, defaultValue ?? DefaultPropertyValue, propertyName, httpContextGetter)
        {
        }

        protected override object GetValueByKey(HttpContextBase httpContext, string key)
        {
            var application = httpContext.Application;
            return (application != null) ? application[key] : null;
        }
    }
}