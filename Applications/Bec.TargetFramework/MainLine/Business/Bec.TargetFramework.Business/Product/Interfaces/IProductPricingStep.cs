using Bec.TargetFramework.Business.Logic;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure.Log;
using Mehdime.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business.Product.Interfaces
{
    public interface IProductPricingStep
    {
        void ApplyPricing(IDbContextReadOnlyScope scope, ShoppingCartItem cartItem, CartItemPricingDTO itemPrice);
    }
}
