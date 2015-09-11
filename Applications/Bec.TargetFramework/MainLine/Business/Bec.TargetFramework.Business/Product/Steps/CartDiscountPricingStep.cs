using Bec.TargetFramework.Business.Product.Helpers;
using Bec.TargetFramework.Business.Product.Interfaces;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities;
using Mehdime.Entity;
using System.Collections.Generic;

namespace Bec.TargetFramework.Business.Product.Steps
{
    class CartDiscountPricingStep : ICartPricingStep
    {
        public void ApplyPricing(IDbContextReadOnlyScope scope, ShoppingCart cart, CartPricingDTO pricingDto)
        {
            pricingDto.DiscountInformationDtos = new List<InformationDTO>();
            if (cart.OrganisationID.HasValue)
            {
                decimal discountPercentage = 0;
                decimal discountValue = 0;

                foreach(var od in DeductionHelper.GetOrganisationCheckoutDiscounts(scope, cart.OrganisationID.Value))
                {
                    var informationDto = PricingHelper.CalculateCheckoutDiscountTierPricing(pricingDto, od.Discount);

                    if (od.Discount.IsPercentage)
                        discountPercentage += informationDto.PercentageComponent;
                    else
                        discountValue += informationDto.ValueComponent;

                    pricingDto.DiscountInformationDtos.Add(informationDto);
                }

                pricingDto.CartTotalDiscounts = discountValue;
                pricingDto.CartTotalDiscountsPercentage = discountPercentage;
                
            }
        }
    }
}
