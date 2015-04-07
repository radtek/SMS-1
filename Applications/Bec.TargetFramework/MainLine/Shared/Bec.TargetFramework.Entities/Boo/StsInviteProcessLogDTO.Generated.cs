﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 16:15:20
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
    public partial class StsInviteProcessLogDTO
    {
        #region Constructors
  
        public StsInviteProcessLogDTO() {
        }

        public StsInviteProcessLogDTO(global::System.Guid stsInviteID, global::System.DateTime createdOn, global::System.Guid statusTypeID, int statusTypeVersionNumber, global::System.Guid statusTypeValueID, bool isCancelled, bool isClosed, bool isRejected, global::System.Nullable<int> rejectReasonTypeID, string rejectReasonComments, StsInviteDTO stsInvite, StatusTypeDTO statusType, StatusTypeValueDTO statusTypeValue) {

          this.StsInviteID = stsInviteID;
          this.CreatedOn = createdOn;
          this.StatusTypeID = statusTypeID;
          this.StatusTypeVersionNumber = statusTypeVersionNumber;
          this.StatusTypeValueID = statusTypeValueID;
          this.IsCancelled = isCancelled;
          this.IsClosed = isClosed;
          this.IsRejected = isRejected;
          this.RejectReasonTypeID = rejectReasonTypeID;
          this.RejectReasonComments = rejectReasonComments;
          this.StsInvite = stsInvite;
          this.StatusType = statusType;
          this.StatusTypeValue = statusTypeValue;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid StsInviteID { get; set; }

        [DataMember]
        public global::System.DateTime CreatedOn { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeID { get; set; }

        [DataMember]
        public int StatusTypeVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeValueID { get; set; }

        [DataMember]
        public bool IsCancelled { get; set; }

        [DataMember]
        public bool IsClosed { get; set; }

        [DataMember]
        public bool IsRejected { get; set; }

        [DataMember]
        public global::System.Nullable<int> RejectReasonTypeID { get; set; }

        [DataMember]
        public string RejectReasonComments { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public StsInviteDTO StsInvite { get; set; }

        [DataMember]
        public StatusTypeDTO StatusType { get; set; }

        [DataMember]
        public StatusTypeValueDTO StatusTypeValue { get; set; }

        #endregion
    }

}
