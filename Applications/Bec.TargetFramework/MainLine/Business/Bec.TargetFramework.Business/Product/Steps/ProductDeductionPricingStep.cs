using Bec.TargetFramework.Business.Logic;
using Bec.TargetFramework.Business.Product.Interfaces;
using Bec.TargetFramework.Business.Product.Helpers;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mehdime.Entity;

namespace Bec.TargetFramework.Business.Product
{
    class ProductDeductionPricingStep : IProductPricingStep
    {
        public void ApplyPricing(IDbContextReadOnlyScope scope, ShoppingCartItem cartItem, CartItemPricingDTO itemPrice)
        {
            itemPrice.DeductionInformationDtos = new List<InformationDTO>();

            decimal valueDeductions = 0;
            decimal percentDeductions = 0;
            // apply value deductions
            foreach (var item in cartItem.Product.ProductDeductions.Where(d => d.IsActive == true && d.IsDeleted == false))
            {
                var informationDto = PricingHelper.CalculateProductDeductionTierPricing(cartItem, item);

                if (item.Deduction.IsPercentageBased)
                {
                    percentDeductions += informationDto.PercentageComponent;                    
                    informationDto.PriceAdjustmentAmount = itemPrice.ProductPriceWithSpecsAndAttrs * informationDto.PercentageComponent;
                }
                else
                {
                    valueDeductions += informationDto.ValueComponent;
                    informationDto.PriceAdjustmentAmount = informationDto.ValueComponent;
                }

                itemPrice.DeductionInformationDtos.Add(informationDto);
            }

            itemPrice.ProductDeductions = valueDeductions;
            itemPrice.ProductDeductionsPercentage = percentDeductions;
            
        }
    }
}
