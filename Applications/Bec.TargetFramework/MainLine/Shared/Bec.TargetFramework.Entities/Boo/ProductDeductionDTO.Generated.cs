﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:06 PM
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
    public partial class ProductDeductionDTO
    {
        #region Constructors
  
        public ProductDeductionDTO() {
        }

        public ProductDeductionDTO(global::System.Guid productID, int productVersionID, global::System.Guid deductionID, global::System.Nullable<decimal> deductionPercentage, global::System.Nullable<decimal> deductionValue, bool isActive, bool isDeleted, global::System.Guid productDeductionID, int deductionVersionNumber, ProductDTO product, DeductionDTO deduction) {

          this.ProductID = productID;
          this.ProductVersionID = productVersionID;
          this.DeductionID = deductionID;
          this.DeductionPercentage = deductionPercentage;
          this.DeductionValue = deductionValue;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ProductDeductionID = productDeductionID;
          this.DeductionVersionNumber = deductionVersionNumber;
          this.Product = product;
          this.Deduction = deduction;
        }

        #endregion

        #region Properties

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
        public global::System.Guid ProductDeductionID { get; set; }

        [DataMember]
        public int DeductionVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ProductDTO Product { get; set; }

        [DataMember]
        public DeductionDTO Deduction { get; set; }

        #endregion
    }

}
