using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Business.Product.Steps;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure.Log;
using EnsureThat;
using Bec.TargetFramework.Business.Logic;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Data;
using Mehdime.Entity;
//using Fabrik.Common;

namespace Bec.TargetFramework.Business.Product.Processor
{
    public static class CartPricingProcessor
    {
        public static CartPricingDTO CalculateCartPrice(IDbContextReadOnlyScope scope, Guid cartID, Guid? organisationId = null)
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


            new CartPricingStep().ApplyPricing(scope, cart, cartPrice);
            new CartDeductionPricingStep().ApplyPricing(scope, cart, cartPrice);
            new CartDiscountPricingStep().ApplyPricing(scope, cart, cartPrice);

            cartPrice.CartFinalPrice = cartPrice.Total;

            return cartPrice;
        }
    }
}
