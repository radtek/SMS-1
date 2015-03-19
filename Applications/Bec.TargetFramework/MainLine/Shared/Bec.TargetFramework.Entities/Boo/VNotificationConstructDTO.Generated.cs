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
    public partial class VNotificationConstructDTO
    {
        #region Constructors
  
        public VNotificationConstructDTO() {
        }

        public VNotificationConstructDTO(global::System.Guid notificationConstructID, int notificationConstructVersionNumber, global::System.Nullable<int> defaultNotificationDeliveryMethodID, global::System.Nullable<int> defaultNotificationExportFormatID, string name, string notificationTitle, string notificationSubject, string notificationDetails, string notificationReference, string notificationAdditionalDetails, bool canBeIncludedInBatchNotification, string description, global::System.Nullable<System.Guid> externalRelatedNotificationConstructID, global::System.Nullable<int> externalRelatedNotificationConstructVersionNumber, bool isActive, bool isDeleted, global::System.Nullable<int> notificationConstructTypeID, global::System.Nullable<int> notificationConstructCategoryID, string typeName, string categoryName, string exportFormatName, string deliveryMethodName) {

          this.NotificationConstructID = notificationConstructID;
          this.NotificationConstructVersionNumber = notificationConstructVersionNumber;
          this.DefaultNotificationDeliveryMethodID = defaultNotificationDeliveryMethodID;
          this.DefaultNotificationExportFormatID = defaultNotificationExportFormatID;
          this.Name = name;
          this.NotificationTitle = notificationTitle;
          this.NotificationSubject = notificationSubject;
          this.NotificationDetails = notificationDetails;
          this.NotificationReference = notificationReference;
          this.NotificationAdditionalDetails = notificationAdditionalDetails;
          this.CanBeIncludedInBatchNotification = canBeIncludedInBatchNotification;
          this.Description = description;
          this.ExternalRelatedNotificationConstructID = externalRelatedNotificationConstructID;
          this.ExternalRelatedNotificationConstructVersionNumber = externalRelatedNotificationConstructVersionNumber;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.NotificationConstructTypeID = notificationConstructTypeID;
          this.NotificationConstructCategoryID = notificationConstructCategoryID;
          this.TypeName = typeName;
          this.CategoryName = categoryName;
          this.ExportFormatName = exportFormatName;
          this.DeliveryMethodName = deliveryMethodName;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid NotificationConstructID { get; set; }

        [DataMember]
        public int NotificationConstructVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<int> DefaultNotificationDeliveryMethodID { get; set; }

        [DataMember]
        public global::System.Nullable<int> DefaultNotificationExportFormatID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string NotificationTitle { get; set; }

        [DataMember]
        public string NotificationSubject { get; set; }

        [DataMember]
        public string NotificationDetails { get; set; }

        [DataMember]
        public string NotificationReference { get; set; }

        [DataMember]
        public string NotificationAdditionalDetails { get; set; }

        [DataMember]
        public bool CanBeIncludedInBatchNotification { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ExternalRelatedNotificationConstructID { get; set; }

        [DataMember]
        public global::System.Nullable<int> ExternalRelatedNotificationConstructVersionNumber { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<int> NotificationConstructTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> NotificationConstructCategoryID { get; set; }

        [DataMember]
        public string TypeName { get; set; }

        [DataMember]
        public string CategoryName { get; set; }

        [DataMember]
        public string ExportFormatName { get; set; }

        [DataMember]
        public string DeliveryMethodName { get; set; }

        #endregion
    }

}
