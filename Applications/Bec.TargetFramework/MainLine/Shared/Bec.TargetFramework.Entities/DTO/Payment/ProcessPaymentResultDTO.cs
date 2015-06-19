using Bec.TargetFramework.Entities.Enums;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities.DTO
{
    [DataContract]
   
    /// <summary>
    /// Represents a ProcessPaymentResult
    /// </summary>
    public partial class ProcessPaymentResultDTO
    {[DataMember]
        private PaymentStatus _newPaymentStatus = PaymentStatus.Pending;
        [DataMember]
        public IList<string> Errors { get; set; }

        public ProcessPaymentResultDTO()
        {
            this.Errors = new List<string>();
        }

        public bool Success
        {
            get { return (this.Errors.Count == 0); }
        }

        public void AddError(string error)
        {
            this.Errors.Add(error);
        }
        [DataMember]
        /// <summary>
        /// Gets or sets an AVS result
        /// </summary>
        public string AvsResult { get; set; }
        [DataMember]
        /// <summary>
        /// Gets or sets the authorization transaction identifier
        /// </summary>
        public string AuthorizationTransactionId { get; set; }
        [DataMember]
        /// <summary>
        /// Gets or sets the authorization transaction code
        /// </summary>
        public string AuthorizationTransactionCode { get; set; }
        [DataMember]
        /// <summary>
        /// Gets or sets the authorization transaction result
        /// </summary>
        public string AuthorizationTransactionResult { get; set; }
        [DataMember]
        /// <summary>
        /// Gets or sets the capture transaction identifier
        /// </summary>
        public string CaptureTransactionId { get; set; }
        [DataMember]
        /// <summary>
        /// Gets or sets the capture transaction result
        /// </summary>
        public string CaptureTransactionResult { get; set; }
        [DataMember]
        /// <summary>
        /// Gets or sets the subscription transaction identifier
        /// </summary>
        public string SubscriptionTransactionId { get; set; }
        [DataMember]
        /// <summary>
        /// Gets or sets a value indicating whether storing of credit card number, CVV2 is allowed
        /// </summary>
        public bool AllowStoringCreditCardNumber { get; set; }
        [DataMember]
        /// <summary>
        /// Gets or sets a payment status after processing
        /// </summary>
        public PaymentStatus NewPaymentStatus
        {
            get
            {
                return _newPaymentStatus;
            }
            set
            {
                _newPaymentStatus = value;
            }
        }
    }
}