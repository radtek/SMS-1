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

    public static partial class CurrencyRateConverter
    {

        public static CurrencyRateDTO ToDto(this Bec.TargetFramework.Data.CurrencyRate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static CurrencyRateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.CurrencyRate source, int level)
        {
            if (source == null)
              return null;

            var target = new CurrencyRateDTO();

            // Properties
            target.CurrencyCode = source.CurrencyCode;
            target.CurrencyRateDate = source.CurrencyRateDate;
            target.CurrencyRate1 = source.CurrencyRate1;
            target.CurrencyRateToGBP = source.CurrencyRateToGBP;
            target.CurrencyRateToUSD = source.CurrencyRateToUSD;
            target.CurrencyRateID = source.CurrencyRateID;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.CurrencyRate ToEntity(this CurrencyRateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.CurrencyRate();

            // Properties
            target.CurrencyCode = source.CurrencyCode;
            target.CurrencyRateDate = source.CurrencyRateDate;
            target.CurrencyRate1 = source.CurrencyRate1;
            target.CurrencyRateToGBP = source.CurrencyRateToGBP;
            target.CurrencyRateToUSD = source.CurrencyRateToUSD;
            target.CurrencyRateID = source.CurrencyRateID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<CurrencyRateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.CurrencyRate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<CurrencyRateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.CurrencyRate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.CurrencyRate> ToEntities(this IEnumerable<CurrencyRateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.CurrencyRate source, CurrencyRateDTO target);

        static partial void OnEntityCreating(CurrencyRateDTO source, Bec.TargetFramework.Data.CurrencyRate target);

    }

}
