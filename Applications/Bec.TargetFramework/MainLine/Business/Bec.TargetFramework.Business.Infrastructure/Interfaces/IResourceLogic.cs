namespace Bec.TargetFramework.Business.Infrastructure.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    using Bec.TargetFramework.Data;
    //Bec.TargetFramework.Entities
    using Bec.TargetFramework.Infrastructure.Caching;
    using Bec.TargetFramework.Infrastructure.Log;
    using Bec.TargetFramework.Entities;

    [ServiceContract(Namespace = Bec.TargetFramework.Business.Infrastructure.BecTargetFrameworkBusinessServiceNamespaces.BusinessNamespace + "/ResourceLogic")]
    public interface IResourceLogic : IBusinessLogicService
    {
        [OperationContract]
        ResourceDTO CreateAndInitializeDTO();

        [OperationContract]
        void ActivateDeactivateResource(Guid id);        

        [OperationContract]
        List<VResourceDTO> GetAllResourceDTO(bool showDeleted);

        [OperationContract]
        ResourceDTO GetResourceDTO(Guid id);

        [OperationContract]
        void SaveResource(ResourceDTO dto, string[] selectedOperations);

        [OperationContract]
        bool DoesResourceNameExist(string Name);

        [OperationContract]
        void DeleteResource(Guid resourceID);
    }
}