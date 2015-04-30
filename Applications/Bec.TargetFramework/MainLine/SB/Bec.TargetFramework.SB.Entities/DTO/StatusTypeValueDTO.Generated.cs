﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 30/04/2015 14:40:27
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.SB.Entities
{

    [DataContractAttribute(IsReference=true)]
    public partial class StatusTypeValueDTO
    {
        #region Constructors
  
        public StatusTypeValueDTO() {
        }

        public StatusTypeValueDTO(global::System.Guid statusTypeValueID, global::System.Guid statusTypeID, int statusTypeVersionNumber, string name, string description, bool isActive, bool isDeleted, List<BusMessageProcessLogDTO> busMessageProcessLogs, List<StatusTypeStructureDTO> statusTypeStructures, StatusTypeDTO statusType, List<BusTaskScheduleProcessLogDTO> busTaskScheduleProcessLogs) {

          this.StatusTypeValueID = statusTypeValueID;
          this.StatusTypeID = statusTypeID;
          this.StatusTypeVersionNumber = statusTypeVersionNumber;
          this.Name = name;
          this.Description = description;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.BusMessageProcessLogs = busMessageProcessLogs;
          this.StatusTypeStructures = statusTypeStructures;
          this.StatusType = statusType;
          this.BusTaskScheduleProcessLogs = busTaskScheduleProcessLogs;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid StatusTypeValueID { get; set; }

        [DataMember]
        public global::System.Guid StatusTypeID { get; set; }

        [DataMember]
        public int StatusTypeVersionNumber { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<BusMessageProcessLogDTO> BusMessageProcessLogs { get; set; }

        [DataMember]
        public List<StatusTypeStructureDTO> StatusTypeStructures { get; set; }

        [DataMember]
        public StatusTypeDTO StatusType { get; set; }

        [DataMember]
        public List<BusTaskScheduleProcessLogDTO> BusTaskScheduleProcessLogs { get; set; }

        #endregion
    }

}
