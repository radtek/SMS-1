using System;
using System.Diagnostics;
using Serilog.Events;
using Bec.TargetFramework.Infrastructure.Serilog.Enricher.Infrastructure;

namespace Bec.TargetFramework.Infrastructure.Serilog.Enricher
{
    public class ProcessNameEnricher : NamedScalarEnricherBase
    {
        public ProcessNameEnricher(string propertyName) : base(propertyName)
        {
            _processName = GetValue();
        }

        protected override object GetValue(LogEvent logEvent)
        {
            return _processName;
        }

        internal static string GetValue()
        {
            string value = Process.GetCurrentProcess().ProcessName;
            return value;
        }

        private readonly string _processName;
    }
}