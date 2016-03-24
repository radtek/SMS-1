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

    public static partial class VRoleHierarchyConverter
    {

        public static VRoleHierarchyDTO ToDto(this Bec.TargetFramework.Data.VRoleHierarchy source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VRoleHierarchyDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VRoleHierarchy source, int level)
        {
            if (source == null)
              return null;

            var target = new VRoleHierarchyDTO();

            // Properties
            target.RoleID = source.RoleID;
            target.RoleName = source.RoleName;
            target.Level = source.Level;
            target.ParentID = source.ParentID;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VRoleHierarchy ToEntity(this VRoleHierarchyDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VRoleHierarchy();

            // Properties
            target.RoleID = source.RoleID;
            target.RoleName = source.RoleName;
            target.Level = source.Level;
            target.ParentID = source.ParentID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VRoleHierarchyDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VRoleHierarchy> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VRoleHierarchyDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VRoleHierarchy> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VRoleHierarchy> ToEntities(this IEnumerable<VRoleHierarchyDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VRoleHierarchy source, VRoleHierarchyDTO target);

        static partial void OnEntityCreating(VRoleHierarchyDTO source, Bec.TargetFramework.Data.VRoleHierarchy target);

    }

}