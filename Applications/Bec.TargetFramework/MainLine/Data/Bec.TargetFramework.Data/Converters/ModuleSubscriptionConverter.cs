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

    public static partial class ModuleSubscriptionConverter
    {

        public static ModuleSubscriptionDTO ToDto(this Bec.TargetFramework.Data.ModuleSubscription source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ModuleSubscriptionDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ModuleSubscription source, int level)
        {
            if (source == null)
              return null;

            var target = new ModuleSubscriptionDTO();

            // Properties
            target.ModuleSubscriptionID = source.ModuleSubscriptionID;
            target.ModuleID = source.ModuleID;
            target.ModuleVersionNumber = source.ModuleVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.PlanSubscriptionID = source.PlanSubscriptionID;
            target.PlanSubscriptionVersionNumber = source.PlanSubscriptionVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.Module = source.Module.ToDtoWithRelated(level - 1);
              target.PlanSubscription = source.PlanSubscription.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ModuleSubscription ToEntity(this ModuleSubscriptionDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ModuleSubscription();

            // Properties
            target.ModuleSubscriptionID = source.ModuleSubscriptionID;
            target.ModuleID = source.ModuleID;
            target.ModuleVersionNumber = source.ModuleVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.PlanSubscriptionID = source.PlanSubscriptionID;
            target.PlanSubscriptionVersionNumber = source.PlanSubscriptionVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ModuleSubscriptionDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ModuleSubscription> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ModuleSubscriptionDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ModuleSubscription> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ModuleSubscription> ToEntities(this IEnumerable<ModuleSubscriptionDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ModuleSubscription source, ModuleSubscriptionDTO target);

        static partial void OnEntityCreating(ModuleSubscriptionDTO source, Bec.TargetFramework.Data.ModuleSubscription target);

    }

}