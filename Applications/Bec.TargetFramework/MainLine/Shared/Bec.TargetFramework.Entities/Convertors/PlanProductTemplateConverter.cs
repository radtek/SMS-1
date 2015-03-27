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

    public static partial class PlanProductTemplateConverter
    {

        public static PlanProductTemplateDTO ToDto(this Bec.TargetFramework.Data.PlanProductTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static PlanProductTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.PlanProductTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new PlanProductTemplateDTO();

            // Properties
            target.PlanTemplateID = source.PlanTemplateID;
            target.PlanTemplateVersionNumber = source.PlanTemplateVersionNumber;
            target.ProductTemplateID = source.ProductTemplateID;
            target.ProductVersionID = source.ProductVersionID;
            target.Period = source.Period;
            target.PeriodUnitID = source.PeriodUnitID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.PlanProductStatusID = source.PlanProductStatusID;

            // Navigation Properties
            if (level > 0) {
              target.PlanTemplate = source.PlanTemplate.ToDtoWithRelated(level - 1);
              target.ProductTemplate = source.ProductTemplate.ToDtoWithRelated(level - 1);
              target.PlanTransactionTemplates = source.PlanTransactionTemplates.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.PlanProductTemplate ToEntity(this PlanProductTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.PlanProductTemplate();

            // Properties
            target.PlanTemplateID = source.PlanTemplateID;
            target.PlanTemplateVersionNumber = source.PlanTemplateVersionNumber;
            target.ProductTemplateID = source.ProductTemplateID;
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

        public static List<PlanProductTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.PlanProductTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<PlanProductTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.PlanProductTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.PlanProductTemplate> ToEntities(this IEnumerable<PlanProductTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.PlanProductTemplate source, PlanProductTemplateDTO target);

        static partial void OnEntityCreating(PlanProductTemplateDTO source, Bec.TargetFramework.Data.PlanProductTemplate target);

    }

}
