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
    public partial class NotificationConstructRoleTemplateDTO
    {
        #region Constructors
  
        public NotificationConstructRoleTemplateDTO() {
        }

        public NotificationConstructRoleTemplateDTO(global::System.Guid notificationConstructRoleID, global::System.Guid notificationConstructTemplateID, int notificationConstructTemplateVersionNumber, string roleName, string roleDescription, global::System.Nullable<int> roleTypeID, global::System.Nullable<int> roleSubTypeID, global::System.Nullable<int> roleCategoryID, global::System.Nullable<int> roleSubCategoryID, bool isActive, bool isDeleted, List<NotificationConstructClaimTemplateDTO> notificationConstructClaimTemplates, NotificationConstructTemplateDTO notificationConstructTemplate) {

          this.NotificationConstructRoleID = notificationConstructRoleID;
          this.NotificationConstructTemplateID = notificationConstructTemplateID;
          this.NotificationConstructTemplateVersionNumber = notificationConstructTemplateVersionNumber;
          this.RoleName = roleName;
          this.RoleDescription = roleDescription;
          this.RoleTypeID = roleTypeID;
          this.RoleSubTypeID = roleSubTypeID;
          this.RoleCategoryID = roleCategoryID;
          this.RoleSubCategoryID = roleSubCategoryID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.NotificationConstructClaimTemplates = notificationConstructClaimTemplates;
          this.NotificationConstructTemplate = notificationConstructTemplate;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid NotificationConstructRoleID { get; set; }

        [DataMember]
        public global::System.Guid NotificationConstructTemplateID { get; set; }

        [DataMember]
        public int NotificationConstructTemplateVersionNumber { get; set; }

        [DataMember]
        public string RoleName { get; set; }

        [DataMember]
        public string RoleDescription { get; set; }

        [DataMember]
        public global::System.Nullable<int> RoleTypeID { get; set; }

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

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<NotificationConstructClaimTemplateDTO> NotificationConstructClaimTemplates { get; set; }

        [DataMember]
        public NotificationConstructTemplateDTO NotificationConstructTemplate { get; set; }

        #endregion
    }

}
