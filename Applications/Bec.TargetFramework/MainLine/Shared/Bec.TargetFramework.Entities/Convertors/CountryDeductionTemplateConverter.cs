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

    public static partial class CountryDeductionTemplateConverter
    {

        public static CountryDeductionTemplateDTO ToDto(this Bec.TargetFramework.Data.CountryDeductionTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static CountryDeductionTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.CountryDeductionTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new CountryDeductionTemplateDTO();

            // Properties
            target.DeductionTemplateID = source.DeductionTemplateID;
            target.CountryCode = source.CountryCode;
            target.DeductionPercentage = source.DeductionPercentage;
            target.DeductionValue = source.DeductionValue;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsAppliedToAllOrders = source.IsAppliedToAllOrders;
            target.CountryDeductionTemplateID = source.CountryDeductionTemplateID;
            target.DeductionTemplateVersionNumber = source.DeductionTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.CountryCode1 = source.CountryCode1.ToDtoWithRelated(level - 1);
              target.DeductionTemplate = source.DeductionTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.CountryDeductionTemplate ToEntity(this CountryDeductionTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.CountryDeductionTemplate();

            // Properties
            target.DeductionTemplateID = source.DeductionTemplateID;
            target.CountryCode = source.CountryCode;
            target.DeductionPercentage = source.DeductionPercentage;
            target.DeductionValue = source.DeductionValue;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsAppliedToAllOrders = source.IsAppliedToAllOrders;
            target.CountryDeductionTemplateID = source.CountryDeductionTemplateID;
            target.DeductionTemplateVersionNumber = source.DeductionTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<CountryDeductionTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.CountryDeductionTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<CountryDeductionTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.CountryDeductionTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.CountryDeductionTemplate> ToEntities(this IEnumerable<CountryDeductionTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.CountryDeductionTemplate source, CountryDeductionTemplateDTO target);

        static partial void OnEntityCreating(CountryDeductionTemplateDTO source, Bec.TargetFramework.Data.CountryDeductionTemplate target);

    }

}
