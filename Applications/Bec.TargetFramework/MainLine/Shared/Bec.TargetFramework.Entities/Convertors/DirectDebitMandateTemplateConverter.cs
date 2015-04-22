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

    public static partial class DirectDebitMandateTemplateConverter
    {

        public static DirectDebitMandateTemplateDTO ToDto(this Bec.TargetFramework.Data.DirectDebitMandateTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DirectDebitMandateTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DirectDebitMandateTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new DirectDebitMandateTemplateDTO();

            // Properties
            target.DirectDebitMandateTemplateID = source.DirectDebitMandateTemplateID;
            target.DirectDebitMandateTemplateVersionNumber = source.DirectDebitMandateTemplateVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.NotificationConstructTemplateID = source.NotificationConstructTemplateID;
            target.NotificationConstructTemplateVersionNumber = source.NotificationConstructTemplateVersionNumber;
            target.IsDefaultMandate = source.IsDefaultMandate;

            // Navigation Properties
            if (level > 0) {
              target.DirectDebitMandates = source.DirectDebitMandates.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DirectDebitMandateTemplate ToEntity(this DirectDebitMandateTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DirectDebitMandateTemplate();

            // Properties
            target.DirectDebitMandateTemplateID = source.DirectDebitMandateTemplateID;
            target.DirectDebitMandateTemplateVersionNumber = source.DirectDebitMandateTemplateVersionNumber;
            target.Name = source.Name;
            target.Description = source.Description;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.NotificationConstructTemplateID = source.NotificationConstructTemplateID;
            target.NotificationConstructTemplateVersionNumber = source.NotificationConstructTemplateVersionNumber;
            target.IsDefaultMandate = source.IsDefaultMandate;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DirectDebitMandateTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DirectDebitMandateTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DirectDebitMandateTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DirectDebitMandateTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DirectDebitMandateTemplate> ToEntities(this IEnumerable<DirectDebitMandateTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DirectDebitMandateTemplate source, DirectDebitMandateTemplateDTO target);

        static partial void OnEntityCreating(DirectDebitMandateTemplateDTO source, Bec.TargetFramework.Data.DirectDebitMandateTemplate target);

    }

}
