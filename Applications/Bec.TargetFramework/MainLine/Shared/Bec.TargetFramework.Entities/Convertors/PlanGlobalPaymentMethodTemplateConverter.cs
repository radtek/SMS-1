﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:55
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class PlanGlobalPaymentMethodTemplateConverter
    {

        public static PlanGlobalPaymentMethodTemplateDTO ToDto(this Bec.TargetFramework.Data.PlanGlobalPaymentMethodTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static PlanGlobalPaymentMethodTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.PlanGlobalPaymentMethodTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new PlanGlobalPaymentMethodTemplateDTO();

            // Properties
            target.PlanTemplateID = source.PlanTemplateID;
            target.PlanTemplateVersionNumber = source.PlanTemplateVersionNumber;
            target.GlobalPaymentMethodID = source.GlobalPaymentMethodID;
            target.IsDefaultPaymentMethod = source.IsDefaultPaymentMethod;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.BillingTemplateID = source.BillingTemplateID;

            // Navigation Properties
            if (level > 0) {
              target.GlobalPaymentMethod = source.GlobalPaymentMethod.ToDtoWithRelated(level - 1);
              target.PlanTemplate = source.PlanTemplate.ToDtoWithRelated(level - 1);
              target.BillingTemplate = source.BillingTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.PlanGlobalPaymentMethodTemplate ToEntity(this PlanGlobalPaymentMethodTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.PlanGlobalPaymentMethodTemplate();

            // Properties
            target.PlanTemplateID = source.PlanTemplateID;
            target.PlanTemplateVersionNumber = source.PlanTemplateVersionNumber;
            target.GlobalPaymentMethodID = source.GlobalPaymentMethodID;
            target.IsDefaultPaymentMethod = source.IsDefaultPaymentMethod;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.BillingTemplateID = source.BillingTemplateID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<PlanGlobalPaymentMethodTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.PlanGlobalPaymentMethodTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<PlanGlobalPaymentMethodTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.PlanGlobalPaymentMethodTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.PlanGlobalPaymentMethodTemplate> ToEntities(this IEnumerable<PlanGlobalPaymentMethodTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.PlanGlobalPaymentMethodTemplate source, PlanGlobalPaymentMethodTemplateDTO target);

        static partial void OnEntityCreating(PlanGlobalPaymentMethodTemplateDTO source, Bec.TargetFramework.Data.PlanGlobalPaymentMethodTemplate target);

    }

}
