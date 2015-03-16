using System;
using System.Threading;
using Serilog.Events;
using Bec.TargetFramework.Infrastructure.Serilog.Enricher.Infrastructure;

namespace Bec.TargetFramework.Infrastructure.Serilog.Enricher
{
    public class ThreadIdEnricher : NamedScalarEnricherBase
    {
        public ThreadIdEnricher(string propertyName) : base(propertyName)
        {
        }

        protected override object GetValue(LogEvent logEvent)
        {
            return GetValue();
        }

        internal static int GetValue()
        {
            int value = Thread.CurrentThread.ManagedThreadId;
            return value;
        }
    }
}