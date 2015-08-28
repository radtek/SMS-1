
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{

    public partial class VCountryDeductionDTO
    {
        [DataMember]
        public ProductDTO DeductionProduct { get; set; }
        [DataMember]
        public DeductionDTO DeductionDto { get; set; }

    }
}
