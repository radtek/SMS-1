﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:50
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
    public partial class PlanProductTemplateDTO
    {
        #region Constructors
  
        public PlanProductTemplateDTO() {
        }

        public PlanProductTemplateDTO(global::System.Guid planTemplateID, int planTemplateVersionNumber, global::System.Guid productTemplateID, int productVersionID, int period, int periodUnitID, bool isActive, bool isDeleted, global::System.Nullable<int> planProductStatusID, PlanTemplateDTO planTemplate, ProductTemplateDTO productTemplate, List<PlanTransactionTemplateDTO> planTransactionTemplates) {

          this.PlanTemplateID = planTemplateID;
          this.PlanTemplateVersionNumber = planTemplateVersionNumber;
          this.ProductTemplateID = productTemplateID;
          this.ProductVersionID = productVersionID;
          this.Period = period;
          this.PeriodUnitID = periodUnitID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.PlanProductStatusID = planProductStatusID;
          this.PlanTemplate = planTemplate;
          this.ProductTemplate = productTemplate;
          this.PlanTransactionTemplates = planTransactionTemplates;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid PlanTemplateID { get; set; }

        [DataMember]
        public int PlanTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid ProductTemplateID { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        [DataMember]
        public int Period { get; set; }

        [DataMember]
        public int PeriodUnitID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<int> PlanProductStatusID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public PlanTemplateDTO PlanTemplate { get; set; }

        [DataMember]
        public ProductTemplateDTO ProductTemplate { get; set; }

        [DataMember]
        public List<PlanTransactionTemplateDTO> PlanTransactionTemplates { get; set; }

        #endregion
    }

}
