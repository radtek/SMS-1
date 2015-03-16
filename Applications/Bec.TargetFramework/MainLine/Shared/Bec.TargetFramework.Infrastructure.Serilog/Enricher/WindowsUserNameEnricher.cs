using System;
using System.Security.Principal;
using Serilog.Events;
using Bec.TargetFramework.Infrastructure.Serilog.Enricher.Infrastructure;

namespace Bec.TargetFramework.Infrastructure.Serilog.Enricher
{
    public class WindowsUserNameEnricher : NamedScalarEnricherBase
    {
        public const string AnonymousValue = "ANONYMOUS";

        public WindowsUserNameEnricher(string propertyName) : base(propertyName)
        {
        }

        protected override object GetValue(LogEvent logEvent)
        {
            return GetValue();
        }

        internal static string GetValue()
        {
            string value = WindowsIdentity.GetCurrent().Name;
            if (String.IsNullOrEmpty(value))
            {
                value = AnonymousValue;
            }
            return value;
        }
    }
}