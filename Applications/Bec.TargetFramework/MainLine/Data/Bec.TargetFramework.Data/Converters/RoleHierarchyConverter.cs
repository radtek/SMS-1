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

    public static partial class RoleHierarchyConverter
    {

        public static RoleHierarchyDTO ToDto(this Bec.TargetFramework.Data.RoleHierarchy source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static RoleHierarchyDTO ToDtoWithRelated(this Bec.TargetFramework.Data.RoleHierarchy source, int level)
        {
            if (source == null)
              return null;

            var target = new RoleHierarchyDTO();

            // Properties
            target.RoleHierarchyID = source.RoleHierarchyID;
            target.RoleID = source.RoleID;
            target.ParentRoleID = source.ParentRoleID;
            target.Level = source.Level;

            // Navigation Properties
            if (level > 0) {
              target.Role_ParentRoleID = source.Role_ParentRoleID.ToDtoWithRelated(level - 1);
              target.Role_RoleID = source.Role_RoleID.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.RoleHierarchy ToEntity(this RoleHierarchyDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.RoleHierarchy();

            // Properties
            target.RoleHierarchyID = source.RoleHierarchyID;
            target.RoleID = source.RoleID;
            target.ParentRoleID = source.ParentRoleID;
            target.Level = source.Level;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<RoleHierarchyDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.RoleHierarchy> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<RoleHierarchyDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.RoleHierarchy> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.RoleHierarchy> ToEntities(this IEnumerable<RoleHierarchyDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.RoleHierarchy source, RoleHierarchyDTO target);

        static partial void OnEntityCreating(RoleHierarchyDTO source, Bec.TargetFramework.Data.RoleHierarchy target);

    }

}
