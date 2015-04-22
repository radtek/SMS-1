﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
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
    /// There are no comments for Bec.TargetFramework.Data.TransactionOrderPayment in the schema.
    /// </summary>
    [System.Serializable]
    public partial class TransactionOrderPayment    {

        public TransactionOrderPayment()
        {
          this.IsPaymentSuccessful = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for TransactionOrderPaymentID in the schema.
        /// </summary>
        public virtual global::System.Guid TransactionOrderPaymentID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsPaymentSuccessful in the schema.
        /// </summary>
        public virtual bool IsPaymentSuccessful
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PaymentDate in the schema.
        /// </summary>
        public virtual global::System.DateTime PaymentDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ResponseData in the schema.
        /// </summary>
        public virtual string ResponseData
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TransactionResult in the schema.
        /// </summary>
        public virtual string TransactionResult
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PaymentType in the schema.
        /// </summary>
        public virtual string PaymentType
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CardBrand in the schema.
        /// </summary>
        public virtual string CardBrand
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ApprovalCode in the schema.
        /// </summary>
        public virtual string ApprovalCode
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AVSResponseCode in the schema.
        /// </summary>
        public virtual string AVSResponseCode
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProcessorResponseCode in the schema.
        /// </summary>
        public virtual string ProcessorResponseCode
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProcessorApprovalCode in the schema.
        /// </summary>
        public virtual string ProcessorApprovalCode
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProcessorReceiptCode in the schema.
        /// </summary>
        public virtual string ProcessorReceiptCode
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProcessorCCVResponse in the schema.
        /// </summary>
        public virtual string ProcessorCCVResponse
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProcessorReferenceNumber in the schema.
        /// </summary>
        public virtual string ProcessorReferenceNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CommercialServiceProvider in the schema.
        /// </summary>
        public virtual string CommercialServiceProvider
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
        /// There are no comments for CCVCode in the schema.
        /// </summary>
        public virtual string CCVCode
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for TransactionOrderPaymentErrors in the schema.
        /// </summary>
        public virtual ICollection<TransactionOrderPaymentError> TransactionOrderPaymentErrors
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for TransactionOrderProcessLogs in the schema.
        /// </summary>
        public virtual ICollection<TransactionOrderProcessLog> TransactionOrderProcessLogs
        {
            get;
            set;
        }

        #endregion
    }

}
