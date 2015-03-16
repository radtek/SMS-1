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
    class ProductDeductionPricingStep : ProductPricingStepBase
    {
        public ProductDeductionPricingStep(ILogger logger, IProductLogic logic)
            : base(logger, logic)
        {
        }

        public override bool ApplyPricing(ProductDTO product)
        {
            bool pricingApplied = true;

            try
            {
                CartItem.DeductionInformationDtos = new List<InformationDTO>();

                decimal valueDeductions = 0;
                decimal percentDeductions = 0;
                // apply value deductions
                if (product.ProductDTODeductions.Any())
                {
                    product.ProductDTODeductions.Where(d => d.IsActive == true && d.IsDeleted == false).ToList().ForEach(item =>
                    {
                        var informationDto = new PricingHelper().CalculateProductDeductionTierPricing(CartItem, product,
                            item);

                        if (item.IsPercentageBased)
                        {
                            percentDeductions += informationDto.PercentageComponent;
                            item.ProductDeductionTotalPercentage = (product.ProductPricingDTO.ProductPriceWithSpecsAndAttrs() *
                                                                   informationDto.PercentageComponent);

                            informationDto.PriceAdjustmentAmount = (product.ProductPricingDTO.ProductPriceWithSpecsAndAttrs() *
                                                                   informationDto.PercentageComponent);
                        }
                        else
                        {
                            valueDeductions += informationDto.ValueComponent;
                            item.ProductDeductionTotal = informationDto.ValueComponent;

                            informationDto.PriceAdjustmentAmount = informationDto.ValueComponent;
                        }

                        CartItem.DeductionInformationDtos.Add(informationDto);
                    });
                }

                product.ProductPricingDTO.ProductDeductions = valueDeductions;
                product.ProductPricingDTO.ProductDeductionsPercentage = percentDeductions;
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
