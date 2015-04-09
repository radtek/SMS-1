﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:50:53
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class OrganisationProductPurchaseConverter
    {

        public static OrganisationProductPurchaseDTO ToDto(this Bec.TargetFramework.Data.OrganisationProductPurchase source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static OrganisationProductPurchaseDTO ToDtoWithRelated(this Bec.TargetFramework.Data.OrganisationProductPurchase source, int level)
        {
            if (source == null)
              return null;

            var target = new OrganisationProductPurchaseDTO();

            // Properties
            target.OrganisationID = source.OrganisationID;
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.InvoiceLineItemID = source.InvoiceLineItemID;

            // Navigation Properties
            if (level > 0) {
              target.Product = source.Product.ToDtoWithRelated(level - 1);
              target.InvoiceLineItem = source.InvoiceLineItem.ToDtoWithRelated(level - 1);
              target.Organisation = source.Organisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.OrganisationProductPurchase ToEntity(this OrganisationProductPurchaseDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.OrganisationProductPurchase();

            // Properties
            target.OrganisationID = source.OrganisationID;
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.InvoiceLineItemID = source.InvoiceLineItemID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<OrganisationProductPurchaseDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.OrganisationProductPurchase> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<OrganisationProductPurchaseDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.OrganisationProductPurchase> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.OrganisationProductPurchase> ToEntities(this IEnumerable<OrganisationProductPurchaseDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.OrganisationProductPurchase source, OrganisationProductPurchaseDTO target);

        static partial void OnEntityCreating(OrganisationProductPurchaseDTO source, Bec.TargetFramework.Data.OrganisationProductPurchase target);

    }

}
