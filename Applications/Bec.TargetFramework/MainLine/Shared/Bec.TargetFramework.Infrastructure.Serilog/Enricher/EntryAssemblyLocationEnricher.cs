using System;
using System.Reflection;
using Serilog.Events;
using Bec.TargetFramework.Infrastructure.Serilog.Enricher.Infrastructure;

namespace Bec.TargetFramework.Infrastructure.Serilog.Enricher
{
    public class EntryAssemblyLocationEnricher : NamedScalarEnricherBase
    {
        private const string DefaultPropertyValue = "N/A";

        public EntryAssemblyLocationEnricher(string propertyName) : base(propertyName)
        {
            _entryAssemblyLocation = GetValue();
        }

        protected override object GetValue(LogEvent logEvent)
        {
            return _entryAssemblyLocation;
        }

        internal static string GetValue()
        {
            var entryAssembly = Assembly.GetEntryAssembly();
            string value = (entryAssembly != null) ? entryAssembly.Location : DefaultPropertyValue;
            return value;
        }

        private readonly string _entryAssemblyLocation;
    }
}