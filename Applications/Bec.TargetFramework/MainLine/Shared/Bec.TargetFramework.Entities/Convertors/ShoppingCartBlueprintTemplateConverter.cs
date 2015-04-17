﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:55
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class ShoppingCartBlueprintTemplateConverter
    {

        public static ShoppingCartBlueprintTemplateDTO ToDto(this Bec.TargetFramework.Data.ShoppingCartBlueprintTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ShoppingCartBlueprintTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ShoppingCartBlueprintTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new ShoppingCartBlueprintTemplateDTO();

            // Properties
            target.ShoppingCartBlueprintTemplateID = source.ShoppingCartBlueprintTemplateID;
            target.ParentID = source.ParentID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.Name = source.Name;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisationShoppingCartBlueprintTemplates = source.DefaultOrganisationShoppingCartBlueprintTemplates.ToDtosWithRelated(level - 1);
              target.ShoppingCartBlueprintProductTemplates = source.ShoppingCartBlueprintProductTemplates.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ShoppingCartBlueprintTemplate ToEntity(this ShoppingCartBlueprintTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ShoppingCartBlueprintTemplate();

            // Properties
            target.ShoppingCartBlueprintTemplateID = source.ShoppingCartBlueprintTemplateID;
            target.ParentID = source.ParentID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.Name = source.Name;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ShoppingCartBlueprintTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ShoppingCartBlueprintTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ShoppingCartBlueprintTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ShoppingCartBlueprintTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ShoppingCartBlueprintTemplate> ToEntities(this IEnumerable<ShoppingCartBlueprintTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ShoppingCartBlueprintTemplate source, ShoppingCartBlueprintTemplateDTO target);

        static partial void OnEntityCreating(ShoppingCartBlueprintTemplateDTO source, Bec.TargetFramework.Data.ShoppingCartBlueprintTemplate target);

    }

}
