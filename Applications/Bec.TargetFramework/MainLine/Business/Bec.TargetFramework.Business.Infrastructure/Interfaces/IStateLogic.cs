namespace Bec.TargetFramework.Business.Infrastructure.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    //Bec.TargetFramework.Entities
    using Bec.TargetFramework.Infrastructure.Caching;
    using Bec.TargetFramework.Infrastructure.Log;
    using Bec.TargetFramework.Entities;

    [ServiceContract(Namespace = Bec.TargetFramework.Business.Infrastructure.BecTargetFrameworkBusinessServiceNamespaces.BusinessNamespace + "/StateLogic")]
    public interface IStateLogic : IBusinessLogicService
    {
        [OperationContract]
        List<StateDTO> GetAllStateDTO(bool showDeleted);

        [OperationContract]
        StateDTO GetStateDTO(Guid id);

        [OperationContract]
        void SaveState(StateDTO dto);

        [OperationContract]
        List<StateItemSlimDTO> GetParentStateItems(Guid stateId, string currentName);

        [OperationContract]
        List<StateItemSlimDTO> GetStateItemSlimDTOsForStateID(Guid stateId);

        [OperationContract]
        StateItemSlimDTO GetStateItemSlimDTO(Guid stateItemId);

        [OperationContract]
        List<StateItemDTO> GetStateItemTreeDTOForStateID(Guid stateItemId);

        [OperationContract]
        void SaveStateItem(StateItemSlimDTO dto);

        [OperationContract]
        void DeleteStateItem(Guid stateItemID);

        [OperationContract]
        bool DoesStateNameExist(string Name);

        [OperationContract]
        bool DoesStateItemNameExist(string Name);

        [OperationContract]
        void DeleteState(Guid stateID);

        [OperationContract]
        void ActivateDeactivateState(Guid id); 
    }
}