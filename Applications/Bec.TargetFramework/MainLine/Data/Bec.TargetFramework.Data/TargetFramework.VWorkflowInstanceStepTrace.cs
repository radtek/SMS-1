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
    /// There are no comments for Bec.TargetFramework.Data.VWorkflowInstanceStepTrace in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VWorkflowInstanceStepTrace    {

        public VWorkflowInstanceStepTrace()
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
        /// There are no comments for Name in the schema.
        /// </summary>
        public virtual string Name
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
        /// There are no comments for WorkflowInstanceSessionID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowInstanceSessionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PreviousStepID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> PreviousStepID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PreviousStepName in the schema.
        /// </summary>
        public virtual string PreviousStepName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StepID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> StepID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StepName in the schema.
        /// </summary>
        public virtual string StepName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SessionStartedOn in the schema.
        /// </summary>
        public virtual global::System.DateTime SessionStartedOn
        {
            get;
            set;
        }


        #endregion
    }

}
