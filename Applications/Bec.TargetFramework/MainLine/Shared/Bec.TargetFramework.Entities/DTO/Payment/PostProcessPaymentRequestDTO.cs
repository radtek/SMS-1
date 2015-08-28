using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities.DTO;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities.DTO
{
    [DataContract]
   
    /// <summary>
    /// Represents a PostProcessPaymentRequest
    /// </summary>
    public partial class PostProcessPaymentRequestDTO
    {
        [DataMember]
        /// <summary>
        /// Gets or sets an order. Used when order is already saved (payment gateways that redirect a customer to a third-party URL)
        /// </summary>
        public TransactionOrderDTO Order { get; set; }
    }
}