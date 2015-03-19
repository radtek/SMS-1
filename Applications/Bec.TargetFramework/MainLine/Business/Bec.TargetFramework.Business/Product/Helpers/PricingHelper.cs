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
        private List<ComponentTierDTO> m_ComponentTiers; 

        private ComponentTierDTO GetTier(List<ComponentTierDTO> tiers,  bool valueBound, bool quantityBound, bool cardTypeBound, bool paymentMethodBound,
            decimal total, int? cardType, int? paymentMethodType,int quantity)
        {
            var results = tiers.Where(s => s.IsActive == true
                                           && s.IsDeleted == false);

            if (cardTypeBound && paymentMethodBound)
            {
                Ensure.That(cardType).IsNotNull();
                Ensure.That(paymentMethodType).IsNotNull();

                results =
                    results.Where(s => (s.ApplyOnPaymentCardTypeID == null ? false : s.ApplyOnPaymentCardTypeID.Value.Equals(cardType.Value))
                                  && (s.ApplyOnPaymentMethodTypeID == null ? false : s.ApplyOnPaymentMethodTypeID.Value.Equals(paymentMethodType.Value)) 
                                  );
            }
            else if (cardTypeBound)
            {
                Ensure.That(cardType).IsNotNull();

                results =
                   results.Where(s => s.ApplyOnPaymentCardTypeID.HasValue &&
                                 s.ApplyOnPaymentCardTypeID.Equals(cardType.Value));
            }
            else if (paymentMethodBound)
            {
                Ensure.That(paymentMethodType);

                results =
                    results.Where(s => s.ApplyOnPaymentMethodTypeID.HasValue &&
                                  s.ApplyOnPaymentMethodTypeID.Equals(paymentMethodType.Value));
            }

            if (valueBound)
            {
                results = results.Where(s =>
                    s.TotalValueLowerBound.HasValue
                    && s.TotalValueUpperBound.HasValue
                    && s.TotalValueLowerBound.Value >= total
                    && s.TotalValueUpperBound.Value <= total);


            }
            else if (quantityBound)
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

        private ComponentTierDTO GetTier(List<ComponentTierDTO> tiers, bool valueBound, bool quantityBound,
            decimal total, int quantity)
        {
            var results = tiers.Where(s => s.IsActive == true
                                           && s.IsDeleted == false);

            if (valueBound)
            {
                results = results.Where(s =>
                    s.TotalValueLowerBound.HasValue
                    && s.TotalValueUpperBound.HasValue
                    && s.TotalValueLowerBound.Value >= total
                    && s.TotalValueUpperBound.Value <= total);


            }
            else if (quantityBound)
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

        private bool ValueBound
        {
            get
            {
                return m_ComponentTiers.Any(s => s.TotalValueLowerBound.HasValue);
            }
        }

        private bool QuantityBound
        {
            get
            {
                return m_ComponentTiers.Any(s => s.QuantityCountLowerBound.HasValue);
            }
        }

        private bool BasedOnPaymentMethod
        {
            get
            {
                return m_ComponentTiers.Any(s => s.ApplyOnPaymentMethodTypeID.HasValue);
            }
        }

        private bool BasedOnPaymentCartType
        {
            get
            {
                return m_ComponentTiers.Any(s => s.ApplyOnPaymentCardTypeID.HasValue);
            }
        }

        public InformationDTO CalculateCheckoutDeductionPricing(ShoppingCartDTO cart,VCountryDeductionDTO deduction)
        {
            var infoDto = new InformationDTO
            {
                Name = deduction.Name,
                Description = deduction.Description,
                InvoiceName = deduction.Name
            };

            if (deduction.DeductionDto != null)
            {
                m_ComponentTiers = deduction.DeductionDto.ComponentTiers;

                // get component tier
                var tier = GetTier(m_ComponentTiers, ValueBound, QuantityBound,
                    BasedOnPaymentCartType, BasedOnPaymentMethod, cart.PriceDTO.SubTotalDiscountsExclTaxAndDeduct,
                    cart.PaymentCardTypeID, cart.PaymentMethodTypeID, 0);

                if (tier.IsPercentageBased)
                    infoDto.PercentageComponent = tier.TierPercentage.GetValueOrDefault(0);
                else
                    infoDto.ValueComponent = tier.TierPrice.GetValueOrDefault(0);
            }
            else if (deduction.DeductionProduct != null)
            {
                m_ComponentTiers = deduction.DeductionProduct.ComponentTiers;

                // get component tier
                var tier = GetTier(m_ComponentTiers, ValueBound, QuantityBound,
                    BasedOnPaymentCartType, BasedOnPaymentMethod, cart.PriceDTO.SubTotalDiscountsExclTaxAndDeduct,
                    cart.PaymentCardTypeID, cart.PaymentMethodTypeID, 0);

                if (tier.IsPercentageBased)
                    infoDto.PercentageComponent = tier.TierPercentage.GetValueOrDefault(0);
                else
                    infoDto.ValueComponent = tier.TierPrice.GetValueOrDefault(0);
            }
            else
            {
                if (deduction.IsPercentageBased)
                    infoDto.PercentageComponent = deduction.DeductionPercentage.GetValueOrDefault(0);
                else
                    infoDto.ValueComponent = deduction.DeductionValue.GetValueOrDefault(0);
            }

            return infoDto;
        }

        public InformationDTO CalculateProductTierPricing(ShoppingCartItemDTO cartItem, ProductDTO product)
        {
            var infoDto = new InformationDTO
            {
                Name = product.CurrentDetail.Name,
                Description = product.CurrentDetail.Description,
                InvoiceName = product.CurrentDetail.InvoiceName
            };

            if (product.CurrentDetail.HasTierPrices)
            {
                m_ComponentTiers = product.ComponentTiers;

                Ensure.That(product.ComponentTiers);

                // get component tier
                var tier = GetTier(m_ComponentTiers, ValueBound, QuantityBound
                    , product.CurrentDetail.Price, cartItem.Quantity);
                
                //TBD do we need percentage tier pricing for products ??
                if (tier.IsPercentageBased)
                    infoDto.PercentageComponent = tier.TierPercentage.GetValueOrDefault(0);
                else
                    infoDto.ValueComponent = tier.TierPrice.GetValueOrDefault(0);
            }
            else
            {
                infoDto.ValueComponent = product.CurrentDetail.Price;
            }

            return infoDto;
        }

        public InformationDTO CalculateProductDeductionTierPricing(ShoppingCartItemDTO cartItem, ProductDTO product, VProductDeductionDTO deduction)
        {
            var infoDto = new InformationDTO
            {
                Name = deduction.Name,
                Description = deduction.Description,
                InvoiceName = deduction.Name
            };

            if (deduction.DeductionDto != null)
            {
                m_ComponentTiers = deduction.DeductionDto.ComponentTiers;

                Ensure.That(deduction.DeductionDto.ComponentTiers);

                // get component tier
                var tier = GetTier(m_ComponentTiers, ValueBound, QuantityBound
                    , product.CurrentDetail.Price, cartItem.Quantity);

                //TBD do we need percentage tier pricing for products ??
                if (tier.IsPercentageBased)
                    infoDto.PercentageComponent = tier.TierPercentage.GetValueOrDefault(0);
                else
                    infoDto.ValueComponent = tier.TierPrice.GetValueOrDefault(0);
            }
            else
            {
                if (deduction.IsPercentageBased)
                    infoDto.PercentageComponent = deduction.DeductionPercentage.GetValueOrDefault(0);
                else
                    infoDto.ValueComponent = deduction.DeductionValue.GetValueOrDefault(0);
            }

            return infoDto;
        }

        public InformationDTO CalculateProductDiscountTierPricing(ShoppingCartItemDTO cartItem, ProductDTO product,VProductDiscountDTO discount)
        {
            var infoDto = new InformationDTO
            {
                Name = discount.Name,
                Description = discount.Description,
                InvoiceName = discount.InvoiceName
            };

            if (discount.DiscountDto != null)
            {
                m_ComponentTiers = discount.DiscountDto.ComponentTiers;

                Ensure.That(discount.DiscountDto.ComponentTiers);

                // get component tier
                var tier = GetTier(m_ComponentTiers, ValueBound, QuantityBound
                    , product.CurrentDetail.Price, cartItem.Quantity);

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

        public InformationDTO CalculateCheckoutDiscountTierPricing(ShoppingCartDTO cart, VOrganisationCheckoutDiscountDTO discount)
        {
            var infoDto = new InformationDTO
            {
                Name = discount.Name,
                Description = discount.Description,
                InvoiceName = discount.InvoiceName
            };

            if (discount.DiscountDto.HasTiers)
            {
                m_ComponentTiers = discount.DiscountDto.ComponentTiers;

                Ensure.That(discount.DiscountDto.ComponentTiers);

                // get component tier
                var tier = GetTier(m_ComponentTiers, ValueBound, QuantityBound
                    , cart.PriceDTO.SubTotalExclDiscountsAndTaxAndDeduct, 0);

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
