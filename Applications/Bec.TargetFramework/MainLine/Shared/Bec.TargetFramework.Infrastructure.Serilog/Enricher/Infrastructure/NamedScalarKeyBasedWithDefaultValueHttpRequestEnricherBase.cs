using System;
using System.Web;

namespace Serilog.Web.Extensions.Enrichers.Infrastructure
{
    public abstract class NamedScalarKeyBasedWithDefaultValueHttpRequestEnricherBase<TKey>
        : NamedScalarKeyBasedWithDefaultValueHttpContextEnricherBase<TKey>
    {
        protected NamedScalarKeyBasedWithDefaultValueHttpRequestEnricherBase(TKey keyName, object defaultValue,
            string propertyName = null, Func<HttpContextBase> httpContextGetter = null)
            : base(keyName, defaultValue, propertyName, httpContextGetter)
        {
        }

        protected sealed override object GetValueByKey(HttpContextBase httpContext, TKey key)
        {
            var request = httpContext.Request;
            if (request != null)
            {
                return GetValueByKey(request, key);
            }
            return null;
        }

        protected abstract object GetValueByKey(HttpRequestBase httpRequest, TKey key);
    }

    public abstract class NamedScalarKeyBasedWithDefaultValueHttpRequestEnricherBase
        : NamedScalarKeyBasedWithDefaultValueHttpRequestEnricherBase<string>
    {
        protected NamedScalarKeyBasedWithDefaultValueHttpRequestEnricherBase(string keyName, object defaultValue,
            string propertyName = null, Func<HttpContextBase> httpContextGetter =  null)
            : base(keyName, defaultValue, propertyName, httpContextGetter)
        {
        }
    }
}