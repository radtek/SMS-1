using Bec.TargetFramework.Entities.Enums;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities.DTO
{
    [DataContract]
   
    /// <summary>
    /// Represents a RefundPaymentResult
    /// </summary>
    public partial class RefundPaymentResultDTO
    {[DataMember]
        private PaymentStatus _newPaymentStatus = PaymentStatus.Pending;
        [DataMember]
        public IList<string> Errors { get; set; }

        public RefundPaymentResultDTO()
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

        #region Properties
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

        #endregion Properties
    }
}