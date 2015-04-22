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

    public static partial class ProductRoleConverter
    {

        public static ProductRoleDTO ToDto(this Bec.TargetFramework.Data.ProductRole source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ProductRoleDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ProductRole source, int level)
        {
            if (source == null)
              return null;

            var target = new ProductRoleDTO();

            // Properties
            target.ProductRoleID = source.ProductRoleID;
            target.RoleName = source.RoleName;
            target.RoleDescription = source.RoleDescription;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.RoleTypeID = source.RoleTypeID;
            target.RoleSubTypeID = source.RoleSubTypeID;
            target.RoleCategoryID = source.RoleCategoryID;
            target.RoleSubCategoryID = source.RoleSubCategoryID;
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;

            // Navigation Properties
            if (level > 0) {
              target.ProductClaims = source.ProductClaims.ToDtosWithRelated(level - 1);
              target.Product = source.Product.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ProductRole ToEntity(this ProductRoleDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ProductRole();

            // Properties
            target.ProductRoleID = source.ProductRoleID;
            target.RoleName = source.RoleName;
            target.RoleDescription = source.RoleDescription;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.RoleTypeID = source.RoleTypeID;
            target.RoleSubTypeID = source.RoleSubTypeID;
            target.RoleCategoryID = source.RoleCategoryID;
            target.RoleSubCategoryID = source.RoleSubCategoryID;
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ProductRoleDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ProductRole> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ProductRoleDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ProductRole> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ProductRole> ToEntities(this IEnumerable<ProductRoleDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ProductRole source, ProductRoleDTO target);

        static partial void OnEntityCreating(ProductRoleDTO source, Bec.TargetFramework.Data.ProductRole target);

    }

}
