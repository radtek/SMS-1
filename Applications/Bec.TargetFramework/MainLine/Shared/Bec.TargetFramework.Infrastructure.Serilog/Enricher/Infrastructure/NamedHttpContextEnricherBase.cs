using System;
using System.Web;
using Bec.TargetFramework.Infrastructure.Serilog;
using Serilog.Core;
using Serilog.Events;
using Bec.TargetFramework.Infrastructure.Serilog.Enricher.Infrastructure;

namespace Serilog.Web.Extensions.Enrichers.Infrastructure
{
    public abstract class NamedHttpContextEnricherBase : NamedEnricherBase
    {
        protected NamedHttpContextEnricherBase(string propertyName, Func<HttpContextBase> httpContextGetter = null)
            : base(propertyName)
        {
            _httpContextGetter = httpContextGetter ?? Utilities.GetCurrentHttpContext;
        }

        protected sealed override LogEventProperty GetLogEventProperty(
            LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            var httpContext = _httpContextGetter();
            LogEventProperty logEventProperty;
            if (httpContext != null)
            {
                logEventProperty = GetLogEventWebProperty(httpContext, logEvent, propertyFactory);
            }
            else
            {
                logEventProperty = GetLogEventNonWebProperty(logEvent, propertyFactory);
            }
            return logEventProperty;
        }

        protected abstract LogEventProperty GetLogEventWebProperty(HttpContextBase httpContext,
            LogEvent logEvent, ILogEventPropertyFactory propertyFactory);

        protected abstract LogEventProperty GetLogEventNonWebProperty(
            LogEvent logEvent, ILogEventPropertyFactory propertyFactory);

        private readonly Func<HttpContextBase> _httpContextGetter;
    }
}