using System;
using System.Web;
using Serilog.Events;

namespace Serilog.Web.Extensions.Enrichers.Infrastructure
{
    public abstract class NamedScalarWithDefaultValueHttpContextEnricherBase : NamedScalarHttpContextEnricherBase
    {
        public object DefaultValue
        {
            get { return _defaultValue; }
        }

        protected NamedScalarWithDefaultValueHttpContextEnricherBase(string propertyName, object defaultValue,
            Func<HttpContextBase> httpContextGetter = null) : base(propertyName, httpContextGetter)
        {
            _defaultValue = defaultValue;
        }

        protected override object GetNonWebValue(LogEvent logEvent)
        {
            return _defaultValue;
        }

        private readonly object _defaultValue;
    }
}