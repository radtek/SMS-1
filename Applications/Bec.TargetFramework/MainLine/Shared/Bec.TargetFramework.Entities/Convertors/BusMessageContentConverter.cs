﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:53
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class BusMessageContentConverter
    {

        public static BusMessageContentDTO ToDto(this Bec.TargetFramework.Data.BusMessageContent source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static BusMessageContentDTO ToDtoWithRelated(this Bec.TargetFramework.Data.BusMessageContent source, int level)
        {
            if (source == null)
              return null;

            var target = new BusMessageContentDTO();

            // Properties
            target.BusMessageContentID = source.BusMessageContentID;
            target.BusMessageContent1 = source.BusMessageContent1;
            target.BusMessageID = source.BusMessageID;
            target.BusMessageContentType = source.BusMessageContentType;
            target.BusMessageHeader = source.BusMessageHeader;

            // Navigation Properties
            if (level > 0) {
              target.BusMessage = source.BusMessage.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.BusMessageContent ToEntity(this BusMessageContentDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.BusMessageContent();

            // Properties
            target.BusMessageContentID = source.BusMessageContentID;
            target.BusMessageContent1 = source.BusMessageContent1;
            target.BusMessageID = source.BusMessageID;
            target.BusMessageContentType = source.BusMessageContentType;
            target.BusMessageHeader = source.BusMessageHeader;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<BusMessageContentDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.BusMessageContent> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<BusMessageContentDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.BusMessageContent> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.BusMessageContent> ToEntities(this IEnumerable<BusMessageContentDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.BusMessageContent source, BusMessageContentDTO target);

        static partial void OnEntityCreating(BusMessageContentDTO source, Bec.TargetFramework.Data.BusMessageContent target);

    }

}
