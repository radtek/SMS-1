﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:20 AM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class LRRegisterExtractConverter
    {

        public static LRRegisterExtractDTO ToDto(this Bec.TargetFramework.Data.LRRegisterExtract source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static LRRegisterExtractDTO ToDtoWithRelated(this Bec.TargetFramework.Data.LRRegisterExtract source, int level)
        {
            if (source == null)
              return null;

            var target = new LRRegisterExtractDTO();

            // Properties
            target.LRRegisterExtractID = source.LRRegisterExtractID;
            target.LRTitleID = source.LRTitleID;
            target.RegisterExtractData = source.RegisterExtractData;
            target.CreatedOn = source.CreatedOn;
            target.CreatedBy = source.CreatedBy;
            target.ProductPurchaseProductTaskID = source.ProductPurchaseProductTaskID;

            // Navigation Properties
            if (level > 0) {
              target.LRTitle = source.LRTitle.ToDtoWithRelated(level - 1);
              target.ProductPurchaseBusTaskProcessLog = source.ProductPurchaseBusTaskProcessLog.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.LRRegisterExtract ToEntity(this LRRegisterExtractDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.LRRegisterExtract();

            // Properties
            target.LRRegisterExtractID = source.LRRegisterExtractID;
            target.LRTitleID = source.LRTitleID;
            target.RegisterExtractData = source.RegisterExtractData;
            target.CreatedOn = source.CreatedOn;
            target.CreatedBy = source.CreatedBy;
            target.ProductPurchaseProductTaskID = source.ProductPurchaseProductTaskID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<LRRegisterExtractDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.LRRegisterExtract> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<LRRegisterExtractDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.LRRegisterExtract> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.LRRegisterExtract> ToEntities(this IEnumerable<LRRegisterExtractDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.LRRegisterExtract source, LRRegisterExtractDTO target);

        static partial void OnEntityCreating(LRRegisterExtractDTO source, Bec.TargetFramework.Data.LRRegisterExtract target);

    }

}
