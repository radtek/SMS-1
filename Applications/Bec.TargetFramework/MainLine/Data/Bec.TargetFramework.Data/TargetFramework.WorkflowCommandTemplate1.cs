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
    /// There are no comments for Bec.TargetFramework.Data.WorkflowCommandTemplate1 in the schema.
    /// </summary>
    [System.Serializable]
    public partial class WorkflowCommandTemplate1    {

        public WorkflowCommandTemplate1()
        {
          this.WorkflowTemplateVersionNumber = 0;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for WorkflowCommandTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowCommandTemplateID
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
        /// There are no comments for WorkflowObjectTypeTemplateID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> WorkflowObjectTypeTemplateID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
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
        /// There are no comments for WorkflowActionExecuteCommandTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowActionExecuteCommandTemplate> WorkflowActionExecuteCommandTemplates
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
        /// There are no comments for WorkflowCommandParameterTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowCommandParameterTemplate> WorkflowCommandParameterTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowCommandConditionTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowCommandConditionTemplate> WorkflowCommandConditionTemplates
        {
            get;
            set;
        }

        #endregion
    }

}
