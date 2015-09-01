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

    public static partial class ProductTagConverter
    {

        public static ProductTagDTO ToDto(this Bec.TargetFramework.Data.ProductTag source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ProductTagDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ProductTag source, int level)
        {
            if (source == null)
              return null;

            var target = new ProductTagDTO();

            // Properties
            target.ProductTagID = source.ProductTagID;
            target.Name = source.Name;
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;

            // Navigation Properties
            if (level > 0) {
              target.Product = source.Product.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ProductTag ToEntity(this ProductTagDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ProductTag();

            // Properties
            target.ProductTagID = source.ProductTagID;
            target.Name = source.Name;
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ProductTagDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ProductTag> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ProductTagDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ProductTag> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ProductTag> ToEntities(this IEnumerable<ProductTagDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ProductTag source, ProductTagDTO target);

        static partial void OnEntityCreating(ProductTagDTO source, Bec.TargetFramework.Data.ProductTag target);

    }

}