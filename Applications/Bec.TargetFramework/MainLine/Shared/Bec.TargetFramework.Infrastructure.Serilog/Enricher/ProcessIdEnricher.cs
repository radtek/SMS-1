using System;
using System.Diagnostics;
using Serilog.Events;
using Bec.TargetFramework.Infrastructure.Serilog.Enricher.Infrastructure;

namespace Bec.TargetFramework.Infrastructure.Serilog.Enricher
{
    public class ProcessIdEnricher : NamedScalarEnricherBase
    {
        public ProcessIdEnricher(string propertyName) : base(propertyName)
        {
            _processId = GetValue();
        }

        protected override object GetValue(LogEvent logEvent)
        {
            return _processId;
        }

        internal static int GetValue()
        {
            int value = Process.GetCurrentProcess().Id;
            return value;
        }

        private readonly int _processId;
    }
}