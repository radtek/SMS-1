﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

namespace Bec.TargetFramework.Data
{

    /// <summary>
    /// There are no comments for Bec.TargetFramework.Data.BusTaskScheduleProcessLog in the schema.
    /// </summary>
    [System.Serializable]
    public partial class BusTaskScheduleProcessLog    {

        public BusTaskScheduleProcessLog()
        {
          this.HasError = false;
          this.IsComplete = false;
          this.NumberOfRetries = 0;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for CreatedOn in the schema.
        /// </summary>
        public virtual global::System.DateTime CreatedOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for HasError in the schema.
        /// </summary>
        public virtual bool HasError
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsComplete in the schema.
        /// </summary>
        public virtual bool IsComplete
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProcessMessage in the schema.
        /// </summary>
        public virtual string ProcessMessage
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProcessDetail in the schema.
        /// </summary>
        public virtual string ProcessDetail
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusTaskScheduleID in the schema.
        /// </summary>
        public virtual global::System.Guid BusTaskScheduleID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusTypeID in the schema.
        /// </summary>
        public virtual global::System.Guid StatusTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusTypeVersionNumber in the schema.
        /// </summary>
        public virtual int StatusTypeVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusTypeValueID in the schema.
        /// </summary>
        public virtual global::System.Guid StatusTypeValueID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusTaskScheduleProcessLogID in the schema.
        /// </summary>
        public virtual global::System.Guid BusTaskScheduleProcessLogID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ParentID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ParentID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NumberOfRetries in the schema.
        /// </summary>
        public virtual int NumberOfRetries
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for BusTaskSchedule in the schema.
        /// </summary>
        public virtual BusTaskSchedule BusTaskSchedule
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for StatusType in the schema.
        /// </summary>
        public virtual StatusType StatusType
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for StatusTypeValue in the schema.
        /// </summary>
        public virtual StatusTypeValue StatusTypeValue
        {
            get;
            set;
        }

        #endregion
    }

}
