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
    /// There are no comments for Bec.TargetFramework.Data.VWorkflowInstanceProgress in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VWorkflowInstanceProgress    {

        public VWorkflowInstanceProgress()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for StepName in the schema.
        /// </summary>
        public virtual string StepName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StepID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> StepID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StepStatus in the schema.
        /// </summary>
        public virtual string StepStatus
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StepDate in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> StepDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StepExecutedBy in the schema.
        /// </summary>
        public virtual string StepExecutedBy
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StepOrder in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> StepOrder
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StepType in the schema.
        /// </summary>
        public virtual string StepType
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StepIsManual in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> StepIsManual
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StepIsStart in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> StepIsStart
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StepIsEnd in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> StepIsEnd
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TransistionName in the schema.
        /// </summary>
        public virtual string TransistionName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsWorkflowStart in the schema.
        /// </summary>
        public virtual bool IsWorkflowStart
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsWorkflowEnd in the schema.
        /// </summary>
        public virtual bool IsWorkflowEnd
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
        /// There are no comments for WorkflowInstanceID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowInstanceID
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

    
        /// <summary>
        /// There are no comments for WorkflowExecutionStatusID in the schema.
        /// </summary>
        public virtual int WorkflowExecutionStatusID
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
        /// There are no comments for Actionarea in the schema.
        /// </summary>
        public virtual string Actionarea
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Actionaction in the schema.
        /// </summary>
        public virtual string Actionaction
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Actioncontroller in the schema.
        /// </summary>
        public virtual string Actioncontroller
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> WorkflowTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Workflowtypename in the schema.
        /// </summary>
        public virtual string Workflowtypename
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> WorkflowCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Workflowcategoryname in the schema.
        /// </summary>
        public virtual string Workflowcategoryname
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowInstanceStatusID in the schema.
        /// </summary>
        public virtual int WorkflowInstanceStatusID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Workflowinstancestatusname in the schema.
        /// </summary>
        public virtual string Workflowinstancestatusname
        {
            get;
            set;
        }


        #endregion
    }

}
