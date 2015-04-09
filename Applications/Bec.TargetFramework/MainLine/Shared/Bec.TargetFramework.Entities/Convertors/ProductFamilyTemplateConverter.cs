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

    public static partial class ProductFamilyTemplateConverter
    {

        public static ProductFamilyTemplateDTO ToDto(this Bec.TargetFramework.Data.ProductFamilyTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ProductFamilyTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ProductFamilyTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new ProductFamilyTemplateDTO();

            // Properties
            target.ProductFamilyTemplateID = source.ProductFamilyTemplateID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.ProductFamilyProductPackageTemplates = source.ProductFamilyProductPackageTemplates.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ProductFamilyTemplate ToEntity(this ProductFamilyTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ProductFamilyTemplate();

            // Properties
            target.ProductFamilyTemplateID = source.ProductFamilyTemplateID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ProductFamilyTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ProductFamilyTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ProductFamilyTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ProductFamilyTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ProductFamilyTemplate> ToEntities(this IEnumerable<ProductFamilyTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ProductFamilyTemplate source, ProductFamilyTemplateDTO target);

        static partial void OnEntityCreating(ProductFamilyTemplateDTO source, Bec.TargetFramework.Data.ProductFamilyTemplate target);

    }

}
