﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:58
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class DefaultOrganisationConverter
    {

        public static DefaultOrganisationDTO ToDto(this Bec.TargetFramework.Data.DefaultOrganisation source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DefaultOrganisationDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DefaultOrganisation source, int level)
        {
            if (source == null)
              return null;

            var target = new DefaultOrganisationDTO();

            // Properties
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;
            target.DefaultOrganisationTemplateID = source.DefaultOrganisationTemplateID;
            target.DefaultOrganisationTemplateVersionNumber = source.DefaultOrganisationTemplateVersionNumber;
            target.OrganisationTypeID = source.OrganisationTypeID;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisationLedgers = source.DefaultOrganisationLedgers.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationModules = source.DefaultOrganisationModules.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationStatusTypes = source.DefaultOrganisationStatusTypes.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationProducts = source.DefaultOrganisationProducts.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationTargets = source.DefaultOrganisationTargets.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationUserTargets = source.DefaultOrganisationUserTargets.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationTemplate = source.DefaultOrganisationTemplate.ToDtoWithRelated(level - 1);
              target.OrganisationType = source.OrganisationType.ToDtoWithRelated(level - 1);
              target.DefaultOrganisationNotificationConstructs = source.DefaultOrganisationNotificationConstructs.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationWorkflows = source.DefaultOrganisationWorkflows.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationUserTypes = source.DefaultOrganisationUserTypes.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationBranches = source.DefaultOrganisationBranches.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationArtefacts = source.DefaultOrganisationArtefacts.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationGroups = source.DefaultOrganisationGroups.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationRoles = source.DefaultOrganisationRoles.ToDtosWithRelated(level - 1);
              target.BucketTemplates = source.BucketTemplates.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationShoppingCartBlueprints = source.DefaultOrganisationShoppingCartBlueprints.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationPaymentMethods = source.DefaultOrganisationPaymentMethods.ToDtosWithRelated(level - 1);
              target.Organisations = source.Organisations.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DefaultOrganisation ToEntity(this DefaultOrganisationDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DefaultOrganisation();

            // Properties
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;
            target.DefaultOrganisationTemplateID = source.DefaultOrganisationTemplateID;
            target.DefaultOrganisationTemplateVersionNumber = source.DefaultOrganisationTemplateVersionNumber;
            target.OrganisationTypeID = source.OrganisationTypeID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DefaultOrganisationDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisation> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DefaultOrganisationDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisation> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DefaultOrganisation> ToEntities(this IEnumerable<DefaultOrganisationDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DefaultOrganisation source, DefaultOrganisationDTO target);

        static partial void OnEntityCreating(DefaultOrganisationDTO source, Bec.TargetFramework.Data.DefaultOrganisation target);

    }

}
