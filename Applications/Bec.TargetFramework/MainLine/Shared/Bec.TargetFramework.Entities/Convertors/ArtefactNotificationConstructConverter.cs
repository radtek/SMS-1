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

    public static partial class ArtefactNotificationConstructConverter
    {

        public static ArtefactNotificationConstructDTO ToDto(this Bec.TargetFramework.Data.ArtefactNotificationConstruct source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ArtefactNotificationConstructDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ArtefactNotificationConstruct source, int level)
        {
            if (source == null)
              return null;

            var target = new ArtefactNotificationConstructDTO();

            // Properties
            target.ArtefactID = source.ArtefactID;
            target.ArtefactVersionNumber = source.ArtefactVersionNumber;
            target.NotificationConstructID = source.NotificationConstructID;
            target.NotificationConstructVersionNumber = source.NotificationConstructVersionNumber;
            target.ArtefactNotificationConstructID = source.ArtefactNotificationConstructID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.Artefact = source.Artefact.ToDtoWithRelated(level - 1);
              target.NotificationConstruct = source.NotificationConstruct.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ArtefactNotificationConstruct ToEntity(this ArtefactNotificationConstructDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ArtefactNotificationConstruct();

            // Properties
            target.ArtefactID = source.ArtefactID;
            target.ArtefactVersionNumber = source.ArtefactVersionNumber;
            target.NotificationConstructID = source.NotificationConstructID;
            target.NotificationConstructVersionNumber = source.NotificationConstructVersionNumber;
            target.ArtefactNotificationConstructID = source.ArtefactNotificationConstructID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ArtefactNotificationConstructDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ArtefactNotificationConstruct> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ArtefactNotificationConstructDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ArtefactNotificationConstruct> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ArtefactNotificationConstruct> ToEntities(this IEnumerable<ArtefactNotificationConstructDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ArtefactNotificationConstruct source, ArtefactNotificationConstructDTO target);

        static partial void OnEntityCreating(ArtefactNotificationConstructDTO source, Bec.TargetFramework.Data.ArtefactNotificationConstruct target);

    }

}
