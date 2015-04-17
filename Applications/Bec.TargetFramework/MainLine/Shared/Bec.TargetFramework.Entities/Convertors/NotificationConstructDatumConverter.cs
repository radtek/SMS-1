﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:54
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class NotificationConstructDatumConverter
    {

        public static NotificationConstructDatumDTO ToDto(this Bec.TargetFramework.Data.NotificationConstructDatum source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static NotificationConstructDatumDTO ToDtoWithRelated(this Bec.TargetFramework.Data.NotificationConstructDatum source, int level)
        {
            if (source == null)
              return null;

            var target = new NotificationConstructDatumDTO();

            // Properties
            target.NotificationConstructDataID = source.NotificationConstructDataID;
            target.NotificationConstructID = source.NotificationConstructID;
            target.NotificationConstructVersionNumber = source.NotificationConstructVersionNumber;
            target.NotificationData = source.NotificationData;
            target.NotificationDataLength = source.NotificationDataLength;
            target.NotificationDataMimeType = source.NotificationDataMimeType;
            target.NotificationDataFileName = source.NotificationDataFileName;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.CreatedOn = source.CreatedOn;
            target.UsesBusinessObjects = source.UsesBusinessObjects;
            target.UsesDataSources = source.UsesDataSources;

            // Navigation Properties
            if (level > 0) {
              target.NotificationConstruct = source.NotificationConstruct.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.NotificationConstructDatum ToEntity(this NotificationConstructDatumDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.NotificationConstructDatum();

            // Properties
            target.NotificationConstructDataID = source.NotificationConstructDataID;
            target.NotificationConstructID = source.NotificationConstructID;
            target.NotificationConstructVersionNumber = source.NotificationConstructVersionNumber;
            target.NotificationData = source.NotificationData;
            target.NotificationDataLength = source.NotificationDataLength;
            target.NotificationDataMimeType = source.NotificationDataMimeType;
            target.NotificationDataFileName = source.NotificationDataFileName;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.CreatedOn = source.CreatedOn;
            target.UsesBusinessObjects = source.UsesBusinessObjects;
            target.UsesDataSources = source.UsesDataSources;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<NotificationConstructDatumDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.NotificationConstructDatum> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<NotificationConstructDatumDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.NotificationConstructDatum> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.NotificationConstructDatum> ToEntities(this IEnumerable<NotificationConstructDatumDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.NotificationConstructDatum source, NotificationConstructDatumDTO target);

        static partial void OnEntityCreating(NotificationConstructDatumDTO source, Bec.TargetFramework.Data.NotificationConstructDatum target);

    }

}
