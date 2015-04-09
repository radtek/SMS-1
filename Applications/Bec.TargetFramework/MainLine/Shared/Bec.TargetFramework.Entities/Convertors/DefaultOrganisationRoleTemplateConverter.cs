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

    public static partial class DefaultOrganisationRoleTemplateConverter
    {

        public static DefaultOrganisationRoleTemplateDTO ToDto(this Bec.TargetFramework.Data.DefaultOrganisationRoleTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DefaultOrganisationRoleTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DefaultOrganisationRoleTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new DefaultOrganisationRoleTemplateDTO();

            // Properties
            target.DefaultOrganisationRoleTemplateID = source.DefaultOrganisationRoleTemplateID;
            target.DefaultOrganisationTemplateID = source.DefaultOrganisationTemplateID;
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
            target.DefaultOrganisationTemplateVersionNumber = source.DefaultOrganisationTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisationTemplate = source.DefaultOrganisationTemplate.ToDtoWithRelated(level - 1);
              target.Role = source.Role.ToDtoWithRelated(level - 1);
              target.DefaultOrganisationGroupRoleTemplates = source.DefaultOrganisationGroupRoleTemplates.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationRoleClaimTemplates = source.DefaultOrganisationRoleClaimTemplates.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationRoleTargetTemplates = source.DefaultOrganisationRoleTargetTemplates.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DefaultOrganisationRoleTemplate ToEntity(this DefaultOrganisationRoleTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DefaultOrganisationRoleTemplate();

            // Properties
            target.DefaultOrganisationRoleTemplateID = source.DefaultOrganisationRoleTemplateID;
            target.DefaultOrganisationTemplateID = source.DefaultOrganisationTemplateID;
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
            target.DefaultOrganisationTemplateVersionNumber = source.DefaultOrganisationTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DefaultOrganisationRoleTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationRoleTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DefaultOrganisationRoleTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationRoleTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DefaultOrganisationRoleTemplate> ToEntities(this IEnumerable<DefaultOrganisationRoleTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DefaultOrganisationRoleTemplate source, DefaultOrganisationRoleTemplateDTO target);

        static partial void OnEntityCreating(DefaultOrganisationRoleTemplateDTO source, Bec.TargetFramework.Data.DefaultOrganisationRoleTemplate target);

    }

}
