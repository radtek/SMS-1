using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities.DTO;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities.DTO
{
    [DataContract]
    /// <summary>
    /// Represents a VoidPaymentResult
    /// </summary>
    public partial class VoidPaymentRequestDTO
    {
        [DataMember]
        /// <summary>
        /// Gets or sets an order
        /// </summary>
        public TransactionOrderDTO Order { get; set; }
    }
}