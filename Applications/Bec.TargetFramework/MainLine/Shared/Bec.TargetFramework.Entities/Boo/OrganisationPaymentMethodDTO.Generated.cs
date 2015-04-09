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
    public partial class OrganisationPaymentMethodDTO
    {
        #region Constructors
  
        public OrganisationPaymentMethodDTO() {
        }

        public OrganisationPaymentMethodDTO(global::System.Guid organisationID, global::System.Guid globalPaymentMethodID, global::System.Nullable<int> organisationBankAccountId, bool isActive, bool isDeleted, bool isDirectDebit, bool isBACS, global::System.Nullable<System.Guid> organisationDirectDebitMandateID, bool isPrimary, global::System.Guid statusTypeID, int statusTypeVersionNumber, global::System.Guid statusTypeValueID, global::System.Nullable<int> directDebitMonthCollectionPeriodNumber, global::System.Nullable<int> bACSMonthPaymentDay, global::System.Nullable<int> directDebitNumberOfNotificationDaysBeforeCollection, global::System.Nullable<int> bACSNumberOfNotificationDaysBeforeExpectationOfPayment, GlobalPaymentMethodDTO globalPaymentMethod, OrganisationBankAccountDTO organisationBankAccount, OrganisationDirectDebitMandateDTO organisationDirectDebitMandate, StatusTypeDTO statusType, StatusTypeValueDTO statusTypeValue, OrganisationDTO organisation) {

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
          this.DirectDebitMonthCollectionPeriodNumber = directDebitMonthCollectionPeriodNumber;
          this.BACSMonthPaymentDay = bACSMonthPaymentDay;
          this.DirectDebitNumberOfNotificationDaysBeforeCollection = directDebitNumberOfNotificationDaysBeforeCollection;
          this.BACSNumberOfNotificationDaysBeforeExpectationOfPayment = bACSNumberOfNotificationDaysBeforeExpectationOfPayment;
          this.GlobalPaymentMethod = globalPaymentMethod;
          this.OrganisationBankAccount = organisationBankAccount;
          this.OrganisationDirectDebitMandate = organisationDirectDebitMandate;
          this.StatusType = statusType;
          this.StatusTypeValue = statusTypeValue;
          this.Organisation = organisation;
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
        public global::System.Nullable<int> DirectDebitMonthCollectionPeriodNumber { get; set; }

        [DataMember]
        public global::System.Nullable<int> BACSMonthPaymentDay { get; set; }

        [DataMember]
        public global::System.Nullable<int> DirectDebitNumberOfNotificationDaysBeforeCollection { get; set; }

        [DataMember]
        public global::System.Nullable<int> BACSNumberOfNotificationDaysBeforeExpectationOfPayment { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public GlobalPaymentMethodDTO GlobalPaymentMethod { get; set; }

        [DataMember]
        public OrganisationBankAccountDTO OrganisationBankAccount { get; set; }

        [DataMember]
        public OrganisationDirectDebitMandateDTO OrganisationDirectDebitMandate { get; set; }

        [DataMember]
        public StatusTypeDTO StatusType { get; set; }

        [DataMember]
        public StatusTypeValueDTO StatusTypeValue { get; set; }

        [DataMember]
        public OrganisationDTO Organisation { get; set; }

        #endregion
    }

}
