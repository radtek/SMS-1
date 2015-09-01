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

    public static partial class BillingTemplateConverter
    {

        public static BillingTemplateDTO ToDto(this Bec.TargetFramework.Data.BillingTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static BillingTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.BillingTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new BillingTemplateDTO();

            // Properties
            target.BillingTemplateID = source.BillingTemplateID;
            target.BillingPeriod = source.BillingPeriod;
            target.BillingPeriodUnitID = source.BillingPeriodUnitID;
            target.BillingPeriodDayOfMonth = source.BillingPeriodDayOfMonth;
            target.DelayedBillingPeriod = source.DelayedBillingPeriod;
            target.DelayedBillingPeriodUnitID = source.DelayedBillingPeriodUnitID;
            target.HasDelayedBilling = source.HasDelayedBilling;
            target.NumberOfBillingPeriods = source.NumberOfBillingPeriods;
            target.InvoiceToProcessingDelayPeriod = source.InvoiceToProcessingDelayPeriod;
            target.InvoiceToProcessingDelayPeriodUnitID = source.InvoiceToProcessingDelayPeriodUnitID;
            target.InvoiceNotificationConstructTemplateID = source.InvoiceNotificationConstructTemplateID;
            target.InvoiceNotificationConstructTemplateVersionNumber = source.InvoiceNotificationConstructTemplateVersionNumber;
            target.EstimatedProcessingPeriod = source.EstimatedProcessingPeriod;
            target.EstimatedProcessingPeriodUnitID = source.EstimatedProcessingPeriodUnitID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ParentID = source.ParentID;
            target.BillingLagPeriod = source.BillingLagPeriod;
            target.BillingLagPeriodUnitID = source.BillingLagPeriodUnitID;

            // Navigation Properties
            if (level > 0) {
              target.PlanBillingTemplates = source.PlanBillingTemplates.ToDtosWithRelated(level - 1);
              target.PlanGlobalPaymentMethodTemplates = source.PlanGlobalPaymentMethodTemplates.ToDtosWithRelated(level - 1);
              target.Billings = source.Billings.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.BillingTemplate ToEntity(this BillingTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.BillingTemplate();

            // Properties
            target.BillingTemplateID = source.BillingTemplateID;
            target.BillingPeriod = source.BillingPeriod;
            target.BillingPeriodUnitID = source.BillingPeriodUnitID;
            target.BillingPeriodDayOfMonth = source.BillingPeriodDayOfMonth;
            target.DelayedBillingPeriod = source.DelayedBillingPeriod;
            target.DelayedBillingPeriodUnitID = source.DelayedBillingPeriodUnitID;
            target.HasDelayedBilling = source.HasDelayedBilling;
            target.NumberOfBillingPeriods = source.NumberOfBillingPeriods;
            target.InvoiceToProcessingDelayPeriod = source.InvoiceToProcessingDelayPeriod;
            target.InvoiceToProcessingDelayPeriodUnitID = source.InvoiceToProcessingDelayPeriodUnitID;
            target.InvoiceNotificationConstructTemplateID = source.InvoiceNotificationConstructTemplateID;
            target.InvoiceNotificationConstructTemplateVersionNumber = source.InvoiceNotificationConstructTemplateVersionNumber;
            target.EstimatedProcessingPeriod = source.EstimatedProcessingPeriod;
            target.EstimatedProcessingPeriodUnitID = source.EstimatedProcessingPeriodUnitID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ParentID = source.ParentID;
            target.BillingLagPeriod = source.BillingLagPeriod;
            target.BillingLagPeriodUnitID = source.BillingLagPeriodUnitID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<BillingTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.BillingTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<BillingTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.BillingTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.BillingTemplate> ToEntities(this IEnumerable<BillingTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.BillingTemplate source, BillingTemplateDTO target);

        static partial void OnEntityCreating(BillingTemplateDTO source, Bec.TargetFramework.Data.BillingTemplate target);

    }

}