﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:58
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
    public partial class ContactPhoneDTO
    {
        #region Constructors
  
        public ContactPhoneDTO() {
        }

        public ContactPhoneDTO(int contactPhoneId, global::System.Nullable<System.Guid> contactID, int phoneTypeID, int phoneNumber, string countryCode, bool isPrimary, bool isActive, bool isDeleted, ContactDTO contact, CountryCodeDTO countryCode1) {

          this.ContactPhoneId = contactPhoneId;
          this.ContactID = contactID;
          this.PhoneTypeID = phoneTypeID;
          this.PhoneNumber = phoneNumber;
          this.CountryCode = countryCode;
          this.IsPrimary = isPrimary;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.Contact = contact;
          this.CountryCode1 = countryCode1;
        }

        #endregion

        #region Properties

        [DataMember]
        public int ContactPhoneId { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ContactID { get; set; }

        [DataMember]
        public int PhoneTypeID { get; set; }

        [DataMember]
        public int PhoneNumber { get; set; }

        [DataMember]
        public string CountryCode { get; set; }

        [DataMember]
        public bool IsPrimary { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ContactDTO Contact { get; set; }

        [DataMember]
        public CountryCodeDTO CountryCode1 { get; set; }

        #endregion
    }

}
