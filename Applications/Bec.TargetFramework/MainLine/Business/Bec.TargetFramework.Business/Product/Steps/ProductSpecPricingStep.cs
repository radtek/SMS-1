using Bec.TargetFramework.Business.Logic;
using Bec.TargetFramework.Business.Product.Interfaces;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure.Log;
using EnsureThat;
using Mehdime.Entity;
//using Fabrik.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business.Product
{
    class ProductSpecPricingStep : IProductPricingStep
    {
        public void ApplyPricing(IDbContextReadOnlyScope scope, ShoppingCartItem cartItem, CartItemPricingDTO itemPrice)
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