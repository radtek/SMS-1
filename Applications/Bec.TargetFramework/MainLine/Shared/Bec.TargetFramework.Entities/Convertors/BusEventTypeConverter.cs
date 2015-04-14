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

    public static partial class BusEventTypeConverter
    {

        public static BusEventTypeDTO ToDto(this Bec.TargetFramework.Data.BusEventType source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static BusEventTypeDTO ToDtoWithRelated(this Bec.TargetFramework.Data.BusEventType source, int level)
        {
            if (source == null)
              return null;

            var target = new BusEventTypeDTO();

            // Properties
            target.BusEventTypeID = source.BusEventTypeID;
            target.Name = source.Name;

            // Navigation Properties
            if (level > 0) {
              target.BusEvents = source.BusEvents.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.BusEventType ToEntity(this BusEventTypeDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.BusEventType();

            // Properties
            target.BusEventTypeID = source.BusEventTypeID;
            target.Name = source.Name;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<BusEventTypeDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.BusEventType> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<BusEventTypeDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.BusEventType> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.BusEventType> ToEntities(this IEnumerable<BusEventTypeDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.BusEventType source, BusEventTypeDTO target);

        static partial void OnEntityCreating(BusEventTypeDTO source, Bec.TargetFramework.Data.BusEventType target);

    }

}
