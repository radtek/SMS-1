using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Bec.TargetFramework.Entities
{
    [DataContract]
    [Serializable]
    public class CartPriceDTO
    {
        [DataMember]
        public decimal CartTotalExcludingDiscountsAndTaxAndDeduct { get; set; }

        [DataMember]
        public decimal CartTotalDiscounts { get; set; }
        [DataMember]
        public decimal CartTotalDeductions { get; set; }

        [DataMember]
        public decimal CartTotalTax { get; set; }

        [DataMember]
        public decimal CartTotalDeductionsPercentage { get; set; }
        [DataMember]
        public decimal CartTotalDiscountsPercentage { get; set; }
        [DataMember]
        public decimal CartTotalTaxPercentage { get; set; }

        public decimal Tax
        {
            get
            {
                decimal initialValue = CartTotalExcludingDiscountsAndTaxAndDeduct;
                decimal taxValue = 0;

                if (CartTotalDiscounts > 0)
                    initialValue -= CartTotalDiscounts;

                if (CartTotalDiscountsPercentage > 0)
                    initialValue -= (CartTotalExcludingDiscountsAndTaxAndDeduct * CartTotalDiscountsPercentage);

                // apply percentage then value
                if (CartTotalDeductions > 0)
                    initialValue += CartTotalDeductions;

                if (CartTotalDeductionsPercentage > 0)
                    initialValue += (initialValue * CartTotalDeductionsPercentage);

                if (CartTotalTax > 0)
                    taxValue += CartTotalTax;

                if (CartTotalTaxPercentage > 0)
                    taxValue += (initialValue * CartTotalTaxPercentage);

                return taxValue;
            }
        }

        public decimal Deductions
        {
            get
            {
                decimal initialValue = CartTotalExcludingDiscountsAndTaxAndDeduct;
                decimal taxValue = 0;

                if (CartTotalDiscounts > 0)
                    initialValue -= CartTotalDiscounts;

                if (CartTotalDiscountsPercentage > 0)
                    initialValue -= (CartTotalExcludingDiscountsAndTaxAndDeduct * CartTotalDiscountsPercentage);

                // apply percentage then value
                if (CartTotalDeductions > 0)
                    taxValue += CartTotalDeductions;

                if (CartTotalDeductionsPercentage > 0)
                    taxValue += (initialValue * CartTotalDeductionsPercentage);

                return taxValue;
            }
        }

        public decimal Discounts
        {
            get
            {
                decimal initialValue = CartTotalExcludingDiscountsAndTaxAndDeduct;

                // apply percentage then value
                if (CartTotalDiscounts > 0)
                    initialValue -= CartTotalDiscounts;

                if (CartTotalDiscountsPercentage > 0)
                    initialValue -= (CartTotalExcludingDiscountsAndTaxAndDeduct * CartTotalDiscountsPercentage);

                return (CartTotalExcludingDiscountsAndTaxAndDeduct - initialValue);
            }
        }

        public decimal SubTotalExclDiscountsAndTaxAndDeduct
        {
            get
            {
                decimal initialValue = CartTotalExcludingDiscountsAndTaxAndDeduct;

                return initialValue; 
            }
        }

        public decimal SubTotalInclDiscountsAndTaxAndDeduct
        {
            get
            {
                decimal initialValue = SubTotalExclDiscountsAndTaxAndDeduct;

                // apply percentage then value
                if (CartTotalDeductions > 0)
                    initialValue += CartTotalDeductions;

                if (CartTotalDeductionsPercentage > 0)
                    initialValue += (initialValue * CartTotalDeductionsPercentage);

                if (CartTotalTax > 0)
                    initialValue += CartTotalTax;

                if (CartTotalTaxPercentage > 0)
                    initialValue += (initialValue * CartTotalTaxPercentage);

                return initialValue;
            }
        }

        public decimal SubTotalDiscountsExclTaxAndDeduct
        {
            get
            {
                decimal initialValue = CartTotalExcludingDiscountsAndTaxAndDeduct;

                // apply percentage then value
                if (CartTotalDiscounts > 0)
                    initialValue -= CartTotalDiscounts;

                if (CartTotalDiscountsPercentage > 0)
                    initialValue -= (CartTotalExcludingDiscountsAndTaxAndDeduct * CartTotalDiscountsPercentage);

                return initialValue;
            }
        }

        public decimal SubTotalDiscountsInclTaxAndDeduct
        {
            get
            {
                decimal initialValue = SubTotalDiscountsExclTaxAndDeduct;

                // apply percentage then value
                if (CartTotalDeductions > 0)
                    initialValue += CartTotalDeductions;

                if (CartTotalDeductionsPercentage > 0)
                    initialValue += (initialValue * CartTotalDeductionsPercentage);

                if (CartTotalTax > 0)
                    initialValue += CartTotalTax;

                if (CartTotalTaxPercentage > 0)
                    initialValue += (initialValue * CartTotalTaxPercentage);

                return initialValue;
            }
        }

        public decimal PaymentMethodAdditionalFeesInclTax
        {
            get
            {
                decimal initialValue = 0;

                // apply percentage then value
                if (CartTotalDeductions > 0)
                    initialValue += CartTotalDeductions;

                if (CartTotalDeductionsPercentage > 0)
                    initialValue += (SubTotalDiscountsExclTaxAndDeduct * CartTotalDeductionsPercentage);

                if (CartTotalTax > 0)
                    initialValue += CartTotalTax;

                if (CartTotalTaxPercentage > 0)
                    initialValue += (initialValue * CartTotalTaxPercentage);

                return initialValue;
            }
        }

        public decimal PaymentMethodAdditionalFeesExclTax
        {
            get
            {
                decimal initialValue = 0;

                // apply percentage then value
                if (CartTotalDeductions > 0)
                    initialValue += CartTotalDeductions;

                if (CartTotalDeductionsPercentage > 0)
                    initialValue += (SubTotalDiscountsExclTaxAndDeduct * CartTotalDeductionsPercentage);

                return initialValue;
            }
        }

        [DataMember]
        public decimal CartFinalPrice { get; set; }

        public decimal Total
        {
            get
            {
                decimal initialValue = CartTotalExcludingDiscountsAndTaxAndDeduct;

                // apply percentage then value
                if (CartTotalDiscounts > 0)
                    initialValue -= CartTotalDiscounts;

                if (CartTotalDiscountsPercentage > 0)
                    initialValue -= (CartTotalExcludingDiscountsAndTaxAndDeduct * CartTotalDiscountsPercentage);

                // apply percentage then value
                if (CartTotalDeductions > 0)
                    initialValue += CartTotalDeductions;

                if (CartTotalDeductionsPercentage > 0)
                    initialValue += (initialValue * CartTotalDeductionsPercentage);

                if (CartTotalTax > 0)
                    initialValue += CartTotalTax;

                if (CartTotalTaxPercentage > 0)
                    initialValue += (initialValue * CartTotalTaxPercentage);

                return initialValue; 
            }
        }

        
    }
}
