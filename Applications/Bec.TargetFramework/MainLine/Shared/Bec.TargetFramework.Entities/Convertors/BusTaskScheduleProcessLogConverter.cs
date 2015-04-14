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

    public static partial class BusTaskScheduleProcessLogConverter
    {

        public static BusTaskScheduleProcessLogDTO ToDto(this Bec.TargetFramework.Data.BusTaskScheduleProcessLog source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static BusTaskScheduleProcessLogDTO ToDtoWithRelated(this Bec.TargetFramework.Data.BusTaskScheduleProcessLog source, int level)
        {
            if (source == null)
              return null;

            var target = new BusTaskScheduleProcessLogDTO();

            // Properties
            target.CreatedOn = source.CreatedOn;
            target.HasError = source.HasError;
            target.IsComplete = source.IsComplete;
            target.ProcessMessage = source.ProcessMessage;
            target.ProcessDetail = source.ProcessDetail;
            target.BusTaskScheduleID = source.BusTaskScheduleID;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.BusTaskScheduleProcessLogID = source.BusTaskScheduleProcessLogID;
            target.ParentID = source.ParentID;
            target.NumberOfRetries = source.NumberOfRetries;

            // Navigation Properties
            if (level > 0) {
              target.BusTaskSchedule = source.BusTaskSchedule.ToDtoWithRelated(level - 1);
              target.StatusType = source.StatusType.ToDtoWithRelated(level - 1);
              target.StatusTypeValue = source.StatusTypeValue.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.BusTaskScheduleProcessLog ToEntity(this BusTaskScheduleProcessLogDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.BusTaskScheduleProcessLog();

            // Properties
            target.CreatedOn = source.CreatedOn;
            target.HasError = source.HasError;
            target.IsComplete = source.IsComplete;
            target.ProcessMessage = source.ProcessMessage;
            target.ProcessDetail = source.ProcessDetail;
            target.BusTaskScheduleID = source.BusTaskScheduleID;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.BusTaskScheduleProcessLogID = source.BusTaskScheduleProcessLogID;
            target.ParentID = source.ParentID;
            target.NumberOfRetries = source.NumberOfRetries;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<BusTaskScheduleProcessLogDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.BusTaskScheduleProcessLog> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<BusTaskScheduleProcessLogDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.BusTaskScheduleProcessLog> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.BusTaskScheduleProcessLog> ToEntities(this IEnumerable<BusTaskScheduleProcessLogDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.BusTaskScheduleProcessLog source, BusTaskScheduleProcessLogDTO target);

        static partial void OnEntityCreating(BusTaskScheduleProcessLogDTO source, Bec.TargetFramework.Data.BusTaskScheduleProcessLog target);

    }

}
