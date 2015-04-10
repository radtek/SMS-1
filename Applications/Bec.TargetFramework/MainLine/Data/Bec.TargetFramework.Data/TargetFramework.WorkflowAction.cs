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
    /// There are no comments for Bec.TargetFramework.Data.WorkflowAction in the schema.
    /// </summary>
    [System.Serializable]
    public partial class WorkflowAction    {

        public WorkflowAction()
        {
          this.IsTransistionStart = false;
          this.IsTransistionEnd = false;
          this.IsManual = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for WorkflowActionID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowActionID
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
        /// There are no comments for IsTransistionStart in the schema.
        /// </summary>
        public virtual bool IsTransistionStart
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsTransistionEnd in the schema.
        /// </summary>
        public virtual bool IsTransistionEnd
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowActionTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> WorkflowActionTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsManual in the schema.
        /// </summary>
        public virtual bool IsManual
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowObjectTypeID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowObjectTypeID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for Workflow in the schema.
        /// </summary>
        public virtual Workflow Workflow
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowObjectType in the schema.
        /// </summary>
        public virtual WorkflowObjectType WorkflowObjectType
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowActionCompleteConditions in the schema.
        /// </summary>
        public virtual ICollection<WorkflowActionCompleteCondition> WorkflowActionCompleteConditions
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowActionExecuteCommands in the schema.
        /// </summary>
        public virtual ICollection<WorkflowActionExecuteCommand> WorkflowActionExecuteCommands
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowActionParameters in the schema.
        /// </summary>
        public virtual ICollection<WorkflowActionParameter> WorkflowActionParameters
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowActionPostCommands in the schema.
        /// </summary>
        public virtual ICollection<WorkflowActionPostCommand> WorkflowActionPostCommands
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowActionStartConditions in the schema.
        /// </summary>
        public virtual ICollection<WorkflowActionStartCondition> WorkflowActionStartConditions
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowDecisionFailures in the schema.
        /// </summary>
        public virtual ICollection<WorkflowDecisionFailure> WorkflowDecisionFailures
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowDecisionSuccesses in the schema.
        /// </summary>
        public virtual ICollection<WorkflowDecisionSuccess> WorkflowDecisionSuccesses
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowTransistionWorkflowActions in the schema.
        /// </summary>
        public virtual ICollection<WorkflowTransistionWorkflowAction> WorkflowTransistionWorkflowActions
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowDecisionErrors in the schema.
        /// </summary>
        public virtual ICollection<WorkflowDecisionError> WorkflowDecisionErrors
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowActionPreCommands in the schema.
        /// </summary>
        public virtual ICollection<WorkflowActionPreCommand> WorkflowActionPreCommands
        {
            get;
            set;
        }

        #endregion
    }

}
