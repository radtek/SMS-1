﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:20 AM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class NotificationConstructRoleConverter
    {

        public static NotificationConstructRoleDTO ToDto(this Bec.TargetFramework.Data.NotificationConstructRole source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static NotificationConstructRoleDTO ToDtoWithRelated(this Bec.TargetFramework.Data.NotificationConstructRole source, int level)
        {
            if (source == null)
              return null;

            var target = new NotificationConstructRoleDTO();

            // Properties
            target.NotificationRoleConstructID = source.NotificationRoleConstructID;
            target.NotificationConstructID = source.NotificationConstructID;
            target.NotificationConstructVersionNumber = source.NotificationConstructVersionNumber;
            target.RoleName = source.RoleName;
            target.RoleDescription = source.RoleDescription;
            target.RoleSubTypeID = source.RoleSubTypeID;
            target.RoleCategoryID = source.RoleCategoryID;
            target.RoleSubCategoryID = source.RoleSubCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.RoleTypeID = source.RoleTypeID;

            // Navigation Properties
            if (level > 0) {
              target.NotificationConstructClaims = source.NotificationConstructClaims.ToDtosWithRelated(level - 1);
              target.NotificationConstruct = source.NotificationConstruct.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.NotificationConstructRole ToEntity(this NotificationConstructRoleDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.NotificationConstructRole();

            // Properties
            target.NotificationRoleConstructID = source.NotificationRoleConstructID;
            target.NotificationConstructID = source.NotificationConstructID;
            target.NotificationConstructVersionNumber = source.NotificationConstructVersionNumber;
            target.RoleName = source.RoleName;
            target.RoleDescription = source.RoleDescription;
            target.RoleSubTypeID = source.RoleSubTypeID;
            target.RoleCategoryID = source.RoleCategoryID;
            target.RoleSubCategoryID = source.RoleSubCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.RoleTypeID = source.RoleTypeID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<NotificationConstructRoleDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.NotificationConstructRole> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<NotificationConstructRoleDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.NotificationConstructRole> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.NotificationConstructRole> ToEntities(this IEnumerable<NotificationConstructRoleDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.NotificationConstructRole source, NotificationConstructRoleDTO target);

        static partial void OnEntityCreating(NotificationConstructRoleDTO source, Bec.TargetFramework.Data.NotificationConstructRole target);

    }

}
