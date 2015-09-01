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

    public static partial class PlanTransactionConverter
    {

        public static PlanTransactionDTO ToDto(this Bec.TargetFramework.Data.PlanTransaction source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static PlanTransactionDTO ToDtoWithRelated(this Bec.TargetFramework.Data.PlanTransaction source, int level)
        {
            if (source == null)
              return null;

            var target = new PlanTransactionDTO();

            // Properties
            target.PlanTransactionID = source.PlanTransactionID;
            target.PlanID = source.PlanID;
            target.PlanVersionNumber = source.PlanVersionNumber;
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.IsTotalValuePricingBound = source.IsTotalValuePricingBound;
            target.IsTransactionCountPricingBound = source.IsTransactionCountPricingBound;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ParentID = source.ParentID;
            target.ApplyTransactionTierPricingPerTransaction = source.ApplyTransactionTierPricingPerTransaction;

            // Navigation Properties
            if (level > 0) {
              target.PlanProduct = source.PlanProduct.ToDtoWithRelated(level - 1);
              target.Plan = source.Plan.ToDtoWithRelated(level - 1);
              target.ComponentTiers = source.ComponentTiers.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.PlanTransaction ToEntity(this PlanTransactionDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.PlanTransaction();

            // Properties
            target.PlanTransactionID = source.PlanTransactionID;
            target.PlanID = source.PlanID;
            target.PlanVersionNumber = source.PlanVersionNumber;
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.IsTotalValuePricingBound = source.IsTotalValuePricingBound;
            target.IsTransactionCountPricingBound = source.IsTransactionCountPricingBound;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ParentID = source.ParentID;
            target.ApplyTransactionTierPricingPerTransaction = source.ApplyTransactionTierPricingPerTransaction;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<PlanTransactionDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.PlanTransaction> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<PlanTransactionDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.PlanTransaction> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.PlanTransaction> ToEntities(this IEnumerable<PlanTransactionDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.PlanTransaction source, PlanTransactionDTO target);

        static partial void OnEntityCreating(PlanTransactionDTO source, Bec.TargetFramework.Data.PlanTransaction target);

    }

}