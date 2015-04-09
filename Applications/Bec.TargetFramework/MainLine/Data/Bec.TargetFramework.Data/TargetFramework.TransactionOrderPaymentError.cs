﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 08/04/2015 17:09:52
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
    /// There are no comments for Bec.TargetFramework.Data.TransactionOrderPaymentError in the schema.
    /// </summary>
    [System.Serializable]
    public partial class TransactionOrderPaymentError    {

        public TransactionOrderPaymentError()
        {
          this.IsMerchantError = false;
          this.IsCardIssuerError = false;
          this.IsProcessorError = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for TransactionOrderPaymentErrorID in the schema.
        /// </summary>
        public virtual global::System.Guid TransactionOrderPaymentErrorID
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

    
        /// <summary>
        /// There are no comments for IsMerchantError in the schema.
        /// </summary>
        public virtual bool IsMerchantError
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsCardIssuerError in the schema.
        /// </summary>
        public virtual bool IsCardIssuerError
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsProcessorError in the schema.
        /// </summary>
        public virtual bool IsProcessorError
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
        /// There are no comments for ErrorMessage in the schema.
        /// </summary>
        public virtual string ErrorMessage
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ErrorCode in the schema.
        /// </summary>
        public virtual string ErrorCode
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ErrorDetail in the schema.
        /// </summary>
        public virtual string ErrorDetail
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
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
