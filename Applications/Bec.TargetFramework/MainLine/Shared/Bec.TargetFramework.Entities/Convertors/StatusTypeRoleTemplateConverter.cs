﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 16:15:20
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class StatusTypeRoleTemplateConverter
    {

        public static StatusTypeRoleTemplateDTO ToDto(this Bec.TargetFramework.Data.StatusTypeRoleTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static StatusTypeRoleTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.StatusTypeRoleTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new StatusTypeRoleTemplateDTO();

            // Properties
            target.StatusTypeRoleTemplateID = source.StatusTypeRoleTemplateID;
            target.RoleName = source.RoleName;
            target.RoleDescription = source.RoleDescription;
            target.RoleTypeID = source.RoleTypeID;
            target.RoleSubTypeID = source.RoleSubTypeID;
            target.RoleCategoryID = source.RoleCategoryID;
            target.RoleSubCategoryID = source.RoleSubCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.StatusTypeTemplateID = source.StatusTypeTemplateID;
            target.StatusTypeTemplateVersionNumber = source.StatusTypeTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.StatusTypeTemplate = source.StatusTypeTemplate.ToDtoWithRelated(level - 1);
              target.StatusTypeClaimTemplates = source.StatusTypeClaimTemplates.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.StatusTypeRoleTemplate ToEntity(this StatusTypeRoleTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.StatusTypeRoleTemplate();

            // Properties
            target.StatusTypeRoleTemplateID = source.StatusTypeRoleTemplateID;
            target.RoleName = source.RoleName;
            target.RoleDescription = source.RoleDescription;
            target.RoleTypeID = source.RoleTypeID;
            target.RoleSubTypeID = source.RoleSubTypeID;
            target.RoleCategoryID = source.RoleCategoryID;
            target.RoleSubCategoryID = source.RoleSubCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.StatusTypeTemplateID = source.StatusTypeTemplateID;
            target.StatusTypeTemplateVersionNumber = source.StatusTypeTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<StatusTypeRoleTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.StatusTypeRoleTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<StatusTypeRoleTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.StatusTypeRoleTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.StatusTypeRoleTemplate> ToEntities(this IEnumerable<StatusTypeRoleTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.StatusTypeRoleTemplate source, StatusTypeRoleTemplateDTO target);

        static partial void OnEntityCreating(StatusTypeRoleTemplateDTO source, Bec.TargetFramework.Data.StatusTypeRoleTemplate target);

    }

}
