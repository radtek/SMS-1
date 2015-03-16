using System;
using Serilog.Core;
using Serilog.Events;

namespace Bec.TargetFramework.Infrastructure.Serilog.Enricher.Infrastructure
{
    public abstract class NamedScalarEnricherBase : NamedEnricherBase
    {
        protected NamedScalarEnricherBase(string propertyName) : base(propertyName)
        {
        }

        protected sealed override LogEventProperty GetLogEventProperty(LogEvent logEvent,
            ILogEventPropertyFactory propertyFactory)
        {
            var scalarValue = new ScalarValue(GetValue(logEvent));
            return new LogEventProperty(PropertyName, scalarValue);
        }

        protected abstract object GetValue(LogEvent logEvent);
    }
}