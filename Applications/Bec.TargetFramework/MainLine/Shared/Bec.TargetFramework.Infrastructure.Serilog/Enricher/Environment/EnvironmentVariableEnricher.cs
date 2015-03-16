using System;
using Bec.TargetFramework.Infrastructure.Serilog.Enricher.Infrastructure;

namespace Bec.TargetFramework.Infrastructure.Serilog.Enricher.Environment
{
    public class EnvironmentVariableEnricher : NamedKeyBasedWithDefaultValueEnricherBase
    {
        public const string DefaultPropertyValue = "N/A";

        public string EnvironmentVariableName
        {
            get { return KeyName; }
        }

        public EnvironmentVariableEnricher(string environmentVariableName, string defaultValue = DefaultPropertyValue,
            string propertyName = null) : base(environmentVariableName, defaultValue, propertyName)
        {
        }

        protected override object GetValueByKey(string key)
        {
            string value = GetValue(key);
            return value;
        }

        internal static string GetValue(string environmentVariableName)
        {
            string value = System.Environment.GetEnvironmentVariable(environmentVariableName, EnvironmentVariableTarget.Process);
            if (value == null)
            {
                value = System.Environment.GetEnvironmentVariable(environmentVariableName, EnvironmentVariableTarget.User);
            }
            if (value == null)
            {
                value = System.Environment.GetEnvironmentVariable(environmentVariableName, EnvironmentVariableTarget.Machine);
            }
            return value;
        }
    }
}