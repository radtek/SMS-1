﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 13/04/2015 17:29:36
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
    /// There are no comments for Bec.TargetFramework.Data.WorkflowInstanceExecutionDataItem in the schema.
    /// </summary>
    [System.Serializable]
    public partial class WorkflowInstanceExecutionDataItem    {

        public WorkflowInstanceExecutionDataItem()
        {
          this.DataNotJsonSerialized = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for WorkflowInstanceExecutionDataItemID in the schema.
        /// </summary>
        public virtual int WorkflowInstanceExecutionDataItemID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowInstanceExecutionID in the schema.
        /// </summary>
        public virtual int WorkflowInstanceExecutionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FieldName in the schema.
        /// </summary>
        public virtual string FieldName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FieldTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> FieldTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DataContent in the schema.
        /// </summary>
        public virtual string DataContent
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DataStr in the schema.
        /// </summary>
        public virtual string DataStr
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DataNotJsonSerialized in the schema.
        /// </summary>
        public virtual bool DataNotJsonSerialized
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for EventOrder in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> EventOrder
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowInstanceExecutionStatusEventID in the schema.
        /// </summary>
        public virtual int WorkflowInstanceExecutionStatusEventID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for WorkflowInstanceExecutionStatusEvent in the schema.
        /// </summary>
        public virtual WorkflowInstanceExecutionStatusEvent WorkflowInstanceExecutionStatusEvent
        {
            get;
            set;
        }

        #endregion
    }

}
