﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 13/04/2015 17:29:36
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
    /// There are no comments for Bec.TargetFramework.Data.WorkflowObjectTypeTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class WorkflowObjectTypeTemplate    {

        public WorkflowObjectTypeTemplate()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for WorkflowObjectTypeTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowObjectTypeTemplateID
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
        /// There are no comments for ObjectTypeName in the schema.
        /// </summary>
        public virtual string ObjectTypeName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ObjectTypeNameSpace in the schema.
        /// </summary>
        public virtual string ObjectTypeNameSpace
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ObjectTypeAssembly in the schema.
        /// </summary>
        public virtual string ObjectTypeAssembly
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
        /// There are no comments for WorkflowCommandTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowCommandTemplate> WorkflowCommandTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowDecisionTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowDecisionTemplate> WorkflowDecisionTemplates
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
        /// There are no comments for WorkflowActionTemplates in the schema.
        /// </summary>
        public virtual ICollection<WorkflowActionTemplate> WorkflowActionTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowCommandTemplate1s in the schema.
        /// </summary>
        public virtual ICollection<WorkflowCommandTemplate1> WorkflowCommandTemplate1s
        {
            get;
            set;
        }

        #endregion
    }

}
