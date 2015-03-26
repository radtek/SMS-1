﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:15:01
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class ProductProductAttributeTemplateConverter
    {

        public static ProductProductAttributeTemplateDTO ToDto(this Bec.TargetFramework.Data.ProductProductAttributeTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ProductProductAttributeTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ProductProductAttributeTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new ProductProductAttributeTemplateDTO();

            // Properties
            target.ProductProductAttributeTemplateID = source.ProductProductAttributeTemplateID;
            target.ProductTemplateID = source.ProductTemplateID;
            target.ProductAttributeTemplateID = source.ProductAttributeTemplateID;
            target.IsRequired = source.IsRequired;
            target.DisplayOrder = source.DisplayOrder;
            target.ProductVersionID = source.ProductVersionID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.ProductVariantAttributeValueTemplates = source.ProductVariantAttributeValueTemplates.ToDtosWithRelated(level - 1);
              target.ProductAttributeTemplate = source.ProductAttributeTemplate.ToDtoWithRelated(level - 1);
              target.ProductTemplate = source.ProductTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ProductProductAttributeTemplate ToEntity(this ProductProductAttributeTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ProductProductAttributeTemplate();

            // Properties
            target.ProductProductAttributeTemplateID = source.ProductProductAttributeTemplateID;
            target.ProductTemplateID = source.ProductTemplateID;
            target.ProductAttributeTemplateID = source.ProductAttributeTemplateID;
            target.IsRequired = source.IsRequired;
            target.DisplayOrder = source.DisplayOrder;
            target.ProductVersionID = source.ProductVersionID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ProductProductAttributeTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ProductProductAttributeTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ProductProductAttributeTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ProductProductAttributeTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ProductProductAttributeTemplate> ToEntities(this IEnumerable<ProductProductAttributeTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ProductProductAttributeTemplate source, ProductProductAttributeTemplateDTO target);

        static partial void OnEntityCreating(ProductProductAttributeTemplateDTO source, Bec.TargetFramework.Data.ProductProductAttributeTemplate target);

    }

}
