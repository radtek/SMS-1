﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:53
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class ShoppingCartBlueprintProductConverter
    {

        public static ShoppingCartBlueprintProductDTO ToDto(this Bec.TargetFramework.Data.ShoppingCartBlueprintProduct source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ShoppingCartBlueprintProductDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ShoppingCartBlueprintProduct source, int level)
        {
            if (source == null)
              return null;

            var target = new ShoppingCartBlueprintProductDTO();

            // Properties
            target.ShoppingCartBlueprintID = source.ShoppingCartBlueprintID;
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.Quantity = source.Quantity;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.Product = source.Product.ToDtoWithRelated(level - 1);
              target.ShoppingCartBlueprint = source.ShoppingCartBlueprint.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ShoppingCartBlueprintProduct ToEntity(this ShoppingCartBlueprintProductDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ShoppingCartBlueprintProduct();

            // Properties
            target.ShoppingCartBlueprintID = source.ShoppingCartBlueprintID;
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.Quantity = source.Quantity;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ShoppingCartBlueprintProductDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ShoppingCartBlueprintProduct> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ShoppingCartBlueprintProductDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ShoppingCartBlueprintProduct> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ShoppingCartBlueprintProduct> ToEntities(this IEnumerable<ShoppingCartBlueprintProductDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ShoppingCartBlueprintProduct source, ShoppingCartBlueprintProductDTO target);

        static partial void OnEntityCreating(ShoppingCartBlueprintProductDTO source, Bec.TargetFramework.Data.ShoppingCartBlueprintProduct target);

    }

}
