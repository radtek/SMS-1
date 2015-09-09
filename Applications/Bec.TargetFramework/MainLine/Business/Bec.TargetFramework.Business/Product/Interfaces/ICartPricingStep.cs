using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Business.Product.Processor;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure.Log;
using Bec.TargetFramework.Business.Logic;
using Mehdime.Entity;

namespace Bec.TargetFramework.Business.Product.Interfaces
{
    public interface ICartPricingStep
    {
        void ApplyPricing(IDbContextReadOnlyScope scope, ShoppingCart cart, CartPricingDTO pricingDto);
    }
}
