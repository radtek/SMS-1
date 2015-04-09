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

    public static partial class ModuleTemplateConverter
    {

        public static ModuleTemplateDTO ToDto(this Bec.TargetFramework.Data.ModuleTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ModuleTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ModuleTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new ModuleTemplateDTO();

            // Properties
            target.ModuleTemplateID = source.ModuleTemplateID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ModuleTemplateVersionNumber = source.ModuleTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.Modules = source.Modules.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationModuleTemplates = source.DefaultOrganisationModuleTemplates.ToDtosWithRelated(level - 1);
              target.ModuleStatusTypeTemplates = source.ModuleStatusTypeTemplates.ToDtosWithRelated(level - 1);
              target.ModuleProductTemplates = source.ModuleProductTemplates.ToDtosWithRelated(level - 1);
              target.ModuleWorkflowTemplates = source.ModuleWorkflowTemplates.ToDtosWithRelated(level - 1);
              target.ModuleClaimTemplates = source.ModuleClaimTemplates.ToDtosWithRelated(level - 1);
              target.ModuleSubscriptionTemplates = source.ModuleSubscriptionTemplates.ToDtosWithRelated(level - 1);
              target.ModulePluginTemplates = source.ModulePluginTemplates.ToDtosWithRelated(level - 1);
              target.ModuleSettingTemplates = source.ModuleSettingTemplates.ToDtosWithRelated(level - 1);
              target.ModuleDependencyTemplates = source.ModuleDependencyTemplates.ToDtosWithRelated(level - 1);
              target.ModuleNotificationConstructTemplates = source.ModuleNotificationConstructTemplates.ToDtosWithRelated(level - 1);
              target.ModuleRoleTemplates = source.ModuleRoleTemplates.ToDtosWithRelated(level - 1);
              target.ModuleArtefactTemplates = source.ModuleArtefactTemplates.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ModuleTemplate ToEntity(this ModuleTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ModuleTemplate();

            // Properties
            target.ModuleTemplateID = source.ModuleTemplateID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ModuleTemplateVersionNumber = source.ModuleTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ModuleTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ModuleTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ModuleTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ModuleTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ModuleTemplate> ToEntities(this IEnumerable<ModuleTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ModuleTemplate source, ModuleTemplateDTO target);

        static partial void OnEntityCreating(ModuleTemplateDTO source, Bec.TargetFramework.Data.ModuleTemplate target);

    }

}
