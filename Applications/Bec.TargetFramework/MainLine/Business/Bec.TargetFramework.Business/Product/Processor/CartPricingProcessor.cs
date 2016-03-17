using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure.Log;
using EnsureThat;
using Bec.TargetFramework.Business.Logic;
using Bec.TargetFramework.Data;
using Mehdime.Entity;
using Bec.TargetFramework.Business.Product.Helpers;

namespace Bec.TargetFramework.Business.Product.Processor
{
    public static class CartPricingProcessor
    {
        public static CartPricingDTO CalculateCartPrice(IDbContextReadOnlyScope scope, Guid cartID)
        {
            Ensure.That(cartID).IsNot(Guid.Empty);

            var cart = scope.DbContexts.Get<TargetFrameworkEntities>().ShoppingCarts.Single(x => x.ShoppingCartID == cartID);

            CartPricingDTO cartPrice = new CartPricingDTO
            {
                ExchangeRate = cart.CurrencyRate,
                DeductionInformationDtos = new List<InformationDTO>(),
                DiscountInformationDtos = new List<InformationDTO>(),
                TaxInformationDtos = new List<InformationDTO>()
            };


            CartPricingStep(cart, cartPrice);
            CartDeductionPricingStep(scope, cart, cartPrice);
            CartDiscountPricingStep(scope, cart, cartPrice);

            cartPrice.CartFinalPrice = cartPrice.Total;

            return cartPrice;
        }

        public static void CartDeductionPricingStep(IDbContextReadOnlyScope scope, ShoppingCart cart, CartPricingDTO dto)
        {
            dto.DeductionInformationDtos = new List<InformationDTO>();
            dto.TaxInformationDtos = new List<InformationDTO>();

            foreach (var d in DeductionHelper.GetCountryDeductions(scope, cart.CountryCode))
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

        public static void CartDiscountPricingStep(IDbContextReadOnlyScope scope, ShoppingCart cart, CartPricingDTO pricingDto)
        {
            pricingDto.DiscountInformationDtos = new List<InformationDTO>();
            if (cart.OrganisationID.HasValue)
            {
                decimal discountPercentage = 0;
                decimal discountValue = 0;

                foreach (var od in DeductionHelper.GetOrganisationCheckoutDiscounts(scope, cart.OrganisationID.Value))
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

        public static void CartPricingStep(ShoppingCart cart, CartPricingDTO pricingDto)
        {
            // perform initial pricing
            foreach (var item in cart.ShoppingCartItems.Where(s => s.IsActive == true && s.IsDeleted == false))
            {
                // apply pricing processor
                var itemPrice = ProductPricingProcessor.CalculateProductPrice(item);
                pricingDto.AddItemPrice(itemPrice);
                pricingDto.CartTotalExcludingDiscountsAndTaxAndDeduct += (item.Quantity * itemPrice.PriceInclDiscountsAndDeducts);
            }
        }
    }
}
