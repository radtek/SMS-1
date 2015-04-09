﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:58
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
    public partial class StsInviteDTO
    {
        #region Constructors
  
        public StsInviteDTO() {
        }

        public StsInviteDTO(global::System.Guid stsInviteID, global::System.Nullable<System.Guid> notificationID, global::System.DateTime createdOn, global::System.Nullable<int> inviteTypeID, string inviteDetail, bool isActive, bool isDeleted, global::System.Nullable<int> inviteSubTypeID, global::System.Nullable<int> inviteCategoryID, bool inviteIsExistingUser, global::System.Guid createdBy, global::System.Nullable<int> inviteSubCategoryID, List<StsInviteProcessLogDTO> stsInviteProcessLogs) {

          this.StsInviteID = stsInviteID;
          this.NotificationID = notificationID;
          this.CreatedOn = createdOn;
          this.InviteTypeID = inviteTypeID;
          this.InviteDetail = inviteDetail;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.InviteSubTypeID = inviteSubTypeID;
          this.InviteCategoryID = inviteCategoryID;
          this.InviteIsExistingUser = inviteIsExistingUser;
          this.CreatedBy = createdBy;
          this.InviteSubCategoryID = inviteSubCategoryID;
          this.StsInviteProcessLogs = stsInviteProcessLogs;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid StsInviteID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> NotificationID { get; set; }

        [DataMember]
        public global::System.DateTime CreatedOn { get; set; }

        [DataMember]
        public global::System.Nullable<int> InviteTypeID { get; set; }

        [DataMember]
        public string InviteDetail { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Nullable<int> InviteSubTypeID { get; set; }

        [DataMember]
        public global::System.Nullable<int> InviteCategoryID { get; set; }

        [DataMember]
        public bool InviteIsExistingUser { get; set; }

        [DataMember]
        public global::System.Guid CreatedBy { get; set; }

        [DataMember]
        public global::System.Nullable<int> InviteSubCategoryID { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<StsInviteProcessLogDTO> StsInviteProcessLogs { get; set; }

        #endregion
    }

}
