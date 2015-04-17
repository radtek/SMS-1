﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 17/04/2015 16:46:51
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Bec.TargetFramework.Data
{

    /// <summary>
    /// There are no comments for Bec.TargetFramework.Data.LedgerAccountBalance in the schema.
    /// </summary>
    [System.Serializable]
    public partial class LedgerAccountBalance    {

        public LedgerAccountBalance()
        {
          this.IsDebit = false;
          this.IsCredit = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for LedgerAccountID in the schema.
        /// </summary>
        public virtual global::System.Guid LedgerAccountID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BalanceOn in the schema.
        /// </summary>
        public virtual global::System.DateTime BalanceOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Balance in the schema.
        /// </summary>
        public virtual decimal Balance
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BalanceAvailableAdjusted in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> BalanceAvailableAdjusted
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BalanceAvailableClosing in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> BalanceAvailableClosing
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BalanceBookAdjusted in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> BalanceBookAdjusted
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BalanceBookClosing in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> BalanceBookClosing
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BalanceCollectedAdjusted in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> BalanceCollectedAdjusted
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BalanceCollectedClosing in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> BalanceCollectedClosing
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsDebit in the schema.
        /// </summary>
        public virtual bool IsDebit
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsCredit in the schema.
        /// </summary>
        public virtual bool IsCredit
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for OrganisationLedgerAccount in the schema.
        /// </summary>
        public virtual OrganisationLedgerAccount OrganisationLedgerAccount
        {
            get;
            set;
        }

        #endregion
    }

}
