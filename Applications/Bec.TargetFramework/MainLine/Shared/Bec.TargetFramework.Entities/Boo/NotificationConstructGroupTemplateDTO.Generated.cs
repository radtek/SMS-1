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
    public partial class NotificationConstructGroupTemplateDTO
    {
        #region Constructors
  
        public NotificationConstructGroupTemplateDTO() {
        }

        public NotificationConstructGroupTemplateDTO(global::System.Guid notificationConstructGroupTemplateID, int notificationConstructGroupTemplateVersion, string name, string description, global::System.Nullable<bool> isActive, global::System.Nullable<bool> isDeleted, global::System.Nullable<System.Guid> parentID, global::System.Nullable<int> notificationConstructGroupTypeID, global::System.Nullable<int> notificationConstructGroupCategoryID, List<NotificationConstructGroupDTO> notificationConstructGroups, List<NotificationConstructGroupNotificationConstructTemplateDTO> notificationConstructGroupNotificationConstructTemplates) {

          this.NotificationConstructGroupTemplateID = notificationConstructGroupTemplateID;
          this.NotificationConstructGroupTemplateVersion = notificationConstructGroupTemplateVersion;
          this.Name = name;
          this.Description = description;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.ParentID = parentID;
          this.NotificationConstructGroupTypeID = notificationConstructGroupTypeID;
          this.NotificationConstructGroupCategoryID = notificationConstructGroupCategoryID;
          this.NotificationConstructGroups = notificationConstructGroups;
          this.NotificationConstructGroupNotificationConstructTemplates = notificationConstructGroupNotificationConstructTemplates;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid NotificationConstructGroupTemplateID { get; set; }

        [DataMember]
        public int NotificationConstructGroupTemplateVersion { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsActive { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public global::System.Nullable<int> NotificationConstructGroupTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> NotificationConstructGroupCategoryID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<NotificationConstructGroupDTO> NotificationConstructGroups { get; set; }

        [DataMember]
        public List<NotificationConstructGroupNotificationConstructTemplateDTO> NotificationConstructGroupNotificationConstructTemplates { get; set; }

        #endregion
    }

}
