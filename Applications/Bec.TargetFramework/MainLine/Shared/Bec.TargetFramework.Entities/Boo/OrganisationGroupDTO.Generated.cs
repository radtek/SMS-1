﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:06 PM
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
    public partial class OrganisationGroupDTO
    {
        #region Constructors
  
        public OrganisationGroupDTO() {
        }

        public OrganisationGroupDTO(global::System.Guid organisationGroupID, string groupName, global::System.Guid organisationID, global::System.Nullable<System.Guid> parentID, global::System.Nullable<System.Guid> parentOrganisationGroupID, global::System.Nullable<System.Guid> parentRootGroupID, bool isManaged, global::System.Nullable<int> groupTypeID, global::System.Nullable<int> groupSubTypeID, global::System.Nullable<int> groupCategoryID, bool isActive, bool isDeleted, string groupDescription, global::System.Nullable<int> groupSubCategoryID, List<OrganisationGroupRoleDTO> organisationGroupRoles, List<OrganisationUnitOrganisationGroupDTO> organisationUnitOrganisationGroups, List<RepositoryStructureGroupDTO> repositoryStructureGroups, List<UserAccountOrganisationGroupDTO> userAccountOrganisationGroups, OrganisationDTO organisation, List<AttachmentDetailGroupDTO> attachmentDetailGroups) {

          this.OrganisationGroupID = organisationGroupID;
          this.GroupName = groupName;
          this.OrganisationID = organisationID;
          this.ParentID = parentID;
          this.ParentOrganisationGroupID = parentOrganisationGroupID;
          this.ParentRootGroupID = parentRootGroupID;
          this.IsManaged = isManaged;
          this.GroupTypeID = groupTypeID;
          this.GroupSubTypeID = groupSubTypeID;
          this.GroupCategoryID = groupCategoryID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.GroupDescription = groupDescription;
          this.GroupSubCategoryID = groupSubCategoryID;
          this.OrganisationGroupRoles = organisationGroupRoles;
          this.OrganisationUnitOrganisationGroups = organisationUnitOrganisationGroups;
          this.RepositoryStructureGroups = repositoryStructureGroups;
          this.UserAccountOrganisationGroups = userAccountOrganisationGroups;
          this.Organisation = organisation;
          this.AttachmentDetailGroups = attachmentDetailGroups;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid OrganisationGroupID { get; set; }

        [DataMember]
        public string GroupName { get; set; }

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentOrganisationGroupID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentRootGroupID { get; set; }

        [DataMember]
        public bool IsManaged { get; set; }

        [DataMember]
        public global::System.Nullable<int> GroupTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> GroupSubTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> GroupCategoryID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public string GroupDescription { get; set; }

        [DataMember]
        public global::System.Nullable<int> GroupSubCategoryID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<OrganisationGroupRoleDTO> OrganisationGroupRoles { get; set; }

        [DataMember]
        public List<OrganisationUnitOrganisationGroupDTO> OrganisationUnitOrganisationGroups { get; set; }

        [DataMember]
        public List<RepositoryStructureGroupDTO> RepositoryStructureGroups { get; set; }

        [DataMember]
        public List<UserAccountOrganisationGroupDTO> UserAccountOrganisationGroups { get; set; }

        [DataMember]
        public OrganisationDTO Organisation { get; set; }

        [DataMember]
        public List<AttachmentDetailGroupDTO> AttachmentDetailGroups { get; set; }

        #endregion
    }

}
