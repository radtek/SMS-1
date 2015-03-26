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

    public static partial class VCountryDeductionConverter
    {

        public static VCountryDeductionDTO ToDto(this Bec.TargetFramework.Data.VCountryDeduction source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VCountryDeductionDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VCountryDeduction source, int level)
        {
            if (source == null)
              return null;

            var target = new VCountryDeductionDTO();

            // Properties
            target.CountryDeductionID = source.CountryDeductionID;
            target.CountryCode = source.CountryCode;
            target.DeductionID = source.DeductionID;
            target.DeductionVersionNumber = source.DeductionVersionNumber;
            target.DeductionPercentage = source.DeductionPercentage;
            target.DeductionValue = source.DeductionValue;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsAppliedToAllOrders = source.IsAppliedToAllOrders;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsPercentageBased = source.IsPercentageBased;
            target.IsProductDeduction = source.IsProductDeduction;
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VCountryDeduction ToEntity(this VCountryDeductionDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VCountryDeduction();

            // Properties
            target.CountryDeductionID = source.CountryDeductionID;
            target.CountryCode = source.CountryCode;
            target.DeductionID = source.DeductionID;
            target.DeductionVersionNumber = source.DeductionVersionNumber;
            target.DeductionPercentage = source.DeductionPercentage;
            target.DeductionValue = source.DeductionValue;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsAppliedToAllOrders = source.IsAppliedToAllOrders;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsPercentageBased = source.IsPercentageBased;
            target.IsProductDeduction = source.IsProductDeduction;
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VCountryDeductionDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VCountryDeduction> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VCountryDeductionDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VCountryDeduction> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VCountryDeduction> ToEntities(this IEnumerable<VCountryDeductionDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VCountryDeduction source, VCountryDeductionDTO target);

        static partial void OnEntityCreating(VCountryDeductionDTO source, Bec.TargetFramework.Data.VCountryDeduction target);

    }

}
