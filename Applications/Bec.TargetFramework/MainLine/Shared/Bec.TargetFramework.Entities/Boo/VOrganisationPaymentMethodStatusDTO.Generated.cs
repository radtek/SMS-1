﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:15:00
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
    public partial class VOrganisationPaymentMethodStatusDTO
    {
        #region Constructors
  
        public VOrganisationPaymentMethodStatusDTO() {
        }

        public VOrganisationPaymentMethodStatusDTO(global::System.Guid organisationID, global::System.Guid globalPaymentMethodID, global::System.Nullable<int> organisationBankAccountId, bool isActive, bool isDeleted, bool isDirectDebit, bool isBACS, global::System.Nullable<System.Guid> organisationDirectDebitMandateID, bool isPrimary, global::System.Guid statusTypeID, int statusTypeVersionNumber, global::System.Guid statusTypeValueID, string paymentMethodStatus, string organisationName) {

          this.OrganisationID = organisationID;
          this.GlobalPaymentMethodID = globalPaymentMethodID;
          this.OrganisationBankAccountId = organisationBankAccountId;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsDirectDebit = isDirectDebit;
          this.IsBACS = isBACS;
          this.OrganisationDirectDebitMandateID = organisationDirectDebitMandateID;
          this.IsPrimary = isPrimary;
          this.StatusTypeID = statusTypeID;
          this.StatusTypeVersionNumber = statusTypeVersionNumber;
          this.StatusTypeValueID = statusTypeValueID;
          this.PaymentMethodStatus = paymentMethodStatus;
          this.OrganisationName = organisationName;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        [DataMember]
        public global::System.Guid GlobalPaymentMethodID { get; set; }

        [DataMember]
        public global::System.Nullable<int> OrganisationBankAccountId { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public bool IsDirectDebit { get; set; }

        [DataMember]
        public bool IsBACS { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OrganisationDirectDebitMandateID { get; set; }

        [DataMember]
        public bool IsPrimary { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeID { get; set; }

        [DataMember]
        public int StatusTypeVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeValueID { get; set; }

        [DataMember]
        public string PaymentMethodStatus { get; set; }

        [DataMember]
        public string OrganisationName { get; set; }

        #endregion
    }

}
