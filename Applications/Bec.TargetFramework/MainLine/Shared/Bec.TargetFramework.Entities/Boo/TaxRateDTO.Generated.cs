﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:50:53
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
    public partial class TaxRateDTO
    {
        #region Constructors
  
        public TaxRateDTO() {
        }

        public TaxRateDTO(global::System.Guid organisationTaxRateID, global::System.Guid taxRateTemplateID, int taxCategoryID, decimal taxPercentage, bool isActive, bool isDeleted, TaxRateTemplateDTO taxRateTemplate) {

          this.OrganisationTaxRateID = organisationTaxRateID;
          this.TaxRateTemplateID = taxRateTemplateID;
          this.TaxCategoryID = taxCategoryID;
          this.TaxPercentage = taxPercentage;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.TaxRateTemplate = taxRateTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid OrganisationTaxRateID { get; set; }

        [DataMember]
        public global::System.Guid TaxRateTemplateID { get; set; }

        [DataMember]
        public int TaxCategoryID { get; set; }

        [DataMember]
        public decimal TaxPercentage { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public TaxRateTemplateDTO TaxRateTemplate { get; set; }

        #endregion
    }

}
