using System;
using Serilog.Events;
using Bec.TargetFramework.Infrastructure.Serilog.Enricher.Infrastructure;
using Bec.TargetFramework.Infrastructure.Serilog.Enricher.Infrastructure;

namespace Bec.TargetFramework.Infrastructure.Serilog.Enricher
{
    public class AppDomainFriendlyNameEnricher : NamedScalarEnricherBase
    {
        public AppDomainFriendlyNameEnricher(string propertyName) : base(propertyName)
        {
        }

        protected override object GetValue(LogEvent logEvent)
        {
            return GetValue();
        }

        internal static string GetValue()
        {
            string value = AppDomain.CurrentDomain.FriendlyName;
            return value;
        }
    }
}