using Bec.TargetFramework.Business.Product.Helpers;
using Bec.TargetFramework.Business.Product.Interfaces;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities;
using Mehdime.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Business.Product.Steps
{
    class CartDeductionPricingStep : ICartPricingStep
    {
        public void ApplyPricing(IDbContextReadOnlyScope scope, ShoppingCart cart, CartPricingDTO dto)
        {
            dto.DeductionInformationDtos = new List<InformationDTO>();
            dto.TaxInformationDtos = new List<InformationDTO>();

            foreach( var d in DeductionHelper.GetCountryDeductions(scope, cart.CountryCode))
            {
                if (d.Deduction.Products.Count == 0)
                {
                    var taxInfo = PricingHelper.CalculateCheckoutDeductionPricing(cart, dto, d, null);
                    if (d.Deduction.IsPercentageBased)
                        dto.CartTotalTaxPercentage += taxInfo.PercentageComponent;
                    else
                        dto.CartTotalTax += taxInfo.ValueComponent;

                    dto.TaxInformationDtos.Add(taxInfo);
                }
                else
                {
                    foreach (var p in d.Deduction.Products)
                    {
                        var deductionDto = PricingHelper.CalculateCheckoutDeductionPricing(cart, dto, d, p);
                        if (d.Deduction.IsPercentageBased)
                            dto.CartTotalDeductionsPercentage += deductionDto.PercentageComponent;
                        else
                            dto.CartTotalDeductions += deductionDto.ValueComponent;

                        dto.DeductionInformationDtos.Add(deductionDto);
                    }
                }
            }

        }
    }
}