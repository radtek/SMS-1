namespace Bec.TargetFramework.Business.Infrastructure.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;


    using Bec.TargetFramework.Infrastructure.Caching;
    using Bec.TargetFramework.Infrastructure.Log;
    using Bec.TargetFramework.Entities;

    [ServiceContract(Namespace = Bec.TargetFramework.Business.Infrastructure.BecTargetFrameworkBusinessServiceNamespaces.BusinessNamespace + "/GroupLogic")]
    public interface IGroupLogic : IBusinessLogicService
    {
        [OperationContract]
        List<VGroupDTO> GetAllGroupDTO(bool showDeleted);

        [OperationContract]
        GroupDTO GetGroupDTO(Guid id);

        [OperationContract]
        void SaveGroup(GroupDTO dto, List<GroupRoleDTO> roles);

        [OperationContract]
        List<GroupRoleDTO> GetRoleItems(Guid groupID);

        [OperationContract]
        List<GroupDTO> GetAllGroups();

        [OperationContract]
        List<GroupRoleDTO> GetRoleItemsForGroupId(Guid groupID);

        [OperationContract]
        bool DoesGroupNameExist(string Name);

        [OperationContract]
        void DeleteGroup(Guid GroupID);

        [OperationContract]
        void ActivateDeactivateGroup(Guid id); 
    }
}