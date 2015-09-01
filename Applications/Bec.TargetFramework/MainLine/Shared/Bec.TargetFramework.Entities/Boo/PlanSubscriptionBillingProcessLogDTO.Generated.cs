﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
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
    public partial class PlanSubscriptionBillingProcessLogDTO
    {
        #region Constructors
  
        public PlanSubscriptionBillingProcessLogDTO() {
        }

        public PlanSubscriptionBillingProcessLogDTO(int billingPeriodNumber, global::System.Guid planSubscriptionID, int planSubscriptionVersionNumber, global::System.DateTime createdOn, global::System.Guid planSubscriptionBillingPeriodID, global::System.DateTime startDate, global::System.DateTime endDate, bool isActive, bool isDeleted, bool isClosed, global::System.Guid statusTypeID, int statusTypeVersionNumber, global::System.Guid statusTypeValueID, global::System.Nullable<System.DateTime> closedOn, PlanSubscriptionDTO planSubscription, StatusTypeDTO statusType, StatusTypeValueDTO statusTypeValue, List<PlanSubscriptionPeriodDTO> planSubscriptionPeriods) {

          this.BillingPeriodNumber = billingPeriodNumber;
          this.PlanSubscriptionID = planSubscriptionID;
          this.PlanSubscriptionVersionNumber = planSubscriptionVersionNumber;
          this.CreatedOn = createdOn;
          this.PlanSubscriptionBillingPeriodID = planSubscriptionBillingPeriodID;
          this.StartDate = startDate;
          this.EndDate = endDate;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsClosed = isClosed;
          this.StatusTypeID = statusTypeID;
          this.StatusTypeVersionNumber = statusTypeVersionNumber;
          this.StatusTypeValueID = statusTypeValueID;
          this.ClosedOn = closedOn;
          this.PlanSubscription = planSubscription;
          this.StatusType = statusType;
          this.StatusTypeValue = statusTypeValue;
          this.PlanSubscriptionPeriods = planSubscriptionPeriods;
        }

        #endregion

        #region Properties

        [DataMember]
        public int BillingPeriodNumber { get; set; }

        [DataMember]
        public global::System.Guid PlanSubscriptionID { get; set; }

        [DataMember]
        public int PlanSubscriptionVersionNumber { get; set; }

        [DataMember]
        public global::System.DateTime CreatedOn { get; set; }

        [DataMember]
        public global::System.Guid PlanSubscriptionBillingPeriodID { get; set; }

        [DataMember]
        public global::System.DateTime StartDate { get; set; }

        [DataMember]
        public global::System.DateTime EndDate { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public bool IsClosed { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeID { get; set; }

        [DataMember]
        public int StatusTypeVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeValueID { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> ClosedOn { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public PlanSubscriptionDTO PlanSubscription { get; set; }

        [DataMember]
        public StatusTypeDTO StatusType { get; set; }

        [DataMember]
        public StatusTypeValueDTO StatusTypeValue { get; set; }

        [DataMember]
        public List<PlanSubscriptionPeriodDTO> PlanSubscriptionPeriods { get; set; }

        #endregion
    }

}