using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Business.Product.Interfaces;
using Bec.TargetFramework.Business.Product.Processor;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Business.Logic;
using Bec.TargetFramework.Data;
using Mehdime.Entity;

namespace Bec.TargetFramework.Business.Product.Steps
{
    class CartPricingStep : ICartPricingStep
    {
        public void ApplyPricing(IDbContextReadOnlyScope scope, ShoppingCart cart, CartPricingDTO pricingDto)
        {
            // perform initial pricing
            foreach(var item in cart.ShoppingCartItems.Where(s => s.IsActive == true && s.IsDeleted == false))
            {
                // apply pricing processor
                var itemPrice = ProductPricingProcessor.CalculateProductPrice(scope, item);
                pricingDto.AddItemPrice(itemPrice);
                pricingDto.CartTotalExcludingDiscountsAndTaxAndDeduct += (item.Quantity * itemPrice.PriceInclDiscountsAndDeducts);
            }
        }
    }
}
