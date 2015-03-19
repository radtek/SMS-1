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

    public static partial class TaxRateTemplateConverter
    {

        public static TaxRateTemplateDTO ToDto(this Bec.TargetFramework.Data.TaxRateTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static TaxRateTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.TaxRateTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new TaxRateTemplateDTO();

            // Properties
            target.TaxRateTemplateID = source.TaxRateTemplateID;
            target.TaxCategoryID = source.TaxCategoryID;
            target.TaxPercentage = source.TaxPercentage;
            target.CountryID = source.CountryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.TaxRates = source.TaxRates.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.TaxRateTemplate ToEntity(this TaxRateTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.TaxRateTemplate();

            // Properties
            target.TaxRateTemplateID = source.TaxRateTemplateID;
            target.TaxCategoryID = source.TaxCategoryID;
            target.TaxPercentage = source.TaxPercentage;
            target.CountryID = source.CountryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<TaxRateTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.TaxRateTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<TaxRateTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.TaxRateTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.TaxRateTemplate> ToEntities(this IEnumerable<TaxRateTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.TaxRateTemplate source, TaxRateTemplateDTO target);

        static partial void OnEntityCreating(TaxRateTemplateDTO source, Bec.TargetFramework.Data.TaxRateTemplate target);

    }

}
