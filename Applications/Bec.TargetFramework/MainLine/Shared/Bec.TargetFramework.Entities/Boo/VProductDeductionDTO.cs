
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{

    public partial class VProductDeductionDTO
    {
        [DataMember]
        public decimal ProductDeductionTotal { get; set; }
        [DataMember]

        public decimal ProductDeductionTotalPercentage { get; set; }
        [DataMember]

        public DeductionDTO DeductionDto { get; set; }
    }
}
