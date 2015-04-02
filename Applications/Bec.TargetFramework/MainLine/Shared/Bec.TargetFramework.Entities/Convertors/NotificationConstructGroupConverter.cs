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

    public static partial class NotificationConstructGroupConverter
    {

        public static NotificationConstructGroupDTO ToDto(this Bec.TargetFramework.Data.NotificationConstructGroup source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static NotificationConstructGroupDTO ToDtoWithRelated(this Bec.TargetFramework.Data.NotificationConstructGroup source, int level)
        {
            if (source == null)
              return null;

            var target = new NotificationConstructGroupDTO();

            // Properties
            target.NotificationConstructGroupID = source.NotificationConstructGroupID;
            target.NotificationConstructGroupVersion = source.NotificationConstructGroupVersion;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ParentID = source.ParentID;
            target.NotificationConstructGroupTemplateID = source.NotificationConstructGroupTemplateID;
            target.NotificationConstructGroupTemplateVersion = source.NotificationConstructGroupTemplateVersion;
            target.NotificationConstructGroupTypeID = source.NotificationConstructGroupTypeID;
            target.NotificationConstructGroupCategoryID = source.NotificationConstructGroupCategoryID;

            // Navigation Properties
            if (level > 0) {
              target.NotificationConstructGroupTemplate = source.NotificationConstructGroupTemplate.ToDtoWithRelated(level - 1);
              target.NotificationConstructGroupNotificationConstructs = source.NotificationConstructGroupNotificationConstructs.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.NotificationConstructGroup ToEntity(this NotificationConstructGroupDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.NotificationConstructGroup();

            // Properties
            target.NotificationConstructGroupID = source.NotificationConstructGroupID;
            target.NotificationConstructGroupVersion = source.NotificationConstructGroupVersion;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ParentID = source.ParentID;
            target.NotificationConstructGroupTemplateID = source.NotificationConstructGroupTemplateID;
            target.NotificationConstructGroupTemplateVersion = source.NotificationConstructGroupTemplateVersion;
            target.NotificationConstructGroupTypeID = source.NotificationConstructGroupTypeID;
            target.NotificationConstructGroupCategoryID = source.NotificationConstructGroupCategoryID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<NotificationConstructGroupDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.NotificationConstructGroup> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<NotificationConstructGroupDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.NotificationConstructGroup> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.NotificationConstructGroup> ToEntities(this IEnumerable<NotificationConstructGroupDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.NotificationConstructGroup source, NotificationConstructGroupDTO target);

        static partial void OnEntityCreating(NotificationConstructGroupDTO source, Bec.TargetFramework.Data.NotificationConstructGroup target);

    }

}
