﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 16:15:20
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class ShoppingCartItemProductSpecificationConverter
    {

        public static ShoppingCartItemProductSpecificationDTO ToDto(this Bec.TargetFramework.Data.ShoppingCartItemProductSpecification source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ShoppingCartItemProductSpecificationDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ShoppingCartItemProductSpecification source, int level)
        {
            if (source == null)
              return null;

            var target = new ShoppingCartItemProductSpecificationDTO();

            // Properties
            target.ShoppingCartItemProductSpecificationID = source.ShoppingCartItemProductSpecificationID;
            target.ProductSpecificationAttributeID = source.ProductSpecificationAttributeID;
            target.ProductSpecificationAttributeOptionID = source.ProductSpecificationAttributeOptionID;
            target.Quantity = source.Quantity;
            target.ShoppingCartItemID = source.ShoppingCartItemID;

            // Navigation Properties
            if (level > 0) {
              target.ProductSpecificationAttributeOption = source.ProductSpecificationAttributeOption.ToDtoWithRelated(level - 1);
              target.ShoppingCartItem = source.ShoppingCartItem.ToDtoWithRelated(level - 1);
              target.ProductSpecificationAttribute = source.ProductSpecificationAttribute.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ShoppingCartItemProductSpecification ToEntity(this ShoppingCartItemProductSpecificationDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ShoppingCartItemProductSpecification();

            // Properties
            target.ShoppingCartItemProductSpecificationID = source.ShoppingCartItemProductSpecificationID;
            target.ProductSpecificationAttributeID = source.ProductSpecificationAttributeID;
            target.ProductSpecificationAttributeOptionID = source.ProductSpecificationAttributeOptionID;
            target.Quantity = source.Quantity;
            target.ShoppingCartItemID = source.ShoppingCartItemID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ShoppingCartItemProductSpecificationDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ShoppingCartItemProductSpecification> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ShoppingCartItemProductSpecificationDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ShoppingCartItemProductSpecification> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ShoppingCartItemProductSpecification> ToEntities(this IEnumerable<ShoppingCartItemProductSpecificationDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ShoppingCartItemProductSpecification source, ShoppingCartItemProductSpecificationDTO target);

        static partial void OnEntityCreating(ShoppingCartItemProductSpecificationDTO source, Bec.TargetFramework.Data.ShoppingCartItemProductSpecification target);

    }

}
