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

    public static partial class DirectDebitMandateConverter
    {

        public static DirectDebitMandateDTO ToDto(this Bec.TargetFramework.Data.DirectDebitMandate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DirectDebitMandateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DirectDebitMandate source, int level)
        {
            if (source == null)
              return null;

            var target = new DirectDebitMandateDTO();

            // Properties
            target.DirectDebitMandateID = source.DirectDebitMandateID;
            target.DirectDebitMandateVersionNumber = source.DirectDebitMandateVersionNumber;
            target.NotificationConstructID = source.NotificationConstructID;
            target.NotificationConstructVersionNumber = source.NotificationConstructVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.DirectDebitMandateTemplateID = source.DirectDebitMandateTemplateID;
            target.DirectDebitMandateTemplateVersionNumber = source.DirectDebitMandateTemplateVersionNumber;
            target.IsDefaultMandate = source.IsDefaultMandate;

            // Navigation Properties
            if (level > 0) {
              target.DirectDebitMandateTemplate = source.DirectDebitMandateTemplate.ToDtoWithRelated(level - 1);
              target.OrganisationDirectDebitMandates = source.OrganisationDirectDebitMandates.ToDtosWithRelated(level - 1);
              target.GlobalPaymentMethods = source.GlobalPaymentMethods.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DirectDebitMandate ToEntity(this DirectDebitMandateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DirectDebitMandate();

            // Properties
            target.DirectDebitMandateID = source.DirectDebitMandateID;
            target.DirectDebitMandateVersionNumber = source.DirectDebitMandateVersionNumber;
            target.NotificationConstructID = source.NotificationConstructID;
            target.NotificationConstructVersionNumber = source.NotificationConstructVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.DirectDebitMandateTemplateID = source.DirectDebitMandateTemplateID;
            target.DirectDebitMandateTemplateVersionNumber = source.DirectDebitMandateTemplateVersionNumber;
            target.IsDefaultMandate = source.IsDefaultMandate;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DirectDebitMandateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DirectDebitMandate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DirectDebitMandateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DirectDebitMandate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DirectDebitMandate> ToEntities(this IEnumerable<DirectDebitMandateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DirectDebitMandate source, DirectDebitMandateDTO target);

        static partial void OnEntityCreating(DirectDebitMandateDTO source, Bec.TargetFramework.Data.DirectDebitMandate target);

    }

}
