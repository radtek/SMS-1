using System;
using System.Diagnostics;
using Serilog.Events;
using Bec.TargetFramework.Infrastructure.Serilog.Enricher.Infrastructure;

namespace Bec.TargetFramework.Infrastructure.Serilog.Enricher
{
    public class ProcessMainModuleFileNameEnricher : NamedScalarEnricherBase
    {
        public ProcessMainModuleFileNameEnricher(string propertyName) : base(propertyName)
        {
            _processMainModuleFileName = GetValue();
        }

        protected override object GetValue(LogEvent logEvent)
        {
            return _processMainModuleFileName;
        }

        internal static string GetValue()
        {
            var mainModule = Process.GetCurrentProcess().MainModule;
            string value = mainModule.FileName;
            return value;
        }

        private readonly string _processMainModuleFileName;
    }
}