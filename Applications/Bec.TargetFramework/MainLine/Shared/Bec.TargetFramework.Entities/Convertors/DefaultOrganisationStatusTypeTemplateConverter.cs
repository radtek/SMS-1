﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:53
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class DefaultOrganisationStatusTypeTemplateConverter
    {

        public static DefaultOrganisationStatusTypeTemplateDTO ToDto(this Bec.TargetFramework.Data.DefaultOrganisationStatusTypeTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DefaultOrganisationStatusTypeTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DefaultOrganisationStatusTypeTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new DefaultOrganisationStatusTypeTemplateDTO();

            // Properties
            target.StatusTypeTemplateID = source.StatusTypeTemplateID;
            target.StatusTypeTemplateVersionNumber = source.StatusTypeTemplateVersionNumber;
            target.ParentID = source.ParentID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.DefaultOrganisationTemplateID = source.DefaultOrganisationTemplateID;
            target.DefaultOrganisationTemplateVersionNumber = source.DefaultOrganisationTemplateVersionNumber;
            target.DefaultStatusTypeValueTemplateID = source.DefaultStatusTypeValueTemplateID;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisationTargetTemplates = source.DefaultOrganisationTargetTemplates.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationTemplate = source.DefaultOrganisationTemplate.ToDtoWithRelated(level - 1);
              target.StatusTypeValueTemplate = source.StatusTypeValueTemplate.ToDtoWithRelated(level - 1);
              target.StatusTypeTemplate = source.StatusTypeTemplate.ToDtoWithRelated(level - 1);
              target.DefaultOrganisationUserTargetTemplates = source.DefaultOrganisationUserTargetTemplates.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DefaultOrganisationStatusTypeTemplate ToEntity(this DefaultOrganisationStatusTypeTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DefaultOrganisationStatusTypeTemplate();

            // Properties
            target.StatusTypeTemplateID = source.StatusTypeTemplateID;
            target.StatusTypeTemplateVersionNumber = source.StatusTypeTemplateVersionNumber;
            target.ParentID = source.ParentID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.DefaultOrganisationTemplateID = source.DefaultOrganisationTemplateID;
            target.DefaultOrganisationTemplateVersionNumber = source.DefaultOrganisationTemplateVersionNumber;
            target.DefaultStatusTypeValueTemplateID = source.DefaultStatusTypeValueTemplateID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DefaultOrganisationStatusTypeTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationStatusTypeTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DefaultOrganisationStatusTypeTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationStatusTypeTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DefaultOrganisationStatusTypeTemplate> ToEntities(this IEnumerable<DefaultOrganisationStatusTypeTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DefaultOrganisationStatusTypeTemplate source, DefaultOrganisationStatusTypeTemplateDTO target);

        static partial void OnEntityCreating(DefaultOrganisationStatusTypeTemplateDTO source, Bec.TargetFramework.Data.DefaultOrganisationStatusTypeTemplate target);

    }

}
