﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 2/12/2015 3:31:04 PM
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
    /// There are no comments for Bec.TargetFramework.Data.WorkflowActionTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class WorkflowActionTemplate    {

        public WorkflowActionTemplate()
        {
          this.IsTransistionStart = false;
          this.IsTransistionEnd = false;
          this.IsManual = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for WorkflowActionTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowActionTemplateID
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
        /// There are no comments for WorkflowActionTypeTemplateID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> WorkflowActionTypeTemplateID
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
        /// There are no comments for WorkflowTransistionWorkflowActionTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowTransistionWorkflowActionTemplate> WorkflowTransistionWorkflowActionTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowActionExecuteCommandTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowActionExecuteCommandTemplate> WorkflowActionExecuteCommandTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowActionCompleteConditionTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowActionCompleteConditionTemplate> WorkflowActionCompleteConditionTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowActionPostCommandTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowActionPostCommandTemplate> WorkflowActionPostCommandTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowActionPreCommandTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowActionPreCommandTemplate> WorkflowActionPreCommandTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowActionParameterTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowActionParameterTemplate> WorkflowActionParameterTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowDecisionErrorTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowDecisionErrorTemplate> WorkflowDecisionErrorTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowActionExecutionTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowActionExecutionTemplate> WorkflowActionExecutionTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowActionNotificationTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowActionNotificationTemplate> WorkflowActionNotificationTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowActionProductPlaceholders in the schema.
        /// </summary>
        public virtual ICollection<WorkflowActionProductPlaceholder> WorkflowActionProductPlaceholders
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowActionStartConditionTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowActionStartConditionTemplate> WorkflowActionStartConditionTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowActionValidationTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowActionValidationTemplate> WorkflowActionValidationTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowDecisionFailureTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowDecisionFailureTemplate> WorkflowDecisionFailureTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowDecisionSuccessTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowDecisionSuccessTemplate> WorkflowDecisionSuccessTemplates
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

        #endregion
    }

}
