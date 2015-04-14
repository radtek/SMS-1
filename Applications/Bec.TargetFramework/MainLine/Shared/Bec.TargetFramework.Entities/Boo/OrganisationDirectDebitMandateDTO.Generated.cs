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
    public partial class OrganisationDirectDebitMandateDTO
    {
        #region Constructors
  
        public OrganisationDirectDebitMandateDTO() {
        }

        public OrganisationDirectDebitMandateDTO(global::System.Guid organisationID, global::System.Guid directDebitMandateID, int directDebitMandateVersionNumber, global::System.DateTime createdOn, int directDebitMandateStatusID, bool isSigned, global::System.Nullable<System.DateTime> signedOn, global::System.Nullable<System.Guid> notificationID, global::System.Guid organisationDirectDebitMandateID, DirectDebitMandateDTO directDebitMandate, NotificationDTO notification, List<OrganisationPaymentMethodDTO> organisationPaymentMethods, List<OrganisationDirectDebitMandateProcessLogDTO> organisationDirectDebitMandateProcessLogs, OrganisationDTO organisation) {

          this.OrganisationID = organisationID;
          this.DirectDebitMandateID = directDebitMandateID;
          this.DirectDebitMandateVersionNumber = directDebitMandateVersionNumber;
          this.CreatedOn = createdOn;
          this.DirectDebitMandateStatusID = directDebitMandateStatusID;
          this.IsSigned = isSigned;
          this.SignedOn = signedOn;
          this.NotificationID = notificationID;
          this.OrganisationDirectDebitMandateID = organisationDirectDebitMandateID;
          this.DirectDebitMandate = directDebitMandate;
          this.Notification = notification;
          this.OrganisationPaymentMethods = organisationPaymentMethods;
          this.OrganisationDirectDebitMandateProcessLogs = organisationDirectDebitMandateProcessLogs;
          this.Organisation = organisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        [DataMember]
        public global::System.Guid DirectDebitMandateID { get; set; }

        [DataMember]
        public int DirectDebitMandateVersionNumber { get; set; }

        [DataMember]
        public global::System.DateTime CreatedOn { get; set; }

        [DataMember]
        public int DirectDebitMandateStatusID { get; set; }

        [DataMember]
        public bool IsSigned { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> SignedOn { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> NotificationID { get; set; }

        [DataMember]
        public global::System.Guid OrganisationDirectDebitMandateID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public DirectDebitMandateDTO DirectDebitMandate { get; set; }

        [DataMember]
        public NotificationDTO Notification { get; set; }

        [DataMember]
        public List<OrganisationPaymentMethodDTO> OrganisationPaymentMethods { get; set; }

        [DataMember]
        public List<OrganisationDirectDebitMandateProcessLogDTO> OrganisationDirectDebitMandateProcessLogs { get; set; }

        [DataMember]
        public OrganisationDTO Organisation { get; set; }

        #endregion
    }

}
