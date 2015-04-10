﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:58
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class ProductRelationshipBlueprintConverter
    {

        public static ProductRelationshipBlueprintDTO ToDto(this Bec.TargetFramework.Data.ProductRelationshipBlueprint source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ProductRelationshipBlueprintDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ProductRelationshipBlueprint source, int level)
        {
            if (source == null)
              return null;

            var target = new ProductRelationshipBlueprintDTO();

            // Properties
            target.ProductRelationshipBlueprintID = source.ProductRelationshipBlueprintID;
            target.ProductRelationshipID = source.ProductRelationshipID;
            target.DefaultQuantity = source.DefaultQuantity;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.ProductRelationship = source.ProductRelationship.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ProductRelationshipBlueprint ToEntity(this ProductRelationshipBlueprintDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ProductRelationshipBlueprint();

            // Properties
            target.ProductRelationshipBlueprintID = source.ProductRelationshipBlueprintID;
            target.ProductRelationshipID = source.ProductRelationshipID;
            target.DefaultQuantity = source.DefaultQuantity;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ProductRelationshipBlueprintDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ProductRelationshipBlueprint> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ProductRelationshipBlueprintDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ProductRelationshipBlueprint> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ProductRelationshipBlueprint> ToEntities(this IEnumerable<ProductRelationshipBlueprintDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ProductRelationshipBlueprint source, ProductRelationshipBlueprintDTO target);

        static partial void OnEntityCreating(ProductRelationshipBlueprintDTO source, Bec.TargetFramework.Data.ProductRelationshipBlueprint target);

    }

}
