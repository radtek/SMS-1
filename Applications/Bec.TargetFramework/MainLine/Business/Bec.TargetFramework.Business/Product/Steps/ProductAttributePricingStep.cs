using Bec.TargetFramework.Business.Product.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnsureThat;
using Bec.TargetFramework.Business.Logic;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using Mehdime.Entity;

namespace Bec.TargetFramework.Business.Product
{
    class ProductAttributePricingStep : IProductPricingStep
    {
        public void ApplyPricing(IDbContextReadOnlyScope scope, ShoppingCartItem cartItem, CartItemPricingDTO itemPrice)
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
    }
}
