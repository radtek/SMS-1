﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 18/03/2015 19:00:46
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
    public partial class NotificationConstructDataTemplateDTO
    {
        #region Constructors
  
        public NotificationConstructDataTemplateDTO() {
        }

        public NotificationConstructDataTemplateDTO(global::System.Guid notificationConstructDataTemplateID, global::System.Guid notificationConstructTemplateID, int notificationConstructTemplateVersionNumber, byte[] notificationData, global::System.Nullable<int> notificationDataLength, string notificationDataMimeType, string notificationDataFileName, bool isActive, bool isDeleted, global::System.Nullable<System.DateTime> createdOn, global::System.Nullable<bool> usesBusinessObjects, global::System.Nullable<bool> usesDataSources, NotificationConstructTemplateDTO notificationConstructTemplate) {

          this.NotificationConstructDataTemplateID = notificationConstructDataTemplateID;
          this.NotificationConstructTemplateID = notificationConstructTemplateID;
          this.NotificationConstructTemplateVersionNumber = notificationConstructTemplateVersionNumber;
          this.NotificationData = notificationData;
          this.NotificationDataLength = notificationDataLength;
          this.NotificationDataMimeType = notificationDataMimeType;
          this.NotificationDataFileName = notificationDataFileName;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.CreatedOn = createdOn;
          this.UsesBusinessObjects = usesBusinessObjects;
          this.UsesDataSources = usesDataSources;
          this.NotificationConstructTemplate = notificationConstructTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid NotificationConstructDataTemplateID { get; set; }

        [DataMember]
        public global::System.Guid NotificationConstructTemplateID { get; set; }

        [DataMember]
        public int NotificationConstructTemplateVersionNumber { get; set; }

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
        public NotificationConstructTemplateDTO NotificationConstructTemplate { get; set; }

        #endregion
    }

}
