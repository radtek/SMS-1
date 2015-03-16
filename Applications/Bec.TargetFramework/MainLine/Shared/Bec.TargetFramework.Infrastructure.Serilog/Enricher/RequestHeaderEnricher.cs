using System;
using System.Web;
using Serilog.Web.Extensions.Enrichers.Infrastructure;

namespace Serilog.Web.Extensions.Enrichers
{
    public class RequestHeaderEnricher : NamedScalarKeyBasedWithDefaultValueHttpRequestEnricherBase
    {
        public const string DefaultPropertyValue = "N/A";

        public RequestHeaderEnricher(string keyName, string defaultValue = DefaultPropertyValue, string propertyName = null,
            Func<HttpContextBase> httpContextGetter = null) : base(keyName, defaultValue, propertyName, httpContextGetter)
        {
        }

        protected override object GetValueByKey(HttpRequestBase httpRequest, string key)
        {
            var headers = httpRequest.Headers;
            if (headers != null)
            {
                return headers[key];
            }
            return null;
        }
    }
}