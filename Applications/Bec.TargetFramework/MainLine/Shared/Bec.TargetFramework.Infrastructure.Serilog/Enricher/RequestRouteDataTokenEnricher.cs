using System;
using System.Web;
using Serilog.Web.Extensions.Enrichers.Infrastructure;

namespace Serilog.Web.Extensions.Enrichers
{
    public class RequestRouteDataTokenEnricher : NamedScalarKeyBasedWithDefaultValueHttpRequestEnricherBase
    {
        public const string DefaultPropertyValue = "N/A";

        public RequestRouteDataTokenEnricher(string keyName, string defaultValue = DefaultPropertyValue, string propertyName = null,
            Func<HttpContextBase> httpContextGetter = null) : base(keyName, defaultValue, propertyName, httpContextGetter)
        {
        }

        protected override object GetValueByKey(HttpRequestBase httpRequest, string key)
        {
            var requestContext = httpRequest.RequestContext;
            if (requestContext != null)
            {
                var routeData = requestContext.RouteData;
                if (routeData != null)
                {
                    var dataTokens = routeData.DataTokens;
                    if (dataTokens != null)
                    {
                        object value;
                        if (dataTokens.TryGetValue(key, out value))
                        {
                            return value;
                        }
                    }
                }
            }
            return null;
        }
    }
}