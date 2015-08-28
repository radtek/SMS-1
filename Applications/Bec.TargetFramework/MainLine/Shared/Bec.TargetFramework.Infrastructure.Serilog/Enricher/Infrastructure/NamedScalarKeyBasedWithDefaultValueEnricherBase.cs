using System;
using Serilog.Events;

namespace Bec.TargetFramework.Infrastructure.Serilog.Enricher.Infrastructure
{
    public abstract class NamedScalarKeyBasedWithDefaultValueEnricherBase<TKey> : NamedScalarWithDefaultValueEnricherBase
    {
        public TKey KeyName
        {
            get { return _keyName; }
        }

        protected NamedScalarKeyBasedWithDefaultValueEnricherBase(TKey keyName, object defaultValue, string propertyName = null)
            : base(propertyName ?? (!ReferenceEquals(keyName, null) ? keyName.ToString() : null), defaultValue)
        {
            if (ReferenceEquals(keyName, null)) throw new ArgumentNullException("keyName");

            _keyName = keyName;
        }

        protected sealed override object GetValue(LogEvent logEvent)
        {
            return GetValueByKey(_keyName);
        }

        protected abstract object GetValueByKey(TKey key);

        private readonly TKey _keyName;
    }

    public abstract class NamedScalarKeyBasedWithDefaultValueEnricherBase : NamedScalarKeyBasedWithDefaultValueEnricherBase<string>
    {
        protected NamedScalarKeyBasedWithDefaultValueEnricherBase(string keyName, object defaultValue, string propertyName = null)
            : base(keyName, defaultValue, propertyName)
        {
        }
    }
}