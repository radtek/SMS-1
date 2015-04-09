﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:58
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
    public partial class PlanGlobalPaymentMethodDTO
    {
        #region Constructors
  
        public PlanGlobalPaymentMethodDTO() {
        }

        public PlanGlobalPaymentMethodDTO(global::System.Guid planID, int planVersionNumber, global::System.Guid globalPaymentMethodID, bool isDefaultPaymentMethod, bool isActive, bool isDeleted, global::System.Nullable<System.Guid> billingID, GlobalPaymentMethodDTO globalPaymentMethod, PlanDTO plan, BillingDTO billing) {

          this.PlanID = planID;
          this.PlanVersionNumber = planVersionNumber;
          this.GlobalPaymentMethodID = globalPaymentMethodID;
          this.IsDefaultPaymentMethod = isDefaultPaymentMethod;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.BillingID = billingID;
          this.GlobalPaymentMethod = globalPaymentMethod;
          this.Plan = plan;
          this.Billing = billing;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid PlanID { get; set; }

        [DataMember]
        public int PlanVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid GlobalPaymentMethodID { get; set; }

        [DataMember]
        public bool IsDefaultPaymentMethod { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> BillingID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public GlobalPaymentMethodDTO GlobalPaymentMethod { get; set; }

        [DataMember]
        public PlanDTO Plan { get; set; }

        [DataMember]
        public BillingDTO Billing { get; set; }

        #endregion
    }

}
