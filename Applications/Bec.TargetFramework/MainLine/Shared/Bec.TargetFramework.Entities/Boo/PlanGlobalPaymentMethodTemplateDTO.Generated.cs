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
    public partial class PlanGlobalPaymentMethodTemplateDTO
    {
        #region Constructors
  
        public PlanGlobalPaymentMethodTemplateDTO() {
        }

        public PlanGlobalPaymentMethodTemplateDTO(global::System.Guid planTemplateID, int planTemplateVersionNumber, global::System.Guid globalPaymentMethodID, bool isDefaultPaymentMethod, bool isActive, bool isDeleted, global::System.Nullable<System.Guid> billingTemplateID, GlobalPaymentMethodDTO globalPaymentMethod, PlanTemplateDTO planTemplate, BillingTemplateDTO billingTemplate) {

          this.PlanTemplateID = planTemplateID;
          this.PlanTemplateVersionNumber = planTemplateVersionNumber;
          this.GlobalPaymentMethodID = globalPaymentMethodID;
          this.IsDefaultPaymentMethod = isDefaultPaymentMethod;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.BillingTemplateID = billingTemplateID;
          this.GlobalPaymentMethod = globalPaymentMethod;
          this.PlanTemplate = planTemplate;
          this.BillingTemplate = billingTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid PlanTemplateID { get; set; }

        [DataMember]
        public int PlanTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid GlobalPaymentMethodID { get; set; }

        [DataMember]
        public bool IsDefaultPaymentMethod { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> BillingTemplateID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public GlobalPaymentMethodDTO GlobalPaymentMethod { get; set; }

        [DataMember]
        public PlanTemplateDTO PlanTemplate { get; set; }

        [DataMember]
        public BillingTemplateDTO BillingTemplate { get; set; }

        #endregion
    }

}