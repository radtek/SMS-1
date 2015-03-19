﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 18/03/2015 19:00:46
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class PlanSubscriptionPeriodConverter
    {

        public static PlanSubscriptionPeriodDTO ToDto(this Bec.TargetFramework.Data.PlanSubscriptionPeriod source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static PlanSubscriptionPeriodDTO ToDtoWithRelated(this Bec.TargetFramework.Data.PlanSubscriptionPeriod source, int level)
        {
            if (source == null)
              return null;

            var target = new PlanSubscriptionPeriodDTO();

            // Properties
            target.PlanSubscriptionID = source.PlanSubscriptionID;
            target.PlanSubscriptionVersionNumber = source.PlanSubscriptionVersionNumber;
            target.CreatedOn = source.CreatedOn;
            target.StartDate = source.StartDate;
            target.EndDate = source.EndDate;
            target.IsCancellationPeriod = source.IsCancellationPeriod;
            target.CancellationPeriodNumber = source.CancellationPeriodNumber;
            target.PeriodNumber = source.PeriodNumber;
            target.IsTrialPeriod = source.IsTrialPeriod;
            target.TrialPeriodNumber = source.TrialPeriodNumber;
            target.TrialStartDate = source.TrialStartDate;
            target.TrialEndDate = source.TrialEndDate;
            target.CancellationStartDate = source.CancellationStartDate;
            target.CancellationEndDate = source.CancellationEndDate;
            target.PlanSubscriptionPeriodID = source.PlanSubscriptionPeriodID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsClosed = source.IsClosed;
            target.PlanSubscriptionBillingPeriodID = source.PlanSubscriptionBillingPeriodID;
            target.ClosedOn = source.ClosedOn;

            // Navigation Properties
            if (level > 0) {
              target.PlanSubscription = source.PlanSubscription.ToDtoWithRelated(level - 1);
              target.InvoiceLineItems = source.InvoiceLineItems.ToDtosWithRelated(level - 1);
              target.PlanSubscriptionBillingProcessLog = source.PlanSubscriptionBillingProcessLog.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.PlanSubscriptionPeriod ToEntity(this PlanSubscriptionPeriodDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.PlanSubscriptionPeriod();

            // Properties
            target.PlanSubscriptionID = source.PlanSubscriptionID;
            target.PlanSubscriptionVersionNumber = source.PlanSubscriptionVersionNumber;
            target.CreatedOn = source.CreatedOn;
            target.StartDate = source.StartDate;
            target.EndDate = source.EndDate;
            target.IsCancellationPeriod = source.IsCancellationPeriod;
            target.CancellationPeriodNumber = source.CancellationPeriodNumber;
            target.PeriodNumber = source.PeriodNumber;
            target.IsTrialPeriod = source.IsTrialPeriod;
            target.TrialPeriodNumber = source.TrialPeriodNumber;
            target.TrialStartDate = source.TrialStartDate;
            target.TrialEndDate = source.TrialEndDate;
            target.CancellationStartDate = source.CancellationStartDate;
            target.CancellationEndDate = source.CancellationEndDate;
            target.PlanSubscriptionPeriodID = source.PlanSubscriptionPeriodID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsClosed = source.IsClosed;
            target.PlanSubscriptionBillingPeriodID = source.PlanSubscriptionBillingPeriodID;
            target.ClosedOn = source.ClosedOn;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<PlanSubscriptionPeriodDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.PlanSubscriptionPeriod> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<PlanSubscriptionPeriodDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.PlanSubscriptionPeriod> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.PlanSubscriptionPeriod> ToEntities(this IEnumerable<PlanSubscriptionPeriodDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.PlanSubscriptionPeriod source, PlanSubscriptionPeriodDTO target);

        static partial void OnEntityCreating(PlanSubscriptionPeriodDTO source, Bec.TargetFramework.Data.PlanSubscriptionPeriod target);

    }

}
