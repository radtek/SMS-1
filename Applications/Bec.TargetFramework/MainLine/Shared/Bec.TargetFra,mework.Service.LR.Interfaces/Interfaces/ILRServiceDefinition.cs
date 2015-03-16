using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Service.LR.Interfaces.Interfaces
{
    public interface ILRServiceDefinition
    {
        object CreateAndInitialiseRequest(ConcurrentDictionary<string,object> objectDictionary);
        object ServiceRequest { get; set; }
        object ServiceResponse { get; set; }

        object ServiceClient { get; set; }

        Type ServiceClientType { get; }
    }
}
