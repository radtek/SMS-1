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

    public static partial class DefaultOrganisationPaymentMethodTemplateConverter
    {

        public static DefaultOrganisationPaymentMethodTemplateDTO ToDto(this Bec.TargetFramework.Data.DefaultOrganisationPaymentMethodTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DefaultOrganisationPaymentMethodTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DefaultOrganisationPaymentMethodTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new DefaultOrganisationPaymentMethodTemplateDTO();

            // Properties
            target.DefaultOrganisationTemplateID = source.DefaultOrganisationTemplateID;
            target.DefaultOrganisationTemplateVersionNumber = source.DefaultOrganisationTemplateVersionNumber;
            target.GlobalPaymentMethodID = source.GlobalPaymentMethodID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisationTemplate = source.DefaultOrganisationTemplate.ToDtoWithRelated(level - 1);
              target.GlobalPaymentMethod = source.GlobalPaymentMethod.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DefaultOrganisationPaymentMethodTemplate ToEntity(this DefaultOrganisationPaymentMethodTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DefaultOrganisationPaymentMethodTemplate();

            // Properties
            target.DefaultOrganisationTemplateID = source.DefaultOrganisationTemplateID;
            target.DefaultOrganisationTemplateVersionNumber = source.DefaultOrganisationTemplateVersionNumber;
            target.GlobalPaymentMethodID = source.GlobalPaymentMethodID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DefaultOrganisationPaymentMethodTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationPaymentMethodTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DefaultOrganisationPaymentMethodTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationPaymentMethodTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DefaultOrganisationPaymentMethodTemplate> ToEntities(this IEnumerable<DefaultOrganisationPaymentMethodTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DefaultOrganisationPaymentMethodTemplate source, DefaultOrganisationPaymentMethodTemplateDTO target);

        static partial void OnEntityCreating(DefaultOrganisationPaymentMethodTemplateDTO source, Bec.TargetFramework.Data.DefaultOrganisationPaymentMethodTemplate target);

    }

}
