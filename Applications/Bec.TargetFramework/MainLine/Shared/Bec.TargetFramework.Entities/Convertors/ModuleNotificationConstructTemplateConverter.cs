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

    public static partial class ModuleNotificationConstructTemplateConverter
    {

        public static ModuleNotificationConstructTemplateDTO ToDto(this Bec.TargetFramework.Data.ModuleNotificationConstructTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ModuleNotificationConstructTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ModuleNotificationConstructTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new ModuleNotificationConstructTemplateDTO();

            // Properties
            target.ModuleNotificationConstructTemplateID = source.ModuleNotificationConstructTemplateID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.NotificationConstructTemplateID = source.NotificationConstructTemplateID;
            target.NotificationConstructTemplateVersionNumber = source.NotificationConstructTemplateVersionNumber;
            target.ModuleTemplateID = source.ModuleTemplateID;
            target.ModuleTemplateVersionNumber = source.ModuleTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.ModuleTemplate = source.ModuleTemplate.ToDtoWithRelated(level - 1);
              target.NotificationConstructTemplate = source.NotificationConstructTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ModuleNotificationConstructTemplate ToEntity(this ModuleNotificationConstructTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ModuleNotificationConstructTemplate();

            // Properties
            target.ModuleNotificationConstructTemplateID = source.ModuleNotificationConstructTemplateID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.NotificationConstructTemplateID = source.NotificationConstructTemplateID;
            target.NotificationConstructTemplateVersionNumber = source.NotificationConstructTemplateVersionNumber;
            target.ModuleTemplateID = source.ModuleTemplateID;
            target.ModuleTemplateVersionNumber = source.ModuleTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ModuleNotificationConstructTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ModuleNotificationConstructTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ModuleNotificationConstructTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ModuleNotificationConstructTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ModuleNotificationConstructTemplate> ToEntities(this IEnumerable<ModuleNotificationConstructTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ModuleNotificationConstructTemplate source, ModuleNotificationConstructTemplateDTO target);

        static partial void OnEntityCreating(ModuleNotificationConstructTemplateDTO source, Bec.TargetFramework.Data.ModuleNotificationConstructTemplate target);

    }

}
