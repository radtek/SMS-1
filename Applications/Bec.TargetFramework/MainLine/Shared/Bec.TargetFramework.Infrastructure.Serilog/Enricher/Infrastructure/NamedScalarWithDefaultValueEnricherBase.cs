using System;

namespace Bec.TargetFramework.Infrastructure.Serilog.Enricher.Infrastructure
{
    public abstract class NamedScalarWithDefaultValueEnricherBase : NamedScalarEnricherBase
    {
        public object DefaultValue
        {
            get { return _defaultValue; }
        }

        protected NamedScalarWithDefaultValueEnricherBase(string propertyName, object defaultValue) : base(propertyName)
        {
            _defaultValue = defaultValue;
        }

        private readonly object _defaultValue;
    }
}