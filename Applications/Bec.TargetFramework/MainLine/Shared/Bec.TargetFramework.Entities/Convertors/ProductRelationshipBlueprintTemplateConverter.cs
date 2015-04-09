﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:50:53
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class ProductRelationshipBlueprintTemplateConverter
    {

        public static ProductRelationshipBlueprintTemplateDTO ToDto(this Bec.TargetFramework.Data.ProductRelationshipBlueprintTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ProductRelationshipBlueprintTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ProductRelationshipBlueprintTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new ProductRelationshipBlueprintTemplateDTO();

            // Properties
            target.ProductRelationshipBlueprintTemplateID = source.ProductRelationshipBlueprintTemplateID;
            target.ProductRelationshipTemplateID = source.ProductRelationshipTemplateID;
            target.DefaultQuantity = source.DefaultQuantity;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.ProductRelationshipTemplate = source.ProductRelationshipTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ProductRelationshipBlueprintTemplate ToEntity(this ProductRelationshipBlueprintTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ProductRelationshipBlueprintTemplate();

            // Properties
            target.ProductRelationshipBlueprintTemplateID = source.ProductRelationshipBlueprintTemplateID;
            target.ProductRelationshipTemplateID = source.ProductRelationshipTemplateID;
            target.DefaultQuantity = source.DefaultQuantity;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ProductRelationshipBlueprintTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ProductRelationshipBlueprintTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ProductRelationshipBlueprintTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ProductRelationshipBlueprintTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ProductRelationshipBlueprintTemplate> ToEntities(this IEnumerable<ProductRelationshipBlueprintTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ProductRelationshipBlueprintTemplate source, ProductRelationshipBlueprintTemplateDTO target);

        static partial void OnEntityCreating(ProductRelationshipBlueprintTemplateDTO source, Bec.TargetFramework.Data.ProductRelationshipBlueprintTemplate target);

    }

}
