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
    public partial class NotificationConstructTargetDTO
    {
        #region Constructors
  
        public NotificationConstructTargetDTO() {
        }

        public NotificationConstructTargetDTO(global::System.Guid notificationConstructTargetID, global::System.Guid notificationConstructID, int notificationConstructVersionNumber, global::System.Nullable<int> organisationTypeID, global::System.Nullable<System.Guid> userTypeID, bool isSingleUser, bool isOrganisationBranchOnly, bool isDefaultTarget, bool isActive, bool isDeleted, OrganisationTypeDTO organisationType, UserTypeDTO userType, NotificationConstructDTO notificationConstruct) {

          this.NotificationConstructTargetID = notificationConstructTargetID;
          this.NotificationConstructID = notificationConstructID;
          this.NotificationConstructVersionNumber = notificationConstructVersionNumber;
          this.OrganisationTypeID = organisationTypeID;
          this.UserTypeID = userTypeID;
          this.IsSingleUser = isSingleUser;
          this.IsOrganisationBranchOnly = isOrganisationBranchOnly;
          this.IsDefaultTarget = isDefaultTarget;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.OrganisationType = organisationType;
          this.UserType = userType;
          this.NotificationConstruct = notificationConstruct;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid NotificationConstructTargetID { get; set; }

        [DataMember]
        public global::System.Guid NotificationConstructID { get; set; }

        [DataMember]
        public int NotificationConstructVersionNumber { get; set; }

        [DataMember]
        public global::System.Nullable<int> OrganisationTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> UserTypeID { get; set; }

        [DataMember]
        public bool IsSingleUser { get; set; }

        [DataMember]
        public bool IsOrganisationBranchOnly { get; set; }

        [DataMember]
        public bool IsDefaultTarget { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public OrganisationTypeDTO OrganisationType { get; set; }

        [DataMember]
        public UserTypeDTO UserType { get; set; }

        [DataMember]
        public NotificationConstructDTO NotificationConstruct { get; set; }

        #endregion
    }

}
