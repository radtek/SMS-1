using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities.DTO;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities.DTO
{
    [DataContract]
   
    /// <summary>
    /// Represents a CapturePaymentRequest
    /// </summary>
    public partial class CapturePaymentRequestDTO
    {
        [DataMember]
        /// <summary>
        /// Gets or sets an order
        /// </summary>
        public TransactionOrderDTO Order { get; set; }
    }
}