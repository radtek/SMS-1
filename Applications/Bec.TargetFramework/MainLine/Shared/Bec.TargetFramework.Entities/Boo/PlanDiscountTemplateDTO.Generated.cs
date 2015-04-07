﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 16:15:20
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
    public partial class PlanDiscountTemplateDTO
    {
        #region Constructors
  
        public PlanDiscountTemplateDTO() {
        }

        public PlanDiscountTemplateDTO(global::System.Guid planTemplateID, int planTemplateVersionNumber, global::System.Guid discountTemplateID, int discountTemplateVersionNumber, bool isActive, bool isDeleted, DiscountTemplateDTO discountTemplate, PlanTemplateDTO planTemplate) {

          this.PlanTemplateID = planTemplateID;
          this.PlanTemplateVersionNumber = planTemplateVersionNumber;
          this.DiscountTemplateID = discountTemplateID;
          this.DiscountTemplateVersionNumber = discountTemplateVersionNumber;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.DiscountTemplate = discountTemplate;
          this.PlanTemplate = planTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid PlanTemplateID { get; set; }

        [DataMember]
        public int PlanTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid DiscountTemplateID { get; set; }

        [DataMember]
        public int DiscountTemplateVersionNumber { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public DiscountTemplateDTO DiscountTemplate { get; set; }

        [DataMember]
        public PlanTemplateDTO PlanTemplate { get; set; }

        #endregion
    }

}
