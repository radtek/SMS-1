﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 16:15:20
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class ModuleStatusTypeTemplateConverter
    {

        public static ModuleStatusTypeTemplateDTO ToDto(this Bec.TargetFramework.Data.ModuleStatusTypeTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ModuleStatusTypeTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ModuleStatusTypeTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new ModuleStatusTypeTemplateDTO();

            // Properties
            target.ModuleTemplateID = source.ModuleTemplateID;
            target.ModuleTemplateVersionNumber = source.ModuleTemplateVersionNumber;
            target.StatusTypeTemplateID = source.StatusTypeTemplateID;
            target.StatusTypeTemplateVersionNumber = source.StatusTypeTemplateVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.ModuleTemplate = source.ModuleTemplate.ToDtoWithRelated(level - 1);
              target.StatusTypeTemplate = source.StatusTypeTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ModuleStatusTypeTemplate ToEntity(this ModuleStatusTypeTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ModuleStatusTypeTemplate();

            // Properties
            target.ModuleTemplateID = source.ModuleTemplateID;
            target.ModuleTemplateVersionNumber = source.ModuleTemplateVersionNumber;
            target.StatusTypeTemplateID = source.StatusTypeTemplateID;
            target.StatusTypeTemplateVersionNumber = source.StatusTypeTemplateVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ModuleStatusTypeTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ModuleStatusTypeTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ModuleStatusTypeTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ModuleStatusTypeTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ModuleStatusTypeTemplate> ToEntities(this IEnumerable<ModuleStatusTypeTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ModuleStatusTypeTemplate source, ModuleStatusTypeTemplateDTO target);

        static partial void OnEntityCreating(ModuleStatusTypeTemplateDTO source, Bec.TargetFramework.Data.ModuleStatusTypeTemplate target);

    }

}
