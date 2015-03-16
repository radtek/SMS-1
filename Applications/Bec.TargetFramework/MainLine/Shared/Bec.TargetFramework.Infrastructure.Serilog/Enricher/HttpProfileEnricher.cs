using System;
using System.Configuration;
using System.Web;
using Serilog.Web.Extensions.Enrichers.Infrastructure;

namespace Serilog.Web.Extensions.Enrichers
{
    public class HttpProfileEnricher : NamedKeyBasedWithDefaultValueHttpContextEnricherBase
    {
        public const string DefaultPropertyValue = "N/A";

        public HttpProfileEnricher(string keyName, object defaultValue = null,
            string propertyName = null, Func<HttpContextBase> httpContextGetter = null)
            : base(keyName, defaultValue ?? DefaultPropertyValue, propertyName, httpContextGetter)
        {
        }

        protected override object GetValueByKey(HttpContextBase httpContext, string key)
        {
            try
            {
                var profile = httpContext.Profile;
                return (profile != null) ? profile[key] : null;
            }
            catch (SettingsPropertyNotFoundException)
            {
                return null;
            }
        }
    }
}