using System;
using System.Security.Principal;
using System.Threading;
using Serilog.Events;
using Bec.TargetFramework.Infrastructure.Serilog.Enricher.Infrastructure;

namespace Bec.TargetFramework.Infrastructure.Serilog.Enricher
{
    public class PrincipalIdentityNameEnricher : NamedScalarWithDefaultValueEnricherBase
    {
        public const string DefaultPropertyValue = "N/A";

        public PrincipalIdentityNameEnricher(string propertyName, string defaultValue = DefaultPropertyValue)
            : base(propertyName, defaultValue)
        {
        }

        protected override object GetValue(LogEvent logEvent)
        {
            string value = GetValue() ?? (string)DefaultValue;
            return value;
        }

        internal static string GetValue()
        {
            string value = DefaultPropertyValue;

            IPrincipal principal = Thread.CurrentPrincipal;

// ReSharper disable ConditionIsAlwaysTrueOrFalse
            if ((principal != null) && (principal.Identity != null))
// ReSharper restore ConditionIsAlwaysTrueOrFalse
            {
                value = principal.Identity.Name;
            }
            return value;
        }
    }
}