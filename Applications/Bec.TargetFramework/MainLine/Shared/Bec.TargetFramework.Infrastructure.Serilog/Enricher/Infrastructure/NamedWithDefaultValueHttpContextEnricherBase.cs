using System;
using System.Web;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Web.Extensions.Enrichers.Infrastructure
{
    public abstract class NamedWithDefaultValueHttpContextEnricherBase : NamedHttpContextEnricherBase
    {
        public object DefaultValue
        {
            get { return _defaultValue; }
        }

        protected NamedWithDefaultValueHttpContextEnricherBase(string propertyName, object defaultValue,
            Func<HttpContextBase> httpContextGetter = null) : base(propertyName, httpContextGetter)
        {
            _defaultValue = defaultValue;
        }

        protected override LogEventProperty GetLogEventNonWebProperty(
            LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            return new LogEventProperty(PropertyName, new ScalarValue(_defaultValue));
        }

        private readonly object _defaultValue;
    }
}