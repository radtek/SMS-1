﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 17/04/2015 16:46:51
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
    /// There are no comments for Bec.TargetFramework.Data.WorkflowParameterTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class WorkflowParameterTemplate    {

        public WorkflowParameterTemplate()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for WorkflowParameterTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowParameterTemplateID
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
        /// There are no comments for ObjectType in the schema.
        /// </summary>
        public virtual string ObjectType
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ObjectValue in the schema.
        /// </summary>
        public virtual string ObjectValue
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for WorkflowTemplate in the schema.
        /// </summary>
        public virtual WorkflowTemplate WorkflowTemplate
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
        /// There are no comments for WorkflowCommandParameterTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowCommandParameterTemplate> WorkflowCommandParameterTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowConditionParameterTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowConditionParameterTemplate> WorkflowConditionParameterTemplates
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
        /// There are no comments for WorkflowTransistionParameterTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowTransistionParameterTemplate> WorkflowTransistionParameterTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowMainParameterTemplate in the schema.
        /// </summary>
        public virtual WorkflowMainParameterTemplate WorkflowMainParameterTemplate
        {
            get;
            set;
        }

        #endregion
    }

}
