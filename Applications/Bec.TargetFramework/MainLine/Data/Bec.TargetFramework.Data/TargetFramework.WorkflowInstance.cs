﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 09/04/2015 12:02:52
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
    /// There are no comments for Bec.TargetFramework.Data.WorkflowInstance in the schema.
    /// </summary>
    [System.Serializable]
    public partial class WorkflowInstance    {

        public WorkflowInstance()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for WorkflowInstanceID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowInstanceID
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

    
        /// <summary>
        /// There are no comments for ParentID in the schema.
        /// </summary>
        public virtual global::System.Guid ParentID
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
        /// There are no comments for WorkflowInstanceTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> WorkflowInstanceTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowInstanceSubTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> WorkflowInstanceSubTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowInstanceCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> WorkflowInstanceCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowInstanceSubCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> WorkflowInstanceSubCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowInstanceTempData in the schema.
        /// </summary>
        public virtual string WorkflowInstanceTempData
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
        /// There are no comments for WorkflowInstanceRestrictions in the schema.
        /// </summary>
        public virtual ICollection<WorkflowInstanceRestriction> WorkflowInstanceRestrictions
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowInstanceSessions in the schema.
        /// </summary>
        public virtual ICollection<WorkflowInstanceSession> WorkflowInstanceSessions
        {
            get;
            set;
        }

        #endregion
    }

}
