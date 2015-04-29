﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 29/04/2015 12:05:02
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Bec.TargetFramework.SB.Data
{

    /// <summary>
    /// There are no comments for Bec.TargetFramework.SB.Data.VBusTaskSchedule in the schema.
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    public partial class VBusTaskSchedule    {

        public VBusTaskSchedule()
        {
            OnCreated();
        }


        #region Properties
    
        /// <summary>
        /// There are no comments for Name in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual string Name
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Description in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual string Description
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ApplicationName in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual string ApplicationName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ApplicationEnvironmentName in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual string ApplicationEnvironmentName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusTaskID in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual global::System.Guid BusTaskID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusTaskGroupName in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual string BusTaskGroupName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusTaskHandlerID in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual global::System.Guid BusTaskHandlerID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusTaskHandlerVersionNumber in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual int BusTaskHandlerVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusTaskHandlerGroupName in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual string BusTaskHandlerGroupName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for HandlerMessageTypeName in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual string HandlerMessageTypeName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for HandlerMessageTypeAssemblyName in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual string HandlerMessageTypeAssemblyName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusTaskHandlerName in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual string BusTaskHandlerName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusTaskScheduleID in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual global::System.Guid BusTaskScheduleID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsActive in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual bool IsActive
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsDeleted in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual bool IsDeleted
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RepeatForever in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual bool RepeatForever
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsCronDriven in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual bool IsCronDriven
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CronScheduleString in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual string CronScheduleString
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsCalendarDriven in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual bool IsCalendarDriven
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RepeatEveryNumberOfSeconds in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual global::System.Nullable<int> RepeatEveryNumberOfSeconds
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RepeatEveryDay in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual bool RepeatEveryDay
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RepeatMondayToFriday in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual bool RepeatMondayToFriday
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RepeatSaturdayAndSunday in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual bool RepeatSaturdayAndSunday
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RepeatEveryNumberOfDays in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual global::System.Nullable<int> RepeatEveryNumberOfDays
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for HasSpecificDailyStartTime in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual bool HasSpecificDailyStartTime
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SpecificDailyStartTimeHour in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual global::System.Nullable<int> SpecificDailyStartTimeHour
        {
            get;
            set;
        }


        #endregion
    
        #region Extensibility Method Definitions
        partial void OnCreated();
        #endregion
    }

}
