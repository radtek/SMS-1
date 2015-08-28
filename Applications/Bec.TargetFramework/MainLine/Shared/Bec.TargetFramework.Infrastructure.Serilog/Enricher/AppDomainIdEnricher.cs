using System;
using Serilog.Events;
using Bec.TargetFramework.Infrastructure.Serilog.Enricher.Infrastructure;

namespace Bec.TargetFramework.Infrastructure.Serilog.Enricher
{
    public class AppDomainIdEnricher : NamedScalarEnricherBase
    {
        public AppDomainIdEnricher(string propertyName) : base(propertyName)
        {
        }

        protected override object GetValue(LogEvent logEvent)
        {
            return GetValue();
        }

        internal static int GetValue()
        {
            int value = AppDomain.CurrentDomain.Id;
            return value;
        }
    }
}