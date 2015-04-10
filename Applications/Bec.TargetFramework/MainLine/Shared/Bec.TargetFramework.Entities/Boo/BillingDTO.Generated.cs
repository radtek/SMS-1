﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:55
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{

    [DataContractAttribute(IsReference=true)]
    [System.Serializable]
    public partial class BillingDTO
    {
        #region Constructors
  
        public BillingDTO() {
        }

        public BillingDTO(global::System.Guid billingID, int billingPeriod, int billingPeriodUnitID, global::System.Nullable<int> billingPeriodDayOfMonth, global::System.Nullable<int> delayedBillingPeriod, global::System.Nullable<int> delayedBillingPeriodUnitID, global::System.Nullable<bool> hasDelayedBilling, global::System.Nullable<System.Guid> billingTemplateID, global::System.Nullable<int> numberOfBillingPeriods, global::System.Nullable<int> invoiceToProcessingDelayPeriod, global::System.Nullable<int> invoiceToProcessingDelayPeriodUnitID, global::System.Nullable<System.Guid> invoiceNotificationConstructID, global::System.Nullable<int> invoiceNotificationConstructVersionNumber, global::System.Nullable<int> estimatedProcessingPeriod, global::System.Nullable<int> estimatedProcessingPeriodUnitID, bool isActive, bool isDeleted, global::System.Nullable<int> billingLagPeriod, global::System.Nullable<int> billingLagPeriodUnitID, List<PlanBillingDTO> planBillings, List<PlanGlobalPaymentMethodDTO> planGlobalPaymentMethods, List<PlanSubscriptionPaymentPlanDTO> planSubscriptionPaymentPlans, BillingTemplateDTO billingTemplate) {

          this.BillingID = billingID;
          this.BillingPeriod = billingPeriod;
          this.BillingPeriodUnitID = billingPeriodUnitID;
          this.BillingPeriodDayOfMonth = billingPeriodDayOfMonth;
          this.DelayedBillingPeriod = delayedBillingPeriod;
          this.DelayedBillingPeriodUnitID = delayedBillingPeriodUnitID;
          this.HasDelayedBilling = hasDelayedBilling;
          this.BillingTemplateID = billingTemplateID;
          this.NumberOfBillingPeriods = numberOfBillingPeriods;
          this.InvoiceToProcessingDelayPeriod = invoiceToProcessingDelayPeriod;
          this.InvoiceToProcessingDelayPeriodUnitID = invoiceToProcessingDelayPeriodUnitID;
          this.InvoiceNotificationConstructID = invoiceNotificationConstructID;
          this.InvoiceNotificationConstructVersionNumber = invoiceNotificationConstructVersionNumber;
          this.EstimatedProcessingPeriod = estimatedProcessingPeriod;
          this.EstimatedProcessingPeriodUnitID = estimatedProcessingPeriodUnitID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.BillingLagPeriod = billingLagPeriod;
          this.BillingLagPeriodUnitID = billingLagPeriodUnitID;
          this.PlanBillings = planBillings;
          this.PlanGlobalPaymentMethods = planGlobalPaymentMethods;
          this.PlanSubscriptionPaymentPlans = planSubscriptionPaymentPlans;
          this.BillingTemplate = billingTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid BillingID { get; set; }

        [DataMember]
        public int BillingPeriod { get; set; }

        [DataMember]
        public int BillingPeriodUnitID { get; set; }

        [DataMember]
        public global::System.Nullable<int> BillingPeriodDayOfMonth { get; set; }

        [DataMember]
        public global::System.Nullable<int> DelayedBillingPeriod { get; set; }

        [DataMember]
        public global::System.Nullable<int> DelayedBillingPeriodUnitID { get; set; }

        [DataMember]
        public global::System.Nullable<bool> HasDelayedBilling { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> BillingTemplateID { get; set; }

        [DataMember]
        public global::System.Nullable<int> NumberOfBillingPeriods { get; set; }

        [DataMember]
        public global::System.Nullable<int> InvoiceToProcessingDelayPeriod { get; set; }

        [DataMember]
        public global::System.Nullable<int> InvoiceToProcessingDelayPeriodUnitID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> InvoiceNotificationConstructID { get; set; }

        [DataMember]
        public global::System.Nullable<int> InvoiceNotificationConstructVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<int> EstimatedProcessingPeriod { get; set; }

        [DataMember]
        public global::System.Nullable<int> EstimatedProcessingPeriodUnitID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<int> BillingLagPeriod { get; set; }

        [DataMember]
        public global::System.Nullable<int> BillingLagPeriodUnitID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<PlanBillingDTO> PlanBillings { get; set; }

        [DataMember]
        public List<PlanGlobalPaymentMethodDTO> PlanGlobalPaymentMethods { get; set; }

        [DataMember]
        public List<PlanSubscriptionPaymentPlanDTO> PlanSubscriptionPaymentPlans { get; set; }

        [DataMember]
        public BillingTemplateDTO BillingTemplate { get; set; }

        #endregion
    }

}
