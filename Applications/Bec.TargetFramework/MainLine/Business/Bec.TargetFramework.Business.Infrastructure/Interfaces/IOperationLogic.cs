namespace Bec.TargetFramework.Business.Infrastructure.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    //Bec.TargetFramework.Entities
    using Bec.TargetFramework.Infrastructure.Caching;
    using Bec.TargetFramework.Infrastructure.Log;
    using Bec.TargetFramework.Entities;

    [ServiceContract(Namespace = Bec.TargetFramework.Business.Infrastructure.BecTargetFrameworkBusinessServiceNamespaces.BusinessNamespace + "/OperationLogic")]
    public interface IOperationLogic : IBusinessLogicService
    {
        [OperationContract]
        List<VOperationDTO> GetAllOperationDTO(bool showDeleted);

        [OperationContract]
        OperationDTO GetOperationDTO(Guid id);

        [OperationContract]
        void SaveOperation(OperationDTO dto);

        [OperationContract]
        bool DoesOperationNameExist(string Name);

        [OperationContract]
        void DeleteOperation(Guid id);

        [OperationContract]
        void ActivateDeactivateOperation(Guid id);

    }
}