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

    public static partial class ProductPlanConverter
    {

        public static ProductPlanDTO ToDto(this Bec.TargetFramework.Data.ProductPlan source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ProductPlanDTO ToDtoWithRelated(this Bec.TargetFramework.Data.ProductPlan source, int level)
        {
            if (source == null)
              return null;

            var target = new ProductPlanDTO();

            // Properties
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.PlanID = source.PlanID;
            target.PlanVersionNumber = source.PlanVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.Plan = source.Plan.ToDtoWithRelated(level - 1);
              target.Product = source.Product.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.ProductPlan ToEntity(this ProductPlanDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.ProductPlan();

            // Properties
            target.ProductID = source.ProductID;
            target.ProductVersionID = source.ProductVersionID;
            target.PlanID = source.PlanID;
            target.PlanVersionNumber = source.PlanVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ProductPlanDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.ProductPlan> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ProductPlanDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.ProductPlan> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.ProductPlan> ToEntities(this IEnumerable<ProductPlanDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.ProductPlan source, ProductPlanDTO target);

        static partial void OnEntityCreating(ProductPlanDTO source, Bec.TargetFramework.Data.ProductPlan target);

    }

}
