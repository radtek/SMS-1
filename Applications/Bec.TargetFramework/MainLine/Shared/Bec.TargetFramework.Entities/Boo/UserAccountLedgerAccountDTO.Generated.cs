﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:06 PM
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
    public partial class UserAccountLedgerAccountDTO
    {
        #region Constructors
  
        public UserAccountLedgerAccountDTO() {
        }

        public UserAccountLedgerAccountDTO(global::System.Guid userAccountID, global::System.Guid ledgerAccountID, bool isActive, bool isDeleted, UserAccountDTO userAccount, OrganisationLedgerAccountDTO organisationLedgerAccount) {

          this.UserAccountID = userAccountID;
          this.LedgerAccountID = ledgerAccountID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.UserAccount = userAccount;
          this.OrganisationLedgerAccount = organisationLedgerAccount;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid UserAccountID { get; set; }

        [DataMember]
        public global::System.Guid LedgerAccountID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public UserAccountDTO UserAccount { get; set; }

        [DataMember]
        public OrganisationLedgerAccountDTO OrganisationLedgerAccount { get; set; }

        #endregion
    }

}
