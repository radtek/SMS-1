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

    public static partial class ProductAttributeConverter
    {

        public static ProductAttributeDTO ToDto(this Bec.TargetFramework.Data.ProductAttribute source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ProductAttributeDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ProductAttribute source, int level)
        {
            if (source == null)
              return null;

            var target = new ProductAttributeDTO();

            // Properties
            target.ProductAttributeID = source.ProductAttributeID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.ProductProductAttributes = source.ProductProductAttributes.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ProductAttribute ToEntity(this ProductAttributeDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ProductAttribute();

            // Properties
            target.ProductAttributeID = source.ProductAttributeID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ProductAttributeDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ProductAttribute> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ProductAttributeDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ProductAttribute> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ProductAttribute> ToEntities(this IEnumerable<ProductAttributeDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ProductAttribute source, ProductAttributeDTO target);

        static partial void OnEntityCreating(ProductAttributeDTO source, Bec.TargetFramework.Data.ProductAttribute target);

    }

}
