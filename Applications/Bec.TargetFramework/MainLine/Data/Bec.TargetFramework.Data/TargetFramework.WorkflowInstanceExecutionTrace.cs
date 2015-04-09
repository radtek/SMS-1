﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 08/04/2015 17:09:52
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
    /// There are no comments for Bec.TargetFramework.Data.WorkflowInstanceExecutionTrace in the schema.
    /// </summary>
    [System.Serializable]
    public partial class WorkflowInstanceExecutionTrace    {

        public WorkflowInstanceExecutionTrace()
        {
          this.HasError = false;
          this.NumberOfRetries = 0;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for WorkflowInstanceExecutionTraceID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowInstanceExecutionTraceID
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
        /// There are no comments for WorkflowInstanceSessionID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowInstanceSessionID
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
        /// There are no comments for WorkflowInstanceID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> WorkflowInstanceID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowTransistionID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> WorkflowTransistionID
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
        /// There are no comments for TraceDetail in the schema.
        /// </summary>
        public virtual string TraceDetail
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TraceStackTrace in the schema.
        /// </summary>
        public virtual string TraceStackTrace
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
        /// There are no comments for ExecutedOn in the schema.
        /// </summary>
        public virtual global::System.DateTime ExecutedOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ExecutedBy in the schema.
        /// </summary>
        public virtual string ExecutedBy
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AdditionalContent in the schema.
        /// </summary>
        public virtual string AdditionalContent
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
        /// There are no comments for WorkflowInstanceExecution in the schema.
        /// </summary>
        public virtual WorkflowInstanceExecution WorkflowInstanceExecution
        {
            get;
            set;
        }

        #endregion
    }

}
