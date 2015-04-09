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
    public partial class LedgerAccountBalanceDTO
    {
        #region Constructors
  
        public LedgerAccountBalanceDTO() {
        }

        public LedgerAccountBalanceDTO(global::System.Guid ledgerAccountID, global::System.DateTime balanceOn, decimal balance, global::System.Nullable<decimal> balanceAvailableAdjusted, global::System.Nullable<decimal> balanceAvailableClosing, global::System.Nullable<decimal> balanceBookAdjusted, global::System.Nullable<decimal> balanceBookClosing, global::System.Nullable<decimal> balanceCollectedAdjusted, global::System.Nullable<decimal> balanceCollectedClosing, bool isDebit, bool isCredit, OrganisationLedgerAccountDTO organisationLedgerAccount) {

          this.LedgerAccountID = ledgerAccountID;
          this.BalanceOn = balanceOn;
          this.Balance = balance;
          this.BalanceAvailableAdjusted = balanceAvailableAdjusted;
          this.BalanceAvailableClosing = balanceAvailableClosing;
          this.BalanceBookAdjusted = balanceBookAdjusted;
          this.BalanceBookClosing = balanceBookClosing;
          this.BalanceCollectedAdjusted = balanceCollectedAdjusted;
          this.BalanceCollectedClosing = balanceCollectedClosing;
          this.IsDebit = isDebit;
          this.IsCredit = isCredit;
          this.OrganisationLedgerAccount = organisationLedgerAccount;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid LedgerAccountID { get; set; }

        [DataMember]
        public global::System.DateTime BalanceOn { get; set; }

        [DataMember]
        public decimal Balance { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> BalanceAvailableAdjusted { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> BalanceAvailableClosing { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> BalanceBookAdjusted { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> BalanceBookClosing { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> BalanceCollectedAdjusted { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> BalanceCollectedClosing { get; set; }

        [DataMember]
        public bool IsDebit { get; set; }

        [DataMember]
        public bool IsCredit { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public OrganisationLedgerAccountDTO OrganisationLedgerAccount { get; set; }

        #endregion
    }

}
