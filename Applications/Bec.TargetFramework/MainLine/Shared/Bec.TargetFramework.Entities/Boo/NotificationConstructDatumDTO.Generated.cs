﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:50
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
    public partial class NotificationConstructDatumDTO
    {
        #region Constructors
  
        public NotificationConstructDatumDTO() {
        }

        public NotificationConstructDatumDTO(global::System.Guid notificationConstructDataID, global::System.Guid notificationConstructID, int notificationConstructVersionNumber, byte[] notificationData, global::System.Nullable<int> notificationDataLength, string notificationDataMimeType, string notificationDataFileName, bool isActive, bool isDeleted, global::System.Nullable<System.DateTime> createdOn, global::System.Nullable<bool> usesBusinessObjects, global::System.Nullable<bool> usesDataSources, NotificationConstructDTO notificationConstruct) {

          this.NotificationConstructDataID = notificationConstructDataID;
          this.NotificationConstructID = notificationConstructID;
          this.NotificationConstructVersionNumber = notificationConstructVersionNumber;
          this.NotificationData = notificationData;
          this.NotificationDataLength = notificationDataLength;
          this.NotificationDataMimeType = notificationDataMimeType;
          this.NotificationDataFileName = notificationDataFileName;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.CreatedOn = createdOn;
          this.UsesBusinessObjects = usesBusinessObjects;
          this.UsesDataSources = usesDataSources;
          this.NotificationConstruct = notificationConstruct;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid NotificationConstructDataID { get; set; }

        [DataMember]
        public global::System.Guid NotificationConstructID { get; set; }

        [DataMember]
        public int NotificationConstructVersionNumber { get; set; }

        [DataMember]
        public byte[] NotificationData { get; set; }

        [DataMember]
        public global::System.Nullable<int> NotificationDataLength { get; set; }

        [DataMember]
        public string NotificationDataMimeType { get; set; }

        [DataMember]
        public string NotificationDataFileName { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> CreatedOn { get; set; }

        [DataMember]
        public global::System.Nullable<bool> UsesBusinessObjects { get; set; }

        [DataMember]
        public global::System.Nullable<bool> UsesDataSources { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public NotificationConstructDTO NotificationConstruct { get; set; }

        #endregion
    }

}
