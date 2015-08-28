using System;
using System.Web;
using Serilog.Core;
using Serilog.Events;

namespace Serilog.Web.Extensions.Enrichers.Infrastructure
{
    public abstract class NamedScalarHttpContextEnricherBase : NamedHttpContextEnricherBase
    {
        protected NamedScalarHttpContextEnricherBase(string propertyName, Func<HttpContextBase> httpContextGetter = null)
            : base(propertyName, httpContextGetter)
        {
        }

        protected sealed override LogEventProperty GetLogEventWebProperty(HttpContextBase httpContext,
            LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var scalarValue = new ScalarValue(GetWebValue(httpContext, logEvent));
            return new LogEventProperty(PropertyName, scalarValue);
        }

        protected sealed override LogEventProperty GetLogEventNonWebProperty(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var scalarValue = new ScalarValue(GetNonWebValue(logEvent));
            return new LogEventProperty(PropertyName, scalarValue);
        }

        protected abstract object GetWebValue(HttpContextBase httpContext, LogEvent logEvent);
        protected abstract object GetNonWebValue(LogEvent logEvent);
    }
}