using System;
using Serilog.Events;
using Bec.TargetFramework.Infrastructure.Serilog.Enricher.Infrastructure;

namespace Bec.TargetFramework.Infrastructure.Serilog.Enricher.Environment
{
    public class CurrentDirectoryEnricher : NamedScalarEnricherBase
    {
        public CurrentDirectoryEnricher(string propertyName) : base(propertyName)
        {
        }

        protected override object GetValue(LogEvent logEvent)
        {
            return GetValue();
        }

        internal static string GetValue()
        {
            string value = System.Environment.CurrentDirectory;
            return value;
        }
    }
}