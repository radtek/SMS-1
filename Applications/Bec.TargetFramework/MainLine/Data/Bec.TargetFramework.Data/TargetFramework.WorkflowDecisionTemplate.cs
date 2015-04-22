﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
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
    /// There are no comments for Bec.TargetFramework.Data.WorkflowDecisionTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class WorkflowDecisionTemplate    {

        public WorkflowDecisionTemplate()
        {
          this.IsTransistionStart = false;
          this.IsTransistionEnd = false;
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
        /// There are no comments for WorkflowDecisionTypeTemplateID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> WorkflowDecisionTypeTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowObjectTypeTemplateID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> WorkflowObjectTypeTemplateID
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


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for WorkflowDecisionExecuteCommandTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowDecisionExecuteCommandTemplate> WorkflowDecisionExecuteCommandTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowDecisionParameterTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowDecisionParameterTemplate> WorkflowDecisionParameterTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowDecisionErrorTemplates_WorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber in the schema.
        /// </summary>
        public virtual ICollection<WorkflowDecisionErrorTemplate> WorkflowDecisionErrorTemplates_WorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowDecisionErrorTemplates_NextWorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber in the schema.
        /// </summary>
        public virtual ICollection<WorkflowDecisionErrorTemplate> WorkflowDecisionErrorTemplates_NextWorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowDecisionFailureTemplates_WorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber in the schema.
        /// </summary>
        public virtual ICollection<WorkflowDecisionFailureTemplate> WorkflowDecisionFailureTemplates_WorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowDecisionFailureTemplates_NextWorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber in the schema.
        /// </summary>
        public virtual ICollection<WorkflowDecisionFailureTemplate> WorkflowDecisionFailureTemplates_NextWorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowDecisionSuccessTemplates_WorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber in the schema.
        /// </summary>
        public virtual ICollection<WorkflowDecisionSuccessTemplate> WorkflowDecisionSuccessTemplates_WorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowDecisionSuccessTemplates_NextWorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber in the schema.
        /// </summary>
        public virtual ICollection<WorkflowDecisionSuccessTemplate> WorkflowDecisionSuccessTemplates_NextWorkflowDecisionTemplateID_WorkflowTemplateID_WorkflowTemplateVersionNumber
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowObjectTypeTemplate in the schema.
        /// </summary>
        public virtual WorkflowObjectTypeTemplate WorkflowObjectTypeTemplate
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowTemplate in the schema.
        /// </summary>
        public virtual WorkflowTemplate WorkflowTemplate
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowTransistionWorkflowDecisionTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowTransistionWorkflowDecisionTemplate> WorkflowTransistionWorkflowDecisionTemplates
        {
            get;
            set;
        }

        #endregion
    }

}
