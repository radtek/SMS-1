﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 17/04/2015 16:46:51
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
    /// There are no comments for Bec.TargetFramework.Data.BusTaskHandler in the schema.
    /// </summary>
    [System.Serializable]
    public partial class BusTaskHandler    {

        public BusTaskHandler()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsHandlerBasedTask = false;
          this.NumberOfRetries = 1;
          this.TaskDataHasExpiry = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for BusTaskHandlerID in the schema.
        /// </summary>
        public virtual global::System.Guid BusTaskHandlerID
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
        /// There are no comments for ObjectTypeName in the schema.
        /// </summary>
        public virtual string ObjectTypeName
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

    
        /// <summary>
        /// There are no comments for HandlerMessageTypeName in the schema.
        /// </summary>
        public virtual string HandlerMessageTypeName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for HandlerMessageTypeAssembly in the schema.
        /// </summary>
        public virtual string HandlerMessageTypeAssembly
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsHandlerBasedTask in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsHandlerBasedTask
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NumberOfRetries in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> NumberOfRetries
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TaskDataHasExpiry in the schema.
        /// </summary>
        public virtual bool TaskDataHasExpiry
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TaskDataExpiryPeriodUnitID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> TaskDataExpiryPeriodUnitID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TaskDataExpiryPeriod in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> TaskDataExpiryPeriod
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DefaultProcessDataTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> DefaultProcessDataTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DefaultProcessDataCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> DefaultProcessDataCategoryID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for BusTasks in the schema.
        /// </summary>
        public virtual ICollection<BusTask> BusTasks
        {
            get;
            set;
        }

        #endregion
    }

}
