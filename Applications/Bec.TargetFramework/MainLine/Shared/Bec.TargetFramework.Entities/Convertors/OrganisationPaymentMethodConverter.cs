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

    public static partial class OrganisationPaymentMethodConverter
    {

        public static OrganisationPaymentMethodDTO ToDto(this Bec.TargetFramework.Data.OrganisationPaymentMethod source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static OrganisationPaymentMethodDTO ToDtoWithRelated(this Bec.TargetFramework.Data.OrganisationPaymentMethod source, int level)
        {
            if (source == null)
              return null;

            var target = new OrganisationPaymentMethodDTO();

            // Properties
            target.OrganisationID = source.OrganisationID;
            target.GlobalPaymentMethodID = source.GlobalPaymentMethodID;
            target.OrganisationBankAccountId = source.OrganisationBankAccountId;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsDirectDebit = source.IsDirectDebit;
            target.IsBACS = source.IsBACS;
            target.OrganisationDirectDebitMandateID = source.OrganisationDirectDebitMandateID;
            target.IsPrimary = source.IsPrimary;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.DirectDebitMonthCollectionPeriodNumber = source.DirectDebitMonthCollectionPeriodNumber;
            target.BACSMonthPaymentDay = source.BACSMonthPaymentDay;
            target.DirectDebitNumberOfNotificationDaysBeforeCollection = source.DirectDebitNumberOfNotificationDaysBeforeCollection;
            target.BACSNumberOfNotificationDaysBeforeExpectationOfPayment = source.BACSNumberOfNotificationDaysBeforeExpectationOfPayment;

            // Navigation Properties
            if (level > 0) {
              target.GlobalPaymentMethod = source.GlobalPaymentMethod.ToDtoWithRelated(level - 1);
              target.OrganisationBankAccount = source.OrganisationBankAccount.ToDtoWithRelated(level - 1);
              target.OrganisationDirectDebitMandate = source.OrganisationDirectDebitMandate.ToDtoWithRelated(level - 1);
              target.StatusType = source.StatusType.ToDtoWithRelated(level - 1);
              target.StatusTypeValue = source.StatusTypeValue.ToDtoWithRelated(level - 1);
              target.Organisation = source.Organisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.OrganisationPaymentMethod ToEntity(this OrganisationPaymentMethodDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.OrganisationPaymentMethod();

            // Properties
            target.OrganisationID = source.OrganisationID;
            target.GlobalPaymentMethodID = source.GlobalPaymentMethodID;
            target.OrganisationBankAccountId = source.OrganisationBankAccountId;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsDirectDebit = source.IsDirectDebit;
            target.IsBACS = source.IsBACS;
            target.OrganisationDirectDebitMandateID = source.OrganisationDirectDebitMandateID;
            target.IsPrimary = source.IsPrimary;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.DirectDebitMonthCollectionPeriodNumber = source.DirectDebitMonthCollectionPeriodNumber;
            target.BACSMonthPaymentDay = source.BACSMonthPaymentDay;
            target.DirectDebitNumberOfNotificationDaysBeforeCollection = source.DirectDebitNumberOfNotificationDaysBeforeCollection;
            target.BACSNumberOfNotificationDaysBeforeExpectationOfPayment = source.BACSNumberOfNotificationDaysBeforeExpectationOfPayment;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<OrganisationPaymentMethodDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.OrganisationPaymentMethod> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<OrganisationPaymentMethodDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.OrganisationPaymentMethod> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.OrganisationPaymentMethod> ToEntities(this IEnumerable<OrganisationPaymentMethodDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.OrganisationPaymentMethod source, OrganisationPaymentMethodDTO target);

        static partial void OnEntityCreating(OrganisationPaymentMethodDTO source, Bec.TargetFramework.Data.OrganisationPaymentMethod target);

    }

}
