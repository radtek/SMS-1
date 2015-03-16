
using System.Collections.Generic;
using System.Runtime.Serialization;
namespace Bec.TargetFramework.Entities
{

    public partial class ShoppingCartDTO
    {
        [DataMember]
        public CartPriceDTO PriceDTO { get; set; }

        [DataMember]
        public List<InformationDTO> DeductionInformationDtos { get; set; }

        [DataMember]
        public List<InformationDTO> TaxInformationDtos { get; set; }

        [DataMember]
        public List<InformationDTO> DiscountInformationDtos { get; set; }

        [DataMember]
        public List<VCountryDeductionDTO> VCountryDeductions { get; set; }

        [DataMember]
        public VUserAccountOrganisationDTO VUserAccountOrganisationDto { get; set; }
    }
}
