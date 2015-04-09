﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:50:53
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
    public partial class StsSearchProcessLogDTO
    {
        #region Constructors
  
        public StsSearchProcessLogDTO() {
        }

        public StsSearchProcessLogDTO(global::System.Guid stsSearchID, global::System.DateTime createdOn, global::System.Guid statusTypeID, int statusTypeVersionNumber, global::System.Guid statusTypeValueID, bool isCancelled, bool isClosed, StsSearchDTO stsSearch, StatusTypeDTO statusType, StatusTypeValueDTO statusTypeValue) {

          this.StsSearchID = stsSearchID;
          this.CreatedOn = createdOn;
          this.StatusTypeID = statusTypeID;
          this.StatusTypeVersionNumber = statusTypeVersionNumber;
          this.StatusTypeValueID = statusTypeValueID;
          this.IsCancelled = isCancelled;
          this.IsClosed = isClosed;
          this.StsSearch = stsSearch;
          this.StatusType = statusType;
          this.StatusTypeValue = statusTypeValue;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid StsSearchID { get; set; }

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

        #endregion

        #region Navigation Properties

        [DataMember]
        public StsSearchDTO StsSearch { get; set; }

        [DataMember]
        public StatusTypeDTO StatusType { get; set; }

        [DataMember]
        public StatusTypeValueDTO StatusTypeValue { get; set; }

        #endregion
    }

}
