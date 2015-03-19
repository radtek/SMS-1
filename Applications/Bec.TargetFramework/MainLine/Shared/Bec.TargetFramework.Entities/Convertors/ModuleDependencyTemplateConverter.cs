﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 18/03/2015 19:00:46
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class ModuleDependencyTemplateConverter
    {

        public static ModuleDependencyTemplateDTO ToDto(this Bec.TargetFramework.Data.ModuleDependencyTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ModuleDependencyTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ModuleDependencyTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new ModuleDependencyTemplateDTO();

            // Properties
            target.ModuleDependencyTemplateID = source.ModuleDependencyTemplateID;
            target.ModuleTemplateID = source.ModuleTemplateID;
            target.ModuleTemplateVersionNumber = source.ModuleTemplateVersionNumber;
            target.DependencyID = source.DependencyID;
            target.DependencyVersionNumber = source.DependencyVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.ModuleTemplate = source.ModuleTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ModuleDependencyTemplate ToEntity(this ModuleDependencyTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ModuleDependencyTemplate();

            // Properties
            target.ModuleDependencyTemplateID = source.ModuleDependencyTemplateID;
            target.ModuleTemplateID = source.ModuleTemplateID;
            target.ModuleTemplateVersionNumber = source.ModuleTemplateVersionNumber;
            target.DependencyID = source.DependencyID;
            target.DependencyVersionNumber = source.DependencyVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ModuleDependencyTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ModuleDependencyTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ModuleDependencyTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ModuleDependencyTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ModuleDependencyTemplate> ToEntities(this IEnumerable<ModuleDependencyTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ModuleDependencyTemplate source, ModuleDependencyTemplateDTO target);

        static partial void OnEntityCreating(ModuleDependencyTemplateDTO source, Bec.TargetFramework.Data.ModuleDependencyTemplate target);

    }

}
