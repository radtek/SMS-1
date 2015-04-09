﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:50:53
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{

    [DataContractAttribute(IsReference=true)]
    [System.Serializable]
    public partial class OrganisationRoleDTO
    {
        #region Constructors
  
        public OrganisationRoleDTO() {
        }

        public OrganisationRoleDTO(global::System.Guid organisationRoleID, global::System.Guid organisationID, global::System.Nullable<System.Guid> parentOrganisationRoleID, string roleName, global::System.Nullable<System.Guid> parentRootRoleID, bool isManaged, global::System.Nullable<int> roleTypeID, global::System.Nullable<int> roleSubTypeID, global::System.Nullable<int> roleCategoryID, bool isActive, bool isDeleted, string roleDescription, global::System.Nullable<int> roleSubCategoryID, global::System.Nullable<System.Guid> parentID, List<OrganisationGroupRoleDTO> organisationGroupRoles, List<OrganisationRoleClaimDTO> organisationRoleClaims, List<UserAccountOrganisationRoleDTO> userAccountOrganisationRoles, List<OrganisationUnitOrganisationRoleDTO> organisationUnitOrganisationRoles, List<AttachmentDetailRoleDTO> attachmentDetailRoles, List<RepositoryStructureRoleDTO> repositoryStructureRoles, OrganisationDTO organisation) {

          this.OrganisationRoleID = organisationRoleID;
          this.OrganisationID = organisationID;
          this.ParentOrganisationRoleID = parentOrganisationRoleID;
          this.RoleName = roleName;
          this.ParentRootRoleID = parentRootRoleID;
          this.IsManaged = isManaged;
          this.RoleTypeID = roleTypeID;
          this.RoleSubTypeID = roleSubTypeID;
          this.RoleCategoryID = roleCategoryID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.RoleDescription = roleDescription;
          this.RoleSubCategoryID = roleSubCategoryID;
          this.ParentID = parentID;
          this.OrganisationGroupRoles = organisationGroupRoles;
          this.OrganisationRoleClaims = organisationRoleClaims;
          this.UserAccountOrganisationRoles = userAccountOrganisationRoles;
          this.OrganisationUnitOrganisationRoles = organisationUnitOrganisationRoles;
          this.AttachmentDetailRoles = attachmentDetailRoles;
          this.RepositoryStructureRoles = repositoryStructureRoles;
          this.Organisation = organisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid OrganisationRoleID { get; set; }

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentOrganisationRoleID { get; set; }

        [DataMember]
        public string RoleName { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentRootRoleID { get; set; }

        [DataMember]
        public bool IsManaged { get; set; }

        [DataMember]
        public global::System.Nullable<int> RoleTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> RoleSubTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> RoleCategoryID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public string RoleDescription { get; set; }

        [DataMember]
        public global::System.Nullable<int> RoleSubCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<OrganisationGroupRoleDTO> OrganisationGroupRoles { get; set; }

        [DataMember]
        public List<OrganisationRoleClaimDTO> OrganisationRoleClaims { get; set; }

        [DataMember]
        public List<UserAccountOrganisationRoleDTO> UserAccountOrganisationRoles { get; set; }

        [DataMember]
        public List<OrganisationUnitOrganisationRoleDTO> OrganisationUnitOrganisationRoles { get; set; }

        [DataMember]
        public List<AttachmentDetailRoleDTO> AttachmentDetailRoles { get; set; }

        [DataMember]
        public List<RepositoryStructureRoleDTO> RepositoryStructureRoles { get; set; }

        [DataMember]
        public OrganisationDTO Organisation { get; set; }

        #endregion
    }

}
