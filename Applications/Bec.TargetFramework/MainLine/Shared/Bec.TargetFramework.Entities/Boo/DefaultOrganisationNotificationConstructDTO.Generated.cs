﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 17/04/2015 16:46:54
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
    public partial class DefaultOrganisationNotificationConstructDTO
    {
        #region Constructors
  
        public DefaultOrganisationNotificationConstructDTO() {
        }

        public DefaultOrganisationNotificationConstructDTO(global::System.Guid defaultOrganisationNotificationConstructID, bool isActive, bool isDeleted, global::System.Guid defaultOrganisationID, global::System.Guid notificationConstructID, int notificationConstructVersionNumber, global::System.Nullable<System.Guid> parentID, int defaultOrganisationVersionNumber, NotificationConstructDTO notificationConstruct, DefaultOrganisationDTO defaultOrganisation) {

          this.DefaultOrganisationNotificationConstructID = defaultOrganisationNotificationConstructID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.DefaultOrganisationID = defaultOrganisationID;
          this.NotificationConstructID = notificationConstructID;
          this.NotificationConstructVersionNumber = notificationConstructVersionNumber;
          this.ParentID = parentID;
          this.DefaultOrganisationVersionNumber = defaultOrganisationVersionNumber;
          this.NotificationConstruct = notificationConstruct;
          this.DefaultOrganisation = defaultOrganisation;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid DefaultOrganisationNotificationConstructID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid DefaultOrganisationID { get; set; }

        [DataMember]
        public global::System.Guid NotificationConstructID { get; set; }

        [DataMember]
        public int NotificationConstructVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public int DefaultOrganisationVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public NotificationConstructDTO NotificationConstruct { get; set; }

        [DataMember]
        public DefaultOrganisationDTO DefaultOrganisation { get; set; }

        #endregion
    }

}
