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
//using Fabrik.Common;

namespace Bec.TargetFramework.Business.Product.Processor
{
    public static class ProductPricingProcessor
    {
        public static CartItemPricingDTO CalculateProductPrice(IDbContextReadOnlyScope scope, ShoppingCartItem cartItem)
        {
            Ensure.That(cartItem).IsNotNull();

            var itemPrice = new CartItemPricingDTO
            {
                ShoppingCartItemID = cartItem.ShoppingCartItemID
            };

            new ProductPricingStep().ApplyPricing(scope, cartItem, itemPrice);
            new ProductAttributePricingStep().ApplyPricing(scope, cartItem, itemPrice);
            new ProductSpecPricingStep().ApplyPricing(scope, cartItem, itemPrice);
            new ProductDeductionPricingStep().ApplyPricing(scope, cartItem, itemPrice);
            new ProductDiscountPricingStep().ApplyPricing(scope, cartItem, itemPrice);

            return itemPrice;
        }
    }
}
