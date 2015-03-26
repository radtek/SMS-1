﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:15:00
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
    public partial class VBusTaskScheduleDTO
    {
        #region Constructors
  
        public VBusTaskScheduleDTO() {
        }

        public VBusTaskScheduleDTO(global::System.Guid busTaskScheduleID, global::System.Guid busTaskID, int intervalInMinutes, global::System.DateTime createdOn, string name, string description, bool isActive, bool isDeleted, global::System.Guid busTaskHandlerID, string objectTypeName, string objectTypeAssembly, string messageTypeName, string messageTypeAssembly) {

          this.BusTaskScheduleID = busTaskScheduleID;
          this.BusTaskID = busTaskID;
          this.IntervalInMinutes = intervalInMinutes;
          this.CreatedOn = createdOn;
          this.Name = name;
          this.Description = description;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.BusTaskHandlerID = busTaskHandlerID;
          this.ObjectTypeName = objectTypeName;
          this.ObjectTypeAssembly = objectTypeAssembly;
          this.MessageTypeName = messageTypeName;
          this.MessageTypeAssembly = messageTypeAssembly;
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
        public global::System.DateTime CreatedOn { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public global::System.Guid BusTaskHandlerID { get; set; }

        [DataMember]
        public string ObjectTypeName { get; set; }

        [DataMember]
        public string ObjectTypeAssembly { get; set; }

        [DataMember]
        public string MessageTypeName { get; set; }

        [DataMember]
        public string MessageTypeAssembly { get; set; }

        #endregion
    }

}
