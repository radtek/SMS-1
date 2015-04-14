﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 13/04/2015 17:29:39
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class LRTitleConverter
    {

        public static LRTitleDTO ToDto(this Bec.TargetFramework.Data.LRTitle source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static LRTitleDTO ToDtoWithRelated(this Bec.TargetFramework.Data.LRTitle source, int level)
        {
            if (source == null)
              return null;

            var target = new LRTitleDTO();

            // Properties
            target.LRTitleID = source.LRTitleID;
            target.TitleNumber = source.TitleNumber;
            target.StsPropertyID = source.StsPropertyID;
            target.Description = source.Description;
            target.CreatedOn = source.CreatedOn;
            target.CreatedBy = source.CreatedBy;
            target.ParentID = source.ParentID;
            target.ProductPurchaseProductTaskID = source.ProductPurchaseProductTaskID;
            target.StsSearchPropertyID = source.StsSearchPropertyID;
            target.LRPropertyTenureTypeID = source.LRPropertyTenureTypeID;
            target.AddressID = source.AddressID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.LRDocuments = source.LRDocuments.ToDtosWithRelated(level - 1);
              target.LRRegisterExtracts = source.LRRegisterExtracts.ToDtosWithRelated(level - 1);
              target.Address = source.Address.ToDtoWithRelated(level - 1);
              target.ProductPurchaseBusTaskProcessLog = source.ProductPurchaseBusTaskProcessLog.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.LRTitle ToEntity(this LRTitleDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.LRTitle();

            // Properties
            target.LRTitleID = source.LRTitleID;
            target.TitleNumber = source.TitleNumber;
            target.StsPropertyID = source.StsPropertyID;
            target.Description = source.Description;
            target.CreatedOn = source.CreatedOn;
            target.CreatedBy = source.CreatedBy;
            target.ParentID = source.ParentID;
            target.ProductPurchaseProductTaskID = source.ProductPurchaseProductTaskID;
            target.StsSearchPropertyID = source.StsSearchPropertyID;
            target.LRPropertyTenureTypeID = source.LRPropertyTenureTypeID;
            target.AddressID = source.AddressID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<LRTitleDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.LRTitle> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<LRTitleDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.LRTitle> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.LRTitle> ToEntities(this IEnumerable<LRTitleDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.LRTitle source, LRTitleDTO target);

        static partial void OnEntityCreating(LRTitleDTO source, Bec.TargetFramework.Data.LRTitle target);

    }

}
