﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 16:15:20
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class TimeoutentityConverter
    {

        public static TimeoutentityDTO ToDto(this Bec.TargetFramework.Data.Timeoutentity source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static TimeoutentityDTO ToDtoWithRelated(this Bec.TargetFramework.Data.Timeoutentity source, int level)
        {
            if (source == null)
              return null;

            var target = new TimeoutentityDTO();

            // Properties
            target.Id = source.Id;
            target.Destination = source.Destination;
            target.Sagaid = source.Sagaid;
            target.State = source.State;
            target.Time = source.Time;
            target.Correlationid = source.Correlationid;
            target.Headers = source.Headers;
            target.Endpoint = source.Endpoint;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.Timeoutentity ToEntity(this TimeoutentityDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.Timeoutentity();

            // Properties
            target.Id = source.Id;
            target.Destination = source.Destination;
            target.Sagaid = source.Sagaid;
            target.State = source.State;
            target.Time = source.Time;
            target.Correlationid = source.Correlationid;
            target.Headers = source.Headers;
            target.Endpoint = source.Endpoint;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<TimeoutentityDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.Timeoutentity> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<TimeoutentityDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.Timeoutentity> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.Timeoutentity> ToEntities(this IEnumerable<TimeoutentityDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.Timeoutentity source, TimeoutentityDTO target);

        static partial void OnEntityCreating(TimeoutentityDTO source, Bec.TargetFramework.Data.Timeoutentity target);

    }

}
