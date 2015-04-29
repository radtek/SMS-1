﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 29/04/2015 12:05:04
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.SB.Entities
{

    public static partial class StatusTypeTemplateConverter
    {

        public static StatusTypeTemplateDTO ToDto(this Bec.TargetFramework.SB.Data.StatusTypeTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static StatusTypeTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.SB.Data.StatusTypeTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new StatusTypeTemplateDTO();

            // Properties
            target.StatusTypeTemplateID = source.StatusTypeTemplateID;
            target.StatusTypeTemplateVersionNumber = source.StatusTypeTemplateVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.StatusTypes = source.StatusTypes.ToDtosWithRelated(level - 1);
              target.StatusTypeValueTemplates = source.StatusTypeValueTemplates.ToDtosWithRelated(level - 1);
              target.StatusTypeStructureTemplates = source.StatusTypeStructureTemplates.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.SB.Data.StatusTypeTemplate ToEntity(this StatusTypeTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.SB.Data.StatusTypeTemplate();

            // Properties
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

        public static List<StatusTypeTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.SB.Data.StatusTypeTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<StatusTypeTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.SB.Data.StatusTypeTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.SB.Data.StatusTypeTemplate> ToEntities(this IEnumerable<StatusTypeTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.SB.Data.StatusTypeTemplate source, StatusTypeTemplateDTO target);

        static partial void OnEntityCreating(StatusTypeTemplateDTO source, Bec.TargetFramework.SB.Data.StatusTypeTemplate target);

    }

}
