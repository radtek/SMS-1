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
    /// There are no comments for Bec.TargetFramework.Data.ApplicationStageWorkflow in the schema.
    /// </summary>
    [System.Serializable]
    public partial class ApplicationStageWorkflow    {

        public ApplicationStageWorkflow()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ApplicationStageWorkflowID in the schema.
        /// </summary>
        public virtual global::System.Guid ApplicationStageWorkflowID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ApplicationStageID in the schema.
        /// </summary>
        public virtual global::System.Guid ApplicationStageID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for VersionNumber in the schema.
        /// </summary>
        public virtual int VersionNumber
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for ApplicationStage in the schema.
        /// </summary>
        public virtual ApplicationStage ApplicationStage
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Workflow in the schema.
        /// </summary>
        public virtual Workflow Workflow
        {
            get;
            set;
        }

        #endregion
    }

}
