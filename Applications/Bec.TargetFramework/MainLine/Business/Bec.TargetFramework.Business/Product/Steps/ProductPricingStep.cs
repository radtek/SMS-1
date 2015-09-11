using Bec.TargetFramework.Business.Logic;
using Bec.TargetFramework.Business.Product.Interfaces;
using Bec.TargetFramework.Business.Product.Helpers;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure.Log;
//using Fabrik.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mehdime.Entity;

namespace Bec.TargetFramework.Business.Product
{
    class ProductPricingStep : IProductPricingStep
    {
        public void ApplyPricing(IDbContextReadOnlyScope scope, ShoppingCartItem cartItem, CartItemPricingDTO itemPrice)
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
    }
}
