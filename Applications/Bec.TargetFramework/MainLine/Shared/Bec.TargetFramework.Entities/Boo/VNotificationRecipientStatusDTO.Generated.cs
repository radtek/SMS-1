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
    public partial class VNotificationRecipientStatusDTO
    {
        #region Constructors
  
        public VNotificationRecipientStatusDTO() {
        }

        public VNotificationRecipientStatusDTO(global::System.Guid userAccountOrganisationID, global::System.Guid notificationID, global::System.Nullable<int> notificationStatusID, global::System.Guid notificationConstructID, int notificationConstructVersionNumber, global::System.Nullable<int> notificationDeliveryMethodID, global::System.Nullable<int> notificationExportFormatID, global::System.DateTime dateSent, bool isSent, bool isActive, bool isDeleted, global::System.Nullable<bool> isAccepted, global::System.Nullable<System.DateTime> acceptedDate, global::System.Nullable<bool> isRead, global::System.DateTime createdOn, global::System.Nullable<bool> errorOccured, global::System.Nullable<System.DateTime> sentOn, string notificationVerificationCode, global::System.Guid notificationRecipientID, global::System.Guid notificationRecipientLogID, global::System.Nullable<System.Guid> organisationID, global::System.Nullable<System.Guid> recipientParent, global::System.Nullable<System.Guid> recipientToParent, global::System.Nullable<System.Guid> parentID, global::System.Nullable<System.Guid> fromParentID) {

          this.UserAccountOrganisationID = userAccountOrganisationID;
          this.NotificationID = notificationID;
          this.NotificationStatusID = notificationStatusID;
          this.NotificationConstructID = notificationConstructID;
          this.NotificationConstructVersionNumber = notificationConstructVersionNumber;
          this.NotificationDeliveryMethodID = notificationDeliveryMethodID;
          this.NotificationExportFormatID = notificationExportFormatID;
          this.DateSent = dateSent;
          this.IsSent = isSent;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsAccepted = isAccepted;
          this.AcceptedDate = acceptedDate;
          this.IsRead = isRead;
          this.CreatedOn = createdOn;
          this.ErrorOccured = errorOccured;
          this.SentOn = sentOn;
          this.NotificationVerificationCode = notificationVerificationCode;
          this.NotificationRecipientID = notificationRecipientID;
          this.NotificationRecipientLogID = notificationRecipientLogID;
          this.OrganisationID = organisationID;
          this.RecipientParent = recipientParent;
          this.RecipientToParent = recipientToParent;
          this.ParentID = parentID;
          this.FromParentID = fromParentID;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid UserAccountOrganisationID { get; set; }

        [DataMember]
        public global::System.Guid NotificationID { get; set; }

        [DataMember]
        public global::System.Nullable<int> NotificationStatusID { get; set; }

        [DataMember]
        public global::System.Guid NotificationConstructID { get; set; }

        [DataMember]
        public int NotificationConstructVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<int> NotificationDeliveryMethodID { get; set; }

        [DataMember]
        public global::System.Nullable<int> NotificationExportFormatID { get; set; }

        [DataMember]
        public global::System.DateTime DateSent { get; set; }

        [DataMember]
        public bool IsSent { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsAccepted { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> AcceptedDate { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsRead { get; set; }

        [DataMember]
        public global::System.DateTime CreatedOn { get; set; }

        [DataMember]
        public global::System.Nullable<bool> ErrorOccured { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> SentOn { get; set; }

        [DataMember]
        public string NotificationVerificationCode { get; set; }

        [DataMember]
        public global::System.Guid NotificationRecipientID { get; set; }

        [DataMember]
        public global::System.Guid NotificationRecipientLogID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> OrganisationID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> RecipientParent { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> RecipientToParent { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> FromParentID { get; set; }

        #endregion
    }

}
