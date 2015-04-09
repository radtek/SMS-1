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
    public partial class ArtefactRoleTemplateDTO
    {
        #region Constructors
  
        public ArtefactRoleTemplateDTO() {
        }

        public ArtefactRoleTemplateDTO(global::System.Guid artefactRoleTemplateID, global::System.Nullable<System.Guid> artefactTemplateID, global::System.Nullable<int> artefactTemplateVersionNumber, string roleName, string roleDescription, global::System.Nullable<int> roleTypeID, global::System.Nullable<int> roleSubTypeID, global::System.Nullable<int> roleCategoryID, global::System.Nullable<int> roleSubCategoryID, bool isActive, bool isDeleted, List<ArtefactClaimTemplateDTO> artefactClaimTemplates, ArtefactTemplateDTO artefactTemplate) {

          this.ArtefactRoleTemplateID = artefactRoleTemplateID;
          this.ArtefactTemplateID = artefactTemplateID;
          this.ArtefactTemplateVersionNumber = artefactTemplateVersionNumber;
          this.RoleName = roleName;
          this.RoleDescription = roleDescription;
          this.RoleTypeID = roleTypeID;
          this.RoleSubTypeID = roleSubTypeID;
          this.RoleCategoryID = roleCategoryID;
          this.RoleSubCategoryID = roleSubCategoryID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ArtefactClaimTemplates = artefactClaimTemplates;
          this.ArtefactTemplate = artefactTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ArtefactRoleTemplateID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ArtefactTemplateID { get; set; }

        [DataMember]
        public global::System.Nullable<int> ArtefactTemplateVersionNumber { get; set; }

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

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<ArtefactClaimTemplateDTO> ArtefactClaimTemplates { get; set; }

        [DataMember]
        public ArtefactTemplateDTO ArtefactTemplate { get; set; }

        #endregion
    }

}
