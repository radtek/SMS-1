﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 3/27/2015 9:57:18 AM
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
    /// There are no comments for Bec.TargetFramework.Data.WorkflowDecisionFailure in the schema.
    /// </summary>
    [System.Serializable]
    public partial class WorkflowDecisionFailure    {

        public WorkflowDecisionFailure()
        {
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
        /// There are no comments for NextWorkflowActionID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> NextWorkflowActionID
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
        /// There are no comments for NextWorkflowDecisionID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> NextWorkflowDecisionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowDecisionFailureID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowDecisionFailureID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for WorkflowDecision_NextWorkflowDecisionID_WorkflowID_WorkflowVersionNumber in the schema.
        /// </summary>
        public virtual WorkflowDecision WorkflowDecision_NextWorkflowDecisionID_WorkflowID_WorkflowVersionNumber
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowAction in the schema.
        /// </summary>
        public virtual WorkflowAction WorkflowAction
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowDecision_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber in the schema.
        /// </summary>
        public virtual WorkflowDecision WorkflowDecision_WorkflowDecisionID_WorkflowID_WorkflowVersionNumber
        {
            get;
            set;
        }

        #endregion
    }

}
