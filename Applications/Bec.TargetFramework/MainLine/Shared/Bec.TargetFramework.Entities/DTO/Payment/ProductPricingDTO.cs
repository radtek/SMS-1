using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities.DTO.Payment
{
    [DataContract]
    [Serializable]
    public class ProductPricingDTO
    {
        [DataMember]
        public decimal ProductCost { get; set; }

        [DataMember]
        public decimal ProductSpecs { get; set; }

        [DataMember]
        public decimal ProductAttrs { get; set; }

        public decimal ProductPriceWithSpecsAndAttrs()
        {
            return (ProductPrice + ProductSpecs + ProductAttrs);
        }

        public decimal Deductions
        {
            get
            {
                decimal productPrice = ProductPriceWithSpecsAndAttrs();
                decimal totalTax = 0;

                // subtract discount percentage
                if (ProductDiscountsPercentage > 0)
                    productPrice -= (productPrice * ProductDiscountsPercentage);

                // subtract discount value
                if (ProductDiscounts > 0)
                    productPrice -= ProductDiscounts;

                // apply deduction values
                if (ProductDeductions > 0)
                    totalTax = ProductDeductions;

                // apply deduction percentage
                if (ProductDeductionsPercentage > 0)
                    totalTax += (productPrice * ProductDeductionsPercentage);

                return totalTax;
            }
        }

        public decimal Discounts
        {
            get
            {
                decimal productPrice = ProductPriceWithSpecsAndAttrs();
                decimal totalDiscount = 0;

                // subtract discount percentage
                if (ProductDiscountsPercentage > 0)
                    totalDiscount -= (productPrice * ProductDiscountsPercentage);

                // subtract discount value
                if (ProductDiscounts > 0)
                    totalDiscount -= ProductDiscounts;

                return totalDiscount;
            }
        }

        public decimal PriceInclDiscountsAndDeducts
        {
            get
            {
                decimal productPrice = ProductPriceWithSpecsAndAttrs();

                // subtract discount percentage
                if (ProductDiscountsPercentage > 0)
                    productPrice -= (productPrice * ProductDiscountsPercentage);

                // subtract discount value
                if (ProductDiscounts > 0)
                    productPrice -= ProductDiscounts;

                // apply deduction values
                if (ProductDeductions > 0)
                    productPrice += ProductDeductions;

                // apply deduction percentage
                if (ProductDeductionsPercentage > 0)
                    productPrice += (productPrice * ProductDeductionsPercentage);

                return productPrice;

            }
            
        }

        public decimal PriceExclDiscountsAndDeduct
        {
            get
            {

                decimal productPrice = ProductPriceWithSpecsAndAttrs();

                // subtract discount percentage
                if (ProductDiscountsPercentage > 0)
                    productPrice -= (productPrice * ProductDiscountsPercentage);

                // subtract discount value
                if (ProductDiscounts > 0)
                    productPrice -= ProductDiscounts;

                return productPrice;
            }
           
        }

        public decimal PriceInclDiscounts
        {
            get
            {
                decimal productPrice = ProductPriceWithSpecsAndAttrs();

                // subtract discount percentage
                if (ProductDiscountsPercentage > 0)
                    productPrice -= (productPrice * ProductDiscountsPercentage);

                // subtract discount value
                if (ProductDiscounts > 0)
                    productPrice -= ProductDiscounts;

                return productPrice;

            }

        }

        public decimal PriceExclDiscounts
        {
            get
            {

                decimal productPrice = ProductPriceWithSpecsAndAttrs();

                return productPrice;
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
