
using System;
using System.Collections.Generic;
using System.ServiceModel;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business.Infrastructure.Interfaces
{
    [ServiceContract(Namespace = Bec.TargetFramework.Business.Infrastructure.BecTargetFrameworkBusinessServiceNamespaces.BusinessNamespace + "/OrganisationLogicService")]
    public interface IOrganisationLogic : IBusinessLogicService
    {

        [OperationContract]
        List<PostCodeDTO> FindAddressesByPostCode(string postCode, string building);

        [OperationContract]
        GoogleGeoCodeResponse GeoCodePostcode(string postCode);

        [OperationContract]
        Guid AddNewUnverifiedOrganisationAndAdministrator(OrganisationTypeEnum organisationType, Bec.TargetFramework.Entities.AddCompanyDTO dto);

        [OperationContract]
        List<OrganisationDTO> GetOrgansationBranchDTOs(Guid orgId);

        [OperationContract]
        Guid? GetTemporaryOrganisationBranchID();

        [OperationContract]
        void ActivateDeactivateOrDeleteOrganisation(Guid id, bool delete = false);
        [OperationContract]
        void ActivateOrDeactivateOrganisationLogo(Guid attachmentDetailID);
        [OperationContract]
        void AddNewOrganisationFromWizard(Bec.TargetFramework.Entities.OrganisationDTO dto);
        [OperationContract]
        void DefaultOrganisationLogo(Guid organisationID, Guid attachmentDetailID);
        [OperationContract]
        void DeleteOrganisationBranch(Guid contactID);
        [OperationContract]
        void DeleteOrganisationUnit(int unitID);
        [OperationContract]
        bool DoesOrganisationBranchExist(string name);
        [OperationContract]
        bool DoesOrganisationLogoExist(string Name);
        [OperationContract]
        bool DoesOrganisationNameExist(string Name);
        [OperationContract]
        bool DoesOrganisationUnitExist(string Name);
        [OperationContract]
        System.Collections.Generic.List<Bec.TargetFramework.Entities.AddressDTO> GetAllBranchAddresses(Guid id);
        [OperationContract]
        System.Collections.Generic.List<Bec.TargetFramework.Entities.ContactDTO> GetAllBranches(Guid orgId);
        [OperationContract]
        System.Collections.Generic.List<Bec.TargetFramework.Entities.vOrganisationDTO> GetAllOrganisationDetailDTO(string searchText);
        [OperationContract]
        Bec.TargetFramework.Entities.vBranchDTO GetOrganisationBranch(int branchID);
        [OperationContract]
        System.Collections.Generic.List<Bec.TargetFramework.Entities.vBranchDTO> GetOrganisationBranches(Guid orgId);
        [OperationContract]
        System.Collections.Generic.List<Bec.TargetFramework.Entities.OrganisationDetailDTO> GetOrganisationDetails();
        [OperationContract]
        System.Collections.Generic.List<Bec.TargetFramework.Entities.OrganisationDetailDTO> GetOrganisationDetailsIncludingBranches(string id);
        [OperationContract]
        Bec.TargetFramework.Entities.vOrganisationDTO GetOrganisationDTO(Guid id);
        [OperationContract]
        Bec.TargetFramework.Entities.vAttachmentDTO GetOrganisationLogo(Guid attachmentDetailID);
        [OperationContract]
        System.Collections.Generic.List<Bec.TargetFramework.Entities.vAttachmentDTO> GetOrganisationLogos(Guid orgId);
        [OperationContract]
        Bec.TargetFramework.Entities.OrganisationUnitDTO GetOrganisationUnit(int unitID);
        [OperationContract]
        System.Collections.Generic.List<Bec.TargetFramework.Entities.OrganisationUnitDTO> GetOrganisationUnits(Guid orgId);
        [OperationContract]     
        System.Collections.Generic.List<Bec.TargetFramework.Entities.GroupDTO> GetOrgGroups(Guid orgId);
        [OperationContract]
        System.Collections.Generic.List<Bec.TargetFramework.Entities.GroupDTO> GetOrgGroupsforOrgId(Guid orgId);
        [OperationContract]
        System.Collections.Generic.List<Bec.TargetFramework.Entities.RoleDTO> GetOrgRoles(Guid orgId);
        [OperationContract]
        System.Collections.Generic.List<Bec.TargetFramework.Entities.RoleDTO> GetOrgRolesforOrgId(Guid orgId);
        [OperationContract]
        void SaveOrganisationBranch(Bec.TargetFramework.Entities.ContactDTO dto);
        [OperationContract]
        void SaveOrganisationDetail(Bec.TargetFramework.Entities.OrganisationDTO dto);
        [OperationContract]
        void SaveOrganisationLogo(Bec.TargetFramework.Entities.vAttachmentDTO dto);
        [OperationContract]
        void SaveOrganisationUnit(Bec.TargetFramework.Entities.OrganisationUnitDTO dto);
        [OperationContract]
        System.Collections.Generic.List<Bec.TargetFramework.Entities.VOrganisationTemplateDTO> GetOrganisationTemplatesforOrganisationType(int typeId);

        [OperationContract]
        List<Bec.TargetFramework.Entities.VOrganisationWithStatusAndAdminDTO> GetCompanies(Bec.TargetFramework.Entities.Enums.ProfessionalOrganisationStatusEnum orgStatus);
    }
}
