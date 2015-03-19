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

    public static partial class PlanProductConverter
    {

        public static PlanProductDTO ToDto(this Bec.TargetFramework.Data.PlanProduct source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static PlanProductDTO ToDtoWithRelated(this Bec.TargetFramework.Data.PlanProduct source, int level)
        {
            if (source == null)
              return null;

            var target = new PlanProductDTO();

            // Properties
            target.PlanID = source.PlanID;
            target.PlanVersionNumber = source.PlanVersionNumber;
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.Period = source.Period;
            target.PeriodUnitID = source.PeriodUnitID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.PlanProductStatusID = source.PlanProductStatusID;

            // Navigation Properties
            if (level > 0) {
              target.Plan = source.Plan.ToDtoWithRelated(level - 1);
              target.Product = source.Product.ToDtoWithRelated(level - 1);
              target.PlanTransactions = source.PlanTransactions.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.PlanProduct ToEntity(this PlanProductDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.PlanProduct();

            // Properties
            target.PlanID = source.PlanID;
            target.PlanVersionNumber = source.PlanVersionNumber;
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.Period = source.Period;
            target.PeriodUnitID = source.PeriodUnitID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.PlanProductStatusID = source.PlanProductStatusID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<PlanProductDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.PlanProduct> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<PlanProductDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.PlanProduct> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.PlanProduct> ToEntities(this IEnumerable<PlanProductDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.PlanProduct source, PlanProductDTO target);

        static partial void OnEntityCreating(PlanProductDTO source, Bec.TargetFramework.Data.PlanProduct target);

    }

}
