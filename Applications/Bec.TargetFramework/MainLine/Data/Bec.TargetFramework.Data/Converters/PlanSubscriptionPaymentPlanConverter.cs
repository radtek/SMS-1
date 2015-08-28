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

    public static partial class PlanSubscriptionPaymentPlanConverter
    {

        public static PlanSubscriptionPaymentPlanDTO ToDto(this Bec.TargetFramework.Data.PlanSubscriptionPaymentPlan source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static PlanSubscriptionPaymentPlanDTO ToDtoWithRelated(this Bec.TargetFramework.Data.PlanSubscriptionPaymentPlan source, int level)
        {
            if (source == null)
              return null;

            var target = new PlanSubscriptionPaymentPlanDTO();

            // Properties
            target.PlanSubscriptionPaymentPlanID = source.PlanSubscriptionPaymentPlanID;
            target.GlobalPaymentMethodID = source.GlobalPaymentMethodID;
            target.PlanSubscriptionID = source.PlanSubscriptionID;
            target.PlanSubscriptionVersionNumber = source.PlanSubscriptionVersionNumber;
            target.BillingID = source.BillingID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.Billing = source.Billing.ToDtoWithRelated(level - 1);
              target.GlobalPaymentMethod = source.GlobalPaymentMethod.ToDtoWithRelated(level - 1);
              target.PlanSubscription = source.PlanSubscription.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.PlanSubscriptionPaymentPlan ToEntity(this PlanSubscriptionPaymentPlanDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.PlanSubscriptionPaymentPlan();

            // Properties
            target.PlanSubscriptionPaymentPlanID = source.PlanSubscriptionPaymentPlanID;
            target.GlobalPaymentMethodID = source.GlobalPaymentMethodID;
            target.PlanSubscriptionID = source.PlanSubscriptionID;
            target.PlanSubscriptionVersionNumber = source.PlanSubscriptionVersionNumber;
            target.BillingID = source.BillingID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<PlanSubscriptionPaymentPlanDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.PlanSubscriptionPaymentPlan> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<PlanSubscriptionPaymentPlanDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.PlanSubscriptionPaymentPlan> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.PlanSubscriptionPaymentPlan> ToEntities(this IEnumerable<PlanSubscriptionPaymentPlanDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.PlanSubscriptionPaymentPlan source, PlanSubscriptionPaymentPlanDTO target);

        static partial void OnEntityCreating(PlanSubscriptionPaymentPlanDTO source, Bec.TargetFramework.Data.PlanSubscriptionPaymentPlan target);

    }

}
