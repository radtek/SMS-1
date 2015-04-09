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
    public partial class VOrganisationFinancialStatusDTO
    {
        #region Constructors
  
        public VOrganisationFinancialStatusDTO() {
        }

        public VOrganisationFinancialStatusDTO(global::System.Guid organisationFinancialDetailID, global::System.Nullable<System.Guid> financialStatusTypeID, global::System.Nullable<int> financialStatusTypeVersionNumber, global::System.Nullable<System.Guid> financialStatusTypeValueID, bool hasACreditLimit, global::System.Nullable<decimal> creditLimit, int numberOfLatePayments, bool hasLatePayments, global::System.Guid organisationID, string name, string financialStatus) {

          this.OrganisationFinancialDetailID = organisationFinancialDetailID;
          this.FinancialStatusTypeID = financialStatusTypeID;
          this.FinancialStatusTypeVersionNumber = financialStatusTypeVersionNumber;
          this.FinancialStatusTypeValueID = financialStatusTypeValueID;
          this.HasACreditLimit = hasACreditLimit;
          this.CreditLimit = creditLimit;
          this.NumberOfLatePayments = numberOfLatePayments;
          this.HasLatePayments = hasLatePayments;
          this.OrganisationID = organisationID;
          this.Name = name;
          this.FinancialStatus = financialStatus;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid OrganisationFinancialDetailID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> FinancialStatusTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> FinancialStatusTypeVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> FinancialStatusTypeValueID { get; set; }

        [DataMember]
        public bool HasACreditLimit { get; set; }

        [DataMember]
        public global::System.Nullable<decimal> CreditLimit { get; set; }

        [DataMember]
        public int NumberOfLatePayments { get; set; }

        [DataMember]
        public bool HasLatePayments { get; set; }

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string FinancialStatus { get; set; }

        #endregion
    }

}
