using System;
using System.Security;
using Serilog.Core;
using Serilog.Debugging;
using Serilog.Events;

namespace Bec.TargetFramework.Infrastructure.Serilog.Enricher.Infrastructure
{
    public abstract class NamedEnricherBase : INamedLogEventEnricher
    {
        public string PropertyName
        {
            get { return _propertyName; }
        }

        protected NamedEnricherBase(string propertyName = null)
        {
            if (propertyName == null) throw new ArgumentNullException("propertyName");

            _propertyName = propertyName;
        }

        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            LogEventProperty value;

            try
            {
                value = GetLogEventProperty(logEvent, propertyFactory);
            }
            catch (SecurityException e)
            {
                SelfLog.WriteLine(String.Format("{0} failed to enrich property {1} because of security error {2}",
                    GetType().Name, PropertyName, e.Message));
                value = new LogEventProperty(PropertyName, new ScalarValue("SECURITYEXCEPTION"));
            }
            catch (Exception e)
            {
                SelfLog.WriteLine(String.Format("{0} failed to enrich property {1} because of error {2}",
                    GetType().Name, PropertyName, e.Message));
                value = new LogEventProperty(PropertyName, new ScalarValue("EXCEPTION"));
            }

            logEvent.AddPropertyIfAbsent(value);
        }

        protected abstract LogEventProperty GetLogEventProperty(LogEvent logEvent, ILogEventPropertyFactory propertyFactory);

        private readonly string _propertyName;
    }
}