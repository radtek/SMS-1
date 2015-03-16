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

    public static partial class ProductSpecificationAttributeTemplateConverter
    {

        public static ProductSpecificationAttributeTemplateDTO ToDto(this Bec.TargetFramework.Data.ProductSpecificationAttributeTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ProductSpecificationAttributeTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ProductSpecificationAttributeTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new ProductSpecificationAttributeTemplateDTO();

            // Properties
            target.ProductTemplateID = source.ProductTemplateID;
            target.IsMandatory = source.IsMandatory;
            target.IsMultiSelect = source.IsMultiSelect;
            target.DisplayOrder = source.DisplayOrder;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.SpecificationAttributeTemplateID = source.SpecificationAttributeTemplateID;
            target.IsPreSelected = source.IsPreSelected;
            target.MinimumSelectionLimit = source.MinimumSelectionLimit;
            target.MaximumSelectionLimit = source.MaximumSelectionLimit;
            target.ProductSpecificationAttributeTemplateID = source.ProductSpecificationAttributeTemplateID;
            target.IsUserDefined = source.IsUserDefined;
            target.IsPriceDriven = source.IsPriceDriven;
            target.ProductVersionID = source.ProductVersionID;

            // Navigation Properties
            if (level > 0) {
              target.SpecificationAttributeTemplate = source.SpecificationAttributeTemplate.ToDtoWithRelated(level - 1);
              target.ProductTemplate = source.ProductTemplate.ToDtoWithRelated(level - 1);
              target.ProductSpecificationAttributeOptionTemplates = source.ProductSpecificationAttributeOptionTemplates.ToDtosWithRelated(level - 1);
              target.ProductSpecificationBlueprintTemplates = source.ProductSpecificationBlueprintTemplates.ToDtosWithRelated(level - 1);
              target.PackageProductSpecificationBlueprintTemplates = source.PackageProductSpecificationBlueprintTemplates.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ProductSpecificationAttributeTemplate ToEntity(this ProductSpecificationAttributeTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ProductSpecificationAttributeTemplate();

            // Properties
            target.ProductTemplateID = source.ProductTemplateID;
            target.IsMandatory = source.IsMandatory;
            target.IsMultiSelect = source.IsMultiSelect;
            target.DisplayOrder = source.DisplayOrder;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.SpecificationAttributeTemplateID = source.SpecificationAttributeTemplateID;
            target.IsPreSelected = source.IsPreSelected;
            target.MinimumSelectionLimit = source.MinimumSelectionLimit;
            target.MaximumSelectionLimit = source.MaximumSelectionLimit;
            target.ProductSpecificationAttributeTemplateID = source.ProductSpecificationAttributeTemplateID;
            target.IsUserDefined = source.IsUserDefined;
            target.IsPriceDriven = source.IsPriceDriven;
            target.ProductVersionID = source.ProductVersionID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ProductSpecificationAttributeTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ProductSpecificationAttributeTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ProductSpecificationAttributeTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ProductSpecificationAttributeTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ProductSpecificationAttributeTemplate> ToEntities(this IEnumerable<ProductSpecificationAttributeTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ProductSpecificationAttributeTemplate source, ProductSpecificationAttributeTemplateDTO target);

        static partial void OnEntityCreating(ProductSpecificationAttributeTemplateDTO source, Bec.TargetFramework.Data.ProductSpecificationAttributeTemplate target);

    }

}
