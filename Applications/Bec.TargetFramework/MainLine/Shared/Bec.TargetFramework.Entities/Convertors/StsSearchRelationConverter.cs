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

    public static partial class StsSearchRelationConverter
    {

        public static StsSearchRelationDTO ToDto(this Bec.TargetFramework.Data.StsSearchRelation source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static StsSearchRelationDTO ToDtoWithRelated(this Bec.TargetFramework.Data.StsSearchRelation source, int level)
        {
            if (source == null)
              return null;

            var target = new StsSearchRelationDTO();

            // Properties
            target.BuyerStsSearchID = source.BuyerStsSearchID;
            target.SellerStsSearchID = source.SellerStsSearchID;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.IsCancelled = source.IsCancelled;
            target.IsClosed = source.IsClosed;

            // Navigation Properties
            if (level > 0) {
              target.StsSearch_BuyerStsSearchID = source.StsSearch_BuyerStsSearchID.ToDtoWithRelated(level - 1);
              target.StsSearch_SellerStsSearchID = source.StsSearch_SellerStsSearchID.ToDtoWithRelated(level - 1);
              target.StatusType = source.StatusType.ToDtoWithRelated(level - 1);
              target.StatusTypeValue = source.StatusTypeValue.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.StsSearchRelation ToEntity(this StsSearchRelationDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.StsSearchRelation();

            // Properties
            target.BuyerStsSearchID = source.BuyerStsSearchID;
            target.SellerStsSearchID = source.SellerStsSearchID;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.IsCancelled = source.IsCancelled;
            target.IsClosed = source.IsClosed;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<StsSearchRelationDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.StsSearchRelation> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<StsSearchRelationDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.StsSearchRelation> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.StsSearchRelation> ToEntities(this IEnumerable<StsSearchRelationDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.StsSearchRelation source, StsSearchRelationDTO target);

        static partial void OnEntityCreating(StsSearchRelationDTO source, Bec.TargetFramework.Data.StsSearchRelation target);

    }

}
