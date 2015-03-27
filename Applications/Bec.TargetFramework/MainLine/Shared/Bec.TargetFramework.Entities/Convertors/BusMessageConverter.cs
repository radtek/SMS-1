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

    public static partial class BusMessageConverter
    {

        public static BusMessageDTO ToDto(this Bec.TargetFramework.Data.BusMessage source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static BusMessageDTO ToDtoWithRelated(this Bec.TargetFramework.Data.BusMessage source, int level)
        {
            if (source == null)
              return null;

            var target = new BusMessageDTO();

            // Properties
            target.MessageId = source.MessageId;
            target.CorrelationId = source.CorrelationId;
            target.BusMessageID = source.BusMessageID;
            target.ConversationId = source.ConversationId;
            target.TimeSent = source.TimeSent;
            target.EnclosedMessageTypes = source.EnclosedMessageTypes;
            target.WinIdName = source.WinIdName;
            target.ProcessingMachine = source.ProcessingMachine;
            target.ProcessingStarted = source.ProcessingStarted;
            target.BusMessageTypeID = source.BusMessageTypeID;
            target.MessageSentFrom = source.MessageSentFrom;
            target.Source = source.Source;
            target.ParentID = source.ParentID;
            target.EventReference = source.EventReference;

            // Navigation Properties
            if (level > 0) {
              target.BusMessageContents = source.BusMessageContents.ToDtosWithRelated(level - 1);
              target.BusMessageProcessLogs = source.BusMessageProcessLogs.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.BusMessage ToEntity(this BusMessageDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.BusMessage();

            // Properties
            target.MessageId = source.MessageId;
            target.CorrelationId = source.CorrelationId;
            target.BusMessageID = source.BusMessageID;
            target.ConversationId = source.ConversationId;
            target.TimeSent = source.TimeSent;
            target.EnclosedMessageTypes = source.EnclosedMessageTypes;
            target.WinIdName = source.WinIdName;
            target.ProcessingMachine = source.ProcessingMachine;
            target.ProcessingStarted = source.ProcessingStarted;
            target.BusMessageTypeID = source.BusMessageTypeID;
            target.MessageSentFrom = source.MessageSentFrom;
            target.Source = source.Source;
            target.ParentID = source.ParentID;
            target.EventReference = source.EventReference;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<BusMessageDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.BusMessage> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<BusMessageDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.BusMessage> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.BusMessage> ToEntities(this IEnumerable<BusMessageDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.BusMessage source, BusMessageDTO target);

        static partial void OnEntityCreating(BusMessageDTO source, Bec.TargetFramework.Data.BusMessage target);

    }

}
