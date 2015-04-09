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
    public partial class BusTaskScheduleProcessLogDTO
    {
        #region Constructors
  
        public BusTaskScheduleProcessLogDTO() {
        }

        public BusTaskScheduleProcessLogDTO(global::System.DateTime createdOn, bool hasError, bool isComplete, string processMessage, string processDetail, global::System.Guid busTaskScheduleID, global::System.Guid statusTypeID, int statusTypeVersionNumber, global::System.Guid statusTypeValueID, global::System.Guid busTaskScheduleProcessLogID, global::System.Nullable<System.Guid> parentID, int numberOfRetries, BusTaskScheduleDTO busTaskSchedule, StatusTypeDTO statusType, StatusTypeValueDTO statusTypeValue) {

          this.CreatedOn = createdOn;
          this.HasError = hasError;
          this.IsComplete = isComplete;
          this.ProcessMessage = processMessage;
          this.ProcessDetail = processDetail;
          this.BusTaskScheduleID = busTaskScheduleID;
          this.StatusTypeID = statusTypeID;
          this.StatusTypeVersionNumber = statusTypeVersionNumber;
          this.StatusTypeValueID = statusTypeValueID;
          this.BusTaskScheduleProcessLogID = busTaskScheduleProcessLogID;
          this.ParentID = parentID;
          this.NumberOfRetries = numberOfRetries;
          this.BusTaskSchedule = busTaskSchedule;
          this.StatusType = statusType;
          this.StatusTypeValue = statusTypeValue;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.DateTime CreatedOn { get; set; }

        [DataMember]
        public bool HasError { get; set; }

        [DataMember]
        public bool IsComplete { get; set; }

        [DataMember]
        public string ProcessMessage { get; set; }

        [DataMember]
        public string ProcessDetail { get; set; }

        [DataMember]
        public global::System.Guid BusTaskScheduleID { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeID { get; set; }

        [DataMember]
        public int StatusTypeVersionNumber { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeValueID { get; set; }

        [DataMember]
        public global::System.Guid BusTaskScheduleProcessLogID { get; set; }

        [DataMember]
        public global::System.Nullable<System.Guid> ParentID { get; set; }

        [DataMember]
        public int NumberOfRetries { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public BusTaskScheduleDTO BusTaskSchedule { get; set; }

        [DataMember]
        public StatusTypeDTO StatusType { get; set; }

        [DataMember]
        public StatusTypeValueDTO StatusTypeValue { get; set; }

        #endregion
    }

}
