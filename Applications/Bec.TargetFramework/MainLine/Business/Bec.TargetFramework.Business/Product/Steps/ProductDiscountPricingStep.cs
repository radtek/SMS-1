using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Business.Product.Base;
using Bec.TargetFramework.Business.Product.Helpers;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business.Product
{
    public class ProductDiscountPricingStep : ProductPricingStepBase
    {
        public ProductDiscountPricingStep(ILogger logger, IProductLogic logic)
            : base(logger, logic)
        {
        }

        public override bool ApplyPricing(ProductDTO product)
        {
            bool pricingApplied = true;

            try
            {
                CartItem.DiscountInformationDtos = new List<InformationDTO>();

                decimal valueDiscounts = 0;
                decimal percentDiscounts = 0;
                // apply value deductions
                if (product.ProductDTODiscounts.Any())
                {
                    product.ProductDTODiscounts.Where(d => d.ValidTill >= DateTime.Now).ToList().ForEach(item =>
                    {
                        var informationDto = new PricingHelper().CalculateProductDiscountTierPricing(CartItem, product,
                            item);

                        if (item.IsPercentage)
                        {
                            percentDiscounts += informationDto.PercentageComponent;
                            item.ProductDiscountTotalPercentage =
                                (product.ProductPricingDTO.ProductPriceWithSpecsAndAttrs()*
                                 informationDto.PercentageComponent);

                            informationDto.PriceAdjustmentAmount = (product.ProductPricingDTO.ProductPriceWithSpecsAndAttrs() *
                                                          informationDto.PercentageComponent);
                        }
                        else
                        {
                            valueDiscounts += informationDto.ValueComponent;
                            item.ProductDiscountTotal = informationDto.ValueComponent;

                            informationDto.PriceAdjustmentAmount = informationDto.ValueComponent;
                        }

                        CartItem.DiscountInformationDtos.Add(informationDto);
                    });
                }

                product.ProductPricingDTO.ProductDiscounts = valueDiscounts;
                product.ProductPricingDTO.ProductDiscountsPercentage = percentDiscounts;
            }
            catch (System.Exception ex)
            {
            	    m_Logger.Error(ex);

                pricingApplied = false;
            }

            return pricingApplied;
           
        }
    }
}
