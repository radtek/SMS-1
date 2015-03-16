using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Business.Product.Base;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure.Log;
using EnsureThat;
//using Fabrik.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business.Product
{
    class ProductSpecPricingStep : ProductPricingStepBase
    {
        public ProductSpecPricingStep(ILogger logger, IProductLogic logic)
            : base(logger,logic)
        {
        }

        public override bool ApplyPricing(ProductDTO product)
        {
            Ensure.That(CartItem).IsNotNull();
            Ensure.That(ExchangeRate).IsNot(0);

            bool pricingApplied = true;

            try
            {
                decimal specCost = 0;

                if (CartItem.ShoppingCartItemProductSpecifications != null && CartItem.ShoppingCartItemProductSpecifications.Count > 0)
                {
                    CartItem.ShoppingCartItemProductSpecifications.ForEach(item =>
                    {
                        var spec = product.ProductDTOSpecOptions.Single(attr => attr.ProductSpecificationAttributeOptionID.Equals(item.ProductSpecificationAttributeOptionID));

                        decimal unitPrice = spec.Cost / ExchangeRate;

                        if (item.Quantity > 0)
                        {
                            specCost += (item.Quantity * unitPrice);
                        }
                    });
                }

                product.ProductPricingDTO.ProductSpecs = specCost;
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
