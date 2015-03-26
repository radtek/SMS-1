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

    public static partial class VBusTaskScheduleConverter
    {

        public static VBusTaskScheduleDTO ToDto(this Bec.TargetFramework.Data.VBusTaskSchedule source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VBusTaskScheduleDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VBusTaskSchedule source, int level)
        {
            if (source == null)
              return null;

            var target = new VBusTaskScheduleDTO();

            // Properties
            target.BusTaskScheduleID = source.BusTaskScheduleID;
            target.BusTaskID = source.BusTaskID;
            target.IntervalInMinutes = source.IntervalInMinutes;
            target.CreatedOn = source.CreatedOn;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.BusTaskHandlerID = source.BusTaskHandlerID;
            target.ObjectTypeName = source.ObjectTypeName;
            target.ObjectTypeAssembly = source.ObjectTypeAssembly;
            target.MessageTypeName = source.MessageTypeName;
            target.MessageTypeAssembly = source.MessageTypeAssembly;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VBusTaskSchedule ToEntity(this VBusTaskScheduleDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VBusTaskSchedule();

            // Properties
            target.BusTaskScheduleID = source.BusTaskScheduleID;
            target.BusTaskID = source.BusTaskID;
            target.IntervalInMinutes = source.IntervalInMinutes;
            target.CreatedOn = source.CreatedOn;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.BusTaskHandlerID = source.BusTaskHandlerID;
            target.ObjectTypeName = source.ObjectTypeName;
            target.ObjectTypeAssembly = source.ObjectTypeAssembly;
            target.MessageTypeName = source.MessageTypeName;
            target.MessageTypeAssembly = source.MessageTypeAssembly;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VBusTaskScheduleDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VBusTaskSchedule> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VBusTaskScheduleDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VBusTaskSchedule> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VBusTaskSchedule> ToEntities(this IEnumerable<VBusTaskScheduleDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VBusTaskSchedule source, VBusTaskScheduleDTO target);

        static partial void OnEntityCreating(VBusTaskScheduleDTO source, Bec.TargetFramework.Data.VBusTaskSchedule target);

    }

}
