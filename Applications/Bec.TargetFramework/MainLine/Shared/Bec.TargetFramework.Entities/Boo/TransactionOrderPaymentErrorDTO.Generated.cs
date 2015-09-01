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
    public partial class TransactionOrderPaymentErrorDTO
    {
        #region Constructors
  
        public TransactionOrderPaymentErrorDTO() {
        }

        public TransactionOrderPaymentErrorDTO(global::System.Guid transactionOrderPaymentErrorID, global::System.Nullable<System.Guid> transactionOrderPaymentID, bool isMerchantError, bool isCardIssuerError, bool isProcessorError, global::System.DateTime createdOn, string errorMessage, string errorCode, string errorDetail, TransactionOrderPaymentDTO transactionOrderPayment) {

          this.TransactionOrderPaymentErrorID = transactionOrderPaymentErrorID;
          this.TransactionOrderPaymentID = transactionOrderPaymentID;
          this.IsMerchantError = isMerchantError;
          this.IsCardIssuerError = isCardIssuerError;
          this.IsProcessorError = isProcessorError;
          this.CreatedOn = createdOn;
          this.ErrorMessage = errorMessage;
          this.ErrorCode = errorCode;
          this.ErrorDetail = errorDetail;
          this.TransactionOrderPayment = transactionOrderPayment;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid TransactionOrderPaymentErrorID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> TransactionOrderPaymentID { get; set; }

        [DataMember]
        public bool IsMerchantError { get; set; }

        [DataMember]
        public bool IsCardIssuerError { get; set; }

        [DataMember]
        public bool IsProcessorError { get; set; }

        [DataMember]
        public global::System.DateTime CreatedOn { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }

        [DataMember]
        public string ErrorCode { get; set; }

        [DataMember]
        public string ErrorDetail { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public TransactionOrderPaymentDTO TransactionOrderPayment { get; set; }

        #endregion
    }

}