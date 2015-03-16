using System;
using System.Runtime.Remoting.Messaging;
using Bec.TargetFramework.Infrastructure.Serilog.Enricher.Infrastructure;

namespace Bec.TargetFramework.Infrastructure.Serilog.Enricher
{
    public class CallContextLogicalDataSlotEnricher : NamedKeyBasedWithDefaultValueEnricherBase
    {
        public const string DefaultPropertyValue = "N/A";

        public string DataSlotName
        {
            get { return KeyName; }
        }

        public CallContextLogicalDataSlotEnricher(string dataSlotName, string defaultValue = DefaultPropertyValue,
            string propertyName = null) : base(dataSlotName, defaultValue, propertyName)
        {
        }

        protected override object GetValueByKey(string key)
        {
            return GetValue(key);
        }

        internal static object GetValue(string key)
        {
            object value = CallContext.LogicalGetData(key);
            return value;
        }
    }
}