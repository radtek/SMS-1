﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 09/04/2015 12:02:52
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
    /// There are no comments for Bec.TargetFramework.Data.WorkflowInstanceExecution in the schema.
    /// </summary>
    [System.Serializable]
    public partial class WorkflowInstanceExecution    {

        public WorkflowInstanceExecution()
        {
          this.NumberOfRetries = 0;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for WorkflowInstanceExecutionID in the schema.
        /// </summary>
        public virtual int WorkflowInstanceExecutionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowInstanceID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowInstanceID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowVersionNumber in the schema.
        /// </summary>
        public virtual int WorkflowVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowTransistionID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowTransistionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowActionID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> WorkflowActionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowDecisionID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> WorkflowDecisionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowConditionID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> WorkflowConditionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowCommandID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> WorkflowCommandID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowInstanceSessionID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowInstanceSessionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CreatedOn in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> CreatedOn
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


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for WorkflowInstanceSession in the schema.
        /// </summary>
        public virtual WorkflowInstanceSession WorkflowInstanceSession
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowInstanceExecutionStatusEvents in the schema.
        /// </summary>
        public virtual ICollection<WorkflowInstanceExecutionStatusEvent> WorkflowInstanceExecutionStatusEvents
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowInstanceExecutionTraces in the schema.
        /// </summary>
        public virtual ICollection<WorkflowInstanceExecutionTrace> WorkflowInstanceExecutionTraces
        {
            get;
            set;
        }

        #endregion
    }

}
