using Bec.TargetFramework.Entities.Enums;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Services.Payments
{
    [DataContract]
    /// <summary>
    /// Represents a VoidPaymentResult
    /// </summary>
    public partial class VoidPaymentResultDTO
    { [DataMember]
      
        private PaymentStatus _newPaymentStatus = PaymentStatus.Pending;
        [DataMember]
        public IList<string> Errors { get; set; }

        public VoidPaymentResultDTO()
        {
            this.Errors = new List<string>();
        }
         [DataMember]
       [IgnoreDataMember]
      
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