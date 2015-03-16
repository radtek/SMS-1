﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:07 PM
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
    public partial class VNotificationWithUAOVerificationCodeDTO
    {
        #region Constructors
  
        public VNotificationWithUAOVerificationCodeDTO() {
        }

        public VNotificationWithUAOVerificationCodeDTO(global::System.Guid userAccountOrganisationID, global::System.Guid notificationID, global::System.Guid notificationConstructID, int notificationConstructVersionNumber, string groupName, string groupDescription, string notificationConstructName, string notificationConstructSubject, string notificationConstructTitle, global::System.DateTime dateSent, bool isSent, bool isActive, bool isDeleted, global::System.Nullable<bool> isAccepted, global::System.Nullable<System.DateTime> acceptedDate, global::System.Guid userTypeID, int organisationTypeID, global::System.Nullable<bool> isRead, global::System.DateTime createdOn, global::System.Nullable<bool> errorOccured, global::System.Nullable<System.DateTime> sentOn, string notificationVerificationCode) {

          this.UserAccountOrganisationID = userAccountOrganisationID;
          this.NotificationID = notificationID;
          this.NotificationConstructID = notificationConstructID;
          this.NotificationConstructVersionNumber = notificationConstructVersionNumber;
          this.GroupName = groupName;
          this.GroupDescription = groupDescription;
          this.NotificationConstructName = notificationConstructName;
          this.NotificationConstructSubject = notificationConstructSubject;
          this.NotificationConstructTitle = notificationConstructTitle;
          this.DateSent = dateSent;
          this.IsSent = isSent;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsAccepted = isAccepted;
          this.AcceptedDate = acceptedDate;
          this.UserTypeID = userTypeID;
          this.OrganisationTypeID = organisationTypeID;
          this.IsRead = isRead;
          this.CreatedOn = createdOn;
          this.ErrorOccured = errorOccured;
          this.SentOn = sentOn;
          this.NotificationVerificationCode = notificationVerificationCode;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid UserAccountOrganisationID { get; set; }

        [DataMember]
        public global::System.Guid NotificationID { get; set; }

        [DataMember]
        public global::System.Guid NotificationConstructID { get; set; }

        [DataMember]
        public int NotificationConstructVersionNumber { get; set; }

        [DataMember]
        public string GroupName { get; set; }

        [DataMember]
        public string GroupDescription { get; set; }

        [DataMember]
        public string NotificationConstructName { get; set; }

        [DataMember]
        public string NotificationConstructSubject { get; set; }

        [DataMember]
        public string NotificationConstructTitle { get; set; }

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
        public global::System.Guid UserTypeID { get; set; }

        [DataMember]
        public int OrganisationTypeID { get; set; }

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

        #endregion
    }

}
