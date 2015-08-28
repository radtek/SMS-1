using System;
using Serilog.Events;
using Bec.TargetFramework.Infrastructure.Serilog.Enricher.Infrastructure;

namespace Bec.TargetFramework.Infrastructure.Serilog.Enricher.Environment
{
    public class ExpandEnvironmentVariablesEnricher : NamedScalarEnricherBase
    {
        public string EnvironmentVariablesExpandFormat
        {
            get { return _environmentVariablesExpandFormat; }
        }

        public ExpandEnvironmentVariablesEnricher(string environmentVariablesExpandFormat, string propertyName)
            : base(propertyName)
        {
            if (environmentVariablesExpandFormat == null) throw new ArgumentNullException("environmentVariablesExpandFormat");

            _environmentVariablesExpandFormat = environmentVariablesExpandFormat;
        }

        protected override object GetValue(LogEvent logEvent)
        {
            return GetValue(_environmentVariablesExpandFormat);
        }

        internal static object GetValue(string environmentVariablesExpandFormat)
        {
            string value = System.Environment.ExpandEnvironmentVariables(environmentVariablesExpandFormat);
            return value;
        }

        private readonly string _environmentVariablesExpandFormat;
    }
}