using System;
using System.Web;
using Serilog.Web.Extensions.Enrichers.Infrastructure;

namespace Serilog.Web.Extensions.Enrichers
{
    public class RequestServerVariableEnricher : NamedScalarKeyBasedWithDefaultValueHttpRequestEnricherBase
    {
        public const string DefaultPropertyValue = "N/A";

        public RequestServerVariableEnricher(string keyName, string defaultValue = DefaultPropertyValue, string propertyName = null,
            Func<HttpContextBase> httpContextGetter = null) : base(keyName, defaultValue, propertyName, httpContextGetter)
        {
        }

        protected override object GetValueByKey(HttpRequestBase httpRequest, string key)
        {
            var serverVariables = httpRequest.ServerVariables;
            if (serverVariables != null)
            {
                return serverVariables[key];
            }
            return null;
        }
    }
}