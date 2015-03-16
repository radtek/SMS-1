using System;
using System.Web;
using Serilog.Web.Extensions.Enrichers.Infrastructure;

namespace Serilog.Web.Extensions.Enrichers
{
    public class RequestRouteDataValueEnricher : NamedScalarKeyBasedWithDefaultValueHttpRequestEnricherBase
    {
        public const string DefaultPropertyValue = "N/A";

        public RequestRouteDataValueEnricher(string keyName, string defaultValue = DefaultPropertyValue, string propertyName = null,
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
                    var dataValues = routeData.Values;
                    if (dataValues != null)
                    {
                        object value;
                        if (dataValues.TryGetValue(key, out value))
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