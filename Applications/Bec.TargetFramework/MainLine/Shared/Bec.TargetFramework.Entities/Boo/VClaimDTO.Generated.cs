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
    public partial class VClaimDTO
    {
        #region Constructors
  
        public VClaimDTO() {
        }

        public VClaimDTO(global::System.Guid userAccountOrganisationID, global::System.Guid organisationID, global::System.Guid organisationRoleID, string roleName, string roleDescription, string claimType, global::System.Nullable<System.Guid> claimID, string claimName, string claimDescription, string claimSubType, global::System.Nullable<System.Guid> claimSubID, string claimSubName, string claimSubDescription, global::System.Nullable<System.Guid> parentID, string roleSource, string claimTypeName) {

          this.UserAccountOrganisationID = userAccountOrganisationID;
          this.OrganisationID = organisationID;
          this.OrganisationRoleID = organisationRoleID;
          this.RoleName = roleName;
          this.RoleDescription = roleDescription;
          this.ClaimType = claimType;
          this.ClaimID = claimID;
          this.ClaimName = claimName;
          this.ClaimDescription = claimDescription;
          this.ClaimSubType = claimSubType;
          this.ClaimSubID = claimSubID;
          this.ClaimSubName = claimSubName;
          this.ClaimSubDescription = claimSubDescription;
          this.ParentID = parentID;
          this.RoleSource = roleSource;
          this.ClaimTypeName = claimTypeName;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid UserAccountOrganisationID { get; set; }

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        [DataMember]
        public global::System.Guid OrganisationRoleID { get; set; }

        [DataMember]
        public string RoleName { get; set; }

        [DataMember]
        public string RoleDescription { get; set; }

        [DataMember]
        public string ClaimType { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ClaimID { get; set; }

        [DataMember]
        public string ClaimName { get; set; }

        [DataMember]
        public string ClaimDescription { get; set; }

        [DataMember]
        public string ClaimSubType { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ClaimSubID { get; set; }

        [DataMember]
        public string ClaimSubName { get; set; }

        [DataMember]
        public string ClaimSubDescription { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public string RoleSource { get; set; }

        [DataMember]
        public string ClaimTypeName { get; set; }

        #endregion
    }

}