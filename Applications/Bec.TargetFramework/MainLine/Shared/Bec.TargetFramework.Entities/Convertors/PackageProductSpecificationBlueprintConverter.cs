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

    public static partial class PackageProductSpecificationBlueprintConverter
    {

        public static PackageProductSpecificationBlueprintDTO ToDto(this Bec.TargetFramework.Data.PackageProductSpecificationBlueprint source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static PackageProductSpecificationBlueprintDTO ToDtoWithRelated(this Bec.TargetFramework.Data.PackageProductSpecificationBlueprint source, int level)
        {
            if (source == null)
              return null;

            var target = new PackageProductSpecificationBlueprintDTO();

            // Properties
            target.PackageProductSpecificationBlueprintID = source.PackageProductSpecificationBlueprintID;
            target.PackageProductID = source.PackageProductID;
            target.ProductSpecificationAttributeID = source.ProductSpecificationAttributeID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.DefaultProductSpecificationAttributeOptionID = source.DefaultProductSpecificationAttributeOptionID;
            target.PackageID = source.PackageID;
            target.PackageVersionNumber = source.PackageVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.ProductSpecificationAttributeOption = source.ProductSpecificationAttributeOption.ToDtoWithRelated(level - 1);
              target.ProductSpecificationAttribute = source.ProductSpecificationAttribute.ToDtoWithRelated(level - 1);
              target.PackageProduct = source.PackageProduct.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.PackageProductSpecificationBlueprint ToEntity(this PackageProductSpecificationBlueprintDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.PackageProductSpecificationBlueprint();

            // Properties
            target.PackageProductSpecificationBlueprintID = source.PackageProductSpecificationBlueprintID;
            target.PackageProductID = source.PackageProductID;
            target.ProductSpecificationAttributeID = source.ProductSpecificationAttributeID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.DefaultProductSpecificationAttributeOptionID = source.DefaultProductSpecificationAttributeOptionID;
            target.PackageID = source.PackageID;
            target.PackageVersionNumber = source.PackageVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<PackageProductSpecificationBlueprintDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.PackageProductSpecificationBlueprint> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<PackageProductSpecificationBlueprintDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.PackageProductSpecificationBlueprint> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.PackageProductSpecificationBlueprint> ToEntities(this IEnumerable<PackageProductSpecificationBlueprintDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.PackageProductSpecificationBlueprint source, PackageProductSpecificationBlueprintDTO target);

        static partial void OnEntityCreating(PackageProductSpecificationBlueprintDTO source, Bec.TargetFramework.Data.PackageProductSpecificationBlueprint target);

    }

}
