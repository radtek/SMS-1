﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 26/03/2015 16:14:58
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
    /// There are no comments for Bec.TargetFramework.Data.WorkflowDecision in the schema.
    /// </summary>
    [System.Serializable]
    public partial class WorkflowDecision    {

        public WorkflowDecision()
        {
          this.IsTransistionStart = false;
          this.IsTransistionEnd = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for WorkflowDecisionID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowDecisionID
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
        /// There are no comments for WorkflowDecisionTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> WorkflowDecisionTypeID
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
        /// There are no comments for WorkflowDecisionFailures_NextWorkflowDecisionID_WorkflowID_WorkflowVersionNumber in the schema.
        /// </summary>
        public virtual ICollection<WorkflowDecisionFailure> WorkflowDecisionFailures_NextWorkflowDecisionID_WorkflowID_WorkflowVersionNumber
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowDecisionFailures_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber in the schema.
        /// </summary>
        public virtual ICollection<WorkflowDecisionFailure> WorkflowDecisionFailures_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowDecisionSuccesses_NextWorkflowDecisionID_WorkflowID_WorkflowVersionNumber in the schema.
        /// </summary>
        public virtual ICollection<WorkflowDecisionSuccess> WorkflowDecisionSuccesses_NextWorkflowDecisionID_WorkflowID_WorkflowVersionNumber
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowDecisionSuccesses_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber in the schema.
        /// </summary>
        public virtual ICollection<WorkflowDecisionSuccess> WorkflowDecisionSuccesses_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowDecisionErrors_NextWorkflowDecisionID_WorkflowID_WorkflowVersionNumber in the schema.
        /// </summary>
        public virtual ICollection<WorkflowDecisionError> WorkflowDecisionErrors_NextWorkflowDecisionID_WorkflowID_WorkflowVersionNumber
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowDecisionErrors_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber in the schema.
        /// </summary>
        public virtual ICollection<WorkflowDecisionError> WorkflowDecisionErrors_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber
        {
            get;
            set;
        }
    
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
        /// There are no comments for WorkflowDecisionExecuteCommands in the schema.
        /// </summary>
        public virtual ICollection<WorkflowDecisionExecuteCommand> WorkflowDecisionExecuteCommands
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowDecisionParameters in the schema.
        /// </summary>
        public virtual ICollection<WorkflowDecisionParameter> WorkflowDecisionParameters
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowTransistionWorkflowDecisions in the schema.
        /// </summary>
        public virtual ICollection<WorkflowTransistionWorkflowDecision> WorkflowTransistionWorkflowDecisions
        {
            get;
            set;
        }

        #endregion
    }

}
