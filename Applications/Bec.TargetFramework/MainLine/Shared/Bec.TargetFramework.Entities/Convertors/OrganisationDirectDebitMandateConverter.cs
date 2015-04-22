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

    public static partial class OrganisationDirectDebitMandateConverter
    {

        public static OrganisationDirectDebitMandateDTO ToDto(this Bec.TargetFramework.Data.OrganisationDirectDebitMandate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static OrganisationDirectDebitMandateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.OrganisationDirectDebitMandate source, int level)
        {
            if (source == null)
              return null;

            var target = new OrganisationDirectDebitMandateDTO();

            // Properties
            target.OrganisationID = source.OrganisationID;
            target.DirectDebitMandateID = source.DirectDebitMandateID;
            target.DirectDebitMandateVersionNumber = source.DirectDebitMandateVersionNumber;
            target.CreatedOn = source.CreatedOn;
            target.DirectDebitMandateStatusID = source.DirectDebitMandateStatusID;
            target.IsSigned = source.IsSigned;
            target.SignedOn = source.SignedOn;
            target.NotificationID = source.NotificationID;
            target.OrganisationDirectDebitMandateID = source.OrganisationDirectDebitMandateID;

            // Navigation Properties
            if (level > 0) {
              target.DirectDebitMandate = source.DirectDebitMandate.ToDtoWithRelated(level - 1);
              target.Notification = source.Notification.ToDtoWithRelated(level - 1);
              target.OrganisationPaymentMethods = source.OrganisationPaymentMethods.ToDtosWithRelated(level - 1);
              target.OrganisationDirectDebitMandateProcessLogs = source.OrganisationDirectDebitMandateProcessLogs.ToDtosWithRelated(level - 1);
              target.Organisation = source.Organisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.OrganisationDirectDebitMandate ToEntity(this OrganisationDirectDebitMandateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.OrganisationDirectDebitMandate();

            // Properties
            target.OrganisationID = source.OrganisationID;
            target.DirectDebitMandateID = source.DirectDebitMandateID;
            target.DirectDebitMandateVersionNumber = source.DirectDebitMandateVersionNumber;
            target.CreatedOn = source.CreatedOn;
            target.DirectDebitMandateStatusID = source.DirectDebitMandateStatusID;
            target.IsSigned = source.IsSigned;
            target.SignedOn = source.SignedOn;
            target.NotificationID = source.NotificationID;
            target.OrganisationDirectDebitMandateID = source.OrganisationDirectDebitMandateID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<OrganisationDirectDebitMandateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.OrganisationDirectDebitMandate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<OrganisationDirectDebitMandateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.OrganisationDirectDebitMandate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.OrganisationDirectDebitMandate> ToEntities(this IEnumerable<OrganisationDirectDebitMandateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.OrganisationDirectDebitMandate source, OrganisationDirectDebitMandateDTO target);

        static partial void OnEntityCreating(OrganisationDirectDebitMandateDTO source, Bec.TargetFramework.Data.OrganisationDirectDebitMandate target);

    }

}
