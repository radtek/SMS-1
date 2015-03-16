﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:07 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class CurrencyCodeConverter
    {

        public static CurrencyCodeDTO ToDto(this Bec.TargetFramework.Data.CurrencyCode source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static CurrencyCodeDTO ToDtoWithRelated(this Bec.TargetFramework.Data.CurrencyCode source, int level)
        {
            if (source == null)
              return null;

            var target = new CurrencyCodeDTO();

            // Properties
            target.CurrencyCode1 = source.CurrencyCode1;
            target.CurrencyName = source.CurrencyName;

            // Navigation Properties
            if (level > 0) {
              target.CountryCodes = source.CountryCodes.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.CurrencyCode ToEntity(this CurrencyCodeDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.CurrencyCode();

            // Properties
            target.CurrencyCode1 = source.CurrencyCode1;
            target.CurrencyName = source.CurrencyName;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<CurrencyCodeDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.CurrencyCode> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<CurrencyCodeDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.CurrencyCode> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.CurrencyCode> ToEntities(this IEnumerable<CurrencyCodeDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.CurrencyCode source, CurrencyCodeDTO target);

        static partial void OnEntityCreating(CurrencyCodeDTO source, Bec.TargetFramework.Data.CurrencyCode target);

    }

}
