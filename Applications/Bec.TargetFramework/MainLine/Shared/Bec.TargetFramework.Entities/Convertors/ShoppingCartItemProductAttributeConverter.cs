﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:54
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class ShoppingCartItemProductAttributeConverter
    {

        public static ShoppingCartItemProductAttributeDTO ToDto(this Bec.TargetFramework.Data.ShoppingCartItemProductAttribute source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ShoppingCartItemProductAttributeDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ShoppingCartItemProductAttribute source, int level)
        {
            if (source == null)
              return null;

            var target = new ShoppingCartItemProductAttributeDTO();

            // Properties
            target.ShoppingCartItemProductAttributeID = source.ShoppingCartItemProductAttributeID;
            target.ProductVariantAttributeValueID = source.ProductVariantAttributeValueID;
            target.Quantity = source.Quantity;
            target.ShoppingCartItemID = source.ShoppingCartItemID;

            // Navigation Properties
            if (level > 0) {
              target.ProductVariantAttributeValue = source.ProductVariantAttributeValue.ToDtoWithRelated(level - 1);
              target.ShoppingCartItem = source.ShoppingCartItem.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ShoppingCartItemProductAttribute ToEntity(this ShoppingCartItemProductAttributeDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ShoppingCartItemProductAttribute();

            // Properties
            target.ShoppingCartItemProductAttributeID = source.ShoppingCartItemProductAttributeID;
            target.ProductVariantAttributeValueID = source.ProductVariantAttributeValueID;
            target.Quantity = source.Quantity;
            target.ShoppingCartItemID = source.ShoppingCartItemID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ShoppingCartItemProductAttributeDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ShoppingCartItemProductAttribute> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ShoppingCartItemProductAttributeDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ShoppingCartItemProductAttribute> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ShoppingCartItemProductAttribute> ToEntities(this IEnumerable<ShoppingCartItemProductAttributeDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ShoppingCartItemProductAttribute source, ShoppingCartItemProductAttributeDTO target);

        static partial void OnEntityCreating(ShoppingCartItemProductAttributeDTO source, Bec.TargetFramework.Data.ShoppingCartItemProductAttribute target);

    }

}
