﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
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
    /// There are no comments for Bec.TargetFramework.Data.WorkflowActionExecutionTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class WorkflowActionExecutionTemplate    {

        public WorkflowActionExecutionTemplate()
        {
          this.IsPre = false;
          this.IsPost = false;
          this.IsCanStart = false;
          this.IsCanComplete = false;
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for WorkflowActionExecutionID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowActionExecutionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowActionTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowActionTemplateID
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
        /// There are no comments for Description in the schema.
        /// </summary>
        public virtual string Description
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsPre in the schema.
        /// </summary>
        public virtual bool IsPre
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsPost in the schema.
        /// </summary>
        public virtual bool IsPost
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsCanStart in the schema.
        /// </summary>
        public virtual bool IsCanStart
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsCanComplete in the schema.
        /// </summary>
        public virtual bool IsCanComplete
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsActive in the schema.
        /// </summary>
        public virtual bool IsActive
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsDeleted in the schema.
        /// </summary>
        public virtual bool IsDeleted
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
        /// There are no comments for WorkflowActionTemplate in the schema.
        /// </summary>
        public virtual WorkflowActionTemplate WorkflowActionTemplate
        {
            get;
            set;
        }

        #endregion
    }

}
