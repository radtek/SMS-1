﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:19 AM
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
    public partial class TaxRateTemplateDTO
    {
        #region Constructors
  
        public TaxRateTemplateDTO() {
        }

        public TaxRateTemplateDTO(global::System.Guid taxRateTemplateID, int taxCategoryID, decimal taxPercentage, int countryID, bool isActive, bool isDeleted, List<TaxRateDTO> taxRates) {

          this.TaxRateTemplateID = taxRateTemplateID;
          this.TaxCategoryID = taxCategoryID;
          this.TaxPercentage = taxPercentage;
          this.CountryID = countryID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.TaxRates = taxRates;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid TaxRateTemplateID { get; set; }

        [DataMember]
        public int TaxCategoryID { get; set; }

        [DataMember]
        public decimal TaxPercentage { get; set; }

        [DataMember]
        public int CountryID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<TaxRateDTO> TaxRates { get; set; }

        #endregion
    }

}
