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
    /// There are no comments for Bec.TargetFramework.Data.WorkflowActionPreCommand in the schema.
    /// </summary>
    [System.Serializable]
    public partial class WorkflowActionPreCommand    {

        public WorkflowActionPreCommand()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for WorkflowActionID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowActionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowCommandID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowCommandID
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
        /// There are no comments for WorkflowVersionNumber in the schema.
        /// </summary>
        public virtual int WorkflowVersionNumber
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for WorkflowCommand in the schema.
        /// </summary>
        public virtual WorkflowCommand WorkflowCommand
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowAction in the schema.
        /// </summary>
        public virtual WorkflowAction WorkflowAction
        {
            get;
            set;
        }

        #endregion
    }

}
