using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Business.Product.Processor;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure.Log;

namespace Bec.TargetFramework.Business.Product.Base
{
    public abstract class CartPricingStepBase : ICartPricingStep
    {
        public ILogger m_Logger;
        private ShoppingCartDTO m_Cart;
        private decimal m_ExchangeRate;
        private IProductLogic m_ProductLogic;
        private IShoppingCartLogic m_ShoppingCartLogic;
       
        private ProductPricingProcessor m_ProductPricingProcessor;
        private List<VOrganisationCheckoutDiscountDTO> m_CheckoutDiscounts; 
        private List<VCountryDeductionDTO> m_CountryDeductions;
        public List<VOrganisationCheckoutDiscountDTO> CheckoutDiscounts
        {
            get { return m_CheckoutDiscounts; }
            set { m_CheckoutDiscounts = value; }
        }
        public Bec.TargetFramework.Business.Product.Processor.ProductPricingProcessor ProductPricingProcessor
        {
            get { return m_ProductPricingProcessor; }
            set { m_ProductPricingProcessor = value; }
        }
        public List<VCountryDeductionDTO> CountryDeductions
        {
            get { return m_CountryDeductions; }
            set { m_CountryDeductions = value; }
        }
        #region Properties

        public decimal ExchangeRate
        {
            get { return m_ExchangeRate; }
            set { m_ExchangeRate = value; }
        }

        public Bec.TargetFramework.Entities.ShoppingCartDTO Cart
        {
            get { return m_Cart; }
            set { m_Cart = value; }
        }

        #endregion

        public CartPricingStepBase(ILogger logger, IProductLogic logic, IShoppingCartLogic cartLogic, ProductPricingProcessor processor)
        {
            m_Logger = logger;
            m_ProductLogic = logic;
            m_ShoppingCartLogic = cartLogic;
            m_ProductPricingProcessor = processor;
        }

        public void InitialiseCart(ShoppingCartDTO cart,Guid? organisationID)
        {
            // set cart
            Cart = cart;

            if(Cart.PriceDTO == null)
                Cart.PriceDTO = new CartPriceDTO();

            ExchangeRate = cart.CurrencyRate;

            m_CountryDeductions = m_ShoppingCartLogic.GetCountryDeductions(cart.CountryCode);

            if (organisationID.HasValue)
            m_CheckoutDiscounts = m_ShoppingCartLogic.GetOrganisationCheckoutDiscounts(organisationID.Value);
        }


        public abstract bool ApplyPricing(ShoppingCartDTO dto);
    }
}
