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
    public partial class NotificationDTO
    {
        #region Constructors
  
        public NotificationDTO() {
        }

        public NotificationDTO(global::System.Guid notificationID, global::System.Nullable<System.Guid> fromParentID, global::System.DateTime dateSent, global::System.Nullable<System.Guid> parentID, global::System.Guid notificationConstructID, int notificationConstructVersionNumber, global::System.Nullable<System.Guid> moduleNotificationConstructID, global::System.Nullable<int> moduleNotificationConstructVersionNumber, bool isSent, bool isActive, bool isDeleted, bool isInternal, bool isExternal, bool isVisible, string notificationData, global::System.Nullable<int> notificationStatusID, List<NotificationRecipientDTO> notificationRecipients, NotificationConstructDTO notificationConstruct, List<InvoiceProcessLogDTO> invoiceProcessLogs, List<OrganisationDirectDebitMandateDTO> organisationDirectDebitMandates) {

          this.NotificationID = notificationID;
          this.FromParentID = fromParentID;
          this.DateSent = dateSent;
          this.ParentID = parentID;
          this.NotificationConstructID = notificationConstructID;
          this.NotificationConstructVersionNumber = notificationConstructVersionNumber;
          this.ModuleNotificationConstructID = moduleNotificationConstructID;
          this.ModuleNotificationConstructVersionNumber = moduleNotificationConstructVersionNumber;
          this.IsSent = isSent;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsInternal = isInternal;
          this.IsExternal = isExternal;
          this.IsVisible = isVisible;
          this.NotificationData = notificationData;
          this.NotificationStatusID = notificationStatusID;
          this.NotificationRecipients = notificationRecipients;
          this.NotificationConstruct = notificationConstruct;
          this.InvoiceProcessLogs = invoiceProcessLogs;
          this.OrganisationDirectDebitMandates = organisationDirectDebitMandates;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid NotificationID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> FromParentID { get; set; }

        [DataMember]
        public global::System.DateTime DateSent { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public global::System.Guid NotificationConstructID { get; set; }

        [DataMember]
        public int NotificationConstructVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ModuleNotificationConstructID { get; set; }

        [DataMember]
        public global::System.Nullable<int> ModuleNotificationConstructVersionNumber { get; set; }

        [DataMember]
        public bool IsSent { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public bool IsInternal { get; set; }

        [DataMember]
        public bool IsExternal { get; set; }

        [DataMember]
        public bool IsVisible { get; set; }

        [DataMember]
        public string NotificationData { get; set; }

        [DataMember]
        public global::System.Nullable<int> NotificationStatusID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<NotificationRecipientDTO> NotificationRecipients { get; set; }

        [DataMember]
        public NotificationConstructDTO NotificationConstruct { get; set; }

        [DataMember]
        public List<InvoiceProcessLogDTO> InvoiceProcessLogs { get; set; }

        [DataMember]
        public List<OrganisationDirectDebitMandateDTO> OrganisationDirectDebitMandates { get; set; }

        #endregion
    }

}
