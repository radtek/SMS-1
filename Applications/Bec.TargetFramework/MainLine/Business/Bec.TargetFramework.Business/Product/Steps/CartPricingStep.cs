using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Business.Product.Base;
using Bec.TargetFramework.Business.Product.Processor;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure.Log;

namespace Bec.TargetFramework.Business.Product.Steps
{
    public class CartPricingStep : CartPricingStepBase
    {
        public CartPricingStep(ILogger logger, IProductLogic logic, IShoppingCartLogic cartLogic,ProductPricingProcessor processor)
            : base(logger, logic, cartLogic, processor)
        {}

        public override bool ApplyPricing(ShoppingCartDTO cartDto)
        {
            bool pricingComplete = true;

            try
            {
                // perform initial pricing
                cartDto.ShoppingCartItems.Where(s => s.IsActive == true && s.IsDeleted == false).ToList().ForEach(item =>
                {
                    // apply pricing processor
                    ProductPricingProcessor.CalculateProductPriceWithDiscountAndDeduction(cartDto, item);

                    cartDto.PriceDTO.CartTotalExcludingDiscountsAndTaxAndDeduct += (item.Quantity * item.ProductPricingDto.PriceInclDiscountsAndDeducts);
                });
            }
            catch (Exception ex)
            {
                m_Logger.Error(ex);

                pricingComplete = false;
            }

            return pricingComplete;
        }
    }
}
