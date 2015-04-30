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
    public partial class VBusTaskScheduleDTO
    {
        #region Constructors
  
        public VBusTaskScheduleDTO() {
        }

        public VBusTaskScheduleDTO(string name, string description, string applicationName, string applicationEnvironmentName, global::System.Guid busTaskID, string busTaskGroupName, global::System.Guid busTaskHandlerID, int busTaskHandlerVersionNumber, string busTaskHandlerGroupName, string handlerMessageTypeName, string handlerMessageTypeAssemblyName, string handlerObjectTypeName, string handlerObjectTypeAssemblyName, string busTaskHandlerName, global::System.Guid busTaskScheduleID, bool isActive, bool isDeleted, bool repeatForever, bool isCronDriven, string cronScheduleString, bool isCalendarDriven, global::System.Nullable<int> repeatEveryNumberOfSeconds, bool repeatEveryDay, bool repeatMondayToFriday, bool repeatSaturdayAndSunday, global::System.Nullable<int> repeatEveryNumberOfDays, bool hasSpecificDailyStartTime, global::System.Nullable<int> specificDailyStartTimeHour) {

          this.Name = name;
          this.Description = description;
          this.ApplicationName = applicationName;
          this.ApplicationEnvironmentName = applicationEnvironmentName;
          this.BusTaskID = busTaskID;
          this.BusTaskGroupName = busTaskGroupName;
          this.BusTaskHandlerID = busTaskHandlerID;
          this.BusTaskHandlerVersionNumber = busTaskHandlerVersionNumber;
          this.BusTaskHandlerGroupName = busTaskHandlerGroupName;
          this.HandlerMessageTypeName = handlerMessageTypeName;
          this.HandlerMessageTypeAssemblyName = handlerMessageTypeAssemblyName;
          this.HandlerObjectTypeName = handlerObjectTypeName;
          this.HandlerObjectTypeAssemblyName = handlerObjectTypeAssemblyName;
          this.BusTaskHandlerName = busTaskHandlerName;
          this.BusTaskScheduleID = busTaskScheduleID;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.RepeatForever = repeatForever;
          this.IsCronDriven = isCronDriven;
          this.CronScheduleString = cronScheduleString;
          this.IsCalendarDriven = isCalendarDriven;
          this.RepeatEveryNumberOfSeconds = repeatEveryNumberOfSeconds;
          this.RepeatEveryDay = repeatEveryDay;
          this.RepeatMondayToFriday = repeatMondayToFriday;
          this.RepeatSaturdayAndSunday = repeatSaturdayAndSunday;
          this.RepeatEveryNumberOfDays = repeatEveryNumberOfDays;
          this.HasSpecificDailyStartTime = hasSpecificDailyStartTime;
          this.SpecificDailyStartTimeHour = specificDailyStartTimeHour;
        }

        #endregion

        #region Properties

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string ApplicationName { get; set; }

        [DataMember]
        public string ApplicationEnvironmentName { get; set; }

        [DataMember]
        public global::System.Guid BusTaskID { get; set; }

        [DataMember]
        public string BusTaskGroupName { get; set; }

        [DataMember]
        public global::System.Guid BusTaskHandlerID { get; set; }

        [DataMember]
        public int BusTaskHandlerVersionNumber { get; set; }

        [DataMember]
        public string BusTaskHandlerGroupName { get; set; }

        [DataMember]
        public string HandlerMessageTypeName { get; set; }

        [DataMember]
        public string HandlerMessageTypeAssemblyName { get; set; }

        [DataMember]
        public string HandlerObjectTypeName { get; set; }

        [DataMember]
        public string HandlerObjectTypeAssemblyName { get; set; }

        [DataMember]
        public string BusTaskHandlerName { get; set; }

        [DataMember]
        public global::System.Guid BusTaskScheduleID { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public bool RepeatForever { get; set; }

        [DataMember]
        public bool IsCronDriven { get; set; }

        [DataMember]
        public string CronScheduleString { get; set; }

        [DataMember]
        public bool IsCalendarDriven { get; set; }

        [DataMember]
        public global::System.Nullable<int> RepeatEveryNumberOfSeconds { get; set; }

        [DataMember]
        public bool RepeatEveryDay { get; set; }

        [DataMember]
        public bool RepeatMondayToFriday { get; set; }

        [DataMember]
        public bool RepeatSaturdayAndSunday { get; set; }

        [DataMember]
        public global::System.Nullable<int> RepeatEveryNumberOfDays { get; set; }

        [DataMember]
        public bool HasSpecificDailyStartTime { get; set; }

        [DataMember]
        public global::System.Nullable<int> SpecificDailyStartTimeHour { get; set; }

        #endregion
    }

}
