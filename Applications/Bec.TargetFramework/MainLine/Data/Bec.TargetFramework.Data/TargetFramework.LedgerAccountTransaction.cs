﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 07/04/2015 09:50:51
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
    /// There are no comments for Bec.TargetFramework.Data.LedgerAccountTransaction in the schema.
    /// </summary>
    [System.Serializable]
    public partial class LedgerAccountTransaction    {

        public LedgerAccountTransaction()
        {
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
        /// There are no comments for TransactionOrderID in the schema.
        /// </summary>
        public virtual global::System.Guid TransactionOrderID
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


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for TransactionOrder in the schema.
        /// </summary>
        public virtual TransactionOrder TransactionOrder
        {
            get;
            set;
        }
    
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
