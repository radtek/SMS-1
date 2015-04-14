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

    public static partial class ArtefactNotificationConstructTemplateConverter
    {

        public static ArtefactNotificationConstructTemplateDTO ToDto(this Bec.TargetFramework.Data.ArtefactNotificationConstructTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ArtefactNotificationConstructTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ArtefactNotificationConstructTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new ArtefactNotificationConstructTemplateDTO();

            // Properties
            target.ArtefactTemplateID = source.ArtefactTemplateID;
            target.ArtefactTemplateVersionNumber = source.ArtefactTemplateVersionNumber;
            target.NotificationConstructTemplateID = source.NotificationConstructTemplateID;
            target.NotificationConstructTemplateVersionNumber = source.NotificationConstructTemplateVersionNumber;
            target.ArtefactNotificationConstructTemplateID = source.ArtefactNotificationConstructTemplateID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.ArtefactTemplate = source.ArtefactTemplate.ToDtoWithRelated(level - 1);
              target.NotificationConstructTemplate = source.NotificationConstructTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ArtefactNotificationConstructTemplate ToEntity(this ArtefactNotificationConstructTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ArtefactNotificationConstructTemplate();

            // Properties
            target.ArtefactTemplateID = source.ArtefactTemplateID;
            target.ArtefactTemplateVersionNumber = source.ArtefactTemplateVersionNumber;
            target.NotificationConstructTemplateID = source.NotificationConstructTemplateID;
            target.NotificationConstructTemplateVersionNumber = source.NotificationConstructTemplateVersionNumber;
            target.ArtefactNotificationConstructTemplateID = source.ArtefactNotificationConstructTemplateID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ArtefactNotificationConstructTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ArtefactNotificationConstructTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ArtefactNotificationConstructTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ArtefactNotificationConstructTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ArtefactNotificationConstructTemplate> ToEntities(this IEnumerable<ArtefactNotificationConstructTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ArtefactNotificationConstructTemplate source, ArtefactNotificationConstructTemplateDTO target);

        static partial void OnEntityCreating(ArtefactNotificationConstructTemplateDTO source, Bec.TargetFramework.Data.ArtefactNotificationConstructTemplate target);

    }

}
