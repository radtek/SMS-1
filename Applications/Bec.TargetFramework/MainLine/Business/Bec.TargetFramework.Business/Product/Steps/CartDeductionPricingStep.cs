using Bec.TargetFramework.Business.Product.Helpers;
using Bec.TargetFramework.Business.Product.Interfaces;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Business.Product.Steps
{
    class CartDeductionPricingStep : ICartPricingStep
    {
        public void ApplyPricing(UnitOfWorkScope<TargetFrameworkEntities> scope, ShoppingCart cart, CartPricingDTO dto)
        {
            dto.DeductionInformationDtos = new List<InformationDTO>();
            dto.TaxInformationDtos = new List<InformationDTO>();

            foreach (var d in DeductionHelper.GetCountryDeductions(scope, cart.CountryCode)
                .SelectMany(x => x.Deduction.Products, (x, y) => new { CountryDeduction = x, Product = y }))
            {

                var informationDto = PricingHelper.CalculateCheckoutDeductionPricing(cart, dto, d.CountryDeduction, d.Product);
                if (d.Product != null)
                {
                    if (d.CountryDeduction.Deduction.IsPercentageBased)
                        dto.CartTotalDeductionsPercentage += informationDto.PercentageComponent;
                    else
                        dto.CartTotalDeductions += informationDto.ValueComponent;

                    dto.DeductionInformationDtos.Add(informationDto);
                }
                else
                {
                    if (d.CountryDeduction.Deduction.IsPercentageBased)
                        dto.CartTotalTaxPercentage += informationDto.PercentageComponent;
                    else
                        dto.CartTotalTax += informationDto.ValueComponent;

                    dto.TaxInformationDtos.Add(informationDto);
                }
            }

        }
    }
}