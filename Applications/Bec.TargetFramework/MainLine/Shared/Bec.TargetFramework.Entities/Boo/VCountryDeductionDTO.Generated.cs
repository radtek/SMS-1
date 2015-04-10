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
    public partial class VCountryDeductionDTO
    {
        #region Constructors
  
        public VCountryDeductionDTO() {
        }

        public VCountryDeductionDTO(global::System.Guid countryDeductionID, string countryCode, global::System.Guid deductionID, int deductionVersionNumber, global::System.Nullable<decimal> deductionPercentage, global::System.Nullable<decimal> deductionValue, bool isActive, bool isDeleted, bool isAppliedToAllOrders, string name, string description, bool isPercentageBased, global::System.Nullable<bool> isProductDeduction, global::System.Guid productID, int productVersionID) {

          this.CountryDeductionID = countryDeductionID;
          this.CountryCode = countryCode;
          this.DeductionID = deductionID;
          this.DeductionVersionNumber = deductionVersionNumber;
          this.DeductionPercentage = deductionPercentage;
          this.DeductionValue = deductionValue;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsAppliedToAllOrders = isAppliedToAllOrders;
          this.Name = name;
          this.Description = description;
          this.IsPercentageBased = isPercentageBased;
          this.IsProductDeduction = isProductDeduction;
          this.ProductID = productID;
          this.ProductVersionID = productVersionID;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid CountryDeductionID { get; set; }

        [DataMember]
        public string CountryCode { get; set; }

        [DataMember]
        public global::System.Guid DeductionID { get; set; }

        [DataMember]
        public int DeductionVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> DeductionPercentage { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> DeductionValue { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public bool IsAppliedToAllOrders { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool IsPercentageBased { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsProductDeduction { get; set; }

        [DataMember]
        public global::System.Guid ProductID { get; set; }

        [DataMember]
        public int ProductVersionID { get; set; }

        #endregion
    }

}
