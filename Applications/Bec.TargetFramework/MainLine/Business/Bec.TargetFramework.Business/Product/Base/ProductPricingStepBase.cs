using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.DTO.Payment;
using Bec.TargetFramework.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business.Product.Base
{
    public abstract class ProductPricingStepBase : IProductPricingStep
    {
        public ILogger m_Logger;
        private ShoppingCartItemDTO m_CartItem;
        private decimal m_ExchangeRate;
        private IProductLogic m_ProductLogic;
        private ProductDTO m_ProductDto;
        public Bec.TargetFramework.Entities.ProductDTO ProductDto
        {
            get { return m_ProductDto; }
            set { m_ProductDto = value; }
        }
        #region Properties

        public decimal ExchangeRate
        {
            get { return m_ExchangeRate; }
            set { m_ExchangeRate = value; }
        }
        public Bec.TargetFramework.Entities.ShoppingCartItemDTO CartItem
        {
            get { return m_CartItem; }
            set { m_CartItem = value; }
        }

        #endregion

        public ProductPricingStepBase(ILogger logger,IProductLogic logic)
        {
            m_Logger = logger;
            m_ProductLogic = logic;
        }

        public void InitialiseProduct(ShoppingCartItemDTO cartItem, decimal exchangeRate,ProductDTO productDto = null)
        {
            CartItem = cartItem;

            // load productDTO
            if (productDto == null)
                m_ProductDto = m_ProductLogic.GetProductWithSpecsAttributesAndDeductions(CartItem.ProductID,
                    CartItem.ProductVersionID, true);
            else
                m_ProductDto = productDto;

            if(m_ProductDto.ProductPricingDTO == null)
                m_ProductDto.ProductPricingDTO = new ProductPricingDTO();

            // set base pricing
            m_ProductDto.ProductPricingDTO.ProductPrice = m_ProductDto.CurrentDetail.Price;
            m_ProductDto.ProductPricingDTO.ProductCost = m_ProductDto.CurrentDetail.ProductCost;

            // set exchangerate
            ExchangeRate = exchangeRate;
        }

        public abstract bool ApplyPricing(ProductDTO dto);
    }
}
