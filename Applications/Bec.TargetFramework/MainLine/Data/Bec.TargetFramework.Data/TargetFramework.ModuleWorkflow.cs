﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 26/03/2015 16:14:57
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
    /// There are no comments for Bec.TargetFramework.Data.ModuleWorkflow in the schema.
    /// </summary>
    [System.Serializable]
    public partial class ModuleWorkflow    {

        public ModuleWorkflow()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.AppliesToAllOrganisations = false;
          this.AppliesToAllUsers = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ModuleWorkflowID in the schema.
        /// </summary>
        public virtual global::System.Guid ModuleWorkflowID
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
        /// There are no comments for ModuleID in the schema.
        /// </summary>
        public virtual global::System.Guid ModuleID
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
        /// There are no comments for AppliesToAllOrganisations in the schema.
        /// </summary>
        public virtual bool AppliesToAllOrganisations
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AppliesToAllUsers in the schema.
        /// </summary>
        public virtual bool AppliesToAllUsers
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ModuleVersionNumber in the schema.
        /// </summary>
        public virtual int ModuleVersionNumber
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for Module in the schema.
        /// </summary>
        public virtual Module Module
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Workflow in the schema.
        /// </summary>
        public virtual Workflow Workflow
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ModuleWorkflowTargets in the schema.
        /// </summary>
        public virtual ICollection<ModuleWorkflowTarget> ModuleWorkflowTargets
        {
            get;
            set;
        }

        #endregion
    }

}
