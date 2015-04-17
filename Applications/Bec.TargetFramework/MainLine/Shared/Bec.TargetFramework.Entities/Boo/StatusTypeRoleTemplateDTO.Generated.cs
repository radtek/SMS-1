﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:54
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
    public partial class StatusTypeRoleTemplateDTO
    {
        #region Constructors
  
        public StatusTypeRoleTemplateDTO() {
        }

        public StatusTypeRoleTemplateDTO(global::System.Guid statusTypeRoleTemplateID, string roleName, string roleDescription, global::System.Nullable<int> roleTypeID, global::System.Nullable<int> roleSubTypeID, global::System.Nullable<int> roleCategoryID, global::System.Nullable<int> roleSubCategoryID, bool isActive, bool isDeleted, global::System.Guid statusTypeTemplateID, int statusTypeTemplateVersionNumber, StatusTypeTemplateDTO statusTypeTemplate, List<StatusTypeClaimTemplateDTO> statusTypeClaimTemplates) {

          this.StatusTypeRoleTemplateID = statusTypeRoleTemplateID;
          this.RoleName = roleName;
          this.RoleDescription = roleDescription;
          this.RoleTypeID = roleTypeID;
          this.RoleSubTypeID = roleSubTypeID;
          this.RoleCategoryID = roleCategoryID;
          this.RoleSubCategoryID = roleSubCategoryID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.StatusTypeTemplateID = statusTypeTemplateID;
          this.StatusTypeTemplateVersionNumber = statusTypeTemplateVersionNumber;
          this.StatusTypeTemplate = statusTypeTemplate;
          this.StatusTypeClaimTemplates = statusTypeClaimTemplates;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid StatusTypeRoleTemplateID { get; set; }

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
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeTemplateID { get; set; }

        [DataMember]
        public int StatusTypeTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public StatusTypeTemplateDTO StatusTypeTemplate { get; set; }

        [DataMember]
        public List<StatusTypeClaimTemplateDTO> StatusTypeClaimTemplates { get; set; }

        #endregion
    }

}
