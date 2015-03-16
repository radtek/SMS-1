using Bec.TargetFramework.Business.Product.Base;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Fabrik.Common;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using EnsureThat;

namespace Bec.TargetFramework.Business.Product
{
    class ProductAttributePricingStep : ProductPricingStepBase
    {
        public ProductAttributePricingStep(ILogger logger, IProductLogic logic)
            : base(logger, logic)
        {
        }

        public override bool ApplyPricing(ProductDTO product)
        {
            Ensure.That(CartItem).IsNotNull();
            Ensure.That(ExchangeRate).IsNot(0);

            bool pricingApplied = true;

            try
            {
                decimal attrTotalCost = 0;

                // apply attributes
                if (CartItem.ShoppingCartItemProductAttributes != null && CartItem.ShoppingCartItemProductAttributes.Count > 0)
                {
                    CartItem.ShoppingCartItemProductAttributes.ForEach(item =>
                    {
                        var attrs = product.ProductDTOAttributes.Single(attr => attr.ProductVariantAttributeValueID.Equals(item.ProductVariantAttributeValueID));

                        decimal unitPrice = attrs.Cost / ExchangeRate;

                        if (item.Quantity > 0)
                        {
                            attrTotalCost += (item.Quantity * unitPrice);
                        }
                    });
                }

                product.ProductPricingDTO.ProductAttrs = attrTotalCost;
            }
            catch (System.Exception ex)
            {
            	    m_Logger.Error(ex);

                pricingApplied = false;
            }

            return pricingApplied;
        }
    }
}
