﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 08/06/2015 16:32:47
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
    /// There are no comments for Bec.TargetFramework.SB.Data.BusTaskScheduleProcessLog in the schema.
    /// </summary>
    [System.Runtime.Serialization.DataContractAttribute(IsReference=true)]
    [System.Runtime.Serialization.KnownType(typeof(StatusType))]
    [System.Runtime.Serialization.KnownType(typeof(StatusTypeValue))]
    [System.Runtime.Serialization.KnownType(typeof(BusTaskHandler))]
    [System.Runtime.Serialization.KnownType(typeof(BusTaskSchedule))]
    public partial class BusTaskScheduleProcessLog    {

        public BusTaskScheduleProcessLog()
        {
          this.HasError = false;
          this.IsComplete = false;
          this.NumberOfRetries = 0;
            OnCreated();
        }


        #region Properties
    
        /// <summary>
        /// There are no comments for CreatedOn in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual global::System.DateTime CreatedOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for HasError in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual bool HasError
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsComplete in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual bool IsComplete
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProcessMessage in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual string ProcessMessage
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProcessDetail in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual string ProcessDetail
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
        /// There are no comments for StatusTypeID in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual global::System.Guid StatusTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusTypeVersionNumber in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual int StatusTypeVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusTypeValueID in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual global::System.Guid StatusTypeValueID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusTaskScheduleProcessLogID in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual global::System.Guid BusTaskScheduleProcessLogID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ParentID in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual global::System.Nullable<System.Guid> ParentID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NumberOfRetries in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual global::System.Nullable<int> NumberOfRetries
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


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for StatusType in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual StatusType StatusType
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for StatusTypeValue in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual StatusTypeValue StatusTypeValue
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for BusTaskHandler in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual BusTaskHandler BusTaskHandler
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for BusTaskSchedule in the schema.
        /// </summary>
        [System.Runtime.Serialization.DataMember]
        public virtual BusTaskSchedule BusTaskSchedule
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