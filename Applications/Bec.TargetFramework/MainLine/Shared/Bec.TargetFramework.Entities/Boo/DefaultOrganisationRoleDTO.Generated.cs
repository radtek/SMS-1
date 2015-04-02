﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:50
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
    public partial class DefaultOrganisationRoleDTO
    {
        #region Constructors
  
        public DefaultOrganisationRoleDTO() {
        }

        public DefaultOrganisationRoleDTO(global::System.Guid defaultOrganisationRoleID, global::System.Guid defaultOrganisationID, string roleName, string roleDescription, global::System.Nullable<int> roleTypeID, global::System.Nullable<int> roleSubTypeID, global::System.Nullable<int> roleCategoryID, global::System.Nullable<int> roleSubCategoryID, global::System.Nullable<System.Guid> parentID, global::System.Nullable<System.Guid> roleID, bool isActive, bool isDeleted, global::System.Nullable<bool> isDefaultOrganisationSpecific, int defaultOrganisationVersionNumber, List<DefaultOrganisationRoleClaimDTO> defaultOrganisationRoleClaims, List<DefaultOrganisationRoleTargetDTO> defaultOrganisationRoleTargets, List<DefaultOrganisationGroupRoleDTO> defaultOrganisationGroupRoles, DefaultOrganisationDTO defaultOrganisation, RoleDTO role) {

          this.DefaultOrganisationRoleID = defaultOrganisationRoleID;
          this.DefaultOrganisationID = defaultOrganisationID;
          this.RoleName = roleName;
          this.RoleDescription = roleDescription;
          this.RoleTypeID = roleTypeID;
          this.RoleSubTypeID = roleSubTypeID;
          this.RoleCategoryID = roleCategoryID;
          this.RoleSubCategoryID = roleSubCategoryID;
          this.ParentID = parentID;
          this.RoleID = roleID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsDefaultOrganisationSpecific = isDefaultOrganisationSpecific;
          this.DefaultOrganisationVersionNumber = defaultOrganisationVersionNumber;
          this.DefaultOrganisationRoleClaims = defaultOrganisationRoleClaims;
          this.DefaultOrganisationRoleTargets = defaultOrganisationRoleTargets;
          this.DefaultOrganisationGroupRoles = defaultOrganisationGroupRoles;
          this.DefaultOrganisation = defaultOrganisation;
          this.Role = role;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DefaultOrganisationRoleID { get; set; }

        [DataMember]
        public global::System.Guid DefaultOrganisationID { get; set; }

        [DataMember]
        public string RoleName { get; set; }

        [DataMember]
        public string RoleDescription { get; set; }

        [DataMember]
        public global::System.Nullable<int> RoleTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> RoleSubTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> RoleCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<int> RoleSubCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> RoleID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsDefaultOrganisationSpecific { get; set; }

        [DataMember]
        public int DefaultOrganisationVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<DefaultOrganisationRoleClaimDTO> DefaultOrganisationRoleClaims { get; set; }

        [DataMember]
        public List<DefaultOrganisationRoleTargetDTO> DefaultOrganisationRoleTargets { get; set; }

        [DataMember]
        public List<DefaultOrganisationGroupRoleDTO> DefaultOrganisationGroupRoles { get; set; }

        [DataMember]
        public DefaultOrganisationDTO DefaultOrganisation { get; set; }

        [DataMember]
        public RoleDTO Role { get; set; }

        #endregion
    }

}
