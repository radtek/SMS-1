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

    public static partial class ArtefactRoleTemplateConverter
    {

        public static ArtefactRoleTemplateDTO ToDto(this Bec.TargetFramework.Data.ArtefactRoleTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ArtefactRoleTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ArtefactRoleTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new ArtefactRoleTemplateDTO();

            // Properties
            target.ArtefactRoleTemplateID = source.ArtefactRoleTemplateID;
            target.ArtefactTemplateID = source.ArtefactTemplateID;
            target.ArtefactTemplateVersionNumber = source.ArtefactTemplateVersionNumber;
            target.RoleName = source.RoleName;
            target.RoleDescription = source.RoleDescription;
            target.RoleTypeID = source.RoleTypeID;
            target.RoleSubTypeID = source.RoleSubTypeID;
            target.RoleCategoryID = source.RoleCategoryID;
            target.RoleSubCategoryID = source.RoleSubCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.ArtefactClaimTemplates = source.ArtefactClaimTemplates.ToDtosWithRelated(level - 1);
              target.ArtefactTemplate = source.ArtefactTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ArtefactRoleTemplate ToEntity(this ArtefactRoleTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ArtefactRoleTemplate();

            // Properties
            target.ArtefactRoleTemplateID = source.ArtefactRoleTemplateID;
            target.ArtefactTemplateID = source.ArtefactTemplateID;
            target.ArtefactTemplateVersionNumber = source.ArtefactTemplateVersionNumber;
            target.RoleName = source.RoleName;
            target.RoleDescription = source.RoleDescription;
            target.RoleTypeID = source.RoleTypeID;
            target.RoleSubTypeID = source.RoleSubTypeID;
            target.RoleCategoryID = source.RoleCategoryID;
            target.RoleSubCategoryID = source.RoleSubCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ArtefactRoleTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ArtefactRoleTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ArtefactRoleTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ArtefactRoleTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ArtefactRoleTemplate> ToEntities(this IEnumerable<ArtefactRoleTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ArtefactRoleTemplate source, ArtefactRoleTemplateDTO target);

        static partial void OnEntityCreating(ArtefactRoleTemplateDTO source, Bec.TargetFramework.Data.ArtefactRoleTemplate target);

    }

}
