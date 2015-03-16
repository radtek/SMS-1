﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:07 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class ProductVariantAttributeValueConverter
    {

        public static ProductVariantAttributeValueDTO ToDto(this Bec.TargetFramework.Data.ProductVariantAttributeValue source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ProductVariantAttributeValueDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ProductVariantAttributeValue source, int level)
        {
            if (source == null)
              return null;

            var target = new ProductVariantAttributeValueDTO();

            // Properties
            target.ProductVariantAttributeValueID = source.ProductVariantAttributeValueID;
            target.ProductProductAttributeID = source.ProductProductAttributeID;
            target.AttributeValueTypeID = source.AttributeValueTypeID;
            target.Name = source.Name;
            target.PriceAdjustment = source.PriceAdjustment;
            target.WeightAdjustement = source.WeightAdjustement;
            target.Cost = source.Cost;
            target.Quantity = source.Quantity;
            target.IsPreSelected = source.IsPreSelected;
            target.DisplayOrder = source.DisplayOrder;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.ProductProductAttribute = source.ProductProductAttribute.ToDtoWithRelated(level - 1);
              target.ShoppingCartItemProductAttributes = source.ShoppingCartItemProductAttributes.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ProductVariantAttributeValue ToEntity(this ProductVariantAttributeValueDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ProductVariantAttributeValue();

            // Properties
            target.ProductVariantAttributeValueID = source.ProductVariantAttributeValueID;
            target.ProductProductAttributeID = source.ProductProductAttributeID;
            target.AttributeValueTypeID = source.AttributeValueTypeID;
            target.Name = source.Name;
            target.PriceAdjustment = source.PriceAdjustment;
            target.WeightAdjustement = source.WeightAdjustement;
            target.Cost = source.Cost;
            target.Quantity = source.Quantity;
            target.IsPreSelected = source.IsPreSelected;
            target.DisplayOrder = source.DisplayOrder;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ProductVariantAttributeValueDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ProductVariantAttributeValue> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ProductVariantAttributeValueDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ProductVariantAttributeValue> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ProductVariantAttributeValue> ToEntities(this IEnumerable<ProductVariantAttributeValueDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ProductVariantAttributeValue source, ProductVariantAttributeValueDTO target);

        static partial void OnEntityCreating(ProductVariantAttributeValueDTO source, Bec.TargetFramework.Data.ProductVariantAttributeValue target);

    }

}
