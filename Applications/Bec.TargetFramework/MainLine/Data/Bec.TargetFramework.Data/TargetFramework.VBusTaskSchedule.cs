﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 2/12/2015 3:31:04 PM
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
    /// There are no comments for Bec.TargetFramework.Data.VBusTaskSchedule in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VBusTaskSchedule    {

        public VBusTaskSchedule()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for BusTaskScheduleID in the schema.
        /// </summary>
        public virtual global::System.Guid BusTaskScheduleID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusTaskID in the schema.
        /// </summary>
        public virtual global::System.Guid BusTaskID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IntervalInMinutes in the schema.
        /// </summary>
        public virtual int IntervalInMinutes
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CreatedOn in the schema.
        /// </summary>
        public virtual global::System.DateTime CreatedOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Name in the schema.
        /// </summary>
        public virtual string Name
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Description in the schema.
        /// </summary>
        public virtual string Description
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsActive in the schema.
        /// </summary>
        public virtual bool IsActive
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsDeleted in the schema.
        /// </summary>
        public virtual bool IsDeleted
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusTaskHandlerID in the schema.
        /// </summary>
        public virtual global::System.Guid BusTaskHandlerID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ObjectTypeName in the schema.
        /// </summary>
        public virtual string ObjectTypeName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ObjectTypeAssembly in the schema.
        /// </summary>
        public virtual string ObjectTypeAssembly
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for MessageTypeName in the schema.
        /// </summary>
        public virtual string MessageTypeName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for MessageTypeAssembly in the schema.
        /// </summary>
        public virtual string MessageTypeAssembly
        {
            get;
            set;
        }


        #endregion
    }

}
