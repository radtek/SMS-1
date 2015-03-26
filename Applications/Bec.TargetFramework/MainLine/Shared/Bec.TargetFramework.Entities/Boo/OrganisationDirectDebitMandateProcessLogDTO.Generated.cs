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
    public partial class OrganisationDirectDebitMandateProcessLogDTO
    {
        #region Constructors
  
        public OrganisationDirectDebitMandateProcessLogDTO() {
        }

        public OrganisationDirectDebitMandateProcessLogDTO(global::System.Guid organisationDirectDebitMandateID, global::System.Guid notificationRecipientID, global::System.DateTime createdOn, global::System.Guid statusTypeID, int statusTypeVersionNumber, global::System.Guid statusTypeValueID, NotificationRecipientDTO notificationRecipient, OrganisationDirectDebitMandateDTO organisationDirectDebitMandate, StatusTypeDTO statusType, StatusTypeValueDTO statusTypeValue) {

          this.OrganisationDirectDebitMandateID = organisationDirectDebitMandateID;
          this.NotificationRecipientID = notificationRecipientID;
          this.CreatedOn = createdOn;
          this.StatusTypeID = statusTypeID;
          this.StatusTypeVersionNumber = statusTypeVersionNumber;
          this.StatusTypeValueID = statusTypeValueID;
          this.NotificationRecipient = notificationRecipient;
          this.OrganisationDirectDebitMandate = organisationDirectDebitMandate;
          this.StatusType = statusType;
          this.StatusTypeValue = statusTypeValue;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid OrganisationDirectDebitMandateID { get; set; }

        [DataMember]
        public global::System.Guid NotificationRecipientID { get; set; }

        [DataMember]
        public global::System.DateTime CreatedOn { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeID { get; set; }

        [DataMember]
        public int StatusTypeVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeValueID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public NotificationRecipientDTO NotificationRecipient { get; set; }

        [DataMember]
        public OrganisationDirectDebitMandateDTO OrganisationDirectDebitMandate { get; set; }

        [DataMember]
        public StatusTypeDTO StatusType { get; set; }

        [DataMember]
        public StatusTypeValueDTO StatusTypeValue { get; set; }

        #endregion
    }

}
