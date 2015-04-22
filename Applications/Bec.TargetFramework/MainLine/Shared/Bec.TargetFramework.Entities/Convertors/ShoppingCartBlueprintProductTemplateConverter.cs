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

    public static partial class ShoppingCartBlueprintProductTemplateConverter
    {

        public static ShoppingCartBlueprintProductTemplateDTO ToDto(this Bec.TargetFramework.Data.ShoppingCartBlueprintProductTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ShoppingCartBlueprintProductTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ShoppingCartBlueprintProductTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new ShoppingCartBlueprintProductTemplateDTO();

            // Properties
            target.ShoppingCartBlueprintTemplateID = source.ShoppingCartBlueprintTemplateID;
            target.ProductTemplateID = source.ProductTemplateID;
            target.ProductVersionID = source.ProductVersionID;
            target.Quantity = source.Quantity;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.ProductTemplate = source.ProductTemplate.ToDtoWithRelated(level - 1);
              target.ShoppingCartBlueprintTemplate = source.ShoppingCartBlueprintTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ShoppingCartBlueprintProductTemplate ToEntity(this ShoppingCartBlueprintProductTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ShoppingCartBlueprintProductTemplate();

            // Properties
            target.ShoppingCartBlueprintTemplateID = source.ShoppingCartBlueprintTemplateID;
            target.ProductTemplateID = source.ProductTemplateID;
            target.ProductVersionID = source.ProductVersionID;
            target.Quantity = source.Quantity;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ShoppingCartBlueprintProductTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ShoppingCartBlueprintProductTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ShoppingCartBlueprintProductTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ShoppingCartBlueprintProductTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ShoppingCartBlueprintProductTemplate> ToEntities(this IEnumerable<ShoppingCartBlueprintProductTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ShoppingCartBlueprintProductTemplate source, ShoppingCartBlueprintProductTemplateDTO target);

        static partial void OnEntityCreating(ShoppingCartBlueprintProductTemplateDTO source, Bec.TargetFramework.Data.ShoppingCartBlueprintProductTemplate target);

    }

}
