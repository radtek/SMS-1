using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Service.LR.Interfaces.Interfaces;

namespace Bec.TargetFramework.Service.LR.Infrastructure.Base
{
    public abstract class LRServiceDefinitionBase : ILRServiceDefinition
    {
        public virtual object CreateAndInitialiseRequest(ConcurrentDictionary<string, object> objectDictionary)
        {
            return null;
        }

        public object ServiceRequest { get; set; }

        public object ServiceResponse { get; set; }

        public object ServiceClient { get; set; }

        public abstract Type ServiceClientType { get; }
    }
}
