﻿using System;
using System.Collections.Generic;
using System.Reflection;

namespace Bec.TargetFramework.Data.Infrastructure.Helpers
{
    internal static class InternalCache
    {
        internal static readonly IDictionary<Tuple<Type, Type>, PropertyInfo> PrimaryKeyMapping = new Dictionary<Tuple<Type, Type>, PropertyInfo>();
    }
}
