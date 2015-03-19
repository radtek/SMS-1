﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 18/03/2015 19:00:46
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class SubscriptionConverter
    {

        public static SubscriptionDTO ToDto(this Bec.TargetFramework.Data.Subscription source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static SubscriptionDTO ToDtoWithRelated(this Bec.TargetFramework.Data.Subscription source, int level)
        {
            if (source == null)
              return null;

            var target = new SubscriptionDTO();

            // Properties
            target.Subscriberendpoint = source.Subscriberendpoint;
            target.Messagetype = source.Messagetype;
            target.Version = source.Version;
            target.Typename = source.Typename;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.Subscription ToEntity(this SubscriptionDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.Subscription();

            // Properties
            target.Subscriberendpoint = source.Subscriberendpoint;
            target.Messagetype = source.Messagetype;
            target.Version = source.Version;
            target.Typename = source.Typename;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<SubscriptionDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.Subscription> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<SubscriptionDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.Subscription> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.Subscription> ToEntities(this IEnumerable<SubscriptionDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.Subscription source, SubscriptionDTO target);

        static partial void OnEntityCreating(SubscriptionDTO source, Bec.TargetFramework.Data.Subscription target);

    }

}
