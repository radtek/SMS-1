using Bec.TargetFramework.Entities;

namespace Bec.TargetFramework.Business.Infrastructure.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    //Bec.TargetFramework.Entities
    using Bec.TargetFramework.Infrastructure.Caching;
    using Bec.TargetFramework.Infrastructure.Log;
    using Bec.TargetFramework.Data;

    [ServiceContract(Namespace = Bec.TargetFramework.Business.Infrastructure.BecTargetFrameworkBusinessServiceNamespaces.BusinessNamespace + "/DataLogic")]
    public interface IDataLogic : IBusinessLogicService
    {


        [OperationContract]
        void MarkServiceInterfaceAsPending(Guid serviceDefinitionID, Guid? productPurchaseProductTaskID,
            Guid? parentID, string data);

        [OperationContract]
        void MarkServiceInterfaceAsFailed(Guid serviceDefinitionID, Guid? productPurchaseProductTaskID,
            Guid? parentID, string data);

        [OperationContract]
        void MarkServiceInterfaceAsSuccessful(Guid serviceDefinitionID, Guid? productPurchaseProductTaskID,
            Guid? parentID, string data);

        [OperationContract]
        void MarkServiceInterfaceAsProcessing(Guid serviceDefinitionID, Guid? productPurchaseProductTaskID,
            Guid? parentID, string data);

        [OperationContract]
        ServiceDefinitionDTO GetServiceDefinitionWithDetail(string name);
        
        
        [OperationContract]
        List<VWorkflowTreeDTO> GetWorkflowTree(Guid workflowID,int workflowVersionNumber);
    [OperationContract]
    List<VStatusTypeDTO> GetStatusType(string statusTypeEnum);

        [OperationContract]
        string GenerateRandomFirstAndLastName();

        [OperationContract]
        TFEventDTO GetTFEventByName(string eventName);

        [OperationContract]
        IEnumerable<string> GenerateMultipleFirstAndLastNames(int count);

        [OperationContract]
        IEnumerable<string> GenerateMultipleLastNames(int count);

        [OperationContract]
        IEnumerable<string> GenerateMultipleFemaleFirstAndLastNames(int count);

        [OperationContract]
        IEnumerable<string> GenerateMultipleMaleFirstAndLastNames(int count);

        [OperationContract]
        IEnumerable<string> GenerateMultipleFemaleFirstNames(int count);

        [OperationContract]
        IEnumerable<string> GenerateMultipleMaleFirstNames(int count);

        [OperationContract]
        string GenerateRandomLastName();

        [OperationContract]
        string GenerateRandomFirstName();

        [OperationContract]
        string GenerateRandomFemaleFirstName();

        [OperationContract]
        string GenerateRandomMaleFirstName();

        [OperationContract]
        string GenerateRandomFemaleFirstAndLastName();

        [OperationContract]
        string GenerateRandomMaleFirstAndLastName();

        [OperationContract]
        string GenerateRandomName();

        
                
    }
}
