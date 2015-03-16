using System;
using System.Web;
using Serilog.Web.Extensions.Enrichers.Infrastructure;

namespace Serilog.Web.Extensions.Enrichers
{
    public class RequestParamEnricher : NamedScalarKeyBasedWithDefaultValueHttpRequestEnricherBase
    {
        public const string DefaultPropertyValue = "N/A";

        public RequestParamEnricher(string keyName, string defaultValue = DefaultPropertyValue, string propertyName = null,
            Func<HttpContextBase> httpContextGetter = null) : base(keyName, defaultValue, propertyName, httpContextGetter)
        {
        }

        protected override object GetValueByKey(HttpRequestBase httpRequest, string key)
        {
            var @params = httpRequest.Params;
            if (@params != null)
            {
                return @params[key];
            }
            return null;
        }
    }
}