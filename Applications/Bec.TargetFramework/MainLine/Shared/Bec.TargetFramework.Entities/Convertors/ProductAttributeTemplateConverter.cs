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

    public static partial class ProductAttributeTemplateConverter
    {

        public static ProductAttributeTemplateDTO ToDto(this Bec.TargetFramework.Data.ProductAttributeTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ProductAttributeTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ProductAttributeTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new ProductAttributeTemplateDTO();

            // Properties
            target.ProductAttributeTemplateID = source.ProductAttributeTemplateID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.ProductProductAttributeTemplates = source.ProductProductAttributeTemplates.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ProductAttributeTemplate ToEntity(this ProductAttributeTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ProductAttributeTemplate();

            // Properties
            target.ProductAttributeTemplateID = source.ProductAttributeTemplateID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ProductAttributeTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ProductAttributeTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ProductAttributeTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ProductAttributeTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ProductAttributeTemplate> ToEntities(this IEnumerable<ProductAttributeTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ProductAttributeTemplate source, ProductAttributeTemplateDTO target);

        static partial void OnEntityCreating(ProductAttributeTemplateDTO source, Bec.TargetFramework.Data.ProductAttributeTemplate target);

    }

}
