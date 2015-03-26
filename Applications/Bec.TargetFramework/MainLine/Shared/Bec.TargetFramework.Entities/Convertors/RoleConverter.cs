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

    public static partial class RoleConverter
    {

        public static RoleDTO ToDto(this Bec.TargetFramework.Data.Role source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static RoleDTO ToDtoWithRelated(this Bec.TargetFramework.Data.Role source, int level)
        {
            if (source == null)
              return null;

            var target = new RoleDTO();

            // Properties
            target.RoleID = source.RoleID;
            target.RoleName = source.RoleName;
            target.RoleDescription = source.RoleDescription;
            target.RoleTypeID = source.RoleTypeID;
            target.RoleSubTypeID = source.RoleSubTypeID;
            target.RoleCategoryID = source.RoleCategoryID;
            target.RoleSubCategoryID = source.RoleSubCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsGlobal = source.IsGlobal;

            // Navigation Properties
            if (level > 0) {
              target.ModuleClaims = source.ModuleClaims.ToDtosWithRelated(level - 1);
              target.InterfacePanelClaimTemplates = source.InterfacePanelClaimTemplates.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationRoleTemplates = source.DefaultOrganisationRoleTemplates.ToDtosWithRelated(level - 1);
              target.InterfacePanelClaims = source.InterfacePanelClaims.ToDtosWithRelated(level - 1);
              target.WorkflowClaimTemplates = source.WorkflowClaimTemplates.ToDtosWithRelated(level - 1);
              target.ProductClaims = source.ProductClaims.ToDtosWithRelated(level - 1);
              target.ProductClaimTemplates = source.ProductClaimTemplates.ToDtosWithRelated(level - 1);
              target.StatusTypeClaimTemplates = source.StatusTypeClaimTemplates.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationRoles = source.DefaultOrganisationRoles.ToDtosWithRelated(level - 1);
              target.ModuleClaimTemplates = source.ModuleClaimTemplates.ToDtosWithRelated(level - 1);
              target.NotificationConstructClaims = source.NotificationConstructClaims.ToDtosWithRelated(level - 1);
              target.NotificationConstructClaimTemplates = source.NotificationConstructClaimTemplates.ToDtosWithRelated(level - 1);
              target.ArtefactClaimTemplates = source.ArtefactClaimTemplates.ToDtosWithRelated(level - 1);
              target.ArtefactClaims = source.ArtefactClaims.ToDtosWithRelated(level - 1);
              target.GroupRoles = source.GroupRoles.ToDtosWithRelated(level - 1);
              target.RoleClaims = source.RoleClaims.ToDtosWithRelated(level - 1);
              target.WorkflowClaims = source.WorkflowClaims.ToDtosWithRelated(level - 1);
              target.ActorClaimRoleMappings = source.ActorClaimRoleMappings.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.Role ToEntity(this RoleDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.Role();

            // Properties
            target.RoleID = source.RoleID;
            target.RoleName = source.RoleName;
            target.RoleDescription = source.RoleDescription;
            target.RoleTypeID = source.RoleTypeID;
            target.RoleSubTypeID = source.RoleSubTypeID;
            target.RoleCategoryID = source.RoleCategoryID;
            target.RoleSubCategoryID = source.RoleSubCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsGlobal = source.IsGlobal;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<RoleDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.Role> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<RoleDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.Role> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.Role> ToEntities(this IEnumerable<RoleDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.Role source, RoleDTO target);

        static partial void OnEntityCreating(RoleDTO source, Bec.TargetFramework.Data.Role target);

    }

}
