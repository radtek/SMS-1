﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:14:59
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
    public partial class PlanSubscriptionDTO
    {
        #region Constructors
  
        public PlanSubscriptionDTO() {
        }

        public PlanSubscriptionDTO(global::System.Guid planSubscriptionID, int planSubscriptionVersionNumber, bool hasInfinitePeriods, int planQuantity, global::System.DateTime createdOn, string createdBy, global::System.Nullable<System.DateTime> activatedOn, global::System.Nullable<System.DateTime> cancelledOn, global::System.Nullable<int> cancelReasonID, global::System.Nullable<int> dueInvoicesCount, global::System.Nullable<System.DateTime> dueSince, global::System.Nullable<decimal> dueAmount, bool isActive, bool isDeleted, global::System.Nullable<System.Guid> parentID, global::System.Guid organisationID, bool isRenewal, global::System.Nullable<System.DateTime> renewedOn, string planSubscriptionReference, string countryCode, bool isFree, global::System.Guid planID, int planVersionNumber, global::System.Nullable<int> parentVersionNumber, List<OrganisationPlanSubscriptionDTO> organisationPlanSubscriptions, List<ModuleSubscriptionDTO> moduleSubscriptions, PlanDTO plan, CountryCodeDTO countryCode1, List<ArtefactSubscriptionDTO> artefactSubscriptions, List<PlanSubscriptionBillingProcessLogDTO> planSubscriptionBillingPeriods, List<PlanSubscriptionPaymentPlanDTO> planSubscriptionPaymentPlans, List<PlanSubscriptionProcessLogDTO> planSubscriptionProcessLogs, List<PlanSubscriptionPeriodDTO> planSubscriptionPeriods, OrganisationDTO organisation) {

          this.PlanSubscriptionID = planSubscriptionID;
          this.PlanSubscriptionVersionNumber = planSubscriptionVersionNumber;
          this.HasInfinitePeriods = hasInfinitePeriods;
          this.PlanQuantity = planQuantity;
          this.CreatedOn = createdOn;
          this.CreatedBy = createdBy;
          this.ActivatedOn = activatedOn;
          this.CancelledOn = cancelledOn;
          this.CancelReasonID = cancelReasonID;
          this.DueInvoicesCount = dueInvoicesCount;
          this.DueSince = dueSince;
          this.DueAmount = dueAmount;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ParentID = parentID;
          this.OrganisationID = organisationID;
          this.IsRenewal = isRenewal;
          this.RenewedOn = renewedOn;
          this.PlanSubscriptionReference = planSubscriptionReference;
          this.CountryCode = countryCode;
          this.IsFree = isFree;
          this.PlanID = planID;
          this.PlanVersionNumber = planVersionNumber;
          this.ParentVersionNumber = parentVersionNumber;
          this.OrganisationPlanSubscriptions = organisationPlanSubscriptions;
          this.ModuleSubscriptions = moduleSubscriptions;
          this.Plan = plan;
          this.CountryCode1 = countryCode1;
          this.ArtefactSubscriptions = artefactSubscriptions;
          this.PlanSubscriptionBillingPeriods = planSubscriptionBillingPeriods;
          this.PlanSubscriptionPaymentPlans = planSubscriptionPaymentPlans;
          this.PlanSubscriptionProcessLogs = planSubscriptionProcessLogs;
          this.PlanSubscriptionPeriods = planSubscriptionPeriods;
          this.Organisation = organisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid PlanSubscriptionID { get; set; }

        [DataMember]
        public int PlanSubscriptionVersionNumber { get; set; }

        [DataMember]
        public bool HasInfinitePeriods { get; set; }

        [DataMember]
        public int PlanQuantity { get; set; }

        [DataMember]
        public global::System.DateTime CreatedOn { get; set; }

        [DataMember]
        public string CreatedBy { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> ActivatedOn { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> CancelledOn { get; set; }

        [DataMember]
        public global::System.Nullable<int> CancelReasonID { get; set; }

        [DataMember]
        public global::System.Nullable<int> DueInvoicesCount { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> DueSince { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> DueAmount { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        [DataMember]
        public bool IsRenewal { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> RenewedOn { get; set; }

        [DataMember]
        public string PlanSubscriptionReference { get; set; }

        [DataMember]
        public string CountryCode { get; set; }

        [DataMember]
        public bool IsFree { get; set; }

        [DataMember]
        public global::System.Guid PlanID { get; set; }

        [DataMember]
        public int PlanVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<int> ParentVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<OrganisationPlanSubscriptionDTO> OrganisationPlanSubscriptions { get; set; }

        [DataMember]
        public List<ModuleSubscriptionDTO> ModuleSubscriptions { get; set; }

        [DataMember]
        public PlanDTO Plan { get; set; }

        [DataMember]
        public CountryCodeDTO CountryCode1 { get; set; }

        [DataMember]
        public List<ArtefactSubscriptionDTO> ArtefactSubscriptions { get; set; }

        [DataMember]
        public List<PlanSubscriptionBillingProcessLogDTO> PlanSubscriptionBillingPeriods { get; set; }

        [DataMember]
        public List<PlanSubscriptionPaymentPlanDTO> PlanSubscriptionPaymentPlans { get; set; }

        [DataMember]
        public List<PlanSubscriptionProcessLogDTO> PlanSubscriptionProcessLogs { get; set; }

        [DataMember]
        public List<PlanSubscriptionPeriodDTO> PlanSubscriptionPeriods { get; set; }

        [DataMember]
        public OrganisationDTO Organisation { get; set; }

        #endregion
    }

}
