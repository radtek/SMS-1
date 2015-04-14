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

    public static partial class PlanGroupConverter
    {

        public static PlanGroupDTO ToDto(this Bec.TargetFramework.Data.PlanGroup source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static PlanGroupDTO ToDtoWithRelated(this Bec.TargetFramework.Data.PlanGroup source, int level)
        {
            if (source == null)
              return null;

            var target = new PlanGroupDTO();

            // Properties
            target.PlanGroupID = source.PlanGroupID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.ParentID = source.ParentID;
            target.HasSameGlobalPaymentMethodForAllPlans = source.HasSameGlobalPaymentMethodForAllPlans;

            // Navigation Properties
            if (level > 0) {
              target.PlanTemplates = source.PlanTemplates.ToDtosWithRelated(level - 1);
              target.Plans = source.Plans.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.PlanGroup ToEntity(this PlanGroupDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.PlanGroup();

            // Properties
            target.PlanGroupID = source.PlanGroupID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.ParentID = source.ParentID;
            target.HasSameGlobalPaymentMethodForAllPlans = source.HasSameGlobalPaymentMethodForAllPlans;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<PlanGroupDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.PlanGroup> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<PlanGroupDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.PlanGroup> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.PlanGroup> ToEntities(this IEnumerable<PlanGroupDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.PlanGroup source, PlanGroupDTO target);

        static partial void OnEntityCreating(PlanGroupDTO source, Bec.TargetFramework.Data.PlanGroup target);

    }

}
