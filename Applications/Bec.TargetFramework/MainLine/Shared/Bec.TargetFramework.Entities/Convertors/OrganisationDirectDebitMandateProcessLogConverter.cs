﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:50:53
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class OrganisationDirectDebitMandateProcessLogConverter
    {

        public static OrganisationDirectDebitMandateProcessLogDTO ToDto(this Bec.TargetFramework.Data.OrganisationDirectDebitMandateProcessLog source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static OrganisationDirectDebitMandateProcessLogDTO ToDtoWithRelated(this Bec.TargetFramework.Data.OrganisationDirectDebitMandateProcessLog source, int level)
        {
            if (source == null)
              return null;

            var target = new OrganisationDirectDebitMandateProcessLogDTO();

            // Properties
            target.OrganisationDirectDebitMandateID = source.OrganisationDirectDebitMandateID;
            target.NotificationRecipientID = source.NotificationRecipientID;
            target.CreatedOn = source.CreatedOn;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.StatusTypeValueID = source.StatusTypeValueID;

            // Navigation Properties
            if (level > 0) {
              target.NotificationRecipient = source.NotificationRecipient.ToDtoWithRelated(level - 1);
              target.OrganisationDirectDebitMandate = source.OrganisationDirectDebitMandate.ToDtoWithRelated(level - 1);
              target.StatusType = source.StatusType.ToDtoWithRelated(level - 1);
              target.StatusTypeValue = source.StatusTypeValue.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.OrganisationDirectDebitMandateProcessLog ToEntity(this OrganisationDirectDebitMandateProcessLogDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.OrganisationDirectDebitMandateProcessLog();

            // Properties
            target.OrganisationDirectDebitMandateID = source.OrganisationDirectDebitMandateID;
            target.NotificationRecipientID = source.NotificationRecipientID;
            target.CreatedOn = source.CreatedOn;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.StatusTypeValueID = source.StatusTypeValueID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<OrganisationDirectDebitMandateProcessLogDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.OrganisationDirectDebitMandateProcessLog> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<OrganisationDirectDebitMandateProcessLogDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.OrganisationDirectDebitMandateProcessLog> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.OrganisationDirectDebitMandateProcessLog> ToEntities(this IEnumerable<OrganisationDirectDebitMandateProcessLogDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.OrganisationDirectDebitMandateProcessLog source, OrganisationDirectDebitMandateProcessLogDTO target);

        static partial void OnEntityCreating(OrganisationDirectDebitMandateProcessLogDTO source, Bec.TargetFramework.Data.OrganisationDirectDebitMandateProcessLog target);

    }

}
