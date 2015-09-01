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
    public partial class OrganisationLedgerAccountDTO
    {
        #region Constructors
  
        public OrganisationLedgerAccountDTO() {
        }

        public OrganisationLedgerAccountDTO(global::System.Guid organisationLedgerAccountID, int ledgerAccountTypeID, global::System.Nullable<int> ledgerAccountCategoryID, string name, string description, global::System.Nullable<System.Guid> parentID, global::System.DateTime createdOn, string createdBy, decimal balance, global::System.Nullable<System.DateTime> updatedOn, bool handlesCredit, bool handlesDebit, global::System.Nullable<System.DateTime> openedOn, global::System.Nullable<System.DateTime> closedOn, global::System.Guid organisationID, bool isActive, int accountingTypeID, bool isPrimaryAccount, bool isDeleted, global::System.Nullable<long> rowVersion, List<UserAccountLedgerAccountDTO> userAccountLedgerAccounts, List<LedgerAccountBalanceDTO> ledgerAccountBalances, OrganisationDTO organisation, List<OrganisationLedgerTransactionDTO> organisationLedgerTransactions) {

          this.OrganisationLedgerAccountID = organisationLedgerAccountID;
          this.LedgerAccountTypeID = ledgerAccountTypeID;
          this.LedgerAccountCategoryID = ledgerAccountCategoryID;
          this.Name = name;
          this.Description = description;
          this.ParentID = parentID;
          this.CreatedOn = createdOn;
          this.CreatedBy = createdBy;
          this.Balance = balance;
          this.UpdatedOn = updatedOn;
          this.HandlesCredit = handlesCredit;
          this.HandlesDebit = handlesDebit;
          this.OpenedOn = openedOn;
          this.ClosedOn = closedOn;
          this.OrganisationID = organisationID;
          this.IsActive = isActive;
          this.AccountingTypeID = accountingTypeID;
          this.IsPrimaryAccount = isPrimaryAccount;
          this.IsDeleted = isDeleted;
          this.RowVersion = rowVersion;
          this.UserAccountLedgerAccounts = userAccountLedgerAccounts;
          this.LedgerAccountBalances = ledgerAccountBalances;
          this.Organisation = organisation;
          this.OrganisationLedgerTransactions = organisationLedgerTransactions;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid OrganisationLedgerAccountID { get; set; }

        [DataMember]
        public int LedgerAccountTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> LedgerAccountCategoryID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public global::System.DateTime CreatedOn { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public decimal Balance { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> UpdatedOn { get; set; }

        [DataMember]
        public bool HandlesCredit { get; set; }

        [DataMember]
        public bool HandlesDebit { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> OpenedOn { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> ClosedOn { get; set; }

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public int AccountingTypeID { get; set; }

        [DataMember]
        public bool IsPrimaryAccount { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<long> RowVersion { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<UserAccountLedgerAccountDTO> UserAccountLedgerAccounts { get; set; }

        [DataMember]
        public List<LedgerAccountBalanceDTO> LedgerAccountBalances { get; set; }

        [DataMember]
        public OrganisationDTO Organisation { get; set; }

        [DataMember]
        public List<OrganisationLedgerTransactionDTO> OrganisationLedgerTransactions { get; set; }

        #endregion
    }

}