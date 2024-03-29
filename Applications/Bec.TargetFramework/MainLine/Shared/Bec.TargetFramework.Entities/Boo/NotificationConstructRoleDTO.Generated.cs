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
    public partial class NotificationConstructRoleDTO
    {
        #region Constructors
  
        public NotificationConstructRoleDTO() {
        }

        public NotificationConstructRoleDTO(global::System.Guid notificationRoleConstructID, global::System.Guid notificationConstructID, int notificationConstructVersionNumber, string roleName, string roleDescription, global::System.Nullable<int> roleSubTypeID, global::System.Nullable<int> roleCategoryID, global::System.Nullable<int> roleSubCategoryID, bool isActive, bool isDeleted, int roleTypeID, List<NotificationConstructClaimDTO> notificationConstructClaims, NotificationConstructDTO notificationConstruct) {

          this.NotificationRoleConstructID = notificationRoleConstructID;
          this.NotificationConstructID = notificationConstructID;
          this.NotificationConstructVersionNumber = notificationConstructVersionNumber;
          this.RoleName = roleName;
          this.RoleDescription = roleDescription;
          this.RoleSubTypeID = roleSubTypeID;
          this.RoleCategoryID = roleCategoryID;
          this.RoleSubCategoryID = roleSubCategoryID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.RoleTypeID = roleTypeID;
          this.NotificationConstructClaims = notificationConstructClaims;
          this.NotificationConstruct = notificationConstruct;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid NotificationRoleConstructID { get; set; }

        [DataMember]
        public global::System.Guid NotificationConstructID { get; set; }

        [DataMember]
        public int NotificationConstructVersionNumber { get; set; }

        [DataMember]
        public string RoleName { get; set; }

        [DataMember]
        public string RoleDescription { get; set; }

        [DataMember]
        public global::System.Nullable<int> RoleSubTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> RoleCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<int> RoleSubCategoryID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public int RoleTypeID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<NotificationConstructClaimDTO> NotificationConstructClaims { get; set; }

        [DataMember]
        public NotificationConstructDTO NotificationConstruct { get; set; }

        #endregion
    }

}
