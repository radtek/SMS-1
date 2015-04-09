﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:50:53
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class BillingConverter
    {

        public static BillingDTO ToDto(this Bec.TargetFramework.Data.Billing source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static BillingDTO ToDtoWithRelated(this Bec.TargetFramework.Data.Billing source, int level)
        {
            if (source == null)
              return null;

            var target = new BillingDTO();

            // Properties
            target.BillingID = source.BillingID;
            target.BillingPeriod = source.BillingPeriod;
            target.BillingPeriodUnitID = source.BillingPeriodUnitID;
            target.BillingPeriodDayOfMonth = source.BillingPeriodDayOfMonth;
            target.DelayedBillingPeriod = source.DelayedBillingPeriod;
            target.DelayedBillingPeriodUnitID = source.DelayedBillingPeriodUnitID;
            target.HasDelayedBilling = source.HasDelayedBilling;
            target.BillingTemplateID = source.BillingTemplateID;
            target.NumberOfBillingPeriods = source.NumberOfBillingPeriods;
            target.InvoiceToProcessingDelayPeriod = source.InvoiceToProcessingDelayPeriod;
            target.InvoiceToProcessingDelayPeriodUnitID = source.InvoiceToProcessingDelayPeriodUnitID;
            target.InvoiceNotificationConstructID = source.InvoiceNotificationConstructID;
            target.InvoiceNotificationConstructVersionNumber = source.InvoiceNotificationConstructVersionNumber;
            target.EstimatedProcessingPeriod = source.EstimatedProcessingPeriod;
            target.EstimatedProcessingPeriodUnitID = source.EstimatedProcessingPeriodUnitID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.BillingLagPeriod = source.BillingLagPeriod;
            target.BillingLagPeriodUnitID = source.BillingLagPeriodUnitID;

            // Navigation Properties
            if (level > 0) {
              target.PlanBillings = source.PlanBillings.ToDtosWithRelated(level - 1);
              target.PlanGlobalPaymentMethods = source.PlanGlobalPaymentMethods.ToDtosWithRelated(level - 1);
              target.PlanSubscriptionPaymentPlans = source.PlanSubscriptionPaymentPlans.ToDtosWithRelated(level - 1);
              target.BillingTemplate = source.BillingTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.Billing ToEntity(this BillingDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.Billing();

            // Properties
            target.BillingID = source.BillingID;
            target.BillingPeriod = source.BillingPeriod;
            target.BillingPeriodUnitID = source.BillingPeriodUnitID;
            target.BillingPeriodDayOfMonth = source.BillingPeriodDayOfMonth;
            target.DelayedBillingPeriod = source.DelayedBillingPeriod;
            target.DelayedBillingPeriodUnitID = source.DelayedBillingPeriodUnitID;
            target.HasDelayedBilling = source.HasDelayedBilling;
            target.BillingTemplateID = source.BillingTemplateID;
            target.NumberOfBillingPeriods = source.NumberOfBillingPeriods;
            target.InvoiceToProcessingDelayPeriod = source.InvoiceToProcessingDelayPeriod;
            target.InvoiceToProcessingDelayPeriodUnitID = source.InvoiceToProcessingDelayPeriodUnitID;
            target.InvoiceNotificationConstructID = source.InvoiceNotificationConstructID;
            target.InvoiceNotificationConstructVersionNumber = source.InvoiceNotificationConstructVersionNumber;
            target.EstimatedProcessingPeriod = source.EstimatedProcessingPeriod;
            target.EstimatedProcessingPeriodUnitID = source.EstimatedProcessingPeriodUnitID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.BillingLagPeriod = source.BillingLagPeriod;
            target.BillingLagPeriodUnitID = source.BillingLagPeriodUnitID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<BillingDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.Billing> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<BillingDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.Billing> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.Billing> ToEntities(this IEnumerable<BillingDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.Billing source, BillingDTO target);

        static partial void OnEntityCreating(BillingDTO source, Bec.TargetFramework.Data.Billing target);

    }

}
