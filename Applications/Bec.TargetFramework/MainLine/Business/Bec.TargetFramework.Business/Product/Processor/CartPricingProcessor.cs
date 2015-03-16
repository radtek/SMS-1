using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Business.Product.Steps;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure.Log;
using EnsureThat;
//using Fabrik.Common;

namespace Bec.TargetFramework.Business.Product.Processor
{
    public class CartPricingProcessor
    {
        private ILogger m_Logger;
        private IProductLogic m_ProductLogic;
        private ProductPricingProcessor m_Processor;
        private IShoppingCartLogic m_CartLogic;

        public CartPricingProcessor(ILogger logger, IProductLogic logic,IShoppingCartLogic cLogic,ProductPricingProcessor processor)
        {
            m_Logger = logger;
            m_ProductLogic = logic;
            m_Processor = processor;
            m_CartLogic = cLogic;
        }

        public void CalculateCartPrice(ShoppingCartDTO cart,Guid? organisationId)
        {
            Ensure.That(cart).IsNotNull();

            var firstStep = new CartPricingStep(m_Logger,m_ProductLogic,m_CartLogic,m_Processor);

            firstStep.InitialiseCart(cart, organisationId);

            firstStep.ApplyPricing(firstStep.Cart);

            ApplyPricingStep<CartDeductionPricingStep>(firstStep, firstStep.Cart);
            ApplyPricingStep<CartDiscountPricingStep>(firstStep, firstStep.Cart);

            cart.PriceDTO = firstStep.Cart.PriceDTO;
            cart.PriceDTO.CartFinalPrice = cart.PriceDTO.Total;
        }

        private bool ApplyPricingStep<T>(ICartPricingStep initialStep, ShoppingCartDTO dto) where T : ICartPricingStep
        {
            ICartPricingStep pricingStep = (ICartPricingStep)Activator.CreateInstance(typeof(T), new object[] { m_Logger, m_ProductLogic, m_CartLogic,m_Processor });

            pricingStep.Cart = initialStep.Cart;
            pricingStep.ExchangeRate = initialStep.ExchangeRate;
            pricingStep.CheckoutDiscounts = initialStep.CheckoutDiscounts;
            pricingStep.CountryDeductions = initialStep.CountryDeductions;

            return pricingStep.ApplyPricing(dto);
        }
    }
}
