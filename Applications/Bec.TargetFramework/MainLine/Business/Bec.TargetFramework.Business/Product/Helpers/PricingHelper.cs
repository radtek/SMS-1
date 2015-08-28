using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Entities;
using EnsureThat;

namespace Bec.TargetFramework.Business.Product.Helpers
{
    public class PricingHelper
    {
        private static ComponentTier GetTier(IEnumerable<ComponentTier> tiers, decimal total, int cardType, int paymentMethodType, int quantity)
        {
            var results = tiers.Where(s => s.IsActive == true && s.IsDeleted == false);

            if (IsBasedOnPaymentCardType(results) && IsBasedOnPaymentMethod(results))
            {
                results = results.Where(s => 
                    (s.ApplyOnPaymentCardTypeID == null ? false : s.ApplyOnPaymentCardTypeID.Value.Equals(cardType)) &&
                    (s.ApplyOnPaymentMethodTypeID == null ? false : s.ApplyOnPaymentMethodTypeID.Value.Equals(paymentMethodType)));
            }
            else if (IsBasedOnPaymentCardType(results))
            {
                results = results.Where(s => s.ApplyOnPaymentCardTypeID.HasValue && s.ApplyOnPaymentCardTypeID.Equals(cardType));
            }
            else if (IsBasedOnPaymentMethod(results))
            {
                results = results.Where(s => s.ApplyOnPaymentMethodTypeID.HasValue && s.ApplyOnPaymentMethodTypeID.Equals(paymentMethodType));
            }

            return filterTiers(results, total, quantity);
        }

        private static ComponentTier GetTier(IEnumerable<ComponentTier> tiers, decimal total, int quantity)
        {
            var results = tiers.Where(s => s.IsActive == true && s.IsDeleted == false);
            return filterTiers(results, total, quantity);
        }

        private static ComponentTier filterTiers(IEnumerable<ComponentTier> results, decimal total, int quantity)
        {
            if (IsValueBound(results))
            {
                results = results.Where(s =>
                    s.TotalValueLowerBound.HasValue
                    && s.TotalValueUpperBound.HasValue
                    && s.TotalValueLowerBound.Value >= total
                    && s.TotalValueUpperBound.Value <= total);
            }
            else if (IsQuantityBound(results))
            {
                results = results.Where(s =>
                    s.QuantityCountLowerBound.HasValue
                    && s.QuantityCountUpperBound.HasValue
                    && s.QuantityCountLowerBound.Value >= quantity
                    && s.QuantityCountUpperBound.Value <= quantity);
            }

            var list = results.ToList();

            Ensure.That(list.Count).IsNot(0);

            return list.First();
        }

        private static bool IsValueBound(IEnumerable<ComponentTier> tiers)
        {
            return tiers.Any(s => s.TotalValueLowerBound.HasValue);
        }

        private static bool IsQuantityBound(IEnumerable<ComponentTier> tiers)
        {
            return tiers.Any(s => s.QuantityCountLowerBound.HasValue);
        }

        private static bool IsBasedOnPaymentMethod(IEnumerable<ComponentTier> tiers)
        {
            return tiers.Any(s => s.ApplyOnPaymentMethodTypeID.HasValue);
        }

        private static bool IsBasedOnPaymentCardType(IEnumerable<ComponentTier> tiers)
        {
            return tiers.Any(s => s.ApplyOnPaymentCardTypeID.HasValue);
        }

        public static InformationDTO CalculateCheckoutDeductionPricing(ShoppingCart cart, CartPricingDTO pricingDto, CountryDeduction cd, Data.Product p)
        {
            var infoDto = new InformationDTO
            {
                Name = cd.Deduction.Name,
                Description = cd.Deduction.Description,
                InvoiceName = cd.Deduction.Name
            };

            if (cd.Deduction.ComponentTiers.Count > 0)
            {
                // get component tier
                var tier = GetTier(cd.Deduction.ComponentTiers, pricingDto.SubTotalDiscountsExclTaxAndDeduct, cart.PaymentCardTypeID, cart.PaymentMethodTypeID, 0);

                if (tier.IsPercentageBased)
                    infoDto.PercentageComponent = tier.TierPercentage.GetValueOrDefault(0);
                else
                    infoDto.ValueComponent = tier.TierPrice.GetValueOrDefault(0);
            }
            else if (p != null)
            {
                // get component tier
                var tier = GetTier(p.ComponentTiers, pricingDto.SubTotalDiscountsExclTaxAndDeduct, cart.PaymentCardTypeID, cart.PaymentMethodTypeID, 0);

                if (tier.IsPercentageBased)
                    infoDto.PercentageComponent = tier.TierPercentage.GetValueOrDefault(0);
                else
                    infoDto.ValueComponent = tier.TierPrice.GetValueOrDefault(0);
            }
            else
            {
                if (cd.Deduction.IsPercentageBased)
                    infoDto.PercentageComponent = cd.DeductionPercentage.GetValueOrDefault(0);
                else
                    infoDto.ValueComponent = cd.DeductionValue.GetValueOrDefault(0);
            }

            return infoDto;
        }

        public static InformationDTO CalculateProductTierPricing(ShoppingCartItem cartItem)
        {
            var detail = cartItem.Product.ProductDetails.First();

            var infoDto = new InformationDTO
            {
                Name = detail.Name,
                Description = detail.Description,
                InvoiceName = detail.InvoiceName
            };

            if (detail.HasTierPrices)
            {
                Ensure.That(cartItem.Product.ComponentTiers);

                // get component tier
                var tier = GetTier(cartItem.Product.ComponentTiers, detail.Price, cartItem.Quantity);
                
                //TBD do we need percentage tier pricing for products ??
                if (tier.IsPercentageBased)
                    infoDto.PercentageComponent = tier.TierPercentage.GetValueOrDefault(0);
                else
                    infoDto.ValueComponent = tier.TierPrice.GetValueOrDefault(0);
            }
            else
            {
                infoDto.ValueComponent = detail.Price;
            }

            return infoDto;
        }

        public static InformationDTO CalculateProductDeductionTierPricing(ShoppingCartItem cartItem, ProductDeduction pd)
        {
            var infoDto = new InformationDTO
            {
                Name = pd.Deduction.Name,
                Description = pd.Deduction.Description,
                InvoiceName = pd.Deduction.Name
            };

            if (pd.Deduction.ComponentTiers.Any())
            {
                // get component tier
                var tier = GetTier(pd.Deduction.ComponentTiers, cartItem.Product.ProductDetails.First().Price, cartItem.Quantity);

                //TBD do we need percentage tier pricing for products ??
                if (tier.IsPercentageBased)
                    infoDto.PercentageComponent = tier.TierPercentage.GetValueOrDefault(0);
                else
                    infoDto.ValueComponent = tier.TierPrice.GetValueOrDefault(0);
            }
            else
            {
                if (pd.Deduction.IsPercentageBased)
                    infoDto.PercentageComponent = pd.DeductionPercentage.GetValueOrDefault(0);
                else
                    infoDto.ValueComponent = pd.DeductionValue.GetValueOrDefault(0);
            }

            return infoDto;
        }

        public static InformationDTO CalculateProductDiscountTierPricing(ShoppingCartItem cartItem, ProductDiscount pd)
        {
            var infoDto = new InformationDTO
            {
                Name = pd.Discount.Name,
                Description = pd.Discount.Description,
                InvoiceName = pd.Discount.InvoiceName
            };

            if (pd.Discount.ComponentTiers.Any())
            {
                // get component tier
                var tier = GetTier(pd.Discount.ComponentTiers, cartItem.Product.ProductDetails.First().Price, cartItem.Quantity);

                //TBD do we need percentage tier pricing for products ??
                if (tier.IsPercentageBased)
                    infoDto.PercentageComponent = tier.TierPercentage.GetValueOrDefault(0);
                else
                    infoDto.ValueComponent = tier.TierPrice.GetValueOrDefault(0);
            }
            else
            {
                if (pd.Discount.IsPercentage)
                    infoDto.PercentageComponent = pd.Discount.DiscountPercentage.GetValueOrDefault(0);
                else
                    infoDto.ValueComponent = pd.Discount.DiscountAmount.GetValueOrDefault(0);
            }

            return infoDto;
        }

        public static InformationDTO CalculateCheckoutDiscountTierPricing(CartPricingDTO pricingDto, Discount discount)
        {
            var infoDto = new InformationDTO
            {
                Name = discount.Name,
                Description = discount.Description,
                InvoiceName = discount.InvoiceName
            };

            if (discount.HasTiers)
            {
                // get component tier
                var tier = GetTier(discount.ComponentTiers, pricingDto.SubTotalExclDiscountsAndTaxAndDeduct, 0);

                //TBD do we need percentage tier pricing for products ??
                if (tier.IsPercentageBased)
                    infoDto.PercentageComponent = tier.TierPercentage.GetValueOrDefault(0);
                else
                    infoDto.ValueComponent = tier.TierPrice.GetValueOrDefault(0);
            }
            else
            {
                if (discount.IsPercentage)
                    infoDto.PercentageComponent = discount.DiscountPercentage.GetValueOrDefault(0);
                else
                    infoDto.ValueComponent = discount.DiscountAmount.GetValueOrDefault(0);
            }

            return infoDto;
        }
    }
}
