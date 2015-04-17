﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:54
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class PlanTemplateConverter
    {

        public static PlanTemplateDTO ToDto(this Bec.TargetFramework.Data.PlanTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static PlanTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.PlanTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new PlanTemplateDTO();

            // Properties
            target.PlanTemplateID = source.PlanTemplateID;
            target.PlanTemplateVersionNumber = source.PlanTemplateVersionNumber;
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
            target.PlanStatusID = source.PlanStatusID;
            target.IsTransactionBased = source.IsTransactionBased;
            target.CoolOffPeriod = source.CoolOffPeriod;
            target.CoolOffPeriodUnitID = source.CoolOffPeriodUnitID;
            target.RenewalPrice = source.RenewalPrice;
            target.RenewalPercentage = source.RenewalPercentage;
            target.RenewalIsPercentageOfOriginalPrice = source.RenewalIsPercentageOfOriginalPrice;
            target.HasForwardCycleFee = source.HasForwardCycleFee;
            target.ForwardCycleFee = source.ForwardCycleFee;
            target.ForwardCycleFeeIsSameAsPrice = source.ForwardCycleFeeIsSameAsPrice;
            target.RenewalOfferPeriod = source.RenewalOfferPeriod;
            target.RenewalOfferPeriodUnitID = source.RenewalOfferPeriodUnitID;
            target.ForwardCycleFeePeriod = source.ForwardCycleFeePeriod;
            target.ForwardCycleFeePeriodUnitID = source.ForwardCycleFeePeriodUnitID;
            target.HasRenewalOffer = source.HasRenewalOffer;
            target.PriceDailyProRata = source.PriceDailyProRata;
            target.IsAutoRenew = source.IsAutoRenew;
            target.AutoRenewDecisionPeriod = source.AutoRenewDecisionPeriod;
            target.AutoRenewDecisionPeriodUnitID = source.AutoRenewDecisionPeriodUnitID;
            target.AutoRenewPeriod = source.AutoRenewPeriod;
            target.AutoRenewPeriodUnitID = source.AutoRenewPeriodUnitID;
            target.PlanGroupID = source.PlanGroupID;
            target.PlanTypeID = source.PlanTypeID;
            target.PlanCategoryID = source.PlanCategoryID;

            // Navigation Properties
            if (level > 0) {
              target.PlanProductTemplates = source.PlanProductTemplates.ToDtosWithRelated(level - 1);
              target.CountryCode1 = source.CountryCode1.ToDtoWithRelated(level - 1);
              target.ProductPlanTemplates = source.ProductPlanTemplates.ToDtosWithRelated(level - 1);
              target.Plans = source.Plans.ToDtosWithRelated(level - 1);
              target.PlanBillingTemplates = source.PlanBillingTemplates.ToDtosWithRelated(level - 1);
              target.PlanTransactionTemplates = source.PlanTransactionTemplates.ToDtosWithRelated(level - 1);
              target.PlanDiscountTemplates = source.PlanDiscountTemplates.ToDtosWithRelated(level - 1);
              target.PlanGlobalPaymentMethodTemplates = source.PlanGlobalPaymentMethodTemplates.ToDtosWithRelated(level - 1);
              target.PlanGroup = source.PlanGroup.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.PlanTemplate ToEntity(this PlanTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.PlanTemplate();

            // Properties
            target.PlanTemplateID = source.PlanTemplateID;
            target.PlanTemplateVersionNumber = source.PlanTemplateVersionNumber;
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
            target.PlanStatusID = source.PlanStatusID;
            target.IsTransactionBased = source.IsTransactionBased;
            target.CoolOffPeriod = source.CoolOffPeriod;
            target.CoolOffPeriodUnitID = source.CoolOffPeriodUnitID;
            target.RenewalPrice = source.RenewalPrice;
            target.RenewalPercentage = source.RenewalPercentage;
            target.RenewalIsPercentageOfOriginalPrice = source.RenewalIsPercentageOfOriginalPrice;
            target.HasForwardCycleFee = source.HasForwardCycleFee;
            target.ForwardCycleFee = source.ForwardCycleFee;
            target.ForwardCycleFeeIsSameAsPrice = source.ForwardCycleFeeIsSameAsPrice;
            target.RenewalOfferPeriod = source.RenewalOfferPeriod;
            target.RenewalOfferPeriodUnitID = source.RenewalOfferPeriodUnitID;
            target.ForwardCycleFeePeriod = source.ForwardCycleFeePeriod;
            target.ForwardCycleFeePeriodUnitID = source.ForwardCycleFeePeriodUnitID;
            target.HasRenewalOffer = source.HasRenewalOffer;
            target.PriceDailyProRata = source.PriceDailyProRata;
            target.IsAutoRenew = source.IsAutoRenew;
            target.AutoRenewDecisionPeriod = source.AutoRenewDecisionPeriod;
            target.AutoRenewDecisionPeriodUnitID = source.AutoRenewDecisionPeriodUnitID;
            target.AutoRenewPeriod = source.AutoRenewPeriod;
            target.AutoRenewPeriodUnitID = source.AutoRenewPeriodUnitID;
            target.PlanGroupID = source.PlanGroupID;
            target.PlanTypeID = source.PlanTypeID;
            target.PlanCategoryID = source.PlanCategoryID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<PlanTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.PlanTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<PlanTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.PlanTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.PlanTemplate> ToEntities(this IEnumerable<PlanTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.PlanTemplate source, PlanTemplateDTO target);

        static partial void OnEntityCreating(PlanTemplateDTO source, Bec.TargetFramework.Data.PlanTemplate target);

    }

}
