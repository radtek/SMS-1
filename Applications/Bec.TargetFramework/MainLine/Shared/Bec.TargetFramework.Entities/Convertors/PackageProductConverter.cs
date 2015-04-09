﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:50:53
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class PackageProductConverter
    {

        public static PackageProductDTO ToDto(this Bec.TargetFramework.Data.PackageProduct source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static PackageProductDTO ToDtoWithRelated(this Bec.TargetFramework.Data.PackageProduct source, int level)
        {
            if (source == null)
              return null;

            var target = new PackageProductDTO();

            // Properties
            target.PackageProductID = source.PackageProductID;
            target.PackageID = source.PackageID;
            target.UseProductDefaultBlueprint = source.UseProductDefaultBlueprint;
            target.UseDefaultProductPricing = source.UseDefaultProductPricing;
            target.IsFixedPrice = source.IsFixedPrice;
            target.ProductPriceModifierPercentage = source.ProductPriceModifierPercentage;
            target.ProductPriceModifierValue = source.ProductPriceModifierValue;
            target.DefaultQuantity = source.DefaultQuantity;
            target.UserDefinableQuantity = source.UserDefinableQuantity;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.PackageVersionNumber = source.PackageVersionNumber;
            target.RelatedProductProductAttributeID = source.RelatedProductProductAttributeID;

            // Navigation Properties
            if (level > 0) {
              target.PackageProductRelationships = source.PackageProductRelationships.ToDtosWithRelated(level - 1);
              target.PackageProductSpecificationBlueprints = source.PackageProductSpecificationBlueprints.ToDtosWithRelated(level - 1);
              target.ProductFamilyProductPackages = source.ProductFamilyProductPackages.ToDtosWithRelated(level - 1);
              target.Product = source.Product.ToDtoWithRelated(level - 1);
              target.Package = source.Package.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.PackageProduct ToEntity(this PackageProductDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.PackageProduct();

            // Properties
            target.PackageProductID = source.PackageProductID;
            target.PackageID = source.PackageID;
            target.UseProductDefaultBlueprint = source.UseProductDefaultBlueprint;
            target.UseDefaultProductPricing = source.UseDefaultProductPricing;
            target.IsFixedPrice = source.IsFixedPrice;
            target.ProductPriceModifierPercentage = source.ProductPriceModifierPercentage;
            target.ProductPriceModifierValue = source.ProductPriceModifierValue;
            target.DefaultQuantity = source.DefaultQuantity;
            target.UserDefinableQuantity = source.UserDefinableQuantity;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.PackageVersionNumber = source.PackageVersionNumber;
            target.RelatedProductProductAttributeID = source.RelatedProductProductAttributeID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<PackageProductDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.PackageProduct> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<PackageProductDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.PackageProduct> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.PackageProduct> ToEntities(this IEnumerable<PackageProductDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.PackageProduct source, PackageProductDTO target);

        static partial void OnEntityCreating(PackageProductDTO source, Bec.TargetFramework.Data.PackageProduct target);

    }

}
