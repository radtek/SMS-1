using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Bec.TargetFramework.Entities.DTO.Payment;

namespace Bec.TargetFramework.Entities
{

    public partial class ProductDTO
    {
        public ProductDetailDTO CurrentDetail
        {
            get
            {
                return this.ProductDetails.First();
            }
        }

        [DataMember]
        public List<ComponentTierDTO> ProductDTOComponentTiers { get; set; }

        [DataMember]
        public List<VProductDiscountDTO> ProductDTODiscounts { get; set; }

        [DataMember]
        public List<VProductAttributeDTO> ProductDTOAttributes { get; set; }
         [DataMember]
      
        public List<VProductSpecificationDTO> ProductDTOSpecs { get; set; }
         [DataMember]
      
        public List<VProductSpecificationOptionDTO> ProductDTOSpecOptions { get; set; }

        public List<VProductAttributeDTO> ProductDTODefaultAttributes
        {
            get
            {
                if (ProductDTOAttributes == null)
                    return null;
                else
                {
                    return ProductDTOAttributes.Where(pa =>
                        pa.IsPreSelected == true || (pa.IsProductAttributeRequired.HasValue
                                                     && pa.IsProductAttributeRequired.Value == true)).ToList();

                }
            }
        }
    

        public List<VProductSpecificationDTO> ProductDTODefaultSpecs
        {
            get
            {
                if (ProductDTOSpecs == null)
                    return null;
                else
                {
                    return ProductDTOSpecs.Where(pa =>
                        pa.IsMandatory == true || pa.IsPreSelected == true).ToList();

                }
            }
        }


         public List<VProductSpecificationOptionDTO> ProductDTODefaultSpecOptions
         {
             get
             {
                 if (ProductDTOSpecOptions == null)
                     return null;
                 else
                 {
                     return ProductDTOSpecOptions.Where(pa =>
                         pa.IsMandatory == true).ToList();

                 }
             }
         }

         [DataMember]
         public List<VProductDeductionDTO> ProductDTODeductions { get; set; }

         [DataMember]
         public ProductPricingDTO ProductPricingDTO { get; set; }
    }
}
