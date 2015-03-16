namespace Bec.TargetFramework.Business.Infrastructure.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.ServiceModel;

    //Bec.TargetFramework.Entities
    using Bec.TargetFramework.Infrastructure.Caching;
    using Bec.TargetFramework.Infrastructure.Log;
    using Bec.TargetFramework.Entities;

    [ServiceContract(Namespace = Bec.TargetFramework.Business.Infrastructure.BecTargetFrameworkBusinessServiceNamespaces.BusinessNamespace + "/OrganisationUserStateTemplateLogic")]
    public interface IOrganisationUserStateTemplateLogic : IBusinessLogicService
    {
        [OperationContract]
        List<OrganisationUserStateTemplateDTO> GetAllOrganisationUserStateTemplateDTO();

        [OperationContract]
        OrganisationUserStateTemplateDTO GetOrganisationUserStateTemplateDTO(Guid id);

        [OperationContract]
        void SaveOrganisationUserStateTemplate(OrganisationUserStateTemplateDTO dto);

        [OperationContract]
        List<OrganisationUserStateTemplateDTO> GetAllOrganisationUserStateTemplate();

        [OperationContract]
        void DeleteOrganisationUserStateTemplate(Guid OrganisationUserStateTemplateId);

        [OperationContract(Name = "DoesOrganisationUserStateTemplateNameExistByName")]
        bool DoesOrganisationUserStateTemplateNameExist(Guid OrganisationUserStateTemplateId, string OrganisationUserStateTemplateName);

        [OperationContract(Name="DoesOrganisationUserStateTemplateNameExist")]
        bool DoesOrganisationUserStateTemplateNameExist(string OrganisationUserStateTemplateName);

    }
}