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

    public static partial class ProductSpecificationBlueprintConverter
    {

        public static ProductSpecificationBlueprintDTO ToDto(this Bec.TargetFramework.Data.ProductSpecificationBlueprint source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ProductSpecificationBlueprintDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ProductSpecificationBlueprint source, int level)
        {
            if (source == null)
              return null;

            var target = new ProductSpecificationBlueprintDTO();

            // Properties
            target.ProductSpecificationBlueprintID = source.ProductSpecificationBlueprintID;
            target.ProductID = source.ProductID;
            target.ProductSpecificationAttributeID = source.ProductSpecificationAttributeID;
            target.DefaultProductSpecificationAttributeOptionID = source.DefaultProductSpecificationAttributeOptionID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ProductVersionID = source.ProductVersionID;

            // Navigation Properties
            if (level > 0) {
              target.ProductSpecificationAttribute = source.ProductSpecificationAttribute.ToDtoWithRelated(level - 1);
              target.ProductSpecificationAttributeOption = source.ProductSpecificationAttributeOption.ToDtoWithRelated(level - 1);
              target.Product = source.Product.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ProductSpecificationBlueprint ToEntity(this ProductSpecificationBlueprintDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ProductSpecificationBlueprint();

            // Properties
            target.ProductSpecificationBlueprintID = source.ProductSpecificationBlueprintID;
            target.ProductID = source.ProductID;
            target.ProductSpecificationAttributeID = source.ProductSpecificationAttributeID;
            target.DefaultProductSpecificationAttributeOptionID = source.DefaultProductSpecificationAttributeOptionID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ProductVersionID = source.ProductVersionID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ProductSpecificationBlueprintDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ProductSpecificationBlueprint> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ProductSpecificationBlueprintDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ProductSpecificationBlueprint> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ProductSpecificationBlueprint> ToEntities(this IEnumerable<ProductSpecificationBlueprintDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ProductSpecificationBlueprint source, ProductSpecificationBlueprintDTO target);

        static partial void OnEntityCreating(ProductSpecificationBlueprintDTO source, Bec.TargetFramework.Data.ProductSpecificationBlueprint target);

    }

}