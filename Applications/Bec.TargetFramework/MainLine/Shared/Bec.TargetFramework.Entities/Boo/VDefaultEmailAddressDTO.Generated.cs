﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 18/03/2015 19:00:46
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
    public partial class VDefaultEmailAddressDTO
    {
        #region Constructors
  
        public VDefaultEmailAddressDTO() {
        }

        public VDefaultEmailAddressDTO(global::System.Guid userID, string username, string email, global::System.Guid userAccountOrganisationID, global::System.Nullable<System.Guid> branchOrganisationID, string branchEmailAddress, global::System.Guid organisationID, string emailAddress1) {

          this.UserID = userID;
          this.Username = username;
          this.Email = email;
          this.UserAccountOrganisationID = userAccountOrganisationID;
          this.BranchOrganisationID = branchOrganisationID;
          this.BranchEmailAddress = branchEmailAddress;
          this.OrganisationID = organisationID;
          this.EmailAddress1 = emailAddress1;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid UserID { get; set; }

        [DataMember]
        public string Username { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public global::System.Guid UserAccountOrganisationID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> BranchOrganisationID { get; set; }

        [DataMember]
        public string BranchEmailAddress { get; set; }

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        [DataMember]
        public string EmailAddress1 { get; set; }

        #endregion
    }

}
