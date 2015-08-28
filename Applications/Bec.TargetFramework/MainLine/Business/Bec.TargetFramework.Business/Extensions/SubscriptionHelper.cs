using Bec.TargetFramework.Aop.Aspects;
using Bec.TargetFramework.Business.Logic;
using Bec.TargetFramework.Data;
using Bec.TargetFramework.Data.Infrastructure;
using Bec.TargetFramework.Entities;
using Bec.TargetFramework.Entities.Enums;
using EnsureThat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bec.TargetFramework.Infrastructure.Extensions;

namespace Bec.TargetFramework.Business
{
    public class SubscriptionHelper
    {
        public static BillingDTO GetBillingForPlan(UnitOfWorkScope<TargetFrameworkEntities> scope, Guid planID,int planVersionNumber)
        {
            var planBilling = scope.DbContext.PlanBillings.Include("Billing").Single(s => s.PlanID.Equals(planID) && s.PlanVersionNumber == planVersionNumber && s.IsActive == true && s.IsDeleted == false);

            Ensure.That(planBilling.Billing).IsNotNull();

            return BillingConverter.ToDto(planBilling.Billing);
        }

        public static BillingDTO GetBillingForPlanSubscription(UnitOfWorkScope<TargetFrameworkEntities> scope, Guid planSubscriptionID, int planSubscriptionVersionNumber)
        {
            var planBilling = scope.DbContext.PlanSubscriptionPaymentPlans.Include("Billing").Single(s => s.PlanSubscriptionID.Equals(planSubscriptionID) && s.PlanSubscriptionVersionNumber == planSubscriptionVersionNumber && s.IsActive == true && s.IsDeleted == false);

            Ensure.That(planBilling.Billing).IsNotNull();

            return BillingConverter.ToDto(planBilling.Billing);
        }

        public static bool DoesPlanSubscriptionAlreadyExist(UnitOfWorkScope<TargetFrameworkEntities> scope, Guid planID,int planVersionNumber,Guid organisationID)
        {
            return scope.DbContext.PlanSubscriptions.Any(s => s.OrganisationID.Equals(organisationID) && s.PlanID.Equals(planID) && s.PlanVersionNumber.Equals(planVersionNumber) && s.IsActive == true && s.IsDeleted == false);
        }

        public static OrganisationPaymentMethodDTO GetPaymentMethodForSubscription(UnitOfWorkScope<TargetFrameworkEntities> scope,
            Guid subscriptionID, int subscriptionVersionNumber,Guid organisationID)
        {
            var paymentPlan =
                scope.DbContext.PlanSubscriptionPaymentPlans.Single(
                    s =>
                        s.PlanSubscriptionID.Equals(subscriptionID) &&
                        s.PlanSubscriptionVersionNumber.Equals(subscriptionVersionNumber));
            return
                OrganisationPaymentMethodConverter.ToDto(
                    scope.DbContext.OrganisationPaymentMethods.Single(
                        s => s.GlobalPaymentMethodID.Equals(paymentPlan.GlobalPaymentMethodID)
                             && s.OrganisationID.Equals(organisationID)
                                                        && s.IsActive == true
                                                        && s.IsDeleted == false));
        }

        public static int GetNumberOfBillingPeriodsForSubscription(UnitOfWorkScope<TargetFrameworkEntities> scope, Guid subscriptionID, int subscriptionVersionNumber)
        {
            var statusTypeForPaidBillings = LogicHelper.GetStatusType(scope, StatusTypeEnum.PlanSubscriptionBillingProcessLog.GetStringValue(),
                PlanSubscriptionBillingStatusEnum.Paid.GetStringValue());

            return
                scope.DbContext.PlanSubscriptionBillingProcessLogs.Where(
                    s =>
                        s.PlanSubscriptionID.Equals(subscriptionID) &&
                        s.PlanSubscriptionVersionNumber.Equals(subscriptionVersionNumber)
                        && s.StatusTypeID == statusTypeForPaidBillings.StatusTypeID
                        && s.StatusTypeValueID == statusTypeForPaidBillings.StatusTypeValueID
                        && s.StatusTypeVersionNumber == statusTypeForPaidBillings.StatusTypeVersionNumber).Count();

        }

        public static PlanDTO GetPlan(UnitOfWorkScope<TargetFrameworkEntities> scope, Guid planID, int planVersionNumber)
        {
            return PlanConverter.ToDto(scope.DbContext.Plans.Single(s => s.PlanID.Equals(planID) && s.PlanVersionNumber == planVersionNumber));
        }



        public static PlanSubscriptionPaymentPlanDTO CreatePlanSubscriptionPaymentPlan(UnitOfWorkScope<TargetFrameworkEntities> scope,
            PlanSubscription subscription, Guid globalPaymentMethodID,Guid billingID)
        {
            var plan = new PlanSubscriptionPaymentPlan
            {
                GlobalPaymentMethodID = globalPaymentMethodID,
                PlanSubscriptionID = subscription.PlanSubscriptionID,
                PlanSubscriptionVersionNumber = subscription.PlanSubscriptionVersionNumber,
                BillingID = billingID
            };

            return PlanSubscriptionPaymentPlanConverter.ToDto(scope.DbContext.PlanSubscriptionPaymentPlans.Add(plan));
        }

        public static PlanSubscriptionPeriodDTO CreatePlanSubscriptionPeriod(UnitOfWorkScope<TargetFrameworkEntities> scope, PlanSubscription subscription, PlanDTO plan)
        {
            var periodId = LogicHelper.GetOrganisationCurrentAccountingPeriod(scope, subscription.OrganisationID);

            var accountingDto = LogicHelper.GetAccountingPeriodDto(scope, periodId);

            var period = new PlanSubscriptionPeriod
            {
                PlanSubscriptionPeriodID = Guid.NewGuid(),
                PlanSubscriptionID = subscription.PlanSubscriptionID,
                PlanSubscriptionVersionNumber = subscription.PlanSubscriptionVersionNumber,
                CreatedOn = DateTime.Now,
                IsCancellationPeriod = false,
                StartDate = accountingDto.AccountingPeriodStart.GetValueOrDefault(DateTime.Now),
                EndDate = accountingDto.AccountingPeriodEnd.GetValueOrDefault(DateTime.Now),
                PeriodNumber = 1,
                IsClosed = false
            };

            if (plan.TrialPeriod > 0)
            {
                period.IsTrialPeriod = true;
                period.TrialStartDate = DateTime.Now;
                period.TrialPeriodNumber = 1;

                if (plan.TrialPeriodUnitID.Equals(PeriodUnitIDEnum.Month.GetIntValue()))
                    period.TrialEndDate = period.TrialStartDate.Value.AddMonths(plan.TrialPeriod);
            }

            scope.DbContext.PlanSubscriptionPeriods.Add(period);

            return PlanSubscriptionPeriodConverter.ToDto(period);
        }

        public static void MarkPlanSubscriptionPeriodAsClosed(UnitOfWorkScope<TargetFrameworkEntities> scope,
             Guid subscriptionID, int subscriptionVersionNumber, VGlobalAccountingCurrentPeriodDTO periodDto)
        {
            var period = scope.DbContext.PlanSubscriptionPeriods.Single(s => s.PlanSubscriptionID.Equals(subscriptionID)
                                                                             &&
                                                                             s.PlanSubscriptionVersionNumber ==
                                                                             subscriptionVersionNumber
                                                                             &&
                                                                             s.StartDate >=
                                                                             periodDto.AccountingPeriodStart.Value
                                                                             &&
                                                                             s.EndDate <=
                                                                             periodDto.AccountingPeriodEnd.Value
                                                                             && s.IsClosed == false);

            period.IsClosed = true;
        }

       public static PlanSubscriptionPeriodDTO GetPlanSubscriptionPeriodForAccountingPeriod(UnitOfWorkScope<TargetFrameworkEntities> scope,
             Guid subscriptionID, int subscriptionVersionNumber, VGlobalAccountingCurrentPeriodDTO periodDto)
        {
           return PlanSubscriptionPeriodConverter.ToDto(scope.DbContext.PlanSubscriptionPeriods.Single(s => s.PlanSubscriptionID.Equals(subscriptionID)
                                                                             &&
                                                                             s.PlanSubscriptionVersionNumber ==
                                                                             subscriptionVersionNumber
                                                                             &&
                                                                             s.StartDate >=
                                                                             periodDto.AccountingPeriodStart.Value
                                                                             &&
                                                                             s.EndDate <=
                                                                             periodDto.AccountingPeriodEnd.Value));
        }

        [EnsureArgumentAspect]
        public static PlanSubscriptionPeriodDTO CreateNextPlanSubscriptionPeriodAndCloseCurrent(UnitOfWorkScope<TargetFrameworkEntities> scope, Guid subscriptionID, int subscriptionVersionNumber,
            VGlobalAccountingCurrentPeriodDTO currentPeriod, VGlobalAccountingCurrentPeriodDTO nextPeriod)
        {
            var currentSubPeriod = GetPlanSubscriptionPeriodForAccountingPeriod(scope, subscriptionID,
                subscriptionVersionNumber, currentPeriod);

            // close current period
            MarkPlanSubscriptionPeriodAsClosed(scope,subscriptionID,subscriptionVersionNumber,currentPeriod);

            // create new period
            var nextSubPeriod = new PlanSubscriptionPeriod
            {
                PlanSubscriptionPeriodID = Guid.NewGuid(),
                PlanSubscriptionID = subscriptionID,
                PlanSubscriptionVersionNumber = subscriptionVersionNumber,
                CreatedOn = DateTime.Now,
                IsCancellationPeriod = false,
                StartDate = nextPeriod.AccountingPeriodStart.GetValueOrDefault(DateTime.Now),
                EndDate = nextPeriod.AccountingPeriodEnd.GetValueOrDefault(DateTime.Now),
                PeriodNumber = currentSubPeriod.PeriodNumber++,
                IsClosed = false
            };

            if (currentSubPeriod.IsTrialPeriod && currentSubPeriod.TrialEndDate >= nextPeriod.AccountingPeriodStart)
            {
                nextSubPeriod.IsTrialPeriod = true;
                nextSubPeriod.TrialStartDate = currentSubPeriod.TrialStartDate;
                nextSubPeriod.TrialEndDate = currentSubPeriod.TrialEndDate;
                nextSubPeriod.TrialPeriodNumber = currentSubPeriod.TrialPeriodNumber++;
            }
            else
                nextSubPeriod.IsTrialPeriod = false;

            scope.DbContext.PlanSubscriptionPeriods.Add(nextSubPeriod);

            return PlanSubscriptionPeriodConverter.ToDto(nextSubPeriod);
        }

        public static void CreateSubscriptionProcessLog(UnitOfWorkScope<TargetFrameworkEntities> scope, Guid subscriptionID,int subscriptionVersionNumber,PlanSubscriptionStatusEnum subStatusEnumValue)
        {
            // set status to processing
            var statusType = LogicHelper.GetStatusType(scope, StatusTypeEnum.PlanSubscriptionProcessLog.GetStringValue(),
                subStatusEnumValue.GetStringValue());

            Ensure.That(statusType);

            PlanSubscriptionProcessLog log = new PlanSubscriptionProcessLog
            {
                PlanSubscriptionID = subscriptionID,
                PlanSubscriptionVersionNumber = subscriptionVersionNumber,
                CreatedOn = DateTime.Now,
                IsCancelled = false,
                IsRenewed = false,
                StatusTypeID = statusType.StatusTypeID,
                StatusTypeValueID = statusType.StatusTypeValueID,
                StatusTypeVersionNumber = statusType.StatusTypeVersionNumber
            };

            scope.DbContext.PlanSubscriptionProcessLogs.Add(log);
        }

        public static void CreateSubscriptionBillingProcessLog(UnitOfWorkScope<TargetFrameworkEntities> scope, Guid subscriptionID, int subscriptionVersionNumber, PlanSubscriptionBillingStatusEnum subStatusEnumValue,DateTime start,DateTime end)
        {
            // set status to processing
            var statusType = LogicHelper.GetStatusType(scope, StatusTypeEnum.PlanSubscriptionBillingProcessLog.GetStringValue(),
                subStatusEnumValue.GetStringValue());

            var numberOfPaidBillingPeriods = GetNumberOfBillingPeriodsForSubscription(scope,
                    subscriptionID, subscriptionVersionNumber);

            PlanSubscriptionBillingProcessLog log = new PlanSubscriptionBillingProcessLog
            {
                PlanSubscriptionID = subscriptionID,
                PlanSubscriptionVersionNumber = subscriptionVersionNumber,
                BillingPeriodNumber = numberOfPaidBillingPeriods++,
                CreatedOn = DateTime.Now,
                StatusTypeID = statusType.StatusTypeID,
                StatusTypeValueID = statusType.StatusTypeValueID,
                StatusTypeVersionNumber = statusType.StatusTypeVersionNumber,
                StartDate = start,
                EndDate = end
            };

            scope.DbContext.PlanSubscriptionBillingProcessLogs.Add(log);
        }

        public static int GetOrganisationCurrentAccountingPeriod(UnitOfWorkScope<TargetFrameworkEntities> scope, Guid organisationID)
        {
            var intCurrentAccountingPeriod = scope.DbContext.VGlobalAccountingCurrentPeriods.Single().GlobalAccountingPeriodID;

            return
                scope.DbContext.OrganisationAccountingPeriods.Single(
                    s => s.GlobalAccountingPeriodID.Equals(intCurrentAccountingPeriod) && s.OrganisationID.Equals(organisationID)).OrganisationAccountingPeriodID;
        }

        public static Guid GetGlobalPaymentMethodIDForOnlineTransactions(UnitOfWorkScope<TargetFrameworkEntities> scope)
        {
            return
                scope.DbContext.GlobalPaymentMethods.Single(s => s.IsDefaultForOnlinePayments == true)
                    .GlobalPaymentMethodID;
        }

        [EnsureArgumentAspect]
        public static OrganisationPaymentMethodDTO GetOrganisationPaymentMethodDtoForGlobalPaymentMethod(UnitOfWorkScope<TargetFrameworkEntities> scope, Guid organisationID, Guid paymentMethodID)
        {
            OrganisationPaymentMethodDTO dto = null;

            var pm = scope.DbContext.OrganisationPaymentMethods.Single(
                s => s.OrganisationID.Equals(organisationID) && s.GlobalPaymentMethodID.Equals(paymentMethodID));

            dto = OrganisationPaymentMethodConverter.ToDto(pm);

            return dto;
        }
    }
}
