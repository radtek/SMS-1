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

    public static partial class ProductRoleTemplateConverter
    {

        public static ProductRoleTemplateDTO ToDto(this Bec.TargetFramework.Data.ProductRoleTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ProductRoleTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ProductRoleTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new ProductRoleTemplateDTO();

            // Properties
            target.ProductRoleTemplateID = source.ProductRoleTemplateID;
            target.RoleName = source.RoleName;
            target.RoleDescription = source.RoleDescription;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.RoleTypeID = source.RoleTypeID;
            target.RoleSubTypeID = source.RoleSubTypeID;
            target.RoleCategoryID = source.RoleCategoryID;
            target.RoleSubCategoryID = source.RoleSubCategoryID;
            target.ProductTemplateID = source.ProductTemplateID;
            target.ProductVersionID = source.ProductVersionID;

            // Navigation Properties
            if (level > 0) {
              target.ProductClaimTemplates = source.ProductClaimTemplates.ToDtosWithRelated(level - 1);
              target.ProductTemplate = source.ProductTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ProductRoleTemplate ToEntity(this ProductRoleTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ProductRoleTemplate();

            // Properties
            target.ProductRoleTemplateID = source.ProductRoleTemplateID;
            target.RoleName = source.RoleName;
            target.RoleDescription = source.RoleDescription;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.RoleTypeID = source.RoleTypeID;
            target.RoleSubTypeID = source.RoleSubTypeID;
            target.RoleCategoryID = source.RoleCategoryID;
            target.RoleSubCategoryID = source.RoleSubCategoryID;
            target.ProductTemplateID = source.ProductTemplateID;
            target.ProductVersionID = source.ProductVersionID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ProductRoleTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ProductRoleTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ProductRoleTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ProductRoleTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ProductRoleTemplate> ToEntities(this IEnumerable<ProductRoleTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ProductRoleTemplate source, ProductRoleTemplateDTO target);

        static partial void OnEntityCreating(ProductRoleTemplateDTO source, Bec.TargetFramework.Data.ProductRoleTemplate target);

    }

}
