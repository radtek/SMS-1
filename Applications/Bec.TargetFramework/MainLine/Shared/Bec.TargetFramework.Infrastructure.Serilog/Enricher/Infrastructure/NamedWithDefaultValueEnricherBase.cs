using System;

namespace Bec.TargetFramework.Infrastructure.Serilog.Enricher.Infrastructure
{
    public abstract class NamedWithDefaultValueEnricherBase : NamedEnricherBase
    {
        public object DefaultValue
        {
            get { return _defaultValue; }
        }

        protected NamedWithDefaultValueEnricherBase(string propertyName, object defaultValue) : base(propertyName)
        {
            _defaultValue = defaultValue;
        }

        private readonly object _defaultValue;
    }
}