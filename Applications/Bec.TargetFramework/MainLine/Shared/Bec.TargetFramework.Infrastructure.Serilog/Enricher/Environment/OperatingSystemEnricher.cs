using System;
using Serilog.Events;
using Bec.TargetFramework.Infrastructure.Serilog.Enricher.Infrastructure;

namespace Bec.TargetFramework.Infrastructure.Serilog.Enricher.Environment
{
    public class OperatingSystemEnricher : NamedScalarEnricherBase
    {
        public OperatingSystemEnricher(string propertyName) : base(propertyName)
        {
            _operatingSystem = GetValue();
        }

        protected override object GetValue(LogEvent logEvent)
        {
            return _operatingSystem;
        }

        internal static string GetValue()
        {
            string value = System.Environment.OSVersion.VersionString;
            return value;
        }

        private readonly string _operatingSystem;
    }
}