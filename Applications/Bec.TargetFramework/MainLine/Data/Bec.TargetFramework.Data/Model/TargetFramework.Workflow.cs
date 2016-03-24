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
    /// There are no comments for Bec.TargetFramework.Data.Workflow in the schema.
    /// </summary>
    [System.Serializable]
    public partial class Workflow    {

        public Workflow()
        {
          this.WorkflowVersionNumber = 0;
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
        /// There are no comments for Description in the schema.
        /// </summary>
        public virtual string Description
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> WorkflowTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowSubTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> WorkflowSubTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> WorkflowCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowSubCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> WorkflowSubCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowTemplateID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> WorkflowTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowTemplateVersionNumber in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> WorkflowTemplateVersionNumber
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for ApplicationStageWorkflows in the schema.
        /// </summary>
        public virtual ICollection<ApplicationStageWorkflow> ApplicationStageWorkflows
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationWorkflows in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationWorkflow> DefaultOrganisationWorkflows
        {
            get;
            set;
        }

        #endregion
    }

}