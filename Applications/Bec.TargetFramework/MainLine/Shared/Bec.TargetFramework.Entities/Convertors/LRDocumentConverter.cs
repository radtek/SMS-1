﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:54
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class LRDocumentConverter
    {

        public static LRDocumentDTO ToDto(this Bec.TargetFramework.Data.LRDocument source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static LRDocumentDTO ToDtoWithRelated(this Bec.TargetFramework.Data.LRDocument source, int level)
        {
            if (source == null)
              return null;

            var target = new LRDocumentDTO();

            // Properties
            target.LRDocumentID = source.LRDocumentID;
            target.LRTitleID = source.LRTitleID;
            target.AttachmentID = source.AttachmentID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ProductPurchaseProductTaskID = source.ProductPurchaseProductTaskID;

            // Navigation Properties
            if (level > 0) {
              target.LRTitle = source.LRTitle.ToDtoWithRelated(level - 1);
              target.Attachment = source.Attachment.ToDtoWithRelated(level - 1);
              target.ProductPurchaseBusTaskProcessLog = source.ProductPurchaseBusTaskProcessLog.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.LRDocument ToEntity(this LRDocumentDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.LRDocument();

            // Properties
            target.LRDocumentID = source.LRDocumentID;
            target.LRTitleID = source.LRTitleID;
            target.AttachmentID = source.AttachmentID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ProductPurchaseProductTaskID = source.ProductPurchaseProductTaskID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<LRDocumentDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.LRDocument> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<LRDocumentDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.LRDocument> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.LRDocument> ToEntities(this IEnumerable<LRDocumentDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.LRDocument source, LRDocumentDTO target);

        static partial void OnEntityCreating(LRDocumentDTO source, Bec.TargetFramework.Data.LRDocument target);

    }

}
