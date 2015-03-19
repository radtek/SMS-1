﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 18/03/2015 19:00:46
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class VProductDeductionConverter
    {

        public static VProductDeductionDTO ToDto(this Bec.TargetFramework.Data.VProductDeduction source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VProductDeductionDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VProductDeduction source, int level)
        {
            if (source == null)
              return null;

            var target = new VProductDeductionDTO();

            // Properties
            target.ProductDeductionID = source.ProductDeductionID;
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.DeductionID = source.DeductionID;
            target.DeductionPercentage = source.DeductionPercentage;
            target.DeductionValue = source.DeductionValue;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsPercentageBased = source.IsPercentageBased;
            target.DeductionVersionNumber = source.DeductionVersionNumber;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VProductDeduction ToEntity(this VProductDeductionDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VProductDeduction();

            // Properties
            target.ProductDeductionID = source.ProductDeductionID;
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.DeductionID = source.DeductionID;
            target.DeductionPercentage = source.DeductionPercentage;
            target.DeductionValue = source.DeductionValue;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsPercentageBased = source.IsPercentageBased;
            target.DeductionVersionNumber = source.DeductionVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VProductDeductionDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VProductDeduction> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VProductDeductionDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VProductDeduction> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VProductDeduction> ToEntities(this IEnumerable<VProductDeductionDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VProductDeduction source, VProductDeductionDTO target);

        static partial void OnEntityCreating(VProductDeductionDTO source, Bec.TargetFramework.Data.VProductDeduction target);

    }

}
