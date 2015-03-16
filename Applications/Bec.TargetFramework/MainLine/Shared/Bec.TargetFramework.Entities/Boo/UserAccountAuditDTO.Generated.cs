﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:07 PM
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
    public partial class UserAccountAuditDTO
    {
        #region Constructors
  
        public UserAccountAuditDTO() {
        }

        public UserAccountAuditDTO(global::System.Guid userAccountID, string userSessionID, global::System.Guid auditID, string userIPAddress, string uRLAccessed, global::System.Nullable<System.DateTime> timeAccessed, string data, bool isActive, bool isDeleted) {

          this.UserAccountID = userAccountID;
          this.UserSessionID = userSessionID;
          this.AuditID = auditID;
          this.UserIPAddress = userIPAddress;
          this.URLAccessed = uRLAccessed;
          this.TimeAccessed = timeAccessed;
          this.Data = data;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid UserAccountID { get; set; }

        [DataMember]
        public string UserSessionID { get; set; }

        [DataMember]
        public global::System.Guid AuditID { get; set; }

        [DataMember]
        public string UserIPAddress { get; set; }

        [DataMember]
        public string URLAccessed { get; set; }

        [DataMember]
        public global::System.Nullable<System.DateTime> TimeAccessed { get; set; }

        [DataMember]
        public string Data { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion
    }

}
