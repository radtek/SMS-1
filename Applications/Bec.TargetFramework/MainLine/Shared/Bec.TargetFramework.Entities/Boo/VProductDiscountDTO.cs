
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{

    public partial class VProductDiscountDTO
    {
        [DataMember]
        public decimal ProductDiscountTotal { get; set; }
        [DataMember]
       
        public decimal ProductDiscountTotalPercentage { get; set; }
        [DataMember]
        public DiscountDTO DiscountDto { get; set; }
    }
}
