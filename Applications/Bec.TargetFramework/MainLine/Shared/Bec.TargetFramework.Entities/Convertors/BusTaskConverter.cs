﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:15:01
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class BusTaskConverter
    {

        public static BusTaskDTO ToDto(this Bec.TargetFramework.Data.BusTask source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static BusTaskDTO ToDtoWithRelated(this Bec.TargetFramework.Data.BusTask source, int level)
        {
            if (source == null)
              return null;

            var target = new BusTaskDTO();

            // Properties
            target.BusTaskID = source.BusTaskID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.CreatedOn = source.CreatedOn;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.BusTaskHandlerID = source.BusTaskHandlerID;
            target.BusTaskVersionNumber = source.BusTaskVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.BusTaskHandler = source.BusTaskHandler.ToDtoWithRelated(level - 1);
              target.BusTaskSchedules = source.BusTaskSchedules.ToDtosWithRelated(level - 1);
              target.ProductBusTasks = source.ProductBusTasks.ToDtosWithRelated(level - 1);
              target.ProductBusTaskTemplates = source.ProductBusTaskTemplates.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.BusTask ToEntity(this BusTaskDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.BusTask();

            // Properties
            target.BusTaskID = source.BusTaskID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.CreatedOn = source.CreatedOn;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.BusTaskHandlerID = source.BusTaskHandlerID;
            target.BusTaskVersionNumber = source.BusTaskVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<BusTaskDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.BusTask> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<BusTaskDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.BusTask> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.BusTask> ToEntities(this IEnumerable<BusTaskDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.BusTask source, BusTaskDTO target);

        static partial void OnEntityCreating(BusTaskDTO source, Bec.TargetFramework.Data.BusTask target);

    }

}
