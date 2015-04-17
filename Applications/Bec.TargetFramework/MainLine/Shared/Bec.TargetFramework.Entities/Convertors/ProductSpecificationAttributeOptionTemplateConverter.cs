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

    public static partial class ProductSpecificationAttributeOptionTemplateConverter
    {

        public static ProductSpecificationAttributeOptionTemplateDTO ToDto(this Bec.TargetFramework.Data.ProductSpecificationAttributeOptionTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ProductSpecificationAttributeOptionTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ProductSpecificationAttributeOptionTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new ProductSpecificationAttributeOptionTemplateDTO();

            // Properties
            target.SpecificationAttributeOptionTemplateID = source.SpecificationAttributeOptionTemplateID;
            target.PriceAdjustement = source.PriceAdjustement;
            target.WeightAdjustment = source.WeightAdjustment;
            target.Cost = source.Cost;
            target.DefaultValue = source.DefaultValue;
            target.DefaultQuantity = source.DefaultQuantity;
            target.DisplayOrder = source.DisplayOrder;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ProductSpecificationAttributeTemplateID = source.ProductSpecificationAttributeTemplateID;
            target.ProductSpecificationAttributeOptionTemplateID = source.ProductSpecificationAttributeOptionTemplateID;

            // Navigation Properties
            if (level > 0) {
              target.ProductSpecificationAttributeTemplate = source.ProductSpecificationAttributeTemplate.ToDtoWithRelated(level - 1);
              target.SpecificationAttributeOptionTemplate = source.SpecificationAttributeOptionTemplate.ToDtoWithRelated(level - 1);
              target.ProductSpecificationBlueprintTemplates = source.ProductSpecificationBlueprintTemplates.ToDtosWithRelated(level - 1);
              target.PackageProductSpecificationBlueprintTemplates = source.PackageProductSpecificationBlueprintTemplates.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ProductSpecificationAttributeOptionTemplate ToEntity(this ProductSpecificationAttributeOptionTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ProductSpecificationAttributeOptionTemplate();

            // Properties
            target.SpecificationAttributeOptionTemplateID = source.SpecificationAttributeOptionTemplateID;
            target.PriceAdjustement = source.PriceAdjustement;
            target.WeightAdjustment = source.WeightAdjustment;
            target.Cost = source.Cost;
            target.DefaultValue = source.DefaultValue;
            target.DefaultQuantity = source.DefaultQuantity;
            target.DisplayOrder = source.DisplayOrder;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ProductSpecificationAttributeTemplateID = source.ProductSpecificationAttributeTemplateID;
            target.ProductSpecificationAttributeOptionTemplateID = source.ProductSpecificationAttributeOptionTemplateID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ProductSpecificationAttributeOptionTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ProductSpecificationAttributeOptionTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ProductSpecificationAttributeOptionTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ProductSpecificationAttributeOptionTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ProductSpecificationAttributeOptionTemplate> ToEntities(this IEnumerable<ProductSpecificationAttributeOptionTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ProductSpecificationAttributeOptionTemplate source, ProductSpecificationAttributeOptionTemplateDTO target);

        static partial void OnEntityCreating(ProductSpecificationAttributeOptionTemplateDTO source, Bec.TargetFramework.Data.ProductSpecificationAttributeOptionTemplate target);

    }

}
