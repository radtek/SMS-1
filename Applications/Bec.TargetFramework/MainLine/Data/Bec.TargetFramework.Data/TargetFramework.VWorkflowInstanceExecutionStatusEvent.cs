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
    /// There are no comments for Bec.TargetFramework.Data.VWorkflowInstanceExecutionStatusEvent in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VWorkflowInstanceExecutionStatusEvent    {

        public VWorkflowInstanceExecutionStatusEvent()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for WorkflowInstanceExecutionStatusEventID in the schema.
        /// </summary>
        public virtual int WorkflowInstanceExecutionStatusEventID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for EventDate in the schema.
        /// </summary>
        public virtual global::System.DateTime EventDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for EventBy in the schema.
        /// </summary>
        public virtual string EventBy
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowExecutionStatusID in the schema.
        /// </summary>
        public virtual int WorkflowExecutionStatusID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowInstanceExecutionID in the schema.
        /// </summary>
        public virtual int WorkflowInstanceExecutionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for EventOrder in the schema.
        /// </summary>
        public virtual int EventOrder
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
        /// There are no comments for ActionDecision in the schema.
        /// </summary>
        public virtual string ActionDecision
        {
            get;
            set;
        }


        #endregion
    }

}
