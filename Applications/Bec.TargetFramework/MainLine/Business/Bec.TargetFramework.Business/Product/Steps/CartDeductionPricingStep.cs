using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Business.Infrastructure.Interfaces;
using Bec.TargetFramework.Business.Product.Base;
using Bec.TargetFramework.Business.Product.Helpers;
using Bec.TargetFramework.Business.Product.Processor;
using Bec.TargetFramework.Infrastructure.Extensions;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Infrastructure.Log;

namespace Bec.TargetFramework.Business.Product.Steps
{
    public class CartDeductionPricingStep : CartPricingStepBase
    {
        public CartDeductionPricingStep(ILogger logger, IProductLogic logic, IShoppingCartLogic cartLogic, ProductPricingProcessor processor)
            : base(logger, logic, cartLogic, processor)
        {}

        public override bool ApplyPricing(ShoppingCartDTO dto)
        {
            if (this.CountryDeductions != null && this.CountryDeductions.Any())
            {
                dto.DeductionInformationDtos = new List<InformationDTO>();
                dto.TaxInformationDtos = new List<InformationDTO>();

                bool success = true;

                try
                {
                    decimal deductionsPercentage = 0;
                    decimal deductionsValue = 0;
                    decimal taxPercentage = 0;
                    decimal taxValue = 0;


                    CountryDeductions.ForEach(d =>
                    {
                        var informationDto = new PricingHelper().CalculateCheckoutDeductionPricing(Cart, d);

                        

                        if (d.IsProductDeduction.GetValueOrDefault(false))
                        {
                            if (d.IsPercentageBased)
                                deductionsPercentage += informationDto.PercentageComponent;
                            else
                                deductionsValue += informationDto.ValueComponent;

                            dto.DeductionInformationDtos.Add(informationDto);
                        }
                        else
                        {
                            if (d.IsPercentageBased)
                                taxPercentage += informationDto.PercentageComponent;
                            else
                                taxValue += informationDto.ValueComponent;

                            dto.TaxInformationDtos.Add(informationDto);
                        }


                    });

                    dto.PriceDTO.CartTotalDeductions = deductionsValue;
                    dto.PriceDTO.CartTotalDeductionsPercentage = deductionsPercentage;
                    dto.PriceDTO.CartTotalTax = taxValue;
                    dto.PriceDTO.CartTotalTaxPercentage = taxPercentage;
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
