using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Business.Product.Base;
using Bec.TargetFramework.Business.Product.Helpers;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure.Log;
//using Fabrik.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business.Product
{
    class ProductPricingStep : ProductPricingStepBase
    {
        public ProductPricingStep(ILogger logger, IProductLogic logic)
            : base(logger,logic)
        {
        }

        public override bool ApplyPricing(ProductDTO product)
        {
            // apply tier pricing if needed
            if (product.CurrentDetail.HasTierPrices)
            {
                var infoDto = new PricingHelper().CalculateProductTierPricing(CartItem, product);

                // apply change to product value
                product.ProductPricingDTO.ProductPrice = infoDto.ValueComponent;
            }

            return true;
        }
    }
}
