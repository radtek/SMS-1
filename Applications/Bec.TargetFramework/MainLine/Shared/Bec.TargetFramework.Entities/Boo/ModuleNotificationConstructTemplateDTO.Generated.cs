﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:58
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
    public partial class ModuleNotificationConstructTemplateDTO
    {
        #region Constructors
  
        public ModuleNotificationConstructTemplateDTO() {
        }

        public ModuleNotificationConstructTemplateDTO(global::System.Guid moduleNotificationConstructTemplateID, bool isActive, bool isDeleted, global::System.Guid notificationConstructTemplateID, int notificationConstructTemplateVersionNumber, global::System.Guid moduleTemplateID, int moduleTemplateVersionNumber, ModuleTemplateDTO moduleTemplate, NotificationConstructTemplateDTO notificationConstructTemplate) {

          this.ModuleNotificationConstructTemplateID = moduleNotificationConstructTemplateID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.NotificationConstructTemplateID = notificationConstructTemplateID;
          this.NotificationConstructTemplateVersionNumber = notificationConstructTemplateVersionNumber;
          this.ModuleTemplateID = moduleTemplateID;
          this.ModuleTemplateVersionNumber = moduleTemplateVersionNumber;
          this.ModuleTemplate = moduleTemplate;
          this.NotificationConstructTemplate = notificationConstructTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid ModuleNotificationConstructTemplateID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid NotificationConstructTemplateID { get; set; }

        [DataMember]
        public int NotificationConstructTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid ModuleTemplateID { get; set; }

        [DataMember]
        public int ModuleTemplateVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public ModuleTemplateDTO ModuleTemplate { get; set; }

        [DataMember]
        public NotificationConstructTemplateDTO NotificationConstructTemplate { get; set; }

        #endregion
    }

}
