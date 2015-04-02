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
    /// There are no comments for Bec.TargetFramework.Data.WorkflowTransistionTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class WorkflowTransistionTemplate    {

        public WorkflowTransistionTemplate()
        {
          this.WorkflowTemplateVersionNumber = 0;
          this.IsWorkflowStart = false;
          this.IsWorkflowEnd = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for WorkflowTransistionTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowTransistionTemplateID
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


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for WorkflowTransistionCompleteConditionTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowTransistionCompleteConditionTemplate> WorkflowTransistionCompleteConditionTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowTransistionStartConditionTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowTransistionStartConditionTemplate> WorkflowTransistionStartConditionTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowTransistionWorkflowActionTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowTransistionWorkflowActionTemplate> WorkflowTransistionWorkflowActionTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowTransistionParameterTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowTransistionParameterTemplate> WorkflowTransistionParameterTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowTransistionHierarchyTemplates_ParentComponentID_WorkflowTemplateID_WorkflowTemplateVersionNumber in the schema.
        /// </summary>
        public virtual ICollection<WorkflowTransistionHierarchyTemplate> WorkflowTransistionHierarchyTemplates_ParentComponentID_WorkflowTemplateID_WorkflowTemplateVersionNumber
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowTransistionHierarchyTemplates_ChildComponentID_WorkflowTemplateID_WorkflowTemplateVersionNumber in the schema.
        /// </summary>
        public virtual ICollection<WorkflowTransistionHierarchyTemplate> WorkflowTransistionHierarchyTemplates_ChildComponentID_WorkflowTemplateID_WorkflowTemplateVersionNumber
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
    
        /// <summary>
        /// There are no comments for WorkflowHierarchyTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowHierarchyTemplate> WorkflowHierarchyTemplates
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
