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
    /// There are no comments for Bec.TargetFramework.Data.WorkflowTransistionHierarchyTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class WorkflowTransistionHierarchyTemplate    {

        public WorkflowTransistionHierarchyTemplate()
        {
          this.IsWorkflowStart = false;
          this.IsWorkflowEnd = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for WorkflowTransistionHierarchyTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowTransistionHierarchyTemplateID
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
        /// There are no comments for ChildComponentID in the schema.
        /// </summary>
        public virtual global::System.Guid ChildComponentID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ParentComponentID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ParentComponentID
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
        /// There are no comments for WorkflowTransistionTemplate_ParentComponentID_WorkflowTemplateID_WorkflowTemplateVersionNumber in the schema.
        /// </summary>
        public virtual WorkflowTransistionTemplate WorkflowTransistionTemplate_ParentComponentID_WorkflowTemplateID_WorkflowTemplateVersionNumber
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowTransistionTemplate_ChildComponentID_WorkflowTemplateID_WorkflowTemplateVersionNumber in the schema.
        /// </summary>
        public virtual WorkflowTransistionTemplate WorkflowTransistionTemplate_ChildComponentID_WorkflowTemplateID_WorkflowTemplateVersionNumber
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
