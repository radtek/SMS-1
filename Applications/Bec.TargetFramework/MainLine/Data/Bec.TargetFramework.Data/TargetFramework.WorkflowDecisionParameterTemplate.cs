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
    /// There are no comments for Bec.TargetFramework.Data.WorkflowDecisionParameterTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class WorkflowDecisionParameterTemplate    {

        public WorkflowDecisionParameterTemplate()
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
        /// There are no comments for WorkflowDecisionTemplate in the schema.
        /// </summary>
        public virtual WorkflowDecisionTemplate WorkflowDecisionTemplate
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

        #endregion
    }

}
