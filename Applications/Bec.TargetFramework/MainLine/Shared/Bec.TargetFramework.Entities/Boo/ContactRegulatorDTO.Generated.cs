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
    public partial class ContactRegulatorDTO
    {
        #region Constructors
  
        public ContactRegulatorDTO() {
        }

        public ContactRegulatorDTO(global::System.Guid contactID, int regulatorID, string regulatorNumber, bool isPrimary, global::System.Nullable<System.DateTime> dateQualified, bool isActive, bool isDeleted, string regulatorName, string regulatorOtherName, ContactDTO contact) {

          this.ContactID = contactID;
          this.RegulatorID = regulatorID;
          this.RegulatorNumber = regulatorNumber;
          this.IsPrimary = isPrimary;
          this.DateQualified = dateQualified;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.RegulatorName = regulatorName;
          this.RegulatorOtherName = regulatorOtherName;
          this.Contact = contact;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ContactID { get; set; }

        [DataMember]
        public int RegulatorID { get; set; }

        [DataMember]
        public string RegulatorNumber { get; set; }

        [DataMember]
        public bool IsPrimary { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> DateQualified { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public string RegulatorName { get; set; }

        [DataMember]
        public string RegulatorOtherName { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ContactDTO Contact { get; set; }

        #endregion
    }

}