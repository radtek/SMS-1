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

    public static partial class OrganisationTypeConverter
    {

        public static OrganisationTypeDTO ToDto(this Bec.TargetFramework.Data.OrganisationType source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static OrganisationTypeDTO ToDtoWithRelated(this Bec.TargetFramework.Data.OrganisationType source, int level)
        {
            if (source == null)
              return null;

            var target = new OrganisationTypeDTO();

            // Properties
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisationTemplates = source.DefaultOrganisationTemplates.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationTargets = source.DefaultOrganisationTargets.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationTargetTemplates = source.DefaultOrganisationTargetTemplates.ToDtosWithRelated(level - 1);
              target.DefaultOrganisations = source.DefaultOrganisations.ToDtosWithRelated(level - 1);
              target.ComponentTierTemplates = source.ComponentTierTemplates.ToDtosWithRelated(level - 1);
              target.ComponentTiers = source.ComponentTiers.ToDtosWithRelated(level - 1);
              target.Discounts = source.Discounts.ToDtosWithRelated(level - 1);
              target.DiscountTemplates = source.DiscountTemplates.ToDtosWithRelated(level - 1);
              target.Deductions = source.Deductions.ToDtosWithRelated(level - 1);
              target.DeductionTemplates = source.DeductionTemplates.ToDtosWithRelated(level - 1);
              target.NotificationConstructGroupNotificationConstructs = source.NotificationConstructGroupNotificationConstructs.ToDtosWithRelated(level - 1);
              target.NotificationConstructGroupNotificationConstructTemplates = source.NotificationConstructGroupNotificationConstructTemplates.ToDtosWithRelated(level - 1);
              target.NotificationConstructTargetTemplates = source.NotificationConstructTargetTemplates.ToDtosWithRelated(level - 1);
              target.NotificationConstructTargets = source.NotificationConstructTargets.ToDtosWithRelated(level - 1);
              target.ResourceOperationTargets = source.ResourceOperationTargets.ToDtosWithRelated(level - 1);
              target.Organisations = source.Organisations.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.OrganisationType ToEntity(this OrganisationTypeDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.OrganisationType();

            // Properties
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<OrganisationTypeDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.OrganisationType> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<OrganisationTypeDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.OrganisationType> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.OrganisationType> ToEntities(this IEnumerable<OrganisationTypeDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.OrganisationType source, OrganisationTypeDTO target);

        static partial void OnEntityCreating(OrganisationTypeDTO source, Bec.TargetFramework.Data.OrganisationType target);

    }

}
