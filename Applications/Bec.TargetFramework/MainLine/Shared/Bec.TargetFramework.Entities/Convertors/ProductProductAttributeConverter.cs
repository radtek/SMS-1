﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:20 AM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class ProductProductAttributeConverter
    {

        public static ProductProductAttributeDTO ToDto(this Bec.TargetFramework.Data.ProductProductAttribute source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ProductProductAttributeDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ProductProductAttribute source, int level)
        {
            if (source == null)
              return null;

            var target = new ProductProductAttributeDTO();

            // Properties
            target.ProductProductAttributeID = source.ProductProductAttributeID;
            target.ProductID = source.ProductID;
            target.ProductAttributeID = source.ProductAttributeID;
            target.IsRequired = source.IsRequired;
            target.DisplayOrder = source.DisplayOrder;
            target.ProductVersionID = source.ProductVersionID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.ProductVariantAttributeValues = source.ProductVariantAttributeValues.ToDtosWithRelated(level - 1);
              target.ProductAttribute = source.ProductAttribute.ToDtoWithRelated(level - 1);
              target.Product = source.Product.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ProductProductAttribute ToEntity(this ProductProductAttributeDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ProductProductAttribute();

            // Properties
            target.ProductProductAttributeID = source.ProductProductAttributeID;
            target.ProductID = source.ProductID;
            target.ProductAttributeID = source.ProductAttributeID;
            target.IsRequired = source.IsRequired;
            target.DisplayOrder = source.DisplayOrder;
            target.ProductVersionID = source.ProductVersionID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ProductProductAttributeDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ProductProductAttribute> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ProductProductAttributeDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ProductProductAttribute> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ProductProductAttribute> ToEntities(this IEnumerable<ProductProductAttributeDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ProductProductAttribute source, ProductProductAttributeDTO target);

        static partial void OnEntityCreating(ProductProductAttributeDTO source, Bec.TargetFramework.Data.ProductProductAttribute target);

    }

}
