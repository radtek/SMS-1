﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class HelpPageItemRoleConverter
    {

        public static HelpPageItemRoleDTO ToDto(this Bec.TargetFramework.Data.HelpPageItemRole source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static HelpPageItemRoleDTO ToDtoWithRelated(this Bec.TargetFramework.Data.HelpPageItemRole source, int level)
        {
            if (source == null)
              return null;

            var target = new HelpPageItemRoleDTO();

            // Properties
            target.HelpPageItemRoleID = source.HelpPageItemRoleID;
            target.RoleID = source.RoleID;
            target.HelpPageItemID = source.HelpPageItemID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.HelpPageItem = source.HelpPageItem.ToDtoWithRelated(level - 1);
              target.Role = source.Role.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.HelpPageItemRole ToEntity(this HelpPageItemRoleDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.HelpPageItemRole();

            // Properties
            target.HelpPageItemRoleID = source.HelpPageItemRoleID;
            target.RoleID = source.RoleID;
            target.HelpPageItemID = source.HelpPageItemID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<HelpPageItemRoleDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.HelpPageItemRole> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<HelpPageItemRoleDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.HelpPageItemRole> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.HelpPageItemRole> ToEntities(this IEnumerable<HelpPageItemRoleDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.HelpPageItemRole source, HelpPageItemRoleDTO target);

        static partial void OnEntityCreating(HelpPageItemRoleDTO source, Bec.TargetFramework.Data.HelpPageItemRole target);

    }

}
