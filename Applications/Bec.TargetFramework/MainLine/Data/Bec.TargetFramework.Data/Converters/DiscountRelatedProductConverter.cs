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

    public static partial class DiscountRelatedProductConverter
    {

        public static DiscountRelatedProductDTO ToDto(this Bec.TargetFramework.Data.DiscountRelatedProduct source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DiscountRelatedProductDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DiscountRelatedProduct source, int level)
        {
            if (source == null)
              return null;

            var target = new DiscountRelatedProductDTO();

            // Properties
            target.DiscountRelatedProductID = source.DiscountRelatedProductID;
            target.DiscountID = source.DiscountID;
            target.DiscountVersionNumber = source.DiscountVersionNumber;
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.Discount = source.Discount.ToDtoWithRelated(level - 1);
              target.Product = source.Product.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DiscountRelatedProduct ToEntity(this DiscountRelatedProductDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DiscountRelatedProduct();

            // Properties
            target.DiscountRelatedProductID = source.DiscountRelatedProductID;
            target.DiscountID = source.DiscountID;
            target.DiscountVersionNumber = source.DiscountVersionNumber;
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DiscountRelatedProductDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DiscountRelatedProduct> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DiscountRelatedProductDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DiscountRelatedProduct> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DiscountRelatedProduct> ToEntities(this IEnumerable<DiscountRelatedProductDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DiscountRelatedProduct source, DiscountRelatedProductDTO target);

        static partial void OnEntityCreating(DiscountRelatedProductDTO source, Bec.TargetFramework.Data.DiscountRelatedProduct target);

    }

}
