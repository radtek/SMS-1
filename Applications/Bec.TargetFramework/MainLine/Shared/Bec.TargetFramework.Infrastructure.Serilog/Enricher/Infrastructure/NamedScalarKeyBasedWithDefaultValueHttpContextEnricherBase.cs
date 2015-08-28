using System;
using System.Web;
using Serilog.Events;

namespace Serilog.Web.Extensions.Enrichers.Infrastructure
{
    public abstract class NamedScalarKeyBasedWithDefaultValueHttpContextEnricherBase<TKey>
        : NamedScalarWithDefaultValueHttpContextEnricherBase
    {
        public TKey KeyName
        {
            get { return _keyName; }
        }

        protected NamedScalarKeyBasedWithDefaultValueHttpContextEnricherBase(TKey keyName, object defaultValue,
            string propertyName = null, Func<HttpContextBase> httpContextGetter = null)
            : base(propertyName ?? (!ReferenceEquals(keyName, null) ? keyName.ToString() : null), defaultValue, httpContextGetter)
        {
            if (ReferenceEquals(keyName, null)) throw new ArgumentNullException("keyName");

            _keyName = keyName;
        }

        protected sealed override object GetWebValue(HttpContextBase httpContext, LogEvent logEvent)
        {
            object value = GetValueByKey(httpContext, _keyName);
            if (value == null)
            {
                value = GetNonWebValue(logEvent);
            }
            return value;
        }

        protected abstract object GetValueByKey(HttpContextBase httpContext, TKey key);

        private readonly TKey _keyName;
    }

    public abstract class NamedScalarKeyBasedWithDefaultValueHttpContextEnricherBase
        : NamedScalarKeyBasedWithDefaultValueHttpContextEnricherBase<string>
    {
        protected NamedScalarKeyBasedWithDefaultValueHttpContextEnricherBase(string keyName, object defaultValue,
            string propertyName = null, Func<HttpContextBase> httpContextGetter = null)
            : base(keyName, defaultValue, propertyName, httpContextGetter)
        {
        }
    }
}