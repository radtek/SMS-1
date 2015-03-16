using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Entities;

namespace Bec.TargetFramework.Service.LR.Interfaces.Interfaces
{
    public interface ILRServiceEngine
    {
        ILRServiceInterface ServiceInterface { get; set; }

        ILRServiceDefinition ServiceDefinition { get; set; }

        LRServiceResponseStatusDTO ServiceResponseStatus { get; set; }

        void CreateServiceRequest(ConcurrentDictionary<string, object> objectDictionary);
        LRServiceResponseDTO ProcessServiceResponse(ConcurrentDictionary<string, object> objectDictionary);

        void InitialiseServiceClient(string username, string password, string certificateSerialNumber);
        void ExecuteService();

        void CloseServiceClient();
    }
}
