﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:15:00
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class OrganisationPlanSubscriptionConverter
    {

        public static OrganisationPlanSubscriptionDTO ToDto(this Bec.TargetFramework.Data.OrganisationPlanSubscription source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static OrganisationPlanSubscriptionDTO ToDtoWithRelated(this Bec.TargetFramework.Data.OrganisationPlanSubscription source, int level)
        {
            if (source == null)
              return null;

            var target = new OrganisationPlanSubscriptionDTO();

            // Properties
            target.OrganisationID = source.OrganisationID;
            target.PlanSubscriptionID = source.PlanSubscriptionID;
            target.PlanSubscriptionVersionNumber = source.PlanSubscriptionVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.PlanSubscription = source.PlanSubscription.ToDtoWithRelated(level - 1);
              target.Organisation = source.Organisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.OrganisationPlanSubscription ToEntity(this OrganisationPlanSubscriptionDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.OrganisationPlanSubscription();

            // Properties
            target.OrganisationID = source.OrganisationID;
            target.PlanSubscriptionID = source.PlanSubscriptionID;
            target.PlanSubscriptionVersionNumber = source.PlanSubscriptionVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<OrganisationPlanSubscriptionDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.OrganisationPlanSubscription> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<OrganisationPlanSubscriptionDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.OrganisationPlanSubscription> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.OrganisationPlanSubscription> ToEntities(this IEnumerable<OrganisationPlanSubscriptionDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.OrganisationPlanSubscription source, OrganisationPlanSubscriptionDTO target);

        static partial void OnEntityCreating(OrganisationPlanSubscriptionDTO source, Bec.TargetFramework.Data.OrganisationPlanSubscription target);

    }

}
