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

    public static partial class ModuleDependencyConverter
    {

        public static ModuleDependencyDTO ToDto(this Bec.TargetFramework.Data.ModuleDependency source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ModuleDependencyDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ModuleDependency source, int level)
        {
            if (source == null)
              return null;

            var target = new ModuleDependencyDTO();

            // Properties
            target.ModuleDependencyID = source.ModuleDependencyID;
            target.ModuleID = source.ModuleID;
            target.ModuleVersionNumber = source.ModuleVersionNumber;
            target.DependencyID = source.DependencyID;
            target.DependencyVersionNumber = source.DependencyVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.Module_DependencyID_DependencyVersionNumber = source.Module_DependencyID_DependencyVersionNumber.ToDtoWithRelated(level - 1);
              target.Module_ModuleID_ModuleVersionNumber = source.Module_ModuleID_ModuleVersionNumber.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ModuleDependency ToEntity(this ModuleDependencyDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ModuleDependency();

            // Properties
            target.ModuleDependencyID = source.ModuleDependencyID;
            target.ModuleID = source.ModuleID;
            target.ModuleVersionNumber = source.ModuleVersionNumber;
            target.DependencyID = source.DependencyID;
            target.DependencyVersionNumber = source.DependencyVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ModuleDependencyDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ModuleDependency> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ModuleDependencyDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ModuleDependency> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ModuleDependency> ToEntities(this IEnumerable<ModuleDependencyDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ModuleDependency source, ModuleDependencyDTO target);

        static partial void OnEntityCreating(ModuleDependencyDTO source, Bec.TargetFramework.Data.ModuleDependency target);

    }

}
