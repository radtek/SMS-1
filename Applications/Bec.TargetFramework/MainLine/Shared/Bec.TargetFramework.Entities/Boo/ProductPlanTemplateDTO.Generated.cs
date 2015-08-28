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
    public partial class ProductPlanTemplateDTO
    {
        #region Constructors
  
        public ProductPlanTemplateDTO() {
        }

        public ProductPlanTemplateDTO(global::System.Guid productTemplateID, int productVersionID, global::System.Guid planTemplateID, int planTemplateVersionNumber, bool isActive, bool isDeleted, PlanTemplateDTO planTemplate, ProductTemplateDTO productTemplate) {

          this.ProductTemplateID = productTemplateID;
          this.ProductVersionID = productVersionID;
          this.PlanTemplateID = planTemplateID;
          this.PlanTemplateVersionNumber = planTemplateVersionNumber;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.PlanTemplate = planTemplate;
          this.ProductTemplate = productTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductTemplateID { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        [DataMember]
        public global::System.Guid PlanTemplateID { get; set; }

        [DataMember]
        public int PlanTemplateVersionNumber { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public PlanTemplateDTO PlanTemplate { get; set; }

        [DataMember]
        public ProductTemplateDTO ProductTemplate { get; set; }

        #endregion
    }

}
