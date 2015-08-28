using System;
using System.Reflection;
using Serilog.Events;
using Bec.TargetFramework.Infrastructure.Serilog.Enricher.Infrastructure;

namespace Bec.TargetFramework.Infrastructure.Serilog.Enricher
{
    public class EntryAssemblyFullNameEnricher : NamedScalarEnricherBase
    {
        private const string DefaultPropertyValue = "N/A";

        public EntryAssemblyFullNameEnricher(string propertyName) : base(propertyName)
        {
            _entryAssemblyFullName = GetValue();
        }

        protected override object GetValue(LogEvent logEvent)
        {
            return _entryAssemblyFullName;
        }

        internal static string GetValue()
        {
            var entryAssembly = Assembly.GetEntryAssembly();
            string value = (entryAssembly != null) ? entryAssembly.FullName : DefaultPropertyValue;
            return value;
        }

        private readonly string _entryAssemblyFullName;
    }
}