﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:53
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
    public partial class BusTaskScheduleDTO
    {
        #region Constructors
  
        public BusTaskScheduleDTO() {
        }

        public BusTaskScheduleDTO(global::System.Guid busTaskScheduleID, global::System.Guid busTaskID, int intervalInMinutes, bool isActive, bool isDeleted, int busTaskVersionNumber, List<BusTaskScheduleProcessLogDTO> busTaskScheduleProcessLogs, BusTaskDTO busTask) {

          this.BusTaskScheduleID = busTaskScheduleID;
          this.BusTaskID = busTaskID;
          this.IntervalInMinutes = intervalInMinutes;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.BusTaskVersionNumber = busTaskVersionNumber;
          this.BusTaskScheduleProcessLogs = busTaskScheduleProcessLogs;
          this.BusTask = busTask;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid BusTaskScheduleID { get; set; }

        [DataMember]
        public global::System.Guid BusTaskID { get; set; }

        [DataMember]
        public int IntervalInMinutes { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public int BusTaskVersionNumber { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<BusTaskScheduleProcessLogDTO> BusTaskScheduleProcessLogs { get; set; }

        [DataMember]
        public BusTaskDTO BusTask { get; set; }

        #endregion
    }

}
