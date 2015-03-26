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

    public static partial class TFEventTypeConverter
    {

        public static TFEventTypeDTO ToDto(this Bec.TargetFramework.Data.TFEventType source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static TFEventTypeDTO ToDtoWithRelated(this Bec.TargetFramework.Data.TFEventType source, int level)
        {
            if (source == null)
              return null;

            var target = new TFEventTypeDTO();

            // Properties
            target.TFEventTypeID = source.TFEventTypeID;
            target.Name = source.Name;

            // Navigation Properties
            if (level > 0) {
              target.TFEvents = source.TFEvents.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.TFEventType ToEntity(this TFEventTypeDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.TFEventType();

            // Properties
            target.TFEventTypeID = source.TFEventTypeID;
            target.Name = source.Name;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<TFEventTypeDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.TFEventType> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<TFEventTypeDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.TFEventType> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.TFEventType> ToEntities(this IEnumerable<TFEventTypeDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.TFEventType source, TFEventTypeDTO target);

        static partial void OnEntityCreating(TFEventTypeDTO source, Bec.TargetFramework.Data.TFEventType target);

    }

}
