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
    /// There are no comments for Bec.TargetFramework.Data.WorkflowTransistionParameter in the schema.
    /// </summary>
    [System.Serializable]
    public partial class WorkflowTransistionParameter    {

        public WorkflowTransistionParameter()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for WorkflowTransistionID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowTransistionID
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
        /// There are no comments for Workflow in the schema.
        /// </summary>
        public virtual Workflow Workflow
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowTransistion in the schema.
        /// </summary>
        public virtual WorkflowTransistion WorkflowTransistion
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
