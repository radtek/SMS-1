﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class PlanConverter
    {

        public static PlanDTO ToDto(this Bec.TargetFramework.Data.Plan source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static PlanDTO ToDtoWithRelated(this Bec.TargetFramework.Data.Plan source, int level)
        {
            if (source == null)
              return null;

            var target = new PlanDTO();

            // Properties
            target.PlanID = source.PlanID;
            target.PlanVersionNumber = source.PlanVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.InvoiceName = source.InvoiceName;
            target.Price = source.Price;
            target.Period = source.Period;
            target.TrialPeriod = source.TrialPeriod;
            target.PeriodUnitID = source.PeriodUnitID;
            target.TrialPeriodUnitID = source.TrialPeriodUnitID;
            target.FreeQuantity = source.FreeQuantity;
            target.SetupCost = source.SetupCost;
            target.DowngradePenalty = source.DowngradePenalty;
            target.CreatedOn = source.CreatedOn;
            target.CreatedBy = source.CreatedBy;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.CountryCode = source.CountryCode;
            target.CurrencyCode = source.CurrencyCode;
            target.CancellationPeriod = source.CancellationPeriod;
            target.CancellationPeriodUnitID = source.CancellationPeriodUnitID;
            target.IsFree = source.IsFree;
            target.HasInfinitePeriods = source.HasInfinitePeriods;
            target.ParentID = source.ParentID;
            target.PlanTemplateID = source.PlanTemplateID;
            target.PlanTemplateVersionNumber = source.PlanTemplateVersionNumber;
            target.PlanStatusID = source.PlanStatusID;
            target.IsTransactionBased = source.IsTransactionBased;
            target.CoolOffPeriod = source.CoolOffPeriod;
            target.CoolOffPeriodUnitID = source.CoolOffPeriodUnitID;
            target.RenewalPrice = source.RenewalPrice;
            target.RenewalPercentage = source.RenewalPercentage;
            target.RenewalIsPercentageOfOriginalPrice = source.RenewalIsPercentageOfOriginalPrice;
            target.HasForwardCycleFee = source.HasForwardCycleFee;
            target.ForwardCycleFee = source.ForwardCycleFee;
            target.ForwardCycleFreeIsSameAsPrice = source.ForwardCycleFreeIsSameAsPrice;
            target.RenewalOfferPeriod = source.RenewalOfferPeriod;
            target.RenewalOfferPeriodUnitID = source.RenewalOfferPeriodUnitID;
            target.ForwardCycleFeePeriod = source.ForwardCycleFeePeriod;
            target.ForwardCycleFeePeriodUnitID = source.ForwardCycleFeePeriodUnitID;
            target.HasRenewalOffer = source.HasRenewalOffer;
            target.PriceDailyProRata = source.PriceDailyProRata;
            target.IsAutoRenew = source.IsAutoRenew;
            target.AutoRenewDecisionPeriod = source.AutoRenewDecisionPeriod;
            target.AutoRenewDecisionUnitID = source.AutoRenewDecisionUnitID;
            target.AutoRenewPeriod = source.AutoRenewPeriod;
            target.AutoRenewPeriodUnitID = source.AutoRenewPeriodUnitID;
            target.PlanGroupID = source.PlanGroupID;
            target.PlanTypeID = source.PlanTypeID;
            target.PlanCategoryID = source.PlanCategoryID;
            target.ModifiedOn = source.ModifiedOn;
            target.ModifiedBy = source.ModifiedBy;

            // Navigation Properties
            if (level > 0) {
              target.CountryCode1 = source.CountryCode1.ToDtoWithRelated(level - 1);
              target.PlanTemplate = source.PlanTemplate.ToDtoWithRelated(level - 1);
              target.PlanSubscriptions = source.PlanSubscriptions.ToDtosWithRelated(level - 1);
              target.PlanProducts = source.PlanProducts.ToDtosWithRelated(level - 1);
              target.PlanBillings = source.PlanBillings.ToDtosWithRelated(level - 1);
              target.PlanTransactions = source.PlanTransactions.ToDtosWithRelated(level - 1);
              target.PlanDiscounts = source.PlanDiscounts.ToDtosWithRelated(level - 1);
              target.PlanGlobalPaymentMethods = source.PlanGlobalPaymentMethods.ToDtosWithRelated(level - 1);
              target.ProductPlans = source.ProductPlans.ToDtosWithRelated(level - 1);
              target.PlanGroup = source.PlanGroup.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.Plan ToEntity(this PlanDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.Plan();

            // Properties
            target.PlanID = source.PlanID;
            target.PlanVersionNumber = source.PlanVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.InvoiceName = source.InvoiceName;
            target.Price = source.Price;
            target.Period = source.Period;
            target.TrialPeriod = source.TrialPeriod;
            target.PeriodUnitID = source.PeriodUnitID;
            target.TrialPeriodUnitID = source.TrialPeriodUnitID;
            target.FreeQuantity = source.FreeQuantity;
            target.SetupCost = source.SetupCost;
            target.DowngradePenalty = source.DowngradePenalty;
            target.CreatedOn = source.CreatedOn;
            target.CreatedBy = source.CreatedBy;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.CountryCode = source.CountryCode;
            target.CurrencyCode = source.CurrencyCode;
            target.CancellationPeriod = source.CancellationPeriod;
            target.CancellationPeriodUnitID = source.CancellationPeriodUnitID;
            target.IsFree = source.IsFree;
            target.HasInfinitePeriods = source.HasInfinitePeriods;
            target.ParentID = source.ParentID;
            target.PlanTemplateID = source.PlanTemplateID;
            target.PlanTemplateVersionNumber = source.PlanTemplateVersionNumber;
            target.PlanStatusID = source.PlanStatusID;
            target.IsTransactionBased = source.IsTransactionBased;
            target.CoolOffPeriod = source.CoolOffPeriod;
            target.CoolOffPeriodUnitID = source.CoolOffPeriodUnitID;
            target.RenewalPrice = source.RenewalPrice;
            target.RenewalPercentage = source.RenewalPercentage;
            target.RenewalIsPercentageOfOriginalPrice = source.RenewalIsPercentageOfOriginalPrice;
            target.HasForwardCycleFee = source.HasForwardCycleFee;
            target.ForwardCycleFee = source.ForwardCycleFee;
            target.ForwardCycleFreeIsSameAsPrice = source.ForwardCycleFreeIsSameAsPrice;
            target.RenewalOfferPeriod = source.RenewalOfferPeriod;
            target.RenewalOfferPeriodUnitID = source.RenewalOfferPeriodUnitID;
            target.ForwardCycleFeePeriod = source.ForwardCycleFeePeriod;
            target.ForwardCycleFeePeriodUnitID = source.ForwardCycleFeePeriodUnitID;
            target.HasRenewalOffer = source.HasRenewalOffer;
            target.PriceDailyProRata = source.PriceDailyProRata;
            target.IsAutoRenew = source.IsAutoRenew;
            target.AutoRenewDecisionPeriod = source.AutoRenewDecisionPeriod;
            target.AutoRenewDecisionUnitID = source.AutoRenewDecisionUnitID;
            target.AutoRenewPeriod = source.AutoRenewPeriod;
            target.AutoRenewPeriodUnitID = source.AutoRenewPeriodUnitID;
            target.PlanGroupID = source.PlanGroupID;
            target.PlanTypeID = source.PlanTypeID;
            target.PlanCategoryID = source.PlanCategoryID;
            target.ModifiedOn = source.ModifiedOn;
            target.ModifiedBy = source.ModifiedBy;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<PlanDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.Plan> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<PlanDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.Plan> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.Plan> ToEntities(this IEnumerable<PlanDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.Plan source, PlanDTO target);

        static partial void OnEntityCreating(PlanDTO source, Bec.TargetFramework.Data.Plan target);

    }

}
