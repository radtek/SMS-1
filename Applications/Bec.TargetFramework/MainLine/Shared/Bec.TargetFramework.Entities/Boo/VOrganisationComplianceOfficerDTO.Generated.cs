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
    public partial class VOrganisationComplianceOfficerDTO
    {
        #region Constructors
  
        public VOrganisationComplianceOfficerDTO() {
        }

        public VOrganisationComplianceOfficerDTO(global::System.Guid organisationID, string cOEmail, string cOFirstName, string cOLastName, string companyName, string tradingName, string branchName, global::System.Nullable<int> branchRegulatorID, string branchRegulator, string branchRegulatorNumber, bool isActive, bool isDeleted) {

          this.OrganisationID = organisationID;
          this.COEmail = cOEmail;
          this.COFirstName = cOFirstName;
          this.COLastName = cOLastName;
          this.CompanyName = companyName;
          this.TradingName = tradingName;
          this.BranchName = branchName;
          this.BranchRegulatorID = branchRegulatorID;
          this.BranchRegulator = branchRegulator;
          this.BranchRegulatorNumber = branchRegulatorNumber;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        [DataMember]
        public string COEmail { get; set; }

        [DataMember]
        public string COFirstName { get; set; }

        [DataMember]
        public string COLastName { get; set; }

        [DataMember]
        public string CompanyName { get; set; }

        [DataMember]
        public string TradingName { get; set; }

        [DataMember]
        public string BranchName { get; set; }

        [DataMember]
        public global::System.Nullable<int> BranchRegulatorID { get; set; }

        [DataMember]
        public string BranchRegulator { get; set; }

        [DataMember]
        public string BranchRegulatorNumber { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion
    }

}
