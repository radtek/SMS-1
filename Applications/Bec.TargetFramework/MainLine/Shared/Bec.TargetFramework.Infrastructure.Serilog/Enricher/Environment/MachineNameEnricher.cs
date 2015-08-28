using System;
using Serilog.Events;
using Bec.TargetFramework.Infrastructure.Serilog.Enricher.Infrastructure;

namespace Bec.TargetFramework.Infrastructure.Serilog.Enricher.Environment
{
    public class MachineNameEnricher : NamedScalarEnricherBase
    {
        public MachineNameEnricher(string propertyName) : base(propertyName)
        {
            _machineName = GetValue();
        }

        protected override object GetValue(LogEvent logEvent)
        {
            return _machineName;
        }

        internal static string GetValue()
        {
            string value = System.Environment.MachineName;
            return value;
        }

        private readonly string _machineName;
    }
}