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
    public partial class VSafeSendRecipientDTO
    {
        #region Constructors
  
        public VSafeSendRecipientDTO() {
        }

        public VSafeSendRecipientDTO(global::System.Guid smsTransactionID, global::System.Guid userAccountOrganisationID, global::System.Guid organisationID, string firstName, string lastName, string organisationName) {

          this.SmsTransactionID = smsTransactionID;
          this.UserAccountOrganisationID = userAccountOrganisationID;
          this.OrganisationID = organisationID;
          this.FirstName = firstName;
          this.LastName = lastName;
          this.OrganisationName = organisationName;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid SmsTransactionID { get; set; }

        [DataMember]
        public global::System.Guid UserAccountOrganisationID { get; set; }

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string LastName { get; set; }

        [DataMember]
        public string OrganisationName { get; set; }

        #endregion
    }

}