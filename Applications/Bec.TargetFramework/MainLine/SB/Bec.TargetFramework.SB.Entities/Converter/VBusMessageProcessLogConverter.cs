﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/06/2015 16:32:47
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.SB.Entities
{

    public static partial class VBusMessageProcessLogConverter
    {

        public static VBusMessageProcessLogDTO ToDto(this Bec.TargetFramework.SB.Data.VBusMessageProcessLog source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VBusMessageProcessLogDTO ToDtoWithRelated(this Bec.TargetFramework.SB.Data.VBusMessageProcessLog source, int level)
        {
            if (source == null)
              return null;

            var target = new VBusMessageProcessLogDTO();

            // Properties
            target.BusMessageID = source.BusMessageID;
            target.CreatedOn = source.CreatedOn;
            target.SentOn = source.SentOn;
            target.ProcessingStarted = source.ProcessingStarted;
            target.ProcessingMachine = source.ProcessingMachine;
            target.MessageSentFrom = source.MessageSentFrom;
            target.EventReference = source.EventReference;
            target.Source = source.Source;
            target.BusMessageSubscriber = source.BusMessageSubscriber;
            target.BusMessageHandler = source.BusMessageHandler;
            target.Name = source.Name;
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.HasError = source.HasError;
            target.IsComplete = source.IsComplete;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.SB.Data.VBusMessageProcessLog ToEntity(this VBusMessageProcessLogDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.SB.Data.VBusMessageProcessLog();

            // Properties
            target.BusMessageID = source.BusMessageID;
            target.CreatedOn = source.CreatedOn;
            target.SentOn = source.SentOn;
            target.ProcessingStarted = source.ProcessingStarted;
            target.ProcessingMachine = source.ProcessingMachine;
            target.MessageSentFrom = source.MessageSentFrom;
            target.EventReference = source.EventReference;
            target.Source = source.Source;
            target.BusMessageSubscriber = source.BusMessageSubscriber;
            target.BusMessageHandler = source.BusMessageHandler;
            target.Name = source.Name;
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.HasError = source.HasError;
            target.IsComplete = source.IsComplete;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VBusMessageProcessLogDTO> ToDtos(this IEnumerable<Bec.TargetFramework.SB.Data.VBusMessageProcessLog> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VBusMessageProcessLogDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.SB.Data.VBusMessageProcessLog> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.SB.Data.VBusMessageProcessLog> ToEntities(this IEnumerable<VBusMessageProcessLogDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.SB.Data.VBusMessageProcessLog source, VBusMessageProcessLogDTO target);

        static partial void OnEntityCreating(VBusMessageProcessLogDTO source, Bec.TargetFramework.SB.Data.VBusMessageProcessLog target);

    }

}
