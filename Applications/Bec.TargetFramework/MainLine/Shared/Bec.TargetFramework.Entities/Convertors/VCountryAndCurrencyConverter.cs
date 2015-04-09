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

    public static partial class VCountryAndCurrencyConverter
    {

        public static VCountryAndCurrencyDTO ToDto(this Bec.TargetFramework.Data.VCountryAndCurrency source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VCountryAndCurrencyDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VCountryAndCurrency source, int level)
        {
            if (source == null)
              return null;

            var target = new VCountryAndCurrencyDTO();

            // Properties
            target.CountryCode = source.CountryCode;
            target.CountryName = source.CountryName;
            target.CurrencyCode = source.CurrencyCode;
            target.CurrencyName = source.CurrencyName;
            target.CurrencyRateDate = source.CurrencyRateDate;
            target.CurrencyRate = source.CurrencyRate;
            target.CurrencyRateToGBP = source.CurrencyRateToGBP;
            target.CurrencyRateToUSD = source.CurrencyRateToUSD;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VCountryAndCurrency ToEntity(this VCountryAndCurrencyDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VCountryAndCurrency();

            // Properties
            target.CountryCode = source.CountryCode;
            target.CountryName = source.CountryName;
            target.CurrencyCode = source.CurrencyCode;
            target.CurrencyName = source.CurrencyName;
            target.CurrencyRateDate = source.CurrencyRateDate;
            target.CurrencyRate = source.CurrencyRate;
            target.CurrencyRateToGBP = source.CurrencyRateToGBP;
            target.CurrencyRateToUSD = source.CurrencyRateToUSD;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VCountryAndCurrencyDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VCountryAndCurrency> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VCountryAndCurrencyDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VCountryAndCurrency> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VCountryAndCurrency> ToEntities(this IEnumerable<VCountryAndCurrencyDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VCountryAndCurrency source, VCountryAndCurrencyDTO target);

        static partial void OnEntityCreating(VCountryAndCurrencyDTO source, Bec.TargetFramework.Data.VCountryAndCurrency target);

    }

}
