
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace Bec.TargetFramework.Entities
{

    public partial class ShoppingCartDTO
    {
        [DataMember]
        public CartPriceDTO PriceDTO { get; set; }

        [DataMember]
        public List<VCountryDeductionDTO> VCountryDeductions { get; set; }

        [DataMember]
        public VUserAccountOrganisationDTO VUserAccountOrganisationDto { get; set; }
    }
}
