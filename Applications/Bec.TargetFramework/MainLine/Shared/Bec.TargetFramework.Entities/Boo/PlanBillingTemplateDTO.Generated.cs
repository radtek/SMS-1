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
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{

    [DataContractAttribute(IsReference=true)]
    [System.Serializable]
    public partial class PlanBillingTemplateDTO
    {
        #region Constructors
  
        public PlanBillingTemplateDTO() {
        }

        public PlanBillingTemplateDTO(global::System.Guid planTemplateID, int planTemplateVersionNumber, global::System.Guid billingTemplateID, bool isActive, bool isDeleted, bool isDefaultBilling, BillingTemplateDTO billingTemplate, PlanTemplateDTO planTemplate) {

          this.PlanTemplateID = planTemplateID;
          this.PlanTemplateVersionNumber = planTemplateVersionNumber;
          this.BillingTemplateID = billingTemplateID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsDefaultBilling = isDefaultBilling;
          this.BillingTemplate = billingTemplate;
          this.PlanTemplate = planTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid PlanTemplateID { get; set; }

        [DataMember]
        public int PlanTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid BillingTemplateID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public bool IsDefaultBilling { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public BillingTemplateDTO BillingTemplate { get; set; }

        [DataMember]
        public PlanTemplateDTO PlanTemplate { get; set; }

        #endregion
    }

}
