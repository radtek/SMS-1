using System;
using Serilog.Core;
using Serilog.Events;

namespace Bec.TargetFramework.Infrastructure.Serilog.Enricher.Infrastructure
{
    public abstract class NamedKeyBasedWithDefaultValueEnricherBase<TKey> : NamedWithDefaultValueEnricherBase
    {
        public TKey KeyName
        {
            get { return _keyName; }
        }

        protected NamedKeyBasedWithDefaultValueEnricherBase(TKey keyName, object defaultValue, string propertyName = null)
            : base(propertyName ?? (!ReferenceEquals(keyName, null) ? keyName.ToString() : null), defaultValue)
        {
            if (ReferenceEquals(keyName, null)) throw new ArgumentNullException("keyName");

            _keyName = keyName;
        }

        protected sealed override LogEventProperty GetLogEventProperty(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            LogEventProperty logEventProperty;
            object item = GetValueByKey(KeyName);
            if (item != null)
            {
                logEventProperty = propertyFactory.CreateProperty(PropertyName, item, true);
            }
            else
            {
                logEventProperty = new LogEventProperty(PropertyName, new ScalarValue(DefaultValue));
            }
            return logEventProperty;
        }

        protected abstract object GetValueByKey(TKey key);

        private readonly TKey _keyName;
    }

    public abstract class NamedKeyBasedWithDefaultValueEnricherBase : NamedKeyBasedWithDefaultValueEnricherBase<string>
    {
        protected NamedKeyBasedWithDefaultValueEnricherBase(string keyName, object defaultValue, string propertyName = null)
            : base(keyName, defaultValue, propertyName)
        {
        }
    }
}