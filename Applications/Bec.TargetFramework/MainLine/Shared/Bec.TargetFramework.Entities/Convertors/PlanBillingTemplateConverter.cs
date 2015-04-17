﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:54
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class PlanBillingTemplateConverter
    {

        public static PlanBillingTemplateDTO ToDto(this Bec.TargetFramework.Data.PlanBillingTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static PlanBillingTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.PlanBillingTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new PlanBillingTemplateDTO();

            // Properties
            target.PlanTemplateID = source.PlanTemplateID;
            target.PlanTemplateVersionNumber = source.PlanTemplateVersionNumber;
            target.BillingTemplateID = source.BillingTemplateID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsDefaultBilling = source.IsDefaultBilling;

            // Navigation Properties
            if (level > 0) {
              target.BillingTemplate = source.BillingTemplate.ToDtoWithRelated(level - 1);
              target.PlanTemplate = source.PlanTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.PlanBillingTemplate ToEntity(this PlanBillingTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.PlanBillingTemplate();

            // Properties
            target.PlanTemplateID = source.PlanTemplateID;
            target.PlanTemplateVersionNumber = source.PlanTemplateVersionNumber;
            target.BillingTemplateID = source.BillingTemplateID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsDefaultBilling = source.IsDefaultBilling;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<PlanBillingTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.PlanBillingTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<PlanBillingTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.PlanBillingTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.PlanBillingTemplate> ToEntities(this IEnumerable<PlanBillingTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.PlanBillingTemplate source, PlanBillingTemplateDTO target);

        static partial void OnEntityCreating(PlanBillingTemplateDTO source, Bec.TargetFramework.Data.PlanBillingTemplate target);

    }

}
