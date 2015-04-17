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
    /// There are no comments for Bec.TargetFramework.Data.Module in the schema.
    /// </summary>
    [System.Serializable]
    public partial class Module    {

        public Module()
        {
          this.ModuleVersionNumber = 0;
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ModuleID in the schema.
        /// </summary>
        public virtual global::System.Guid ModuleID
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
        /// There are no comments for ModuleTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid ModuleTemplateID
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
        /// There are no comments for ModuleSubscriptions in the schema.
        /// </summary>
        public virtual ICollection<ModuleSubscription> ModuleSubscriptions
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ModuleClaims in the schema.
        /// </summary>
        public virtual ICollection<ModuleClaim> ModuleClaims
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ModuleSettings in the schema.
        /// </summary>
        public virtual ICollection<ModuleSetting> ModuleSettings
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ModuleProducts in the schema.
        /// </summary>
        public virtual ICollection<ModuleProduct> ModuleProducts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ModuleWorkflows in the schema.
        /// </summary>
        public virtual ICollection<ModuleWorkflow> ModuleWorkflows
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ModuleDependencies_DependencyID_DependencyVersionNumber in the schema.
        /// </summary>
        public virtual ICollection<ModuleDependency> ModuleDependencies_DependencyID_DependencyVersionNumber
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ModuleDependencies_ModuleID_ModuleVersionNumber in the schema.
        /// </summary>
        public virtual ICollection<ModuleDependency> ModuleDependencies_ModuleID_ModuleVersionNumber
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ModuleStatusTypes in the schema.
        /// </summary>
        public virtual ICollection<ModuleStatusType> ModuleStatusTypes
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationModules in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationModule> DefaultOrganisationModules
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ModulePlugins in the schema.
        /// </summary>
        public virtual ICollection<ModulePlugin> ModulePlugins
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ModuleArtefacts in the schema.
        /// </summary>
        public virtual ICollection<ModuleArtefact> ModuleArtefacts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ModuleNotificationConstructs in the schema.
        /// </summary>
        public virtual ICollection<ModuleNotificationConstruct> ModuleNotificationConstructs
        {
            get;
            set;
        }

        #endregion
    }

}
