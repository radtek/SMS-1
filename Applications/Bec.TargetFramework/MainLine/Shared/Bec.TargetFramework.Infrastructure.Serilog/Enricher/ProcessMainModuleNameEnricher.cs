using System;
using System.Diagnostics;
using Serilog.Events;
using Bec.TargetFramework.Infrastructure.Serilog.Enricher.Infrastructure;

namespace Bec.TargetFramework.Infrastructure.Serilog.Enricher
{
    public class ProcessMainModuleNameEnricher : NamedScalarEnricherBase
    {
        public ProcessMainModuleNameEnricher(string propertyName) : base(propertyName)
        {
            _processMainModuleName = GetValue();
        }

        protected override object GetValue(LogEvent logEvent)
        {
            return _processMainModuleName;
        }

        internal static string GetValue()
        {
            var mainModule = Process.GetCurrentProcess().MainModule;
            string value = mainModule.ModuleName;
            return value;
        }

        private readonly string _processMainModuleName;
    }
}