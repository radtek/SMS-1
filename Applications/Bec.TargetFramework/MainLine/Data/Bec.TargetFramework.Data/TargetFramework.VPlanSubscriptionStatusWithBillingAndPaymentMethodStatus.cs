﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 07/04/2015 16:15:16
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Bec.TargetFramework.Data
{

    /// <summary>
    /// There are no comments for Bec.TargetFramework.Data.VPlanSubscriptionStatusWithBillingAndPaymentMethodStatus in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VPlanSubscriptionStatusWithBillingAndPaymentMethodStatus    {

        public VPlanSubscriptionStatusWithBillingAndPaymentMethodStatus()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for PlanSubscriptionID in the schema.
        /// </summary>
        public virtual global::System.Guid PlanSubscriptionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanSubscriptionVersionNumber in the schema.
        /// </summary>
        public virtual int PlanSubscriptionVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for HasInfinitePeriods in the schema.
        /// </summary>
        public virtual bool HasInfinitePeriods
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanQuantity in the schema.
        /// </summary>
        public virtual int PlanQuantity
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CreatedOn in the schema.
        /// </summary>
        public virtual global::System.DateTime CreatedOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CreatedBy in the schema.
        /// </summary>
        public virtual string CreatedBy
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ActivatedOn in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> ActivatedOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CancelledOn in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> CancelledOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CancelReasonID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> CancelReasonID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DueInvoicesCount in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> DueInvoicesCount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DueSince in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> DueSince
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DueAmount in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> DueAmount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsActive in the schema.
        /// </summary>
        public virtual bool IsActive
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsDeleted in the schema.
        /// </summary>
        public virtual bool IsDeleted
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsFree in the schema.
        /// </summary>
        public virtual bool IsFree
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationID in the schema.
        /// </summary>
        public virtual global::System.Guid OrganisationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsRenewal in the schema.
        /// </summary>
        public virtual bool IsRenewal
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RenewedOn in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> RenewedOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanSubscriptionReference in the schema.
        /// </summary>
        public virtual string PlanSubscriptionReference
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanName in the schema.
        /// </summary>
        public virtual string PlanName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceName in the schema.
        /// </summary>
        public virtual string InvoiceName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Price in the schema.
        /// </summary>
        public virtual decimal Price
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Period in the schema.
        /// </summary>
        public virtual int Period
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanID in the schema.
        /// </summary>
        public virtual global::System.Guid PlanID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanVersionNumber in the schema.
        /// </summary>
        public virtual int PlanVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TrialPeriod in the schema.
        /// </summary>
        public virtual int TrialPeriod
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PeriodUnitID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> PeriodUnitID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TrialPeriodUnitID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> TrialPeriodUnitID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FreeQuantity in the schema.
        /// </summary>
        public virtual int FreeQuantity
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SetupCost in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> SetupCost
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DowngradePenalty in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> DowngradePenalty
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CountryCode in the schema.
        /// </summary>
        public virtual string CountryCode
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CurrencyCode in the schema.
        /// </summary>
        public virtual string CurrencyCode
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CancellationPeriod in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> CancellationPeriod
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CancellationPeriodUnitID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> CancellationPeriodUnitID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanStatusID in the schema.
        /// </summary>
        public virtual int PlanStatusID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsTransactionBased in the schema.
        /// </summary>
        public virtual bool IsTransactionBased
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CoolOffPeriod in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> CoolOffPeriod
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CoolOffPeriodUnitID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> CoolOffPeriodUnitID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RenewalPrice in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> RenewalPrice
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RenewalPercentage in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> RenewalPercentage
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RenewalIsPercentageOfOriginalPrice in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> RenewalIsPercentageOfOriginalPrice
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for HasForwardCycleFee in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> HasForwardCycleFee
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ForwardCycleFee in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> ForwardCycleFee
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ForwardCycleFreeIsSameAsPrice in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> ForwardCycleFreeIsSameAsPrice
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RenewalOfferPeriod in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> RenewalOfferPeriod
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RenewalOfferPeriodUnitID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> RenewalOfferPeriodUnitID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ForwardCycleFeePeriod in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ForwardCycleFeePeriod
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ForwardCycleFeePeriodUnitID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ForwardCycleFeePeriodUnitID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for HasRenewalOffer in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> HasRenewalOffer
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PriceDailyProRata in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> PriceDailyProRata
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsAutoRenew in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsAutoRenew
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AutoRenewDecisionPeriod in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> AutoRenewDecisionPeriod
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AutoRenewDecisionUnitID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> AutoRenewDecisionUnitID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AutoRenewPeriod in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> AutoRenewPeriod
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AutoRenewPeriodUnitID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> AutoRenewPeriodUnitID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanGroupID in the schema.
        /// </summary>
        public virtual int PlanGroupID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> PlanTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanCategoryID in the schema.
        /// </summary>
        public virtual int PlanCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BillingID in the schema.
        /// </summary>
        public virtual global::System.Guid BillingID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for GlobalPaymentMethodID in the schema.
        /// </summary>
        public virtual global::System.Guid GlobalPaymentMethodID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanSubscriptionStatus in the schema.
        /// </summary>
        public virtual string PlanSubscriptionStatus
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanSubscriptionStatusTypeName in the schema.
        /// </summary>
        public virtual string PlanSubscriptionStatusTypeName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanSubscriptionStatusOrder in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> PlanSubscriptionStatusOrder
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanSubscriptionStatusTypeValueID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> PlanSubscriptionStatusTypeValueID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanSubscriptionStatusTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> PlanSubscriptionStatusTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanSubscriptionStatusTypeVersionNumber in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> PlanSubscriptionStatusTypeVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanSubscriptionStatusIsStart in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> PlanSubscriptionStatusIsStart
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanSubscriptionStatusIsEnd in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> PlanSubscriptionStatusIsEnd
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsCancelled in the schema.
        /// </summary>
        public virtual bool IsCancelled
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsRenewed in the schema.
        /// </summary>
        public virtual bool IsRenewed
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanSubscriptionStatusCreatedOn in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> PlanSubscriptionStatusCreatedOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanSubscriptionStatusDetail in the schema.
        /// </summary>
        public virtual string PlanSubscriptionStatusDetail
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Name in the schema.
        /// </summary>
        public virtual string Name
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationBankAccountId in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> OrganisationBankAccountId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsDirectDebit in the schema.
        /// </summary>
        public virtual bool IsDirectDebit
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsBACS in the schema.
        /// </summary>
        public virtual bool IsBACS
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationDirectDebitMandateID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> OrganisationDirectDebitMandateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsPrimary in the schema.
        /// </summary>
        public virtual bool IsPrimary
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DirectDebitMonthCollectionPeriodNumber in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> DirectDebitMonthCollectionPeriodNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BACSMonthPaymentDay in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> BACSMonthPaymentDay
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DirectDebitNumberOfNotificationDaysBeforeCollection in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> DirectDebitNumberOfNotificationDaysBeforeCollection
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BACSNumberOfNotificationDaysBeforeExpectationOfPayment in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> BACSNumberOfNotificationDaysBeforeExpectationOfPayment
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationPaymentMethodStatus in the schema.
        /// </summary>
        public virtual string OrganisationPaymentMethodStatus
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationPaymentMethodStatusTypeName in the schema.
        /// </summary>
        public virtual string OrganisationPaymentMethodStatusTypeName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationPaymentMethodStatusOrder in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> OrganisationPaymentMethodStatusOrder
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationPaymentMethodStatusTypeValueID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> OrganisationPaymentMethodStatusTypeValueID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationPaymentMethodStatusTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> OrganisationPaymentMethodStatusTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationPaymentMethodStatusTypeVersionNumber in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> OrganisationPaymentMethodStatusTypeVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationPaymentMethodStatusIsStart in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> OrganisationPaymentMethodStatusIsStart
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationPaymentMethodStatusIsEnd in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> OrganisationPaymentMethodStatusIsEnd
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BillingPeriod in the schema.
        /// </summary>
        public virtual int BillingPeriod
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BillingPeriodUnitID in the schema.
        /// </summary>
        public virtual int BillingPeriodUnitID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BillingLagPeriod in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> BillingLagPeriod
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BillingLagPeriodUnitID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> BillingLagPeriodUnitID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BillingPeriodDayOfMonth in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> BillingPeriodDayOfMonth
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DelayedBillingPeriod in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> DelayedBillingPeriod
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DelayedBillingPeriodUnitID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> DelayedBillingPeriodUnitID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for HasDelayedBilling in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> HasDelayedBilling
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NumberOfBillingPeriods in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> NumberOfBillingPeriods
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceToProcessingDelayPeriod in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> InvoiceToProcessingDelayPeriod
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceToProcessingDelayPeriodUnitID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> InvoiceToProcessingDelayPeriodUnitID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceNotificationConstructID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> InvoiceNotificationConstructID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceNotificationConstructVersionNumber in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> InvoiceNotificationConstructVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for EstimatedProcessingPeriod in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> EstimatedProcessingPeriod
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for EstimatedProcessingPeriodUnitID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> EstimatedProcessingPeriodUnitID
        {
            get;
            set;
        }


        #endregion
    }

}
