﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class StsSearchDetailConverter
    {

        public static StsSearchDetailDTO ToDto(this Bec.TargetFramework.Data.StsSearchDetail source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static StsSearchDetailDTO ToDtoWithRelated(this Bec.TargetFramework.Data.StsSearchDetail source, int level)
        {
            if (source == null)
              return null;

            var target = new StsSearchDetailDTO();

            // Properties
            target.StsSearchDetailID = source.StsSearchDetailID;
            target.StsSearchID = source.StsSearchID;

            // Navigation Properties
            if (level > 0) {
              target.StsSearch = source.StsSearch.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.StsSearchDetail ToEntity(this StsSearchDetailDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.StsSearchDetail();

            // Properties
            target.StsSearchDetailID = source.StsSearchDetailID;
            target.StsSearchID = source.StsSearchID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<StsSearchDetailDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.StsSearchDetail> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<StsSearchDetailDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.StsSearchDetail> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.StsSearchDetail> ToEntities(this IEnumerable<StsSearchDetailDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.StsSearchDetail source, StsSearchDetailDTO target);

        static partial void OnEntityCreating(StsSearchDetailDTO source, Bec.TargetFramework.Data.StsSearchDetail target);

    }

}
