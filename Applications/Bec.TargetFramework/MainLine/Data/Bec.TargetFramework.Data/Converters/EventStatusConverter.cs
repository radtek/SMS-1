﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class EventStatusConverter
    {

        public static EventStatusDTO ToDto(this Bec.TargetFramework.Data.EventStatus source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static EventStatusDTO ToDtoWithRelated(this Bec.TargetFramework.Data.EventStatus source, int level)
        {
            if (source == null)
              return null;

            var target = new EventStatusDTO();

            // Properties
            target.EventStatusID = source.EventStatusID;
            target.EventName = source.EventName;
            target.EventReference = source.EventReference;
            target.Status = source.Status;
            target.Created = source.Created;
            target.Recipients = source.Recipients;
            target.Subject = source.Subject;
            target.Body = source.Body;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.EventStatus ToEntity(this EventStatusDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.EventStatus();

            // Properties
            target.EventStatusID = source.EventStatusID;
            target.EventName = source.EventName;
            target.EventReference = source.EventReference;
            target.Status = source.Status;
            target.Created = source.Created;
            target.Recipients = source.Recipients;
            target.Subject = source.Subject;
            target.Body = source.Body;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<EventStatusDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.EventStatus> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<EventStatusDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.EventStatus> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.EventStatus> ToEntities(this IEnumerable<EventStatusDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.EventStatus source, EventStatusDTO target);

        static partial void OnEntityCreating(EventStatusDTO source, Bec.TargetFramework.Data.EventStatus target);

    }

}
