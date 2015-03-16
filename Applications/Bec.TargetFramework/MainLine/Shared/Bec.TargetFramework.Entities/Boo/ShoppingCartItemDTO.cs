
using System.Collections.Generic;
using System.Runtime.Serialization;
using Bec.TargetFramework.Entities.DTO.Payment;

namespace Bec.TargetFramework.Entities
{

    public partial class ShoppingCartItemDTO
    {
         [DataMember]
        public ProductPricingDTO ProductPricingDto { get; set; }

         [DataMember]
         public List<InformationDTO> DeductionInformationDtos { get; set; }
         [DataMember]
         public List<InformationDTO> DiscountInformationDtos { get; set; }

         [DataMember]
       
         public InformationDTO ProductInformationDto { get; set; }
    }
}
