﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:58
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class GroupRoleConverter
    {

        public static GroupRoleDTO ToDto(this Bec.TargetFramework.Data.GroupRole source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static GroupRoleDTO ToDtoWithRelated(this Bec.TargetFramework.Data.GroupRole source, int level)
        {
            if (source == null)
              return null;

            var target = new GroupRoleDTO();

            // Properties
            target.GroupID = source.GroupID;
            target.RoleID = source.RoleID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsGlobal = source.IsGlobal;

            // Navigation Properties
            if (level > 0) {
              target.Group = source.Group.ToDtoWithRelated(level - 1);
              target.Role = source.Role.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.GroupRole ToEntity(this GroupRoleDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.GroupRole();

            // Properties
            target.GroupID = source.GroupID;
            target.RoleID = source.RoleID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsGlobal = source.IsGlobal;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<GroupRoleDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.GroupRole> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<GroupRoleDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.GroupRole> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.GroupRole> ToEntities(this IEnumerable<GroupRoleDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.GroupRole source, GroupRoleDTO target);

        static partial void OnEntityCreating(GroupRoleDTO source, Bec.TargetFramework.Data.GroupRole target);

    }

}
