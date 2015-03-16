using System;
using Bec.TargetFramework.Infrastructure.Serilog.Enricher.Infrastructure;

namespace Bec.TargetFramework.Infrastructure.Serilog.Enricher.Environment
{
    public class SpecialFolderPathEnricher : NamedScalarKeyBasedWithDefaultValueEnricherBase<System.Environment.SpecialFolder>
    {
        public const string DefaultPropertyValue = "N/A";

        public System.Environment.SpecialFolder SpecialFolder
        {
            get { return KeyName; }
        }

        public SpecialFolderPathEnricher(System.Environment.SpecialFolder specialFolder,
            string defaultValue = DefaultPropertyValue, string propertyName = null)
            : base(specialFolder, defaultValue, propertyName)
        {
        }

        protected override object GetValueByKey(System.Environment.SpecialFolder key)
        {
            string value = GetValue(key);
            if (String.IsNullOrEmpty(value))
            {
                return DefaultValue;
            }
            return value;
        }

        internal static string GetValue(System.Environment.SpecialFolder specialFolder)
        {
            return System.Environment.GetFolderPath(specialFolder, System.Environment.SpecialFolderOption.DoNotVerify);
        }
    }
}