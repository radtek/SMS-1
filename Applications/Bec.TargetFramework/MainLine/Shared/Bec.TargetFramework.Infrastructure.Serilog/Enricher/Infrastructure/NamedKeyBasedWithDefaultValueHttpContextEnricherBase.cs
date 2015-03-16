using System;
using System.Web;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Web.Extensions.Enrichers.Infrastructure
{
    public abstract class NamedKeyBasedWithDefaultValueHttpContextEnricherBase<TKey> : NamedWithDefaultValueHttpContextEnricherBase
    {
        public TKey KeyName
        {
            get { return _keyName; }
        }

        protected NamedKeyBasedWithDefaultValueHttpContextEnricherBase(TKey keyName, object defaultValue,
            string propertyName = null, Func<HttpContextBase> httpContextGetter = null)
            : base(propertyName ?? (!ReferenceEquals(keyName, null) ? keyName.ToString() : null), defaultValue, httpContextGetter)
        {
            if (ReferenceEquals(keyName, null)) throw new ArgumentNullException("keyName");

            _keyName = keyName;
        }

        protected sealed override LogEventProperty GetLogEventWebProperty(
            HttpContextBase httpContext, LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            LogEventProperty logEventProperty;
            object item = GetValueByKey(httpContext, _keyName);
            if (item != null)
            {
                logEventProperty = propertyFactory.CreateProperty(PropertyName, item, true);
            }
            else
            {
                logEventProperty = GetLogEventNonWebProperty(logEvent, propertyFactory);
            }
            return logEventProperty;
        }

        protected abstract object GetValueByKey(HttpContextBase httpContext, TKey key);

        private readonly TKey _keyName;
    }

    public abstract class NamedKeyBasedWithDefaultValueHttpContextEnricherBase
        : NamedKeyBasedWithDefaultValueHttpContextEnricherBase<string>
    {
        protected NamedKeyBasedWithDefaultValueHttpContextEnricherBase(string keyName, object defaultValue,
            string propertyName = null, Func<HttpContextBase> httpContextGetter = null)
            : base(keyName, defaultValue, propertyName, httpContextGetter)
        {
        }
    }
}