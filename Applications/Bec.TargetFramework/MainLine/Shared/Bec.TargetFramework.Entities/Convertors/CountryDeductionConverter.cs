﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:58
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class CountryDeductionConverter
    {

        public static CountryDeductionDTO ToDto(this Bec.TargetFramework.Data.CountryDeduction source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static CountryDeductionDTO ToDtoWithRelated(this Bec.TargetFramework.Data.CountryDeduction source, int level)
        {
            if (source == null)
              return null;

            var target = new CountryDeductionDTO();

            // Properties
            target.CountryCode = source.CountryCode;
            target.DeductionPercentage = source.DeductionPercentage;
            target.DeductionValue = source.DeductionValue;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsAppliedToAllOrders = source.IsAppliedToAllOrders;
            target.DeductionID = source.DeductionID;
            target.CountryDeductionID = source.CountryDeductionID;
            target.DeductionVersionNumber = source.DeductionVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.CountryCode1 = source.CountryCode1.ToDtoWithRelated(level - 1);
              target.Deduction = source.Deduction.ToDtoWithRelated(level - 1);
              target.ShoppingCarts = source.ShoppingCarts.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.CountryDeduction ToEntity(this CountryDeductionDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.CountryDeduction();

            // Properties
            target.CountryCode = source.CountryCode;
            target.DeductionPercentage = source.DeductionPercentage;
            target.DeductionValue = source.DeductionValue;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsAppliedToAllOrders = source.IsAppliedToAllOrders;
            target.DeductionID = source.DeductionID;
            target.CountryDeductionID = source.CountryDeductionID;
            target.DeductionVersionNumber = source.DeductionVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<CountryDeductionDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.CountryDeduction> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<CountryDeductionDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.CountryDeduction> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.CountryDeduction> ToEntities(this IEnumerable<CountryDeductionDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.CountryDeduction source, CountryDeductionDTO target);

        static partial void OnEntityCreating(CountryDeductionDTO source, Bec.TargetFramework.Data.CountryDeduction target);

    }

}
