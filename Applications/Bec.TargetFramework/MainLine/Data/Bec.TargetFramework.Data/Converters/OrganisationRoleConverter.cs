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

    public static partial class OrganisationRoleConverter
    {

        public static OrganisationRoleDTO ToDto(this Bec.TargetFramework.Data.OrganisationRole source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static OrganisationRoleDTO ToDtoWithRelated(this Bec.TargetFramework.Data.OrganisationRole source, int level)
        {
            if (source == null)
              return null;

            var target = new OrganisationRoleDTO();

            // Properties
            target.OrganisationRoleID = source.OrganisationRoleID;
            target.OrganisationID = source.OrganisationID;
            target.ParentOrganisationRoleID = source.ParentOrganisationRoleID;
            target.RoleName = source.RoleName;
            target.ParentRootRoleID = source.ParentRootRoleID;
            target.IsManaged = source.IsManaged;
            target.RoleTypeID = source.RoleTypeID;
            target.RoleSubTypeID = source.RoleSubTypeID;
            target.RoleCategoryID = source.RoleCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.RoleDescription = source.RoleDescription;
            target.RoleSubCategoryID = source.RoleSubCategoryID;
            target.ParentID = source.ParentID;
            target.IsDefault = source.IsDefault;

            // Navigation Properties
            if (level > 0) {
              target.OrganisationGroupRoles = source.OrganisationGroupRoles.ToDtosWithRelated(level - 1);
              target.OrganisationRoleClaims = source.OrganisationRoleClaims.ToDtosWithRelated(level - 1);
              target.UserAccountOrganisationRoles = source.UserAccountOrganisationRoles.ToDtosWithRelated(level - 1);
              target.OrganisationUnitOrganisationRoles = source.OrganisationUnitOrganisationRoles.ToDtosWithRelated(level - 1);
              target.AttachmentDetailRoles = source.AttachmentDetailRoles.ToDtosWithRelated(level - 1);
              target.RepositoryStructureRoles = source.RepositoryStructureRoles.ToDtosWithRelated(level - 1);
              target.Organisation = source.Organisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.OrganisationRole ToEntity(this OrganisationRoleDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.OrganisationRole();

            // Properties
            target.OrganisationRoleID = source.OrganisationRoleID;
            target.OrganisationID = source.OrganisationID;
            target.ParentOrganisationRoleID = source.ParentOrganisationRoleID;
            target.RoleName = source.RoleName;
            target.ParentRootRoleID = source.ParentRootRoleID;
            target.IsManaged = source.IsManaged;
            target.RoleTypeID = source.RoleTypeID;
            target.RoleSubTypeID = source.RoleSubTypeID;
            target.RoleCategoryID = source.RoleCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.RoleDescription = source.RoleDescription;
            target.RoleSubCategoryID = source.RoleSubCategoryID;
            target.ParentID = source.ParentID;
            target.IsDefault = source.IsDefault;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<OrganisationRoleDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.OrganisationRole> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<OrganisationRoleDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.OrganisationRole> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.OrganisationRole> ToEntities(this IEnumerable<OrganisationRoleDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.OrganisationRole source, OrganisationRoleDTO target);

        static partial void OnEntityCreating(OrganisationRoleDTO source, Bec.TargetFramework.Data.OrganisationRole target);

    }

}
