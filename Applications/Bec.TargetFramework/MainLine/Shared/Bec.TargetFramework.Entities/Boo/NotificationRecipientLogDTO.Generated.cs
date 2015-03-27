﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:20 AM
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
    public partial class NotificationRecipientLogDTO
    {
        #region Constructors
  
        public NotificationRecipientLogDTO() {
        }

        public NotificationRecipientLogDTO(global::System.Guid notificationRecipientID, global::System.DateTime createdOn, global::System.Nullable<System.DateTime> sentOn, global::System.Nullable<int> notificationExportFormatID, global::System.Nullable<bool> isSent, global::System.Nullable<bool> isRead, global::System.Nullable<bool> errorOccured, global::System.Nullable<System.DateTime> dateRead, global::System.Nullable<int> notificationDeliveryMethodID, global::System.Guid notificationRecipientLogID, NotificationRecipientDTO notificationRecipient) {

          this.NotificationRecipientID = notificationRecipientID;
          this.CreatedOn = createdOn;
          this.SentOn = sentOn;
          this.NotificationExportFormatID = notificationExportFormatID;
          this.IsSent = isSent;
          this.IsRead = isRead;
          this.ErrorOccured = errorOccured;
          this.DateRead = dateRead;
          this.NotificationDeliveryMethodID = notificationDeliveryMethodID;
          this.NotificationRecipientLogID = notificationRecipientLogID;
          this.NotificationRecipient = notificationRecipient;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid NotificationRecipientID { get; set; }

        [DataMember]
        public global::System.DateTime CreatedOn { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> SentOn { get; set; }

        [DataMember]
        public global::System.Nullable<int> NotificationExportFormatID { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsSent { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsRead { get; set; }

        [DataMember]
        public global::System.Nullable<bool> ErrorOccured { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> DateRead { get; set; }

        [DataMember]
        public global::System.Nullable<int> NotificationDeliveryMethodID { get; set; }

        [DataMember]
        public global::System.Guid NotificationRecipientLogID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public NotificationRecipientDTO NotificationRecipient { get; set; }

        #endregion
    }

}
