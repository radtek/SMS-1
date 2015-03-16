using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure.Log;
using EnsureThat;
//using Fabrik.Common;

namespace Bec.TargetFramework.Business.Product.Processor
{
    public class ProductPricingProcessor
    {
        private ILogger m_Logger;
        private IProductLogic m_ProductLogic;

        public ProductPricingProcessor(ILogger logger, IProductLogic logic)
        {
            m_Logger = logger;
            m_ProductLogic = logic;
        }

        public void CalculateProductPriceWithoutDiscountAndDeduction(ShoppingCartDTO cart,ShoppingCartItemDTO cartItem,ProductDTO productDto = null)
        {
            Ensure.That(cart).IsNotNull();
            Ensure.That(cartItem).IsNotNull();

            var firstStep = new ProductPricingStep(m_Logger,m_ProductLogic);

            firstStep.InitialiseProduct(cartItem,cart.CurrencyRate,productDto);

            firstStep.ApplyPricing(firstStep.ProductDto);

            ApplyDefaultPricing(firstStep);

            cartItem.ProductPricingDto = firstStep.ProductDto.ProductPricingDTO;
        }

        public void CalculateProductPriceWithDiscountAndDeduction(ShoppingCartDTO cart, ShoppingCartItemDTO cartItem, ProductDTO productDto = null)
        {
            Ensure.That(cart);
            Ensure.That(cartItem);

            var firstStep = new ProductPricingStep(m_Logger, m_ProductLogic);

            firstStep.InitialiseProduct(cartItem, cart.CurrencyRate, productDto);

            firstStep.ApplyPricing(firstStep.ProductDto);

            ApplyDefaultPricing(firstStep);
            ApplyDeductionAndDiscounts(firstStep);

            cartItem.ProductPricingDto = firstStep.ProductDto.ProductPricingDTO;
            cartItem.ProductPricingDto.ProductFinalPrice = cartItem.ProductPricingDto.PriceInclDiscountsAndDeducts;
        }

        private void ApplyDefaultPricing(IProductPricingStep initialStep)
        {
            ApplyPricingStep<ProductAttributePricingStep>(initialStep, initialStep.ProductDto);
            ApplyPricingStep<ProductSpecPricingStep>(initialStep, initialStep.ProductDto);
        }

        private void ApplyDeductionAndDiscounts(IProductPricingStep initialStep)
        {
            ApplyPricingStep<ProductDeductionPricingStep>(initialStep, initialStep.ProductDto);
            ApplyPricingStep<ProductDiscountPricingStep>(initialStep, initialStep.ProductDto);
        }

        private bool ApplyPricingStep<T>(IProductPricingStep initialStep,ProductDTO dto) where T : IProductPricingStep
        {
            IProductPricingStep pricingStep = (IProductPricingStep) Activator.CreateInstance(typeof(T), new object[] { m_Logger, m_ProductLogic });

            pricingStep.CartItem = initialStep.CartItem;
            pricingStep.ExchangeRate = initialStep.ExchangeRate;

            return pricingStep.ApplyPricing(dto);
        }
    }
}
