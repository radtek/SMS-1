﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:55
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
    public partial class InterfacePanelRoleTemplateDTO
    {
        #region Constructors
  
        public InterfacePanelRoleTemplateDTO() {
        }

        public InterfacePanelRoleTemplateDTO(global::System.Guid interfacePanelRoleTemplateID, string roleName, string roleDescription, global::System.Nullable<int> roleTypeID, global::System.Nullable<int> roleSubTypeID, global::System.Nullable<int> roleCategoryID, bool isActive, bool isDeleted, global::System.Guid interfacePanelTemplateID, int interfacePanelTemplateVersionNumber, global::System.Nullable<int> roleSubCategoryID, List<InterfacePanelClaimTemplateDTO> interfacePanelClaimTemplates, InterfacePanelTemplateDTO interfacePanelTemplate) {

          this.InterfacePanelRoleTemplateID = interfacePanelRoleTemplateID;
          this.RoleName = roleName;
          this.RoleDescription = roleDescription;
          this.RoleTypeID = roleTypeID;
          this.RoleSubTypeID = roleSubTypeID;
          this.RoleCategoryID = roleCategoryID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.InterfacePanelTemplateID = interfacePanelTemplateID;
          this.InterfacePanelTemplateVersionNumber = interfacePanelTemplateVersionNumber;
          this.RoleSubCategoryID = roleSubCategoryID;
          this.InterfacePanelClaimTemplates = interfacePanelClaimTemplates;
          this.InterfacePanelTemplate = interfacePanelTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid InterfacePanelRoleTemplateID { get; set; }

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
        public global::System.Guid InterfacePanelTemplateID { get; set; }

        [DataMember]
        public int InterfacePanelTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<int> RoleSubCategoryID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<InterfacePanelClaimTemplateDTO> InterfacePanelClaimTemplates { get; set; }

        [DataMember]
        public InterfacePanelTemplateDTO InterfacePanelTemplate { get; set; }

        #endregion
    }

}
