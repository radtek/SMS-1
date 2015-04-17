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
    public partial class VOrganisationStatusDTO
    {
        #region Constructors
  
        public VOrganisationStatusDTO() {
        }

        public VOrganisationStatusDTO(global::System.Guid organisationID, bool isBranch, bool isActive, bool isDeleted, bool isHeadOffice, bool isUserOrganisation, string statusTypeName, global::System.Guid statusTypeID, int statusTypeVersionNumber, global::System.Guid statusTypeTemplateID, int statusTypeTemplateVersionNumber, global::System.Guid statusTypeValueID, string statusValueName, global::System.DateTime statusChangedOn, string statusChangedBy, global::System.Nullable<int> statusOrder, global::System.Nullable<bool> isStart, global::System.Nullable<bool> isEnd, global::System.Nullable<System.Guid> nextStatusTypeValueID, string nextStatusTypeName, global::System.Nullable<int> nextStatusOrder, global::System.Nullable<bool> nextStatusStart, global::System.Nullable<bool> nextStatusEnd) {

          this.OrganisationID = organisationID;
          this.IsBranch = isBranch;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.IsHeadOffice = isHeadOffice;
          this.IsUserOrganisation = isUserOrganisation;
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
        public global::System.Guid OrganisationID { get; set; }

        [DataMember]
        public bool IsBranch { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public bool IsHeadOffice { get; set; }

        [DataMember]
        public bool IsUserOrganisation { get; set; }

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
