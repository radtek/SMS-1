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

    public static partial class ModuleConverter
    {

        public static ModuleDTO ToDto(this Bec.TargetFramework.Data.Module source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ModuleDTO ToDtoWithRelated(this Bec.TargetFramework.Data.Module source, int level)
        {
            if (source == null)
              return null;

            var target = new ModuleDTO();

            // Properties
            target.ModuleID = source.ModuleID;
            target.ModuleVersionNumber = source.ModuleVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.ModuleTemplateID = source.ModuleTemplateID;
            target.ModuleTemplateVersionNumber = source.ModuleTemplateVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.ModuleTemplate = source.ModuleTemplate.ToDtoWithRelated(level - 1);
              target.ModuleSubscriptions = source.ModuleSubscriptions.ToDtosWithRelated(level - 1);
              target.ModuleClaims = source.ModuleClaims.ToDtosWithRelated(level - 1);
              target.ModuleSettings = source.ModuleSettings.ToDtosWithRelated(level - 1);
              target.ModuleProducts = source.ModuleProducts.ToDtosWithRelated(level - 1);
              target.ModuleWorkflows = source.ModuleWorkflows.ToDtosWithRelated(level - 1);
              target.ModuleDependencies_DependencyID_DependencyVersionNumber = source.ModuleDependencies_DependencyID_DependencyVersionNumber.ToDtosWithRelated(level - 1);
              target.ModuleDependencies_ModuleID_ModuleVersionNumber = source.ModuleDependencies_ModuleID_ModuleVersionNumber.ToDtosWithRelated(level - 1);
              target.ModuleStatusTypes = source.ModuleStatusTypes.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationModules = source.DefaultOrganisationModules.ToDtosWithRelated(level - 1);
              target.ModulePlugins = source.ModulePlugins.ToDtosWithRelated(level - 1);
              target.ModuleArtefacts = source.ModuleArtefacts.ToDtosWithRelated(level - 1);
              target.ModuleNotificationConstructs = source.ModuleNotificationConstructs.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.Module ToEntity(this ModuleDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.Module();

            // Properties
            target.ModuleID = source.ModuleID;
            target.ModuleVersionNumber = source.ModuleVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.ModuleTemplateID = source.ModuleTemplateID;
            target.ModuleTemplateVersionNumber = source.ModuleTemplateVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ModuleDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.Module> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ModuleDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.Module> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.Module> ToEntities(this IEnumerable<ModuleDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.Module source, ModuleDTO target);

        static partial void OnEntityCreating(ModuleDTO source, Bec.TargetFramework.Data.Module target);

    }

}
