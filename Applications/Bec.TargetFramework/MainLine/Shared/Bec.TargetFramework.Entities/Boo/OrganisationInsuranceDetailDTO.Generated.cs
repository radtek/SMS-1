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
    public partial class OrganisationInsuranceDetailDTO
    {
        #region Constructors
  
        public OrganisationInsuranceDetailDTO() {
        }

        public OrganisationInsuranceDetailDTO(global::System.Nullable<System.Guid> organisationID, global::System.Nullable<int> insuranceProviderID, string insuranceProviderName, global::System.Nullable<int> insuranceTypeID, string policyNumber, global::System.Nullable<System.DateTime> policyRenewalDate, bool isActive, bool isDeleted, OrganisationDTO organisation) {

          this.OrganisationID = organisationID;
          this.InsuranceProviderID = insuranceProviderID;
          this.InsuranceProviderName = insuranceProviderName;
          this.InsuranceTypeID = insuranceTypeID;
          this.PolicyNumber = policyNumber;
          this.PolicyRenewalDate = policyRenewalDate;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.Organisation = organisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Nullable<System.Guid> OrganisationID { get; set; }

        [DataMember]
        public global::System.Nullable<int> InsuranceProviderID { get; set; }

        [DataMember]
        public string InsuranceProviderName { get; set; }

        [DataMember]
        public global::System.Nullable<int> InsuranceTypeID { get; set; }

        [DataMember]
        public string PolicyNumber { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> PolicyRenewalDate { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public OrganisationDTO Organisation { get; set; }

        #endregion
    }

}
