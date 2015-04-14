﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 13/04/2015 17:29:38
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
    public partial class ProductDeductionTemplateDTO
    {
        #region Constructors
  
        public ProductDeductionTemplateDTO() {
        }

        public ProductDeductionTemplateDTO(global::System.Guid productTemplateID, int productVersionID, global::System.Guid deductionTemplateID, global::System.Nullable<decimal> deductionPercentage, global::System.Nullable<decimal> deductionValue, bool isActive, bool isDeleted, global::System.Guid productDeductionTemplateID, int deductionTemplateVersionNumber, ProductTemplateDTO productTemplate, DeductionTemplateDTO deductionTemplate) {

          this.ProductTemplateID = productTemplateID;
          this.ProductVersionID = productVersionID;
          this.DeductionTemplateID = deductionTemplateID;
          this.DeductionPercentage = deductionPercentage;
          this.DeductionValue = deductionValue;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ProductDeductionTemplateID = productDeductionTemplateID;
          this.DeductionTemplateVersionNumber = deductionTemplateVersionNumber;
          this.ProductTemplate = productTemplate;
          this.DeductionTemplate = deductionTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductTemplateID { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        [DataMember]
        public global::System.Guid DeductionTemplateID { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> DeductionPercentage { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> DeductionValue { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid ProductDeductionTemplateID { get; set; }

        [DataMember]
        public int DeductionTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ProductTemplateDTO ProductTemplate { get; set; }

        [DataMember]
        public DeductionTemplateDTO DeductionTemplate { get; set; }

        #endregion
    }

}
