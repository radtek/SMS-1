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

    public static partial class TFEventConverter
    {

        public static TFEventDTO ToDto(this Bec.TargetFramework.Data.TFEvent source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static TFEventDTO ToDtoWithRelated(this Bec.TargetFramework.Data.TFEvent source, int level)
        {
            if (source == null)
              return null;

            var target = new TFEventDTO();

            // Properties
            target.TFEventID = source.TFEventID;
            target.TFEventName = source.TFEventName;
            target.TFEventDescription = source.TFEventDescription;
            target.TFEventTypeID = source.TFEventTypeID;

            // Navigation Properties
            if (level > 0) {
              target.TFEventType = source.TFEventType.ToDtoWithRelated(level - 1);
              target.TFEventMessageSubscribers = source.TFEventMessageSubscribers.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.TFEvent ToEntity(this TFEventDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.TFEvent();

            // Properties
            target.TFEventID = source.TFEventID;
            target.TFEventName = source.TFEventName;
            target.TFEventDescription = source.TFEventDescription;
            target.TFEventTypeID = source.TFEventTypeID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<TFEventDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.TFEvent> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<TFEventDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.TFEvent> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.TFEvent> ToEntities(this IEnumerable<TFEventDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.TFEvent source, TFEventDTO target);

        static partial void OnEntityCreating(TFEventDTO source, Bec.TargetFramework.Data.TFEvent target);

    }

}
