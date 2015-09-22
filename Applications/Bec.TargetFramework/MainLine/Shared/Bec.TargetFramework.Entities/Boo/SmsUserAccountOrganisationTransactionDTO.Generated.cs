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
    public partial class SmsUserAccountOrganisationTransactionDTO
    {
        #region Constructors
  
        public SmsUserAccountOrganisationTransactionDTO() {
        }

        public SmsUserAccountOrganisationTransactionDTO(global::System.Guid smsUserAccountOrganisationTransactionID, global::System.Guid userAccountOrganisationID, global::System.Guid smsTransactionID, int smsUserAccountOrganisationTransactionTypeID, global::System.Nullable<System.Guid> addressID, global::System.Guid contactID, bool isActive, bool isDeleted, global::System.DateTime createdOn, string createdBy, global::System.Nullable<System.DateTime> modifiedOn, string modifiedBy, SmsTransactionDTO smsTransaction, SmsUserAccountOrganisationTransactionTypeDTO smsUserAccountOrganisationTransactionType, AddressDTO address, ContactDTO contact, UserAccountOrganisationDTO userAccountOrganisation) {

          this.SmsUserAccountOrganisationTransactionID = smsUserAccountOrganisationTransactionID;
          this.UserAccountOrganisationID = userAccountOrganisationID;
          this.SmsTransactionID = smsTransactionID;
          this.SmsUserAccountOrganisationTransactionTypeID = smsUserAccountOrganisationTransactionTypeID;
          this.AddressID = addressID;
          this.ContactID = contactID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.CreatedOn = createdOn;
          this.CreatedBy = createdBy;
          this.ModifiedOn = modifiedOn;
          this.ModifiedBy = modifiedBy;
          this.SmsTransaction = smsTransaction;
          this.SmsUserAccountOrganisationTransactionType = smsUserAccountOrganisationTransactionType;
          this.Address = address;
          this.Contact = contact;
          this.UserAccountOrganisation = userAccountOrganisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid SmsUserAccountOrganisationTransactionID { get; set; }

        [DataMember]
        public global::System.Guid UserAccountOrganisationID { get; set; }

        [DataMember]
        public global::System.Guid SmsTransactionID { get; set; }

        [DataMember]
        public int SmsUserAccountOrganisationTransactionTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> AddressID { get; set; }

        [DataMember]
        public global::System.Guid ContactID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.DateTime CreatedOn { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> ModifiedOn { get; set; }

        [DataMember]
        public string ModifiedBy { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public SmsTransactionDTO SmsTransaction { get; set; }

        [DataMember]
        public SmsUserAccountOrganisationTransactionTypeDTO SmsUserAccountOrganisationTransactionType { get; set; }

        [DataMember]
        public AddressDTO Address { get; set; }

        [DataMember]
        public ContactDTO Contact { get; set; }

        [DataMember]
        public UserAccountOrganisationDTO UserAccountOrganisation { get; set; }

        #endregion
    }

}
