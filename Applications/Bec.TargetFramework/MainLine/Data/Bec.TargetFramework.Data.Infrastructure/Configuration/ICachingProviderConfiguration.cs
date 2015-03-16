using System;
using System.Collections.Generic;
using Bec.TargetFramework.Data.Infrastructure.Caching;

namespace Bec.TargetFramework.Data.Infrastructure.Configuration
{
    public interface ICachingProviderConfiguration
    {
        string Name { get; set; }
        Type Factory { get; set; }
        IDictionary<string, string> Attributes { get; set; }
        string this[string key] { get; }

        ICachingProvider GetInstance();
    }
}
