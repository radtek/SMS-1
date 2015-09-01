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

    public static partial class ProductVariantAttributeCombinationConverter
    {

        public static ProductVariantAttributeCombinationDTO ToDto(this Bec.TargetFramework.Data.ProductVariantAttributeCombination source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ProductVariantAttributeCombinationDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ProductVariantAttributeCombination source, int level)
        {
            if (source == null)
              return null;

            var target = new ProductVariantAttributeCombinationDTO();

            // Properties
            target.ProductVariantAttributeCombinationID = source.ProductVariantAttributeCombinationID;
            target.ProductID = source.ProductID;
            target.AllowOutOfStockOrders = source.AllowOutOfStockOrders;
            target.StockQuantity = source.StockQuantity;
            target.Sku = source.Sku;
            target.ManufacturerPartNumber = source.ManufacturerPartNumber;
            target.Gtin = source.Gtin;
            target.OverridenPrice = source.OverridenPrice;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ProductVersionID = source.ProductVersionID;

            // Navigation Properties
            if (level > 0) {
              target.Product = source.Product.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ProductVariantAttributeCombination ToEntity(this ProductVariantAttributeCombinationDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ProductVariantAttributeCombination();

            // Properties
            target.ProductVariantAttributeCombinationID = source.ProductVariantAttributeCombinationID;
            target.ProductID = source.ProductID;
            target.AllowOutOfStockOrders = source.AllowOutOfStockOrders;
            target.StockQuantity = source.StockQuantity;
            target.Sku = source.Sku;
            target.ManufacturerPartNumber = source.ManufacturerPartNumber;
            target.Gtin = source.Gtin;
            target.OverridenPrice = source.OverridenPrice;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ProductVersionID = source.ProductVersionID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ProductVariantAttributeCombinationDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ProductVariantAttributeCombination> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ProductVariantAttributeCombinationDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ProductVariantAttributeCombination> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ProductVariantAttributeCombination> ToEntities(this IEnumerable<ProductVariantAttributeCombinationDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ProductVariantAttributeCombination source, ProductVariantAttributeCombinationDTO target);

        static partial void OnEntityCreating(ProductVariantAttributeCombinationDTO source, Bec.TargetFramework.Data.ProductVariantAttributeCombination target);

    }

}