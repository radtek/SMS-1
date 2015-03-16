
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{

    public partial class TransactionOrderPaymentErrorDTO
    {
        [DataMember]
        public ErrorCodeDTO ErrorCodeDto { get; set; }

    }
}
