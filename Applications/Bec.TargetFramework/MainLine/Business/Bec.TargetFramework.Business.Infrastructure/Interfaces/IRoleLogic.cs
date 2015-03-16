namespace Bec.TargetFramework.Business.Infrastructure.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    //Bec.TargetFramework.Entities
    using Bec.TargetFramework.Infrastructure.Caching;
    using Bec.TargetFramework.Infrastructure.Log;
    using Bec.TargetFramework.Entities;

    [ServiceContract(Namespace = Bec.TargetFramework.Business.Infrastructure.BecTargetFrameworkBusinessServiceNamespaces.BusinessNamespace + "/RoleLogic")]
    public interface IRoleLogic : IBusinessLogicService
    {
        [OperationContract]
        List<VRoleDTO> GetAllRoleDTO(bool showDeleted);

        [OperationContract]
        RoleDTO GetRoleDTO(Guid id);

        [OperationContract]
        void SaveRole(RoleDTO dto, List<RoleClaimDescriptionDTO> claims);

        [OperationContract]
        List<RoleDTO> GetAllRoles();

        [OperationContract]
        List<RoleClaimDescriptionDTO> GetRoleClaimSourceItems(Guid roleID);

        [OperationContract]
        List<RoleClaimDescriptionDTO> GetClaimSourceItemsForRoleId(Guid roleId);

        [OperationContract]
        bool DoesRoleNameExist(string Name);

        [OperationContract]
        void DeleteRole(Guid id);

        [OperationContract]
        void ActivateDeactivateRole(Guid id); 
    }
}