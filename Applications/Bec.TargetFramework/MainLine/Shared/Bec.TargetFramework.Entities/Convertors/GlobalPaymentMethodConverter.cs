﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 18/03/2015 19:00:46
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class GlobalPaymentMethodConverter
    {

        public static GlobalPaymentMethodDTO ToDto(this Bec.TargetFramework.Data.GlobalPaymentMethod source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static GlobalPaymentMethodDTO ToDtoWithRelated(this Bec.TargetFramework.Data.GlobalPaymentMethod source, int level)
        {
            if (source == null)
              return null;

            var target = new GlobalPaymentMethodDTO();

            // Properties
            target.GlobalPaymentMethodID = source.GlobalPaymentMethodID;
            target.Name = source.Name;
            target.PaymentMethodID = source.PaymentMethodID;
            target.IsDefaultForOnlinePayments = source.IsDefaultForOnlinePayments;
            target.IsDefaultForOfflinePayments = source.IsDefaultForOfflinePayments;
            target.DirectDebitMandateID = source.DirectDebitMandateID;
            target.DirectDebitMandateVersionNumber = source.DirectDebitMandateVersionNumber;
            target.IsDirectDebit = source.IsDirectDebit;
            target.DirectDebitDefaultMonthlyPeriodNumber = source.DirectDebitDefaultMonthlyPeriodNumber;
            target.DirectDebitMaxDaysAwaitingCollectionFromMonthPeriodNumber = source.DirectDebitMaxDaysAwaitingCollectionFromMonthPeriodNumber;
            target.BACSDefaultMonthlyPaymentDay = source.BACSDefaultMonthlyPaymentDay;
            target.BACSMaxDaysAwaitingPaymentFromMonthlyPaymentDay = source.BACSMaxDaysAwaitingPaymentFromMonthlyPaymentDay;
            target.DirectDebitDefaultNumberOfNotificationDaysBeforeCollection = source.DirectDebitDefaultNumberOfNotificationDaysBeforeCollection;
            target.BACSDefaultNumberOfNotificationDaysBeforeExpectationOfPayment = source.BACSDefaultNumberOfNotificationDaysBeforeExpectationOfPayment;
            target.Description = source.Description;

            // Navigation Properties
            if (level > 0) {
              target.PlanGlobalPaymentMethods = source.PlanGlobalPaymentMethods.ToDtosWithRelated(level - 1);
              target.PlanGlobalPaymentMethodTemplates = source.PlanGlobalPaymentMethodTemplates.ToDtosWithRelated(level - 1);
              target.PlanSubscriptionPaymentPlans = source.PlanSubscriptionPaymentPlans.ToDtosWithRelated(level - 1);
              target.TransactionOrders = source.TransactionOrders.ToDtosWithRelated(level - 1);
              target.ShoppingCarts = source.ShoppingCarts.ToDtosWithRelated(level - 1);
              target.OrganisationPaymentMethods = source.OrganisationPaymentMethods.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationPaymentMethods = source.DefaultOrganisationPaymentMethods.ToDtosWithRelated(level - 1);
              target.DefaultOrganisationPaymentMethodTemplates = source.DefaultOrganisationPaymentMethodTemplates.ToDtosWithRelated(level - 1);
              target.DirectDebitMandate = source.DirectDebitMandate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.GlobalPaymentMethod ToEntity(this GlobalPaymentMethodDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.GlobalPaymentMethod();

            // Properties
            target.GlobalPaymentMethodID = source.GlobalPaymentMethodID;
            target.Name = source.Name;
            target.PaymentMethodID = source.PaymentMethodID;
            target.IsDefaultForOnlinePayments = source.IsDefaultForOnlinePayments;
            target.IsDefaultForOfflinePayments = source.IsDefaultForOfflinePayments;
            target.DirectDebitMandateID = source.DirectDebitMandateID;
            target.DirectDebitMandateVersionNumber = source.DirectDebitMandateVersionNumber;
            target.IsDirectDebit = source.IsDirectDebit;
            target.DirectDebitDefaultMonthlyPeriodNumber = source.DirectDebitDefaultMonthlyPeriodNumber;
            target.DirectDebitMaxDaysAwaitingCollectionFromMonthPeriodNumber = source.DirectDebitMaxDaysAwaitingCollectionFromMonthPeriodNumber;
            target.BACSDefaultMonthlyPaymentDay = source.BACSDefaultMonthlyPaymentDay;
            target.BACSMaxDaysAwaitingPaymentFromMonthlyPaymentDay = source.BACSMaxDaysAwaitingPaymentFromMonthlyPaymentDay;
            target.DirectDebitDefaultNumberOfNotificationDaysBeforeCollection = source.DirectDebitDefaultNumberOfNotificationDaysBeforeCollection;
            target.BACSDefaultNumberOfNotificationDaysBeforeExpectationOfPayment = source.BACSDefaultNumberOfNotificationDaysBeforeExpectationOfPayment;
            target.Description = source.Description;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<GlobalPaymentMethodDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.GlobalPaymentMethod> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<GlobalPaymentMethodDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.GlobalPaymentMethod> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.GlobalPaymentMethod> ToEntities(this IEnumerable<GlobalPaymentMethodDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.GlobalPaymentMethod source, GlobalPaymentMethodDTO target);

        static partial void OnEntityCreating(GlobalPaymentMethodDTO source, Bec.TargetFramework.Data.GlobalPaymentMethod target);

    }

}
