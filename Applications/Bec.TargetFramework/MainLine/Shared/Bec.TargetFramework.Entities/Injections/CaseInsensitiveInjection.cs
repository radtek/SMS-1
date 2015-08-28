﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Omu.ValueInjecter;

namespace Bec.TargetFramework.Entities.Injections
{
    public class CaseInsensitiveInjection : ConventionInjection
    {
        protected override bool Match(ConventionInfo c)
        {
            return c.SourceProp.Name.ToLower() == c.TargetProp.Name.ToLower() &&
                (c.SourceProp.Type == c.TargetProp.Type
              || c.SourceProp.Type == Nullable.GetUnderlyingType(c.TargetProp.Type)
              || (Nullable.GetUnderlyingType(c.SourceProp.Type) == c.TargetProp.Type
                && c.SourceProp.Value != null)
              );
        }

        protected override object SetValue(ConventionInfo c)
        {
            return c.SourceProp.Value;
        }
    }
}
