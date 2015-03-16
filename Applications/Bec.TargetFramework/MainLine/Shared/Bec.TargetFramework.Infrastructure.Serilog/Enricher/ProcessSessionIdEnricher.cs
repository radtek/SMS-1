using System;
using System.Diagnostics;
using Serilog.Events;
using Bec.TargetFramework.Infrastructure.Serilog.Enricher.Infrastructure;

namespace Bec.TargetFramework.Infrastructure.Serilog.Enricher
{
    public class ProcessSessionIdEnricher : NamedScalarEnricherBase
    {
        public ProcessSessionIdEnricher(string propertyName) : base(propertyName)
        {
            _processSessionId = GetValue();
        }

        protected override object GetValue(LogEvent logEvent)
        {
            return _processSessionId;
        }

        internal static int GetValue()
        {
            int value = Process.GetCurrentProcess().SessionId;
            return value;
        }

        private readonly int _processSessionId;
    }
}