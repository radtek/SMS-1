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
    public partial class VNotificationViewOnlyUaoDTO
    {
        #region Constructors
  
        public VNotificationViewOnlyUaoDTO() {
        }

        public VNotificationViewOnlyUaoDTO(global::System.Guid userAccountOrganisationID, global::System.Nullable<int> resourceTypeID, global::System.Guid notificationID, string notificationData, global::System.Guid notificationConstructID, int notificationConstructVersionNumber, global::System.DateTime dateSent, string name, string notificationSubject, bool isInternal) {

          this.UserAccountOrganisationID = userAccountOrganisationID;
          this.ResourceTypeID = resourceTypeID;
          this.NotificationID = notificationID;
          this.NotificationData = notificationData;
          this.NotificationConstructID = notificationConstructID;
          this.NotificationConstructVersionNumber = notificationConstructVersionNumber;
          this.DateSent = dateSent;
          this.Name = name;
          this.NotificationSubject = notificationSubject;
          this.IsInternal = isInternal;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid UserAccountOrganisationID { get; set; }

        [DataMember]
        public global::System.Nullable<int> ResourceTypeID { get; set; }

        [DataMember]
        public global::System.Guid NotificationID { get; set; }

        [DataMember]
        public string NotificationData { get; set; }

        [DataMember]
        public global::System.Guid NotificationConstructID { get; set; }

        [DataMember]
        public int NotificationConstructVersionNumber { get; set; }

        [DataMember]
        public global::System.DateTime DateSent { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string NotificationSubject { get; set; }

        [DataMember]
        public bool IsInternal { get; set; }

        #endregion
    }

}
