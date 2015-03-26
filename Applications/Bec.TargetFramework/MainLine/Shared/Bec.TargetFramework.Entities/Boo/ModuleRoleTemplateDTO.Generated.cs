﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:15:00
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
    public partial class ModuleRoleTemplateDTO
    {
        #region Constructors
  
        public ModuleRoleTemplateDTO() {
        }

        public ModuleRoleTemplateDTO(global::System.Guid roleID, string roleName, string roleDescription, global::System.Nullable<int> roleTypeID, global::System.Nullable<int> roleSubTypeID, global::System.Nullable<int> roleCategoryID, bool isActive, bool isDeleted, global::System.Guid moduleTemplateID, int moduleTemplateVersionNumber, global::System.Nullable<int> roleSubCategoryID, List<ModuleClaimTemplateDTO> moduleClaimTemplates, ModuleTemplateDTO moduleTemplate) {

          this.RoleID = roleID;
          this.RoleName = roleName;
          this.RoleDescription = roleDescription;
          this.RoleTypeID = roleTypeID;
          this.RoleSubTypeID = roleSubTypeID;
          this.RoleCategoryID = roleCategoryID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ModuleTemplateID = moduleTemplateID;
          this.ModuleTemplateVersionNumber = moduleTemplateVersionNumber;
          this.RoleSubCategoryID = roleSubCategoryID;
          this.ModuleClaimTemplates = moduleClaimTemplates;
          this.ModuleTemplate = moduleTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid RoleID { get; set; }

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
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid ModuleTemplateID { get; set; }

        [DataMember]
        public int ModuleTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<int> RoleSubCategoryID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<ModuleClaimTemplateDTO> ModuleClaimTemplates { get; set; }

        [DataMember]
        public ModuleTemplateDTO ModuleTemplate { get; set; }

        #endregion
    }

}
