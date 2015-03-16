using System;
using Serilog.Core;

namespace Bec.TargetFramework.Infrastructure.Serilog.Enricher.Infrastructure
{
    public interface INamedLogEventEnricher : ILogEventEnricher
    {
        string PropertyName { get; }
    }
}