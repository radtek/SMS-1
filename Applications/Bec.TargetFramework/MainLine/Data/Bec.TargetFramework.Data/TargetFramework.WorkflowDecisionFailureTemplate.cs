﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 07/04/2015 16:15:16
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
    /// There are no comments for Bec.TargetFramework.Data.WorkflowDecisionFailureTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class WorkflowDecisionFailureTemplate    {

        public WorkflowDecisionFailureTemplate()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for WorkflowDecisionTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowDecisionTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NextWorkflowActionTemplateID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> NextWorkflowActionTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowTemplateVersionNumber in the schema.
        /// </summary>
        public virtual int WorkflowTemplateVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NextWorkflowDecisionTemplateID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> NextWorkflowDecisionTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowDecisionFailureTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowDecisionFailureTemplateID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for WorkflowDecisionTemplate_WorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber in the schema.
        /// </summary>
        public virtual WorkflowDecisionTemplate WorkflowDecisionTemplate_WorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowActionTemplate in the schema.
        /// </summary>
        public virtual WorkflowActionTemplate WorkflowActionTemplate
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowDecisionTemplate_NextWorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber in the schema.
        /// </summary>
        public virtual WorkflowDecisionTemplate WorkflowDecisionTemplate_NextWorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber
        {
            get;
            set;
        }

        #endregion
    }

}
