﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 13/04/2015 17:29:39
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class ProductDiscountConverter
    {

        public static ProductDiscountDTO ToDto(this Bec.TargetFramework.Data.ProductDiscount source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ProductDiscountDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ProductDiscount source, int level)
        {
            if (source == null)
              return null;

            var target = new ProductDiscountDTO();

            // Properties
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.DiscountID = source.DiscountID;
            target.DiscountVersionNumber = source.DiscountVersionNumber;
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

        public static Bec.TargetFramework.Data.ProductDiscount ToEntity(this ProductDiscountDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ProductDiscount();

            // Properties
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.DiscountID = source.DiscountID;
            target.DiscountVersionNumber = source.DiscountVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ProductDiscountDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ProductDiscount> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ProductDiscountDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ProductDiscount> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ProductDiscount> ToEntities(this IEnumerable<ProductDiscountDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ProductDiscount source, ProductDiscountDTO target);

        static partial void OnEntityCreating(ProductDiscountDTO source, Bec.TargetFramework.Data.ProductDiscount target);

    }

}
