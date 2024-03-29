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

    public static partial class DefaultOrganisationTargetTemplateConverter
    {

        public static DefaultOrganisationTargetTemplateDTO ToDto(this Bec.TargetFramework.Data.DefaultOrganisationTargetTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DefaultOrganisationTargetTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DefaultOrganisationTargetTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new DefaultOrganisationTargetTemplateDTO();

            // Properties
            target.DefaultOrganisationTargetTemplateID = source.DefaultOrganisationTargetTemplateID;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.OrganisationSubTypeID = source.OrganisationSubTypeID;
            target.OrganisationCategoryID = source.OrganisationCategoryID;
            target.OrganisationSubCategoryID = source.OrganisationSubCategoryID;
            target.DefaultOrganisationTemplateID = source.DefaultOrganisationTemplateID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.DefaultOrganisationTemplateVersionNumber = source.DefaultOrganisationTemplateVersionNumber;
            target.StatusTypeTemplateID = source.StatusTypeTemplateID;
            target.StatusTypeTemplateVersionNumber = source.StatusTypeTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisationStatusTypeTemplate = source.DefaultOrganisationStatusTypeTemplate.ToDtoWithRelated(level - 1);
              target.DefaultOrganisationTemplate = source.DefaultOrganisationTemplate.ToDtoWithRelated(level - 1);
              target.OrganisationType = source.OrganisationType.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DefaultOrganisationTargetTemplate ToEntity(this DefaultOrganisationTargetTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DefaultOrganisationTargetTemplate();

            // Properties
            target.DefaultOrganisationTargetTemplateID = source.DefaultOrganisationTargetTemplateID;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.OrganisationSubTypeID = source.OrganisationSubTypeID;
            target.OrganisationCategoryID = source.OrganisationCategoryID;
            target.OrganisationSubCategoryID = source.OrganisationSubCategoryID;
            target.DefaultOrganisationTemplateID = source.DefaultOrganisationTemplateID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.DefaultOrganisationTemplateVersionNumber = source.DefaultOrganisationTemplateVersionNumber;
            target.StatusTypeTemplateID = source.StatusTypeTemplateID;
            target.StatusTypeTemplateVersionNumber = source.StatusTypeTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DefaultOrganisationTargetTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationTargetTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DefaultOrganisationTargetTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationTargetTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DefaultOrganisationTargetTemplate> ToEntities(this IEnumerable<DefaultOrganisationTargetTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DefaultOrganisationTargetTemplate source, DefaultOrganisationTargetTemplateDTO target);

        static partial void OnEntityCreating(DefaultOrganisationTargetTemplateDTO source, Bec.TargetFramework.Data.DefaultOrganisationTargetTemplate target);

    }

}
