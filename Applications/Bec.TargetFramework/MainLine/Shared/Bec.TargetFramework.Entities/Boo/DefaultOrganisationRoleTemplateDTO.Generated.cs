﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
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
    public partial class DefaultOrganisationRoleTemplateDTO
    {
        #region Constructors
  
        public DefaultOrganisationRoleTemplateDTO() {
        }

        public DefaultOrganisationRoleTemplateDTO(global::System.Guid defaultOrganisationRoleTemplateID, global::System.Guid defaultOrganisationTemplateID, string roleName, string roleDescription, global::System.Nullable<int> roleTypeID, global::System.Nullable<int> roleSubTypeID, global::System.Nullable<int> roleCategoryID, global::System.Nullable<int> roleSubCategoryID, global::System.Nullable<System.Guid> parentID, global::System.Nullable<System.Guid> roleID, bool isActive, bool isDeleted, global::System.Nullable<bool> isDefaultOrganisationSpecific, int defaultOrganisationTemplateVersionNumber, bool isDefault, DefaultOrganisationTemplateDTO defaultOrganisationTemplate, RoleDTO role, List<DefaultOrganisationGroupRoleTemplateDTO> defaultOrganisationGroupRoleTemplates, List<DefaultOrganisationRoleClaimTemplateDTO> defaultOrganisationRoleClaimTemplates, List<DefaultOrganisationRoleTargetTemplateDTO> defaultOrganisationRoleTargetTemplates) {

          this.DefaultOrganisationRoleTemplateID = defaultOrganisationRoleTemplateID;
          this.DefaultOrganisationTemplateID = defaultOrganisationTemplateID;
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
          this.DefaultOrganisationTemplateVersionNumber = defaultOrganisationTemplateVersionNumber;
          this.IsDefault = isDefault;
          this.DefaultOrganisationTemplate = defaultOrganisationTemplate;
          this.Role = role;
          this.DefaultOrganisationGroupRoleTemplates = defaultOrganisationGroupRoleTemplates;
          this.DefaultOrganisationRoleClaimTemplates = defaultOrganisationRoleClaimTemplates;
          this.DefaultOrganisationRoleTargetTemplates = defaultOrganisationRoleTargetTemplates;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DefaultOrganisationRoleTemplateID { get; set; }

        [DataMember]
        public global::System.Guid DefaultOrganisationTemplateID { get; set; }

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
        public int DefaultOrganisationTemplateVersionNumber { get; set; }

        [DataMember]
        public bool IsDefault { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public DefaultOrganisationTemplateDTO DefaultOrganisationTemplate { get; set; }

        [DataMember]
        public RoleDTO Role { get; set; }

        [DataMember]
        public List<DefaultOrganisationGroupRoleTemplateDTO> DefaultOrganisationGroupRoleTemplates { get; set; }

        [DataMember]
        public List<DefaultOrganisationRoleClaimTemplateDTO> DefaultOrganisationRoleClaimTemplates { get; set; }

        [DataMember]
        public List<DefaultOrganisationRoleTargetTemplateDTO> DefaultOrganisationRoleTargetTemplates { get; set; }

        #endregion
    }

}
