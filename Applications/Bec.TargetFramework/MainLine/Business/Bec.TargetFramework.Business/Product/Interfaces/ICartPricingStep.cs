using Bec.TargetFramework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Business.Product
{
    public interface ICartPricingStep
    {
        ShoppingCartDTO Cart {get;set;}

        decimal ExchangeRate {get;set;}

        bool ApplyPricing(ShoppingCartDTO dto);

        void InitialiseCart(ShoppingCartDTO cartItem,Guid? organisationID);

        List<VOrganisationCheckoutDiscountDTO> CheckoutDiscounts { get; set; }
        List<VCountryDeductionDTO> CountryDeductions { get; set; }
    }
}
