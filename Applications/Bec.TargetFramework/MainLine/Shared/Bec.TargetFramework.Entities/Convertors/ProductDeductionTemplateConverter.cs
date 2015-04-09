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

    public static partial class ProductDeductionTemplateConverter
    {

        public static ProductDeductionTemplateDTO ToDto(this Bec.TargetFramework.Data.ProductDeductionTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ProductDeductionTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ProductDeductionTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new ProductDeductionTemplateDTO();

            // Properties
            target.ProductTemplateID = source.ProductTemplateID;
            target.ProductVersionID = source.ProductVersionID;
            target.DeductionTemplateID = source.DeductionTemplateID;
            target.DeductionPercentage = source.DeductionPercentage;
            target.DeductionValue = source.DeductionValue;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ProductDeductionTemplateID = source.ProductDeductionTemplateID;
            target.DeductionTemplateVersionNumber = source.DeductionTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.ProductTemplate = source.ProductTemplate.ToDtoWithRelated(level - 1);
              target.DeductionTemplate = source.DeductionTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ProductDeductionTemplate ToEntity(this ProductDeductionTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ProductDeductionTemplate();

            // Properties
            target.ProductTemplateID = source.ProductTemplateID;
            target.ProductVersionID = source.ProductVersionID;
            target.DeductionTemplateID = source.DeductionTemplateID;
            target.DeductionPercentage = source.DeductionPercentage;
            target.DeductionValue = source.DeductionValue;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ProductDeductionTemplateID = source.ProductDeductionTemplateID;
            target.DeductionTemplateVersionNumber = source.DeductionTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ProductDeductionTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ProductDeductionTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ProductDeductionTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ProductDeductionTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ProductDeductionTemplate> ToEntities(this IEnumerable<ProductDeductionTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ProductDeductionTemplate source, ProductDeductionTemplateDTO target);

        static partial void OnEntityCreating(ProductDeductionTemplateDTO source, Bec.TargetFramework.Data.ProductDeductionTemplate target);

    }

}
