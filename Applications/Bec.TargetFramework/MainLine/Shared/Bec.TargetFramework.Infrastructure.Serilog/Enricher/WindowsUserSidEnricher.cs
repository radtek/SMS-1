using System;
using System.Security.Principal;
using Serilog.Events;
using Bec.TargetFramework.Infrastructure.Serilog.Enricher.Infrastructure;

namespace Bec.TargetFramework.Infrastructure.Serilog.Enricher
{
    public class WindowsUserSidEnricher : NamedScalarEnricherBase
    {
        public static readonly string AnonymousValue = new SecurityIdentifier(WellKnownSidType.AnonymousSid, null).Value;

        public WindowsUserSidEnricher(string propertyName) : base(propertyName)
        {
        }

        protected override object GetValue(LogEvent logEvent)
        {
            return GetValue();
        }

        internal static string GetValue()
        {
            SecurityIdentifier userSid = WindowsIdentity.GetCurrent().User;
            string value = (userSid != null) ? userSid.Value : AnonymousValue;
            return value;
        }
    }
}