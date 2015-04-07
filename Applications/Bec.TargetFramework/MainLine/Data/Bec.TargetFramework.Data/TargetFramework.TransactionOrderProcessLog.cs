﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 07/04/2015 16:15:16
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
    /// There are no comments for Bec.TargetFramework.Data.TransactionOrderProcessLog in the schema.
    /// </summary>
    [System.Serializable]
    public partial class TransactionOrderProcessLog    {

        public TransactionOrderProcessLog()
        {
          this.IsTransactionOrderProcessed = false;
          this.IsPaid = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for TransactionOrderID in the schema.
        /// </summary>
        public virtual global::System.Guid TransactionOrderID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CreatedOn in the schema.
        /// </summary>
        public virtual global::System.DateTime CreatedOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TransactionOrderStatusDetail in the schema.
        /// </summary>
        public virtual string TransactionOrderStatusDetail
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsTransactionOrderProcessed in the schema.
        /// </summary>
        public virtual bool IsTransactionOrderProcessed
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PaidOn in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> PaidOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsPaid in the schema.
        /// </summary>
        public virtual bool IsPaid
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusTypeID in the schema.
        /// </summary>
        public virtual global::System.Guid StatusTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusTypeVersionNumber in the schema.
        /// </summary>
        public virtual int StatusTypeVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusTypeValueID in the schema.
        /// </summary>
        public virtual global::System.Guid StatusTypeValueID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TransactionOrderPaymentID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> TransactionOrderPaymentID
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
        /// There are no comments for StatusType in the schema.
        /// </summary>
        public virtual StatusType StatusType
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for StatusTypeValue in the schema.
        /// </summary>
        public virtual StatusTypeValue StatusTypeValue
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for TransactionOrderPayment in the schema.
        /// </summary>
        public virtual TransactionOrderPayment TransactionOrderPayment
        {
            get;
            set;
        }

        #endregion
    }

}
