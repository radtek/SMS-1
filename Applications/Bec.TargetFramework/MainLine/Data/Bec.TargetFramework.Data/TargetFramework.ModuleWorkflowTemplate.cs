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
    /// There are no comments for Bec.TargetFramework.Data.ModuleWorkflowTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class ModuleWorkflowTemplate    {

        public ModuleWorkflowTemplate()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.AppliesToAllOrganisations = false;
          this.AppliesToAllUsers = false;
          this.ModuleTemplateVersionNumber = 0;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ModuleWorkflowTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid ModuleWorkflowTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ModuleTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid ModuleTemplateID
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
        /// There are no comments for ModuleTemplateVersionNumber in the schema.
        /// </summary>
        public virtual int ModuleTemplateVersionNumber
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
        /// There are no comments for ModuleTemplate in the schema.
        /// </summary>
        public virtual ModuleTemplate ModuleTemplate
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for WorkflowTemplate in the schema.
        /// </summary>
        public virtual WorkflowTemplate WorkflowTemplate
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ModuleWorkflowTargetTemplates in the schema.
        /// </summary>
        public virtual ICollection<ModuleWorkflowTargetTemplate> ModuleWorkflowTargetTemplates
        {
            get;
            set;
        }

        #endregion
    }

}
