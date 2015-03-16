﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:07 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class BusMessageProcessLogConverter
    {

        public static BusMessageProcessLogDTO ToDto(this Bec.TargetFramework.Data.BusMessageProcessLog source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static BusMessageProcessLogDTO ToDtoWithRelated(this Bec.TargetFramework.Data.BusMessageProcessLog source, int level)
        {
            if (source == null)
              return null;

            var target = new BusMessageProcessLogDTO();

            // Properties
            target.BusMessageID = source.BusMessageID;
            target.CreatedOn = source.CreatedOn;
            target.BusMessageProcessLogID = source.BusMessageProcessLogID;
            target.ProcessDetail = source.ProcessDetail;
            target.ProcessMessage = source.ProcessMessage;
            target.ParentID = source.ParentID;
            target.BusMessageSubscriber = source.BusMessageSubscriber;
            target.BusMessageHandler = source.BusMessageHandler;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.HasError = source.HasError;
            target.NumberOfRetries = source.NumberOfRetries;
            target.IsComplete = source.IsComplete;

            // Navigation Properties
            if (level > 0) {
              target.StatusType = source.StatusType.ToDtoWithRelated(level - 1);
              target.StatusTypeValue = source.StatusTypeValue.ToDtoWithRelated(level - 1);
              target.BusMessage = source.BusMessage.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.BusMessageProcessLog ToEntity(this BusMessageProcessLogDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.BusMessageProcessLog();

            // Properties
            target.BusMessageID = source.BusMessageID;
            target.CreatedOn = source.CreatedOn;
            target.BusMessageProcessLogID = source.BusMessageProcessLogID;
            target.ProcessDetail = source.ProcessDetail;
            target.ProcessMessage = source.ProcessMessage;
            target.ParentID = source.ParentID;
            target.BusMessageSubscriber = source.BusMessageSubscriber;
            target.BusMessageHandler = source.BusMessageHandler;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.HasError = source.HasError;
            target.NumberOfRetries = source.NumberOfRetries;
            target.IsComplete = source.IsComplete;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<BusMessageProcessLogDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.BusMessageProcessLog> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<BusMessageProcessLogDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.BusMessageProcessLog> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.BusMessageProcessLog> ToEntities(this IEnumerable<BusMessageProcessLogDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.BusMessageProcessLog source, BusMessageProcessLogDTO target);

        static partial void OnEntityCreating(BusMessageProcessLogDTO source, Bec.TargetFramework.Data.BusMessageProcessLog target);

    }

}
