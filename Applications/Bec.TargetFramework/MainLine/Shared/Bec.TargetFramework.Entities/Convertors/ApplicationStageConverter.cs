﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:20 AM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class ApplicationStageConverter
    {

        public static ApplicationStageDTO ToDto(this Bec.TargetFramework.Data.ApplicationStage source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ApplicationStageDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ApplicationStage source, int level)
        {
            if (source == null)
              return null;

            var target = new ApplicationStageDTO();

            // Properties
            target.ApplicationStageID = source.ApplicationStageID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.Order = source.Order;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.ApplicationStageWorkflows = source.ApplicationStageWorkflows.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ApplicationStage ToEntity(this ApplicationStageDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ApplicationStage();

            // Properties
            target.ApplicationStageID = source.ApplicationStageID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.Order = source.Order;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ApplicationStageDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ApplicationStage> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ApplicationStageDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ApplicationStage> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ApplicationStage> ToEntities(this IEnumerable<ApplicationStageDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ApplicationStage source, ApplicationStageDTO target);

        static partial void OnEntityCreating(ApplicationStageDTO source, Bec.TargetFramework.Data.ApplicationStage target);

    }

}
