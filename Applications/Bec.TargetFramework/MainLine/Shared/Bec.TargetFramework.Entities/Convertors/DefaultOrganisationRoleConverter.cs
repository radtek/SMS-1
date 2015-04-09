﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:58
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class DefaultOrganisationRoleConverter
    {

        public static DefaultOrganisationRoleDTO ToDto(this Bec.TargetFramework.Data.DefaultOrganisationRole source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DefaultOrganisationRoleDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DefaultOrganisationRole source, int level)
        {
            if (source == null)
              return null;

            var target = new DefaultOrganisationRoleDTO();

            // Properties
            target.DefaultOrganisationRoleID = source.DefaultOrganisationRoleID;
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.RoleName = source.RoleName;
            target.RoleDescription = source.RoleDescription;
            target.RoleTypeID = source.RoleTypeID;
            target.RoleSubTypeID = source.RoleSubTypeID;
            target.RoleCategoryID = source.RoleCategoryID;
            target.RoleSubCategoryID = source.RoleSubCategoryID;
            target.ParentID = source.ParentID;
            target.RoleID = source.RoleID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsDefaultOrganisationSpecific = source.IsDefaultOrganisationSpecific;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisationRoleClaims = source.DefaultOrganisationRoleClaims.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationRoleTargets = source.DefaultOrganisationRoleTargets.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationGroupRoles = source.DefaultOrganisationGroupRoles.ToDtosWithRelated(level - 1);
              target.DefaultOrganisation = source.DefaultOrganisation.ToDtoWithRelated(level - 1);
              target.Role = source.Role.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DefaultOrganisationRole ToEntity(this DefaultOrganisationRoleDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DefaultOrganisationRole();

            // Properties
            target.DefaultOrganisationRoleID = source.DefaultOrganisationRoleID;
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.RoleName = source.RoleName;
            target.RoleDescription = source.RoleDescription;
            target.RoleTypeID = source.RoleTypeID;
            target.RoleSubTypeID = source.RoleSubTypeID;
            target.RoleCategoryID = source.RoleCategoryID;
            target.RoleSubCategoryID = source.RoleSubCategoryID;
            target.ParentID = source.ParentID;
            target.RoleID = source.RoleID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsDefaultOrganisationSpecific = source.IsDefaultOrganisationSpecific;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DefaultOrganisationRoleDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationRole> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DefaultOrganisationRoleDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationRole> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DefaultOrganisationRole> ToEntities(this IEnumerable<DefaultOrganisationRoleDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DefaultOrganisationRole source, DefaultOrganisationRoleDTO target);

        static partial void OnEntityCreating(DefaultOrganisationRoleDTO source, Bec.TargetFramework.Data.DefaultOrganisationRole target);

    }

}
