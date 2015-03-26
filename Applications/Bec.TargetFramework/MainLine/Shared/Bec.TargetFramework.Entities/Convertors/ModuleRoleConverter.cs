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

    public static partial class ModuleRoleConverter
    {

        public static ModuleRoleDTO ToDto(this Bec.TargetFramework.Data.ModuleRole source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ModuleRoleDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ModuleRole source, int level)
        {
            if (source == null)
              return null;

            var target = new ModuleRoleDTO();

            // Properties
            target.RoleID = source.RoleID;
            target.ModuleID = source.ModuleID;
            target.RoleName = source.RoleName;
            target.RoleDescription = source.RoleDescription;
            target.RoleTypeID = source.RoleTypeID;
            target.RoleSubTypeID = source.RoleSubTypeID;
            target.RoleCategoryID = source.RoleCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ModuleVersionNumber = source.ModuleVersionNumber;
            target.RoleSubCategoryID = source.RoleSubCategoryID;

            // Navigation Properties
            if (level > 0) {
              target.ModuleClaims = source.ModuleClaims.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ModuleRole ToEntity(this ModuleRoleDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ModuleRole();

            // Properties
            target.RoleID = source.RoleID;
            target.ModuleID = source.ModuleID;
            target.RoleName = source.RoleName;
            target.RoleDescription = source.RoleDescription;
            target.RoleTypeID = source.RoleTypeID;
            target.RoleSubTypeID = source.RoleSubTypeID;
            target.RoleCategoryID = source.RoleCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ModuleVersionNumber = source.ModuleVersionNumber;
            target.RoleSubCategoryID = source.RoleSubCategoryID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ModuleRoleDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ModuleRole> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ModuleRoleDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ModuleRole> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ModuleRole> ToEntities(this IEnumerable<ModuleRoleDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ModuleRole source, ModuleRoleDTO target);

        static partial void OnEntityCreating(ModuleRoleDTO source, Bec.TargetFramework.Data.ModuleRole target);

    }

}
