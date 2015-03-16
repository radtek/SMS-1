using Bec.TargetFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business.Product
{
    public interface IProductPricingStep
    {
        ShoppingCartItemDTO CartItem {get;set;}

        Bec.TargetFramework.Entities.ProductDTO ProductDto { get; set; }

        decimal ExchangeRate {get;set;}

        bool ApplyPricing(ProductDTO dto);

        void InitialiseProduct(ShoppingCartItemDTO cartItem, decimal exchangeRate, ProductDTO productDto = null);
    }
}
