﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:20 AM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class DefaultOrganisationTemplateConverter
    {

        public static DefaultOrganisationTemplateDTO ToDto(this Bec.TargetFramework.Data.DefaultOrganisationTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DefaultOrganisationTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DefaultOrganisationTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new DefaultOrganisationTemplateDTO();

            // Properties
            target.DefaultOrganisationTemplateID = source.DefaultOrganisationTemplateID;
            target.DefaultOrganisationTemplateVersionNumber = source.DefaultOrganisationTemplateVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.OrganisationTypeID = source.OrganisationTypeID;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisationProductTemplates = source.DefaultOrganisationProductTemplates.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationUserTypeTemplates = source.DefaultOrganisationUserTypeTemplates.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationLedgerTemplates = source.DefaultOrganisationLedgerTemplates.ToDtosWithRelated(level - 1);
              target.OrganisationType = source.OrganisationType.ToDtoWithRelated(level - 1);
              target.DefaultOrganisationNotificationConstructTemplates = source.DefaultOrganisationNotificationConstructTemplates.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationModuleTemplates = source.DefaultOrganisationModuleTemplates.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationBranchTemplates = source.DefaultOrganisationBranchTemplates.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationArtefactTemplates = source.DefaultOrganisationArtefactTemplates.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationWorkflowTemplates = source.DefaultOrganisationWorkflowTemplates.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationRoleTemplates = source.DefaultOrganisationRoleTemplates.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationTargetTemplates = source.DefaultOrganisationTargetTemplates.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationStatusTypeTemplates = source.DefaultOrganisationStatusTypeTemplates.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationUserTargetTemplates = source.DefaultOrganisationUserTargetTemplates.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationGroupTemplates = source.DefaultOrganisationGroupTemplates.ToDtosWithRelated(level - 1);
              target.DefaultOrganisations = source.DefaultOrganisations.ToDtosWithRelated(level - 1);
              target.BucketTemplates = source.BucketTemplates.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationShoppingCartBlueprintTemplates = source.DefaultOrganisationShoppingCartBlueprintTemplates.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationPaymentMethodTemplates = source.DefaultOrganisationPaymentMethodTemplates.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DefaultOrganisationTemplate ToEntity(this DefaultOrganisationTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DefaultOrganisationTemplate();

            // Properties
            target.DefaultOrganisationTemplateID = source.DefaultOrganisationTemplateID;
            target.DefaultOrganisationTemplateVersionNumber = source.DefaultOrganisationTemplateVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.OrganisationTypeID = source.OrganisationTypeID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DefaultOrganisationTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DefaultOrganisationTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DefaultOrganisationTemplate> ToEntities(this IEnumerable<DefaultOrganisationTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DefaultOrganisationTemplate source, DefaultOrganisationTemplateDTO target);

        static partial void OnEntityCreating(DefaultOrganisationTemplateDTO source, Bec.TargetFramework.Data.DefaultOrganisationTemplate target);

    }

}
