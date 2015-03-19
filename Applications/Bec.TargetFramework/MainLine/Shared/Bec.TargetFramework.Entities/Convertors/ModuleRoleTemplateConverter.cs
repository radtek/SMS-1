﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 18/03/2015 19:00:46
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class ModuleRoleTemplateConverter
    {

        public static ModuleRoleTemplateDTO ToDto(this Bec.TargetFramework.Data.ModuleRoleTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ModuleRoleTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ModuleRoleTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new ModuleRoleTemplateDTO();

            // Properties
            target.RoleID = source.RoleID;
            target.RoleName = source.RoleName;
            target.RoleDescription = source.RoleDescription;
            target.RoleTypeID = source.RoleTypeID;
            target.RoleSubTypeID = source.RoleSubTypeID;
            target.RoleCategoryID = source.RoleCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ModuleTemplateID = source.ModuleTemplateID;
            target.ModuleTemplateVersionNumber = source.ModuleTemplateVersionNumber;
            target.RoleSubCategoryID = source.RoleSubCategoryID;

            // Navigation Properties
            if (level > 0) {
              target.ModuleClaimTemplates = source.ModuleClaimTemplates.ToDtosWithRelated(level - 1);
              target.ModuleTemplate = source.ModuleTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ModuleRoleTemplate ToEntity(this ModuleRoleTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ModuleRoleTemplate();

            // Properties
            target.RoleID = source.RoleID;
            target.RoleName = source.RoleName;
            target.RoleDescription = source.RoleDescription;
            target.RoleTypeID = source.RoleTypeID;
            target.RoleSubTypeID = source.RoleSubTypeID;
            target.RoleCategoryID = source.RoleCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ModuleTemplateID = source.ModuleTemplateID;
            target.ModuleTemplateVersionNumber = source.ModuleTemplateVersionNumber;
            target.RoleSubCategoryID = source.RoleSubCategoryID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ModuleRoleTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ModuleRoleTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ModuleRoleTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ModuleRoleTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ModuleRoleTemplate> ToEntities(this IEnumerable<ModuleRoleTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ModuleRoleTemplate source, ModuleRoleTemplateDTO target);

        static partial void OnEntityCreating(ModuleRoleTemplateDTO source, Bec.TargetFramework.Data.ModuleRoleTemplate target);

    }

}
