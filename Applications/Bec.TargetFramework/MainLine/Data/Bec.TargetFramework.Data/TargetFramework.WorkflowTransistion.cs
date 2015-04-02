﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 02/04/2015 16:41:46
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
    /// There are no comments for Bec.TargetFramework.Data.WorkflowTransistion in the schema.
    /// </summary>
    [System.Serializable]
    public partial class WorkflowTransistion    {

        public WorkflowTransistion()
        {
          this.IsWorkflowStart = false;
          this.IsWorkflowEnd = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for WorkflowTransistionID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowTransistionID
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


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for WorkflowTransistionWorkflowActions in the schema.
        /// </summary>
        public virtual ICollection<WorkflowTransistionWorkflowAction> WorkflowTransistionWorkflowActions
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowTransistionCompleteConditions in the schema.
        /// </summary>
        public virtual ICollection<WorkflowTransistionCompleteCondition> WorkflowTransistionCompleteConditions
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowTransistionStartConditions in the schema.
        /// </summary>
        public virtual ICollection<WorkflowTransistionStartCondition> WorkflowTransistionStartConditions
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
    
        /// <summary>
        /// There are no comments for WorkflowHierarchies in the schema.
        /// </summary>
        public virtual ICollection<WorkflowHierarchy> WorkflowHierarchies
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
        /// There are no comments for WorkflowTransistionHierarchies_ParentComponentID_WorkflowID_WorkflowVersionNumber in the schema.
        /// </summary>
        public virtual ICollection<WorkflowTransistionHierarchy> WorkflowTransistionHierarchies_ParentComponentID_WorkflowID_WorkflowVersionNumber
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowTransistionHierarchies_ChildComponentID_WorkflowID_WorkflowVersionNumber in the schema.
        /// </summary>
        public virtual ICollection<WorkflowTransistionHierarchy> WorkflowTransistionHierarchies_ChildComponentID_WorkflowID_WorkflowVersionNumber
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowTransistionParameters in the schema.
        /// </summary>
        public virtual ICollection<WorkflowTransistionParameter> WorkflowTransistionParameters
        {
            get;
            set;
        }

        #endregion
    }

}
