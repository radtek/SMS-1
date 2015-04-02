﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:53
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class ProductFamilyProductPackageConverter
    {

        public static ProductFamilyProductPackageDTO ToDto(this Bec.TargetFramework.Data.ProductFamilyProductPackage source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ProductFamilyProductPackageDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ProductFamilyProductPackage source, int level)
        {
            if (source == null)
              return null;

            var target = new ProductFamilyProductPackageDTO();

            // Properties
            target.ProductFamilyProductPackageID = source.ProductFamilyProductPackageID;
            target.ProductID = source.ProductID;
            target.ProductFamilyID = source.ProductFamilyID;
            target.PackageProductID = source.PackageProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.PackageID = source.PackageID;
            target.PackageVersionNumber = source.PackageVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.PackageProduct = source.PackageProduct.ToDtoWithRelated(level - 1);
              target.ProductFamily = source.ProductFamily.ToDtoWithRelated(level - 1);
              target.Product = source.Product.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ProductFamilyProductPackage ToEntity(this ProductFamilyProductPackageDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ProductFamilyProductPackage();

            // Properties
            target.ProductFamilyProductPackageID = source.ProductFamilyProductPackageID;
            target.ProductID = source.ProductID;
            target.ProductFamilyID = source.ProductFamilyID;
            target.PackageProductID = source.PackageProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.PackageID = source.PackageID;
            target.PackageVersionNumber = source.PackageVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ProductFamilyProductPackageDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ProductFamilyProductPackage> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ProductFamilyProductPackageDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ProductFamilyProductPackage> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ProductFamilyProductPackage> ToEntities(this IEnumerable<ProductFamilyProductPackageDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ProductFamilyProductPackage source, ProductFamilyProductPackageDTO target);

        static partial void OnEntityCreating(ProductFamilyProductPackageDTO source, Bec.TargetFramework.Data.ProductFamilyProductPackage target);

    }

}
