using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Business.Product.Base;
using Bec.TargetFramework.Business.Product.Helpers;
using Bec.TargetFramework.Business.Product.Processor;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure.Log;

namespace Bec.TargetFramework.Business.Product.Steps
{
    public class CartDiscountPricingStep : CartPricingStepBase
    {
        public CartDiscountPricingStep(ILogger logger, IProductLogic logic, IShoppingCartLogic cartLogic, ProductPricingProcessor processor)
            : base(logger, logic, cartLogic, processor)
        {}

        public override bool ApplyPricing(ShoppingCartDTO cartDto)
        {
            if (this.CheckoutDiscounts != null && this.CheckoutDiscounts.Any())
            {
                cartDto.DiscountInformationDtos = new List<InformationDTO>();

                bool success = true;

                try
                {
                    decimal discountPercentage = 0;
                    decimal discountValue = 0;

                    CheckoutDiscounts.ForEach(cd =>
                    {
                        var informationDto = new PricingHelper().CalculateCheckoutDiscountTierPricing(Cart, cd);

                        if (cd.IsPercentage)
                            discountPercentage += informationDto.PercentageComponent;
                        else
                            discountValue += informationDto.ValueComponent;

                        cartDto.DiscountInformationDtos.Add(informationDto);
                    });

                    cartDto.PriceDTO.CartTotalDiscounts = discountValue;
                    cartDto.PriceDTO.CartTotalDiscountsPercentage = discountPercentage;
                }
                catch (Exception ex)
                {
                    m_Logger.Error(ex);
                    success = false;
                }

                return success;
            }
            else
                return true;
        }
    }
}
