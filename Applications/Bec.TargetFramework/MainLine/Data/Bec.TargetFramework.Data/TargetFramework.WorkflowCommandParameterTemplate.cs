﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 08/04/2015 17:09:52
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
    /// There are no comments for Bec.TargetFramework.Data.WorkflowCommandParameterTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class WorkflowCommandParameterTemplate    {

        public WorkflowCommandParameterTemplate()
        {
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
        /// There are no comments for WorkflowParameterTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowParameterTemplateID
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
        /// There are no comments for WorkflowCommandTemplate in the schema.
        /// </summary>
        public virtual WorkflowCommandTemplate WorkflowCommandTemplate
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
        /// There are no comments for WorkflowParameterTemplate in the schema.
        /// </summary>
        public virtual WorkflowParameterTemplate WorkflowParameterTemplate
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowCommandTemplate1 in the schema.
        /// </summary>
        public virtual WorkflowCommandTemplate1 WorkflowCommandTemplate1
        {
            get;
            set;
        }

        #endregion
    }

}
