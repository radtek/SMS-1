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
    /// There are no comments for Bec.TargetFramework.Data.VWorkflowInstanceNotStarted in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VWorkflowInstanceNotStarted    {

        public VWorkflowInstanceNotStarted()
        {
        }

        #region Properties
    
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

    
        /// <summary>
        /// There are no comments for WorkflowInstanceID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowInstanceID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowInstanceStatusID in the schema.
        /// </summary>
        public virtual int WorkflowInstanceStatusID
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
        /// There are no comments for ParentID in the schema.
        /// </summary>
        public virtual global::System.Guid ParentID
        {
            get;
            set;
        }


        #endregion
    }

}
