using Bec.TargetFramework.Business.Logic;
using Bec.TargetFramework.Business.Product.Interfaces;
using Bec.TargetFramework.Business.Product.Helpers;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mehdime.Entity;

namespace Bec.TargetFramework.Business.Product
{
    class ProductDiscountPricingStep : IProductPricingStep
    {
        public void ApplyPricing(IDbContextReadOnlyScope scope, ShoppingCartItem cartItem, CartItemPricingDTO itemPrice)
        {
            decimal valueDiscounts = 0;
            decimal percentDiscounts = 0;
            // apply value deductions
            foreach (var item in cartItem.Product.ProductDiscounts.Where(d => d.Discount.ValidTill >= DateTime.Now))
            {
                var informationDto = PricingHelper.CalculateProductDiscountTierPricing(cartItem, item);

                if (item.Discount.IsPercentage)
                {
                    percentDiscounts += informationDto.PercentageComponent;
                    informationDto.PriceAdjustmentAmount = itemPrice.ProductPriceWithSpecsAndAttrs *informationDto.PercentageComponent;
                }
                else
                {
                    valueDiscounts += informationDto.ValueComponent;
                    informationDto.PriceAdjustmentAmount = informationDto.ValueComponent;
                }

                itemPrice.DiscountInformationDtos.Add(informationDto);
            }

            itemPrice.ProductDiscounts = valueDiscounts;
            itemPrice.ProductDiscountsPercentage = percentDiscounts;
        }
    }
}
