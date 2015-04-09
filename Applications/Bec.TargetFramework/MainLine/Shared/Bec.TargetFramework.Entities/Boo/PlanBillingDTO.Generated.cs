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
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{

    [DataContractAttribute(IsReference=true)]
    [System.Serializable]
    public partial class PlanBillingDTO
    {
        #region Constructors
  
        public PlanBillingDTO() {
        }

        public PlanBillingDTO(global::System.Guid planID, int planVersionNumber, global::System.Guid billingID, bool isActive, bool isDeleted, bool isDefaultBilling, BillingDTO billing, PlanDTO plan) {

          this.PlanID = planID;
          this.PlanVersionNumber = planVersionNumber;
          this.BillingID = billingID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsDefaultBilling = isDefaultBilling;
          this.Billing = billing;
          this.Plan = plan;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid PlanID { get; set; }

        [DataMember]
        public int PlanVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid BillingID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public bool IsDefaultBilling { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public BillingDTO Billing { get; set; }

        [DataMember]
        public PlanDTO Plan { get; set; }

        #endregion
    }

}
