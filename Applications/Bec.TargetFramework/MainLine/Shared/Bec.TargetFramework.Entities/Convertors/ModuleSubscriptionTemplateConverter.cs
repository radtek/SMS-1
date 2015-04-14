﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 13/04/2015 17:29:39
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class ModuleSubscriptionTemplateConverter
    {

        public static ModuleSubscriptionTemplateDTO ToDto(this Bec.TargetFramework.Data.ModuleSubscriptionTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ModuleSubscriptionTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ModuleSubscriptionTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new ModuleSubscriptionTemplateDTO();

            // Properties
            target.ModuleSubscriptionTemplateID = source.ModuleSubscriptionTemplateID;
            target.ModuleTemplateID = source.ModuleTemplateID;
            target.ModuleTemplateVersionNumber = source.ModuleTemplateVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.PlanSubscriptionTemplateID = source.PlanSubscriptionTemplateID;
            target.PlanSubscriptionTemplateVersionNumber = source.PlanSubscriptionTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.ModuleTemplate = source.ModuleTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ModuleSubscriptionTemplate ToEntity(this ModuleSubscriptionTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ModuleSubscriptionTemplate();

            // Properties
            target.ModuleSubscriptionTemplateID = source.ModuleSubscriptionTemplateID;
            target.ModuleTemplateID = source.ModuleTemplateID;
            target.ModuleTemplateVersionNumber = source.ModuleTemplateVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.PlanSubscriptionTemplateID = source.PlanSubscriptionTemplateID;
            target.PlanSubscriptionTemplateVersionNumber = source.PlanSubscriptionTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ModuleSubscriptionTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ModuleSubscriptionTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ModuleSubscriptionTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ModuleSubscriptionTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ModuleSubscriptionTemplate> ToEntities(this IEnumerable<ModuleSubscriptionTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ModuleSubscriptionTemplate source, ModuleSubscriptionTemplateDTO target);

        static partial void OnEntityCreating(ModuleSubscriptionTemplateDTO source, Bec.TargetFramework.Data.ModuleSubscriptionTemplate target);

    }

}
