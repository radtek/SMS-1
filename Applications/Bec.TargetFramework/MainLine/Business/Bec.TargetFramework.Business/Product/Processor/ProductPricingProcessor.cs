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
    public static class ProductPricingProcessor
    {
        public static CartItemPricingDTO CalculateProductPrice(ShoppingCartItem cartItem)
        {
            Ensure.That(cartItem).IsNotNull();

            var itemPrice = new CartItemPricingDTO
            {
                ShoppingCartItemID = cartItem.ShoppingCartItemID
            };

            ProductPricingStep(cartItem, itemPrice);
            ProductAttributePricingStep(cartItem, itemPrice);
            ProductSpecPricingStep(cartItem, itemPrice);
            ProductDeductionPricingStep(cartItem, itemPrice);
            ProductDiscountPricingStep(cartItem, itemPrice);

            return itemPrice;
        }

        public static void ProductAttributePricingStep(ShoppingCartItem cartItem, CartItemPricingDTO itemPrice)
        {
            Ensure.That(cartItem).IsNotNull();

            decimal attrTotalCost = 0;

            foreach (var item in cartItem.ShoppingCartItemProductAttributes)
            {
                if (item.Quantity > 0)
                {
                    var attr = cartItem.Product.ProductProductAttributes.SelectMany(x => x.ProductVariantAttributeValues)
                        .Single(x => x.ProductVariantAttributeValueID == item.ProductVariantAttributeValueID);

                    decimal unitPrice = attr.Cost / cartItem.ShoppingCart.CurrencyRate;
                    attrTotalCost += (item.Quantity * unitPrice);
                }
            }
            itemPrice.ProductAttrs = attrTotalCost;
        }

        public static void ProductDeductionPricingStep(ShoppingCartItem cartItem, CartItemPricingDTO itemPrice)
        {
            itemPrice.DeductionInformationDtos = new List<InformationDTO>();

            decimal valueDeductions = 0;
            decimal percentDeductions = 0;
            // apply value deductions
            foreach (var item in cartItem.Product.ProductDeductions.Where(d => d.IsActive == true && d.IsDeleted == false))
            {
                var informationDto = PricingHelper.CalculateProductDeductionTierPricing(cartItem, item);

                if (item.Deduction.IsPercentageBased)
                {
                    percentDeductions += informationDto.PercentageComponent;
                    informationDto.PriceAdjustmentAmount = itemPrice.ProductPriceWithSpecsAndAttrs * informationDto.PercentageComponent;
                }
                else
                {
                    valueDeductions += informationDto.ValueComponent;
                    informationDto.PriceAdjustmentAmount = informationDto.ValueComponent;
                }

                itemPrice.DeductionInformationDtos.Add(informationDto);
            }

            itemPrice.ProductDeductions = valueDeductions;
            itemPrice.ProductDeductionsPercentage = percentDeductions;

        }

        public static void ProductDiscountPricingStep(ShoppingCartItem cartItem, CartItemPricingDTO itemPrice)
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
                    informationDto.PriceAdjustmentAmount = itemPrice.ProductPriceWithSpecsAndAttrs * informationDto.PercentageComponent;
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

        public static void ProductPricingStep(ShoppingCartItem cartItem, CartItemPricingDTO itemPrice)
        {
            var detail = cartItem.Product.ProductDetails.First();
            itemPrice.ProductCost = detail.ProductCost;

            // apply tier pricing if needed
            if (detail.HasTierPrices)
            {
                var infoDto = PricingHelper.CalculateProductTierPricing(cartItem);
                itemPrice.ProductPrice = infoDto.ValueComponent;
            }
            else
            {
                if (detail.CustomerEntersPrice)
                    itemPrice.ProductPrice = cartItem.CustomerPrice.Value;
                else
                    itemPrice.ProductPrice = detail.Price;
            }
        }

        public static void ProductSpecPricingStep(ShoppingCartItem cartItem, CartItemPricingDTO itemPrice)
        {
            Ensure.That(cartItem).IsNotNull();

            decimal specCost = 0;

            foreach (var item in cartItem.ShoppingCartItemProductSpecifications)
            {
                if (item.Quantity > 0)
                {
                    var spec = cartItem.Product.ProductSpecificationAttributes.SelectMany(x => x.ProductSpecificationAttributeOptions)
                        .Single(x => x.ProductSpecificationAttributeOptionID == item.ProductSpecificationAttributeOptionID);

                    decimal unitPrice = spec.Cost / cartItem.ShoppingCart.CurrencyRate;
                    specCost += (item.Quantity * unitPrice);
                }
            }

            itemPrice.ProductSpecs = specCost;
        }
    }
}
