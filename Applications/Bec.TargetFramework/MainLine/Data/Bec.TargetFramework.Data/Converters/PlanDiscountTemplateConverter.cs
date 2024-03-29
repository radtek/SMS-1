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

    public static partial class PlanDiscountTemplateConverter
    {

        public static PlanDiscountTemplateDTO ToDto(this Bec.TargetFramework.Data.PlanDiscountTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static PlanDiscountTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.PlanDiscountTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new PlanDiscountTemplateDTO();

            // Properties
            target.PlanTemplateID = source.PlanTemplateID;
            target.PlanTemplateVersionNumber = source.PlanTemplateVersionNumber;
            target.DiscountTemplateID = source.DiscountTemplateID;
            target.DiscountTemplateVersionNumber = source.DiscountTemplateVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.DiscountTemplate = source.DiscountTemplate.ToDtoWithRelated(level - 1);
              target.PlanTemplate = source.PlanTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.PlanDiscountTemplate ToEntity(this PlanDiscountTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.PlanDiscountTemplate();

            // Properties
            target.PlanTemplateID = source.PlanTemplateID;
            target.PlanTemplateVersionNumber = source.PlanTemplateVersionNumber;
            target.DiscountTemplateID = source.DiscountTemplateID;
            target.DiscountTemplateVersionNumber = source.DiscountTemplateVersionNumber;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<PlanDiscountTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.PlanDiscountTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<PlanDiscountTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.PlanDiscountTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.PlanDiscountTemplate> ToEntities(this IEnumerable<PlanDiscountTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.PlanDiscountTemplate source, PlanDiscountTemplateDTO target);

        static partial void OnEntityCreating(PlanDiscountTemplateDTO source, Bec.TargetFramework.Data.PlanDiscountTemplate target);

    }

}
