using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Service.LR.Interfaces.Interfaces;

namespace Bec.TargetFramework.Service.LR.Infrastructure.Base
{
    public class LRServiceEngineBase : ILRServiceEngine
    {
        public ILRServiceInterface ServiceInterface { get; set; }
        public ILogger Logger { get; set; }
        public ILRServiceDefinition ServiceDefinition { get; set; }
        public LRServiceResponseStatusDTO ServiceResponseStatus { get; set; }

        public LRServiceEngineBase(ILogger logger)
        {
            Logger = logger;
        }

        public virtual void CreateServiceRequest(System.Collections.Concurrent.ConcurrentDictionary<string, object> objectDictionary)
        {
        }

        public virtual LRServiceResponseDTO ProcessServiceResponse(ConcurrentDictionary<string, object> objectDictionary)
        {
            return null;
        }

        public virtual void ExecuteService()
        {
        }

        public virtual void CloseServiceClient()
        {
            
        }

        public virtual void InitialiseServiceClient(string username, string password, string certificateSerialNumber)
        {
        }

    }
}
