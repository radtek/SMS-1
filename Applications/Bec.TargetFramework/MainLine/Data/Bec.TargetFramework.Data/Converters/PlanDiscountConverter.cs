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

    public static partial class PlanDiscountConverter
    {

        public static PlanDiscountDTO ToDto(this Bec.TargetFramework.Data.PlanDiscount source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static PlanDiscountDTO ToDtoWithRelated(this Bec.TargetFramework.Data.PlanDiscount source, int level)
        {
            if (source == null)
              return null;

            var target = new PlanDiscountDTO();

            // Properties
            target.PlanID = source.PlanID;
            target.PlanVersionNumber = source.PlanVersionNumber;
            target.DiscountID = source.DiscountID;
            target.DiscountVersionNumber = source.DiscountVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.Discount = source.Discount.ToDtoWithRelated(level - 1);
              target.Plan = source.Plan.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.PlanDiscount ToEntity(this PlanDiscountDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.PlanDiscount();

            // Properties
            target.PlanID = source.PlanID;
            target.PlanVersionNumber = source.PlanVersionNumber;
            target.DiscountID = source.DiscountID;
            target.DiscountVersionNumber = source.DiscountVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<PlanDiscountDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.PlanDiscount> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<PlanDiscountDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.PlanDiscount> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.PlanDiscount> ToEntities(this IEnumerable<PlanDiscountDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.PlanDiscount source, PlanDiscountDTO target);

        static partial void OnEntityCreating(PlanDiscountDTO source, Bec.TargetFramework.Data.PlanDiscount target);

    }

}