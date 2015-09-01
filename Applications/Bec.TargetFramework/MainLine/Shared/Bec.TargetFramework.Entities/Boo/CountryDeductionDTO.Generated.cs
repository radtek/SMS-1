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
    public partial class CountryDeductionDTO
    {
        #region Constructors
  
        public CountryDeductionDTO() {
        }

        public CountryDeductionDTO(string countryCode, global::System.Nullable<decimal> deductionPercentage, global::System.Nullable<decimal> deductionValue, bool isActive, bool isDeleted, bool isAppliedToAllOrders, global::System.Guid deductionID, global::System.Guid countryDeductionID, int deductionVersionNumber, CountryCodeDTO countryCode1, DeductionDTO deduction, List<ShoppingCartDTO> shoppingCarts) {

          this.CountryCode = countryCode;
          this.DeductionPercentage = deductionPercentage;
          this.DeductionValue = deductionValue;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsAppliedToAllOrders = isAppliedToAllOrders;
          this.DeductionID = deductionID;
          this.CountryDeductionID = countryDeductionID;
          this.DeductionVersionNumber = deductionVersionNumber;
          this.CountryCode1 = countryCode1;
          this.Deduction = deduction;
          this.ShoppingCarts = shoppingCarts;
        }

        #endregion

        #region Properties

        [DataMember]
        public string CountryCode { get; set; }

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
        public global::System.Guid DeductionID { get; set; }

        [DataMember]
        public global::System.Guid CountryDeductionID { get; set; }

        [DataMember]
        public int DeductionVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public CountryCodeDTO CountryCode1 { get; set; }

        [DataMember]
        public DeductionDTO Deduction { get; set; }

        [DataMember]
        public List<ShoppingCartDTO> ShoppingCarts { get; set; }

        #endregion
    }

}