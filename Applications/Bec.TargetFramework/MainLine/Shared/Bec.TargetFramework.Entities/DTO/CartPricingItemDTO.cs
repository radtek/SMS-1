
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{
    public class CartItemPricingDTO
    {
        public CartItemPricingDTO()
        {
            DeductionInformationDtos = new List<InformationDTO>();
            DiscountInformationDtos = new List<InformationDTO>();
        }
        public Guid ShoppingCartItemID { get; set; }
        public List<InformationDTO> DeductionInformationDtos { get; set; }
        public List<InformationDTO> DiscountInformationDtos { get; set; }

        [DataMember]
        public decimal ProductCost { get; set; }

        [DataMember]
        public decimal ProductSpecs { get; set; }

        [DataMember]
        public decimal ProductAttrs { get; set; }

        public decimal ProductPriceWithSpecsAndAttrs
        {
            get { return (ProductPrice + ProductSpecs + ProductAttrs); }
        }

        public decimal Deductions
        {
            get { return PriceInclDiscountsAndDeducts - PriceInclDiscounts; }
        }

        public decimal Discounts
        {
            get
            {
                decimal productPrice = ProductPriceWithSpecsAndAttrs;
                decimal totalDiscount = 0;

                // subtract discount percentage
                if (ProductDiscountsPercentage > 0) totalDiscount -= (productPrice * ProductDiscountsPercentage);

                // subtract discount value
                if (ProductDiscounts > 0) totalDiscount -= ProductDiscounts;

                return totalDiscount;
            }
        }

        public decimal PriceInclDiscountsAndDeducts
        {
            get
            {
                decimal productPrice = PriceInclDiscounts;

                // apply deduction values
                if (ProductDeductions > 0) productPrice += ProductDeductions;

                // apply deduction percentage
                if (ProductDeductionsPercentage > 0) productPrice += (productPrice * ProductDeductionsPercentage);

                return productPrice;
            }
        }

        public decimal PriceInclDiscounts
        {
            get
            {
                return ProductPriceWithSpecsAndAttrs + Discounts;
            }
        }

        public decimal PriceExclDiscounts
        {
            get
            {
                return ProductPriceWithSpecsAndAttrs;
            }
        }


        [DataMember]
        public decimal ProductPrice { get; set; }

        [DataMember]
        public decimal ProductFinalPrice { get; set; }

        [DataMember]
        public decimal ProductDiscounts { get; set; }
        [DataMember]
        public decimal ProductDeductions { get; set; }

        [DataMember]
        public decimal ProductDiscountsPercentage { get; set; }
        [DataMember]
        public decimal ProductDeductionsPercentage { get; set; }

        [DataMember]
        public decimal ProductCostWithDiscountsAndDeductions { get; set; }
    }
}
