﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 07/04/2015 09:50:51
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
    /// There are no comments for Bec.TargetFramework.Data.WorkflowActionParameter in the schema.
    /// </summary>
    [System.Serializable]
    public partial class WorkflowActionParameter    {

        public WorkflowActionParameter()
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
        /// There are no comments for WorkflowParameterID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowParameterID
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
        /// There are no comments for WorkflowAction in the schema.
        /// </summary>
        public virtual WorkflowAction WorkflowAction
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowParameter in the schema.
        /// </summary>
        public virtual WorkflowParameter WorkflowParameter
        {
            get;
            set;
        }

        #endregion
    }

}
