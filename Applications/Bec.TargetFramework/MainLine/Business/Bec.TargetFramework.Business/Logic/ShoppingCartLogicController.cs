﻿using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using Bec.TargetFramework.Infrastructure;
using Bec.TargetFramework.Infrastructure.Caching;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Infrastructure.Log;
using EnsureThat;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business.Logic
{
    [Trace(TraceExceptionsOnly = true)]
    public class ShoppingCartLogicController : LogicBase
    {
        public ProductLogicController ProductLogic { get; set; }

        public ShoppingCartLogicController() 
        {
        }

        public async Task<ShoppingCartDTO> CreateShoppingCartAsync(Guid userAccountOrganisationID, PaymentCardTypeIDEnum cardTypeEnum, PaymentMethodTypeIDEnum paymentTypeEnum, string countryCode = "UK")
        {
            Ensure.That(userAccountOrganisationID).IsNot(Guid.Empty);
            Ensure.That(countryCode).IsNotNullOrEmpty();

            using (var scope = DbContextScopeFactory.Create())
            {
                var curr = scope.DbContexts.Get<TargetFrameworkEntities>().VCountryAndCurrencies.Single(s => s.CountryCode.Equals(countryCode));
                var cart = new ShoppingCart
                {
                    ShoppingCartID = Guid.NewGuid(),
                    CreatedOn = DateTime.Now,
                    PaymentCardTypeID = cardTypeEnum.GetIntValue(),
                    PaymentMethodTypeID = paymentTypeEnum.GetIntValue(),
                    UserAccountOrganisationID = userAccountOrganisationID,
                    GlobalPaymentMethodID = LogicHelper.GetGlobalPaymentMethodIDForOnlineTransactions(scope),
                    CountryCode = countryCode,
                    CurrencyCode = curr.CurrencyCode,
                    CurrencyRate = curr.CurrencyRate,
                    CurrencyRateDate = curr.CurrencyRateDate,
                    CurrencyRateToGBP = curr.CurrencyRateToGBP.GetValueOrDefault(0),
                    CurrencyRateToUSD = curr.CurrencyRateToUSD,
                };

                scope.DbContexts.Get<TargetFrameworkEntities>().ShoppingCarts.Add(cart);
                await scope.SaveChangesAsync();
                return cart.ToDto();
            }
        }


        public async Task AddProductToShoppingCartAsync(Guid cartID, Guid productID, int versionNumber, int quantity, decimal? customerPrice = null)
        {
            Ensure.That(cartID).IsNot(Guid.Empty);
            Ensure.That(productID).IsNot(Guid.Empty);
            Ensure.That(versionNumber).IsNot(0);
            Ensure.That(quantity).IsNot(0);

            using (var scope = DbContextScopeFactory.Create())
            {
                var product = scope.DbContexts.Get<TargetFrameworkEntities>().Products.Single(x => x.ProductID == productID && x.ProductVersionID == versionNumber);

                var newItem = new ShoppingCartItem
                {
                    ShoppingCartItemID = Guid.NewGuid(),
                    ShoppingCartID = cartID,
                    Product = product,
                    Quantity = quantity,
                    CustomerPrice = customerPrice
                };
                scope.DbContexts.Get<TargetFrameworkEntities>().ShoppingCartItems.Add(newItem);
                await scope.SaveChangesAsync();
            }
        }

        public async Task RemoveProductFromShoppingCart(Guid cartID, Guid itemID)
        {
            Ensure.That(cartID).IsNot(Guid.Empty);
            Ensure.That(itemID).IsNot(Guid.Empty);
            using (var scope = DbContextScopeFactory.Create())
            {
                var cart = scope.DbContexts.Get<TargetFrameworkEntities>().ShoppingCarts.Single(x => x.ShoppingCartID == cartID);
                var cartItem = cart.ShoppingCartItems.Single(x => x.ShoppingCartItemID == itemID);
                cart.ShoppingCartItems.Remove(cartItem);
                await scope.SaveChangesAsync();
            }
        }
    }
}