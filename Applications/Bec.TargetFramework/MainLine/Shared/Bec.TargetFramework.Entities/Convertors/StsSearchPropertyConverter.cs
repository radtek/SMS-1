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

    public static partial class StsSearchPropertyConverter
    {

        public static StsSearchPropertyDTO ToDto(this Bec.TargetFramework.Data.StsSearchProperty source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static StsSearchPropertyDTO ToDtoWithRelated(this Bec.TargetFramework.Data.StsSearchProperty source, int level)
        {
            if (source == null)
              return null;

            var target = new StsSearchPropertyDTO();

            // Properties
            target.StsSearchID = source.StsSearchID;
            target.StsPropertyID = source.StsPropertyID;
            target.PropertyPrice = source.PropertyPrice;
            target.PropertyTenureID = source.PropertyTenureID;
            target.PropertySellerRelationshipTypeID = source.PropertySellerRelationshipTypeID;
            target.StsSearchPropertyID = source.StsSearchPropertyID;

            // Navigation Properties
            if (level > 0) {
              target.StsProperty = source.StsProperty.ToDtoWithRelated(level - 1);
              target.StsSearch = source.StsSearch.ToDtoWithRelated(level - 1);
              target.LRTitles = source.LRTitles.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.StsSearchProperty ToEntity(this StsSearchPropertyDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.StsSearchProperty();

            // Properties
            target.StsSearchID = source.StsSearchID;
            target.StsPropertyID = source.StsPropertyID;
            target.PropertyPrice = source.PropertyPrice;
            target.PropertyTenureID = source.PropertyTenureID;
            target.PropertySellerRelationshipTypeID = source.PropertySellerRelationshipTypeID;
            target.StsSearchPropertyID = source.StsSearchPropertyID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<StsSearchPropertyDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.StsSearchProperty> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<StsSearchPropertyDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.StsSearchProperty> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.StsSearchProperty> ToEntities(this IEnumerable<StsSearchPropertyDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.StsSearchProperty source, StsSearchPropertyDTO target);

        static partial void OnEntityCreating(StsSearchPropertyDTO source, Bec.TargetFramework.Data.StsSearchProperty target);

    }

}
