﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 26/03/2015 16:14:58
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
    /// There are no comments for Bec.TargetFramework.Data.WorkflowTransistionStartCondition in the schema.
    /// </summary>
    [System.Serializable]
    public partial class WorkflowTransistionStartCondition    {

        public WorkflowTransistionStartCondition()
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
        /// There are no comments for WorkflowConditionID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowConditionID
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

        #endregion
    }

}
