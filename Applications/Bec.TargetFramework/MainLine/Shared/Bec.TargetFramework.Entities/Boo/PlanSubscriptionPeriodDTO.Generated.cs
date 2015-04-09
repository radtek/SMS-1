﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:58
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
    public partial class PlanSubscriptionPeriodDTO
    {
        #region Constructors
  
        public PlanSubscriptionPeriodDTO() {
        }

        public PlanSubscriptionPeriodDTO(global::System.Guid planSubscriptionID, int planSubscriptionVersionNumber, global::System.Nullable<System.DateTime> createdOn, global::System.DateTime startDate, global::System.DateTime endDate, bool isCancellationPeriod, global::System.Nullable<int> cancellationPeriodNumber, int periodNumber, bool isTrialPeriod, global::System.Nullable<int> trialPeriodNumber, global::System.Nullable<System.DateTime> trialStartDate, global::System.Nullable<System.DateTime> trialEndDate, global::System.Nullable<System.DateTime> cancellationStartDate, global::System.Nullable<System.DateTime> cancellationEndDate, global::System.Guid planSubscriptionPeriodID, bool isActive, bool isDeleted, bool isClosed, global::System.Nullable<System.Guid> planSubscriptionBillingPeriodID, global::System.Nullable<System.DateTime> closedOn, PlanSubscriptionDTO planSubscription, List<InvoiceLineItemDTO> invoiceLineItems, PlanSubscriptionBillingProcessLogDTO planSubscriptionBillingProcessLog) {

          this.PlanSubscriptionID = planSubscriptionID;
          this.PlanSubscriptionVersionNumber = planSubscriptionVersionNumber;
          this.CreatedOn = createdOn;
          this.StartDate = startDate;
          this.EndDate = endDate;
          this.IsCancellationPeriod = isCancellationPeriod;
          this.CancellationPeriodNumber = cancellationPeriodNumber;
          this.PeriodNumber = periodNumber;
          this.IsTrialPeriod = isTrialPeriod;
          this.TrialPeriodNumber = trialPeriodNumber;
          this.TrialStartDate = trialStartDate;
          this.TrialEndDate = trialEndDate;
          this.CancellationStartDate = cancellationStartDate;
          this.CancellationEndDate = cancellationEndDate;
          this.PlanSubscriptionPeriodID = planSubscriptionPeriodID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsClosed = isClosed;
          this.PlanSubscriptionBillingPeriodID = planSubscriptionBillingPeriodID;
          this.ClosedOn = closedOn;
          this.PlanSubscription = planSubscription;
          this.InvoiceLineItems = invoiceLineItems;
          this.PlanSubscriptionBillingProcessLog = planSubscriptionBillingProcessLog;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid PlanSubscriptionID { get; set; }

        [DataMember]
        public int PlanSubscriptionVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> CreatedOn { get; set; }

        [DataMember]
        public global::System.DateTime StartDate { get; set; }

        [DataMember]
        public global::System.DateTime EndDate { get; set; }

        [DataMember]
        public bool IsCancellationPeriod { get; set; }

        [DataMember]
        public global::System.Nullable<int> CancellationPeriodNumber { get; set; }

        [DataMember]
        public int PeriodNumber { get; set; }

        [DataMember]
        public bool IsTrialPeriod { get; set; }

        [DataMember]
        public global::System.Nullable<int> TrialPeriodNumber { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> TrialStartDate { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> TrialEndDate { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> CancellationStartDate { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> CancellationEndDate { get; set; }

        [DataMember]
        public global::System.Guid PlanSubscriptionPeriodID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public bool IsClosed { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> PlanSubscriptionBillingPeriodID { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> ClosedOn { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public PlanSubscriptionDTO PlanSubscription { get; set; }

        [DataMember]
        public List<InvoiceLineItemDTO> InvoiceLineItems { get; set; }

        [DataMember]
        public PlanSubscriptionBillingProcessLogDTO PlanSubscriptionBillingProcessLog { get; set; }

        #endregion
    }

}
