﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:19 AM
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
    public partial class DefaultOrganisationLedgerDTO
    {
        #region Constructors
  
        public DefaultOrganisationLedgerDTO() {
        }

        public DefaultOrganisationLedgerDTO(global::System.Guid defaultOrganisationLedgerID, global::System.Guid defaultOrganisationID, int defaultOrganisationVersionNumber, int ledgerAccountTypeID, string ledgerAccountName, bool handlesCredit, bool handlesDebit, bool isActive, bool isDeleted, global::System.Nullable<System.Guid> parentID, DefaultOrganisationDTO defaultOrganisation) {

          this.DefaultOrganisationLedgerID = defaultOrganisationLedgerID;
          this.DefaultOrganisationID = defaultOrganisationID;
          this.DefaultOrganisationVersionNumber = defaultOrganisationVersionNumber;
          this.LedgerAccountTypeID = ledgerAccountTypeID;
          this.LedgerAccountName = ledgerAccountName;
          this.HandlesCredit = handlesCredit;
          this.HandlesDebit = handlesDebit;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ParentID = parentID;
          this.DefaultOrganisation = defaultOrganisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DefaultOrganisationLedgerID { get; set; }

        [DataMember]
        public global::System.Guid DefaultOrganisationID { get; set; }

        [DataMember]
        public int DefaultOrganisationVersionNumber { get; set; }

        [DataMember]
        public int LedgerAccountTypeID { get; set; }

        [DataMember]
        public string LedgerAccountName { get; set; }

        [DataMember]
        public bool HandlesCredit { get; set; }

        [DataMember]
        public bool HandlesDebit { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public DefaultOrganisationDTO DefaultOrganisation { get; set; }

        #endregion
    }

}
