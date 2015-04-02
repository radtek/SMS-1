﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:53
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class ProductDeductionConverter
    {

        public static ProductDeductionDTO ToDto(this Bec.TargetFramework.Data.ProductDeduction source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ProductDeductionDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ProductDeduction source, int level)
        {
            if (source == null)
              return null;

            var target = new ProductDeductionDTO();

            // Properties
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.DeductionID = source.DeductionID;
            target.DeductionPercentage = source.DeductionPercentage;
            target.DeductionValue = source.DeductionValue;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ProductDeductionID = source.ProductDeductionID;
            target.DeductionVersionNumber = source.DeductionVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.Product = source.Product.ToDtoWithRelated(level - 1);
              target.Deduction = source.Deduction.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ProductDeduction ToEntity(this ProductDeductionDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ProductDeduction();

            // Properties
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.DeductionID = source.DeductionID;
            target.DeductionPercentage = source.DeductionPercentage;
            target.DeductionValue = source.DeductionValue;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ProductDeductionID = source.ProductDeductionID;
            target.DeductionVersionNumber = source.DeductionVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ProductDeductionDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ProductDeduction> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ProductDeductionDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ProductDeduction> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ProductDeduction> ToEntities(this IEnumerable<ProductDeductionDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ProductDeduction source, ProductDeductionDTO target);

        static partial void OnEntityCreating(ProductDeductionDTO source, Bec.TargetFramework.Data.ProductDeduction target);

    }

}
