﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
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
    public partial class NotificationRecipientDTO
    {
        #region Constructors
  
        public NotificationRecipientDTO() {
        }

        public NotificationRecipientDTO(global::System.Guid notificationRecipientID, global::System.Guid notificationID, global::System.Nullable<System.Guid> toParentID, global::System.Nullable<System.Guid> organisationID, bool isActive, bool isDeleted, global::System.Nullable<System.Guid> parentID, global::System.Nullable<bool> isAccepted, global::System.Nullable<System.Guid> userAccountOrganisationID, global::System.Nullable<System.DateTime> acceptedDate, NotificationDTO notification, List<NotificationRecipientLogDTO> notificationRecipientLogs, List<OrganisationDirectDebitMandateProcessLogDTO> organisationDirectDebitMandateProcessLogs, UserAccountOrganisationDTO userAccountOrganisation) {

          this.NotificationRecipientID = notificationRecipientID;
          this.NotificationID = notificationID;
          this.ToParentID = toParentID;
          this.OrganisationID = organisationID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ParentID = parentID;
          this.IsAccepted = isAccepted;
          this.UserAccountOrganisationID = userAccountOrganisationID;
          this.AcceptedDate = acceptedDate;
          this.Notification = notification;
          this.NotificationRecipientLogs = notificationRecipientLogs;
          this.OrganisationDirectDebitMandateProcessLogs = organisationDirectDebitMandateProcessLogs;
          this.UserAccountOrganisation = userAccountOrganisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid NotificationRecipientID { get; set; }

        [DataMember]
        public global::System.Guid NotificationID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ToParentID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OrganisationID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsAccepted { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> UserAccountOrganisationID { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> AcceptedDate { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public NotificationDTO Notification { get; set; }

        [DataMember]
        public List<NotificationRecipientLogDTO> NotificationRecipientLogs { get; set; }

        [DataMember]
        public List<OrganisationDirectDebitMandateProcessLogDTO> OrganisationDirectDebitMandateProcessLogs { get; set; }

        [DataMember]
        public UserAccountOrganisationDTO UserAccountOrganisation { get; set; }

        #endregion
    }

}
