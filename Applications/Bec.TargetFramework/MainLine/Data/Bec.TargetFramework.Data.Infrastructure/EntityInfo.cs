using System;
using System.Data.Entity;

namespace Bec.TargetFramework.Data.Infrastructure
{
    public class EntityInfo
    {
        protected internal EntityInfo()
        {
        }

        public Object Entity { get; internal set; }

        public EntityState EntityState { get; set; }

        public bool ForceUpdate { get; set; }
    }
}