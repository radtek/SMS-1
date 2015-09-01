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
    public partial class VUserStatusDTO
    {
        #region Constructors
  
        public VUserStatusDTO() {
        }

        public VUserStatusDTO(global::System.Guid userAccountOrganisationID, global::System.Guid organisationID, global::System.Guid userID, bool isActive, bool isDeleted, global::System.Guid userTypeID, string statusTypeName, global::System.Guid statusTypeID, int statusTypeVersionNumber, global::System.Guid statusTypeTemplateID, int statusTypeTemplateVersionNumber, global::System.Guid statusTypeValueID, string statusValueName, global::System.DateTime statusChangedOn, string statusChangedBy, global::System.Nullable<int> statusOrder, global::System.Nullable<bool> isStart, global::System.Nullable<bool> isEnd, global::System.Nullable<System.Guid> nextStatusTypeValueID, string nextStatusTypeName, global::System.Nullable<int> nextStatusOrder, global::System.Nullable<bool> nextStatusStart, global::System.Nullable<bool> nextStatusEnd) {

          this.UserAccountOrganisationID = userAccountOrganisationID;
          this.OrganisationID = organisationID;
          this.UserID = userID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.UserTypeID = userTypeID;
          this.StatusTypeName = statusTypeName;
          this.StatusTypeID = statusTypeID;
          this.StatusTypeVersionNumber = statusTypeVersionNumber;
          this.StatusTypeTemplateID = statusTypeTemplateID;
          this.StatusTypeTemplateVersionNumber = statusTypeTemplateVersionNumber;
          this.StatusTypeValueID = statusTypeValueID;
          this.StatusValueName = statusValueName;
          this.StatusChangedOn = statusChangedOn;
          this.StatusChangedBy = statusChangedBy;
          this.StatusOrder = statusOrder;
          this.IsStart = isStart;
          this.IsEnd = isEnd;
          this.NextStatusTypeValueID = nextStatusTypeValueID;
          this.NextStatusTypeName = nextStatusTypeName;
          this.NextStatusOrder = nextStatusOrder;
          this.NextStatusStart = nextStatusStart;
          this.NextStatusEnd = nextStatusEnd;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid UserAccountOrganisationID { get; set; }

        [DataMember]
        public global::System.Guid OrganisationID { get; set; }

        [DataMember]
        public global::System.Guid UserID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid UserTypeID { get; set; }

        [DataMember]
        public string StatusTypeName { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeID { get; set; }

        [DataMember]
        public int StatusTypeVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeTemplateID { get; set; }

        [DataMember]
        public int StatusTypeTemplateVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeValueID { get; set; }

        [DataMember]
        public string StatusValueName { get; set; }

        [DataMember]
        public global::System.DateTime StatusChangedOn { get; set; }

        [DataMember]
        public string StatusChangedBy { get; set; }

        [DataMember]
        public global::System.Nullable<int> StatusOrder { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsStart { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsEnd { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> NextStatusTypeValueID { get; set; }

        [DataMember]
        public string NextStatusTypeName { get; set; }

        [DataMember]
        public global::System.Nullable<int> NextStatusOrder { get; set; }

        [DataMember]
        public global::System.Nullable<bool> NextStatusStart { get; set; }

        [DataMember]
        public global::System.Nullable<bool> NextStatusEnd { get; set; }

        #endregion
    }

}