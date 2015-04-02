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

    public static partial class NotificationConstructGroupTemplateConverter
    {

        public static NotificationConstructGroupTemplateDTO ToDto(this Bec.TargetFramework.Data.NotificationConstructGroupTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static NotificationConstructGroupTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.NotificationConstructGroupTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new NotificationConstructGroupTemplateDTO();

            // Properties
            target.NotificationConstructGroupTemplateID = source.NotificationConstructGroupTemplateID;
            target.NotificationConstructGroupTemplateVersion = source.NotificationConstructGroupTemplateVersion;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ParentID = source.ParentID;
            target.NotificationConstructGroupTypeID = source.NotificationConstructGroupTypeID;
            target.NotificationConstructGroupCategoryID = source.NotificationConstructGroupCategoryID;

            // Navigation Properties
            if (level > 0) {
              target.NotificationConstructGroups = source.NotificationConstructGroups.ToDtosWithRelated(level - 1);
              target.NotificationConstructGroupNotificationConstructTemplates = source.NotificationConstructGroupNotificationConstructTemplates.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.NotificationConstructGroupTemplate ToEntity(this NotificationConstructGroupTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.NotificationConstructGroupTemplate();

            // Properties
            target.NotificationConstructGroupTemplateID = source.NotificationConstructGroupTemplateID;
            target.NotificationConstructGroupTemplateVersion = source.NotificationConstructGroupTemplateVersion;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ParentID = source.ParentID;
            target.NotificationConstructGroupTypeID = source.NotificationConstructGroupTypeID;
            target.NotificationConstructGroupCategoryID = source.NotificationConstructGroupCategoryID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<NotificationConstructGroupTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.NotificationConstructGroupTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<NotificationConstructGroupTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.NotificationConstructGroupTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.NotificationConstructGroupTemplate> ToEntities(this IEnumerable<NotificationConstructGroupTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.NotificationConstructGroupTemplate source, NotificationConstructGroupTemplateDTO target);

        static partial void OnEntityCreating(NotificationConstructGroupTemplateDTO source, Bec.TargetFramework.Data.NotificationConstructGroupTemplate target);

    }

}
