﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 16:15:20
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
    public partial class ArtefactRoleDTO
    {
        #region Constructors
  
        public ArtefactRoleDTO() {
        }

        public ArtefactRoleDTO(global::System.Guid artefactRoleID, global::System.Nullable<System.Guid> artefactID, global::System.Nullable<int> artefactVersionNumber, string roleName, string roleDescription, global::System.Nullable<int> roleTypeID, global::System.Nullable<int> roleSubTypeID, global::System.Nullable<int> roleCategoryID, global::System.Nullable<int> roleSubCategoryID, bool isActive, bool isDeleted, List<ArtefactClaimDTO> artefactClaims, ArtefactDTO artefact) {

          this.ArtefactRoleID = artefactRoleID;
          this.ArtefactID = artefactID;
          this.ArtefactVersionNumber = artefactVersionNumber;
          this.RoleName = roleName;
          this.RoleDescription = roleDescription;
          this.RoleTypeID = roleTypeID;
          this.RoleSubTypeID = roleSubTypeID;
          this.RoleCategoryID = roleCategoryID;
          this.RoleSubCategoryID = roleSubCategoryID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ArtefactClaims = artefactClaims;
          this.Artefact = artefact;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ArtefactRoleID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ArtefactID { get; set; }

        [DataMember]
        public global::System.Nullable<int> ArtefactVersionNumber { get; set; }

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
        public List<ArtefactClaimDTO> ArtefactClaims { get; set; }

        [DataMember]
        public ArtefactDTO Artefact { get; set; }

        #endregion
    }

}
