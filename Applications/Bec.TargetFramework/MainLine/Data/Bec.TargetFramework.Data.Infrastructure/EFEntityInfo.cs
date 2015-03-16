using System;
using System.Data.Entity.Core.Objects;

namespace Bec.TargetFramework.Data.Infrastructure
{
    public class EFEntityInfo : EntityInfo
    {
        internal EFEntityInfo()
        {
        }

        internal String EntitySetName;
        internal ObjectStateEntry ObjectStateEntry;
    }
}