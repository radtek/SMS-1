using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities.DTO;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities.DTO
{
    [DataContract]
   
    /// <summary>
    /// Represents a RefundPaymentResult
    /// </summary>
    public partial class RefundPaymentRequestDTO
    {
        [DataMember]
        /// <summary>
        /// Gets or sets an order
        /// </summary>
        public TransactionOrderDTO Order { get; set; }
        [DataMember]
        /// <summary>
        /// Gets or sets an amount
        /// </summary>
        public decimal AmountToRefund { get; set; }
        [DataMember]
        /// <summary>
        /// Gets or sets a value indicating whether it's a partial refund; otherwize, full refund
        /// </summary>
        public bool IsPartialRefund { get; set; }
    }
}