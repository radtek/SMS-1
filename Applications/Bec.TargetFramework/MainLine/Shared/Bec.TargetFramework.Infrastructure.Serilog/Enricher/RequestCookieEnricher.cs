using System;
using System.Web;
using Serilog.Web.Extensions.Enrichers.Infrastructure;

namespace Serilog.Web.Extensions.Enrichers
{
    public class RequestCookieEnricher : NamedScalarKeyBasedWithDefaultValueHttpRequestEnricherBase
    {
        public const string DefaultPropertyValue = "N/A";

        public RequestCookieEnricher(string keyName, string defaultValue = DefaultPropertyValue, string propertyName = null,
            Func<HttpContextBase> httpContextGetter = null) : base(keyName, defaultValue, propertyName, httpContextGetter)
        {
        }

        protected override object GetValueByKey(HttpRequestBase httpRequest, string key)
        {
            var cookies = httpRequest.Cookies;
            if (cookies != null)
            {
                var cookie = cookies[key];
                if (cookie != null)
                {
                    return cookie.Value;
                }
            }
            return null;
        }
    }
}