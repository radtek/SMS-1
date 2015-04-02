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

    public static partial class StatusTypeValueTemplateConverter
    {

        public static StatusTypeValueTemplateDTO ToDto(this Bec.TargetFramework.Data.StatusTypeValueTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static StatusTypeValueTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.StatusTypeValueTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new StatusTypeValueTemplateDTO();

            // Properties
            target.StatusTypeValueTemplateID = source.StatusTypeValueTemplateID;
            target.StatusTypeTemplateID = source.StatusTypeTemplateID;
            target.StatusTypeTemplateVersionNumber = source.StatusTypeTemplateVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisationStatusTypeTemplates = source.DefaultOrganisationStatusTypeTemplates.ToDtosWithRelated(level - 1);
              target.StatusTypeStructureTemplates = source.StatusTypeStructureTemplates.ToDtosWithRelated(level - 1);
              target.StatusTypeTemplate = source.StatusTypeTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.StatusTypeValueTemplate ToEntity(this StatusTypeValueTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.StatusTypeValueTemplate();

            // Properties
            target.StatusTypeValueTemplateID = source.StatusTypeValueTemplateID;
            target.StatusTypeTemplateID = source.StatusTypeTemplateID;
            target.StatusTypeTemplateVersionNumber = source.StatusTypeTemplateVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<StatusTypeValueTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.StatusTypeValueTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<StatusTypeValueTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.StatusTypeValueTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.StatusTypeValueTemplate> ToEntities(this IEnumerable<StatusTypeValueTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.StatusTypeValueTemplate source, StatusTypeValueTemplateDTO target);

        static partial void OnEntityCreating(StatusTypeValueTemplateDTO source, Bec.TargetFramework.Data.StatusTypeValueTemplate target);

    }

}
