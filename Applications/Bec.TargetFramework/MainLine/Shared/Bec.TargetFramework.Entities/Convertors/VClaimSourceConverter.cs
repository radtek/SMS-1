﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:55
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class VClaimSourceConverter
    {

        public static VClaimSourceDTO ToDto(this Bec.TargetFramework.Data.VClaimSource source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VClaimSourceDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VClaimSource source, int level)
        {
            if (source == null)
              return null;

            var target = new VClaimSourceDTO();

            // Properties
            target.ID = source.ID;
            target.ClaimType = source.ClaimType;
            target.ClaimID = source.ClaimID;
            target.ClaimName = source.ClaimName;
            target.ClaimSubType = source.ClaimSubType;
            target.ClaimSubID = source.ClaimSubID;
            target.ClaimSubName = source.ClaimSubName;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VClaimSource ToEntity(this VClaimSourceDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VClaimSource();

            // Properties
            target.ID = source.ID;
            target.ClaimType = source.ClaimType;
            target.ClaimID = source.ClaimID;
            target.ClaimName = source.ClaimName;
            target.ClaimSubType = source.ClaimSubType;
            target.ClaimSubID = source.ClaimSubID;
            target.ClaimSubName = source.ClaimSubName;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VClaimSourceDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VClaimSource> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VClaimSourceDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VClaimSource> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VClaimSource> ToEntities(this IEnumerable<VClaimSourceDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VClaimSource source, VClaimSourceDTO target);

        static partial void OnEntityCreating(VClaimSourceDTO source, Bec.TargetFramework.Data.VClaimSource target);

    }

}
