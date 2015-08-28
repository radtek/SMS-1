using System;
using System.Globalization;
using System.Threading;
using Serilog.Events;
using Bec.TargetFramework.Infrastructure.Serilog.Enricher.Infrastructure;

namespace Bec.TargetFramework.Infrastructure.Serilog.Enricher
{
    public class ThreadNameEnricher : NamedScalarEnricherBase
    {
        public ThreadNameEnricher(string propertyName) : base(propertyName)
        {
        }

        protected override object GetValue(LogEvent logEvent)
        {
            return GetValue();
        }

        internal static string GetValue()
        {
            string value = Thread.CurrentThread.Name;
            if (String.IsNullOrEmpty(value))
            {
                value = Thread.CurrentThread.ManagedThreadId.ToString(CultureInfo.InvariantCulture);
            }
            return value;
        }
    }
}