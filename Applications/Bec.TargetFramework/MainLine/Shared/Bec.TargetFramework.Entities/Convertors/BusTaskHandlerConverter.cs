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

    public static partial class BusTaskHandlerConverter
    {

        public static BusTaskHandlerDTO ToDto(this Bec.TargetFramework.Data.BusTaskHandler source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static BusTaskHandlerDTO ToDtoWithRelated(this Bec.TargetFramework.Data.BusTaskHandler source, int level)
        {
            if (source == null)
              return null;

            var target = new BusTaskHandlerDTO();

            // Properties
            target.BusTaskHandlerID = source.BusTaskHandlerID;
            target.Name = source.Name;
            target.ObjectTypeName = source.ObjectTypeName;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ObjectTypeAssembly = source.ObjectTypeAssembly;
            target.MessageTypeName = source.MessageTypeName;
            target.MessageTypeAssembly = source.MessageTypeAssembly;
            target.HandlerMessageTypeName = source.HandlerMessageTypeName;
            target.HandlerMessageTypeAssembly = source.HandlerMessageTypeAssembly;
            target.IsHandlerBasedTask = source.IsHandlerBasedTask;
            target.NumberOfRetries = source.NumberOfRetries;
            target.TaskDataHasExpiry = source.TaskDataHasExpiry;
            target.TaskDataExpiryPeriodUnitID = source.TaskDataExpiryPeriodUnitID;
            target.TaskDataExpiryPeriod = source.TaskDataExpiryPeriod;
            target.DefaultProcessDataTypeID = source.DefaultProcessDataTypeID;
            target.DefaultProcessDataCategoryID = source.DefaultProcessDataCategoryID;

            // Navigation Properties
            if (level > 0) {
              target.BusTasks = source.BusTasks.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.BusTaskHandler ToEntity(this BusTaskHandlerDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.BusTaskHandler();

            // Properties
            target.BusTaskHandlerID = source.BusTaskHandlerID;
            target.Name = source.Name;
            target.ObjectTypeName = source.ObjectTypeName;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ObjectTypeAssembly = source.ObjectTypeAssembly;
            target.MessageTypeName = source.MessageTypeName;
            target.MessageTypeAssembly = source.MessageTypeAssembly;
            target.HandlerMessageTypeName = source.HandlerMessageTypeName;
            target.HandlerMessageTypeAssembly = source.HandlerMessageTypeAssembly;
            target.IsHandlerBasedTask = source.IsHandlerBasedTask;
            target.NumberOfRetries = source.NumberOfRetries;
            target.TaskDataHasExpiry = source.TaskDataHasExpiry;
            target.TaskDataExpiryPeriodUnitID = source.TaskDataExpiryPeriodUnitID;
            target.TaskDataExpiryPeriod = source.TaskDataExpiryPeriod;
            target.DefaultProcessDataTypeID = source.DefaultProcessDataTypeID;
            target.DefaultProcessDataCategoryID = source.DefaultProcessDataCategoryID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<BusTaskHandlerDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.BusTaskHandler> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<BusTaskHandlerDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.BusTaskHandler> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.BusTaskHandler> ToEntities(this IEnumerable<BusTaskHandlerDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.BusTaskHandler source, BusTaskHandlerDTO target);

        static partial void OnEntityCreating(BusTaskHandlerDTO source, Bec.TargetFramework.Data.BusTaskHandler target);

    }

}
