﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:55
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
    public partial class ModuleRoleDTO
    {
        #region Constructors
  
        public ModuleRoleDTO() {
        }

        public ModuleRoleDTO(global::System.Guid roleID, global::System.Guid moduleID, string roleName, string roleDescription, global::System.Nullable<int> roleTypeID, global::System.Nullable<int> roleSubTypeID, global::System.Nullable<int> roleCategoryID, bool isActive, bool isDeleted, int moduleVersionNumber, global::System.Nullable<int> roleSubCategoryID, List<ModuleClaimDTO> moduleClaims) {

          this.RoleID = roleID;
          this.ModuleID = moduleID;
          this.RoleName = roleName;
          this.RoleDescription = roleDescription;
          this.RoleTypeID = roleTypeID;
          this.RoleSubTypeID = roleSubTypeID;
          this.RoleCategoryID = roleCategoryID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ModuleVersionNumber = moduleVersionNumber;
          this.RoleSubCategoryID = roleSubCategoryID;
          this.ModuleClaims = moduleClaims;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid RoleID { get; set; }

        [DataMember]
        public global::System.Guid ModuleID { get; set; }

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
        public int ModuleVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<int> RoleSubCategoryID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<ModuleClaimDTO> ModuleClaims { get; set; }

        #endregion
    }

}
