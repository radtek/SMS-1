﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:53
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
    public partial class VProductDeductionDTO
    {
        #region Constructors
  
        public VProductDeductionDTO() {
        }

        public VProductDeductionDTO(global::System.Guid productDeductionID, global::System.Guid productID, int productVersionID, global::System.Guid deductionID, global::System.Nullable<decimal> deductionPercentage, global::System.Nullable<decimal> deductionValue, bool isActive, bool isDeleted, string name, string description, bool isPercentageBased, int deductionVersionNumber) {

          this.ProductDeductionID = productDeductionID;
          this.ProductID = productID;
          this.ProductVersionID = productVersionID;
          this.DeductionID = deductionID;
          this.DeductionPercentage = deductionPercentage;
          this.DeductionValue = deductionValue;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.Name = name;
          this.Description = description;
          this.IsPercentageBased = isPercentageBased;
          this.DeductionVersionNumber = deductionVersionNumber;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ProductDeductionID { get; set; }

        [DataMember]
        public global::System.Guid ProductID { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        [DataMember]
        public global::System.Guid DeductionID { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> DeductionPercentage { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> DeductionValue { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool IsPercentageBased { get; set; }

        [DataMember]
        public int DeductionVersionNumber { get; set; }

        #endregion
    }

}
