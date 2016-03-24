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

    public static partial class ProductPurchaseReferenceConverter
    {

        public static ProductPurchaseReferenceDTO ToDto(this Bec.TargetFramework.Data.ProductPurchaseReference source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ProductPurchaseReferenceDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ProductPurchaseReference source, int level)
        {
            if (source == null)
              return null;

            var target = new ProductPurchaseReferenceDTO();

            // Properties
            target.ProductPurchaseReferenceID = source.ProductPurchaseReferenceID;
            target.ProductPurchaseReferenceTypeID = source.ProductPurchaseReferenceTypeID;
            target.ProductPurchaseReferenceValue = source.ProductPurchaseReferenceValue;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.InvoiceLineItemID = source.InvoiceLineItemID;

            // Navigation Properties
            if (level > 0) {
              target.InvoiceLineItem = source.InvoiceLineItem.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ProductPurchaseReference ToEntity(this ProductPurchaseReferenceDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ProductPurchaseReference();

            // Properties
            target.ProductPurchaseReferenceID = source.ProductPurchaseReferenceID;
            target.ProductPurchaseReferenceTypeID = source.ProductPurchaseReferenceTypeID;
            target.ProductPurchaseReferenceValue = source.ProductPurchaseReferenceValue;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.InvoiceLineItemID = source.InvoiceLineItemID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ProductPurchaseReferenceDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ProductPurchaseReference> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ProductPurchaseReferenceDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ProductPurchaseReference> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ProductPurchaseReference> ToEntities(this IEnumerable<ProductPurchaseReferenceDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ProductPurchaseReference source, ProductPurchaseReferenceDTO target);

        static partial void OnEntityCreating(ProductPurchaseReferenceDTO source, Bec.TargetFramework.Data.ProductPurchaseReference target);

    }

}