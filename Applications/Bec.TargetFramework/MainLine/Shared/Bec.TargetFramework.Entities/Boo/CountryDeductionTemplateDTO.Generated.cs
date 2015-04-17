﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:54
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
    public partial class CountryDeductionTemplateDTO
    {
        #region Constructors
  
        public CountryDeductionTemplateDTO() {
        }

        public CountryDeductionTemplateDTO(global::System.Guid deductionTemplateID, string countryCode, global::System.Nullable<decimal> deductionPercentage, global::System.Nullable<decimal> deductionValue, bool isActive, bool isDeleted, bool isAppliedToAllOrders, global::System.Guid countryDeductionTemplateID, int deductionTemplateVersionNumber, CountryCodeDTO countryCode1, DeductionTemplateDTO deductionTemplate) {

          this.DeductionTemplateID = deductionTemplateID;
          this.CountryCode = countryCode;
          this.DeductionPercentage = deductionPercentage;
          this.DeductionValue = deductionValue;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsAppliedToAllOrders = isAppliedToAllOrders;
          this.CountryDeductionTemplateID = countryDeductionTemplateID;
          this.DeductionTemplateVersionNumber = deductionTemplateVersionNumber;
          this.CountryCode1 = countryCode1;
          this.DeductionTemplate = deductionTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DeductionTemplateID { get; set; }

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
        public global::System.Guid CountryDeductionTemplateID { get; set; }

        [DataMember]
        public int DeductionTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public CountryCodeDTO CountryCode1 { get; set; }

        [DataMember]
        public DeductionTemplateDTO DeductionTemplate { get; set; }

        #endregion
    }

}
