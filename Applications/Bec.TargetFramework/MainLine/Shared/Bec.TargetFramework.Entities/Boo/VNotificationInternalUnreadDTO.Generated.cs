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
    public partial class VNotificationInternalUnreadDTO
    {
        #region Constructors
  
        public VNotificationInternalUnreadDTO() {
        }

        public VNotificationInternalUnreadDTO(global::System.Guid notificationID, global::System.Guid notificationRecipientID, global::System.DateTime dateSent, string notificationData, global::System.Guid notificationConstructID, int notificationConstructVersionNumber, string name, string notificationSubject, global::System.Guid userID) {

          this.NotificationID = notificationID;
          this.NotificationRecipientID = notificationRecipientID;
          this.DateSent = dateSent;
          this.NotificationData = notificationData;
          this.NotificationConstructID = notificationConstructID;
          this.NotificationConstructVersionNumber = notificationConstructVersionNumber;
          this.Name = name;
          this.NotificationSubject = notificationSubject;
          this.UserID = userID;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid NotificationID { get; set; }

        [DataMember]
        public global::System.Guid NotificationRecipientID { get; set; }

        [DataMember]
        public global::System.DateTime DateSent { get; set; }

        [DataMember]
        public string NotificationData { get; set; }

        [DataMember]
        public global::System.Guid NotificationConstructID { get; set; }

        [DataMember]
        public int NotificationConstructVersionNumber { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string NotificationSubject { get; set; }

        [DataMember]
        public global::System.Guid UserID { get; set; }

        #endregion
    }

}
