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

    public static partial class FnGetUserClaimResultConverter
    {

        public static FnGetUserClaimResultDTO ToDto(this Bec.TargetFramework.Data.FnGetUserClaimResult source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static FnGetUserClaimResultDTO ToDtoWithRelated(this Bec.TargetFramework.Data.FnGetUserClaimResult source, int level)
        {
            if (source == null)
              return null;

            var target = new FnGetUserClaimResultDTO();

            // Properties
            target.ClaimType = source.ClaimType;
            target.ClaimName = source.ClaimName;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.FnGetUserClaimResult ToEntity(this FnGetUserClaimResultDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.FnGetUserClaimResult();

            // Properties
            target.ClaimType = source.ClaimType;
            target.ClaimName = source.ClaimName;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<FnGetUserClaimResultDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.FnGetUserClaimResult> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<FnGetUserClaimResultDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.FnGetUserClaimResult> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.FnGetUserClaimResult> ToEntities(this IEnumerable<FnGetUserClaimResultDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.FnGetUserClaimResult source, FnGetUserClaimResultDTO target);

        static partial void OnEntityCreating(FnGetUserClaimResultDTO source, Bec.TargetFramework.Data.FnGetUserClaimResult target);

    }

}
