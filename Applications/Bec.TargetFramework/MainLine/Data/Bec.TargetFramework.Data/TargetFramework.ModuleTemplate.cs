﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 18/03/2015 19:00:45
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
    /// There are no comments for Bec.TargetFramework.Data.ModuleTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class ModuleTemplate    {

        public ModuleTemplate()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.ModuleTemplateVersionNumber = 0;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ModuleTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid ModuleTemplateID
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
        /// There are no comments for ModuleTemplateVersionNumber in the schema.
        /// </summary>
        public virtual int ModuleTemplateVersionNumber
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for Modules in the schema.
        /// </summary>
        public virtual ICollection<Module> Modules
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationModuleTemplates in the schema.
        /// </summary>
        public virtual ICollection<DefaultOrganisationModuleTemplate> DefaultOrganisationModuleTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ModuleStatusTypeTemplates in the schema.
        /// </summary>
        public virtual ICollection<ModuleStatusTypeTemplate> ModuleStatusTypeTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ModuleProductTemplates in the schema.
        /// </summary>
        public virtual ICollection<ModuleProductTemplate> ModuleProductTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ModuleWorkflowTemplates in the schema.
        /// </summary>
        public virtual ICollection<ModuleWorkflowTemplate> ModuleWorkflowTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ModuleClaimTemplates in the schema.
        /// </summary>
        public virtual ICollection<ModuleClaimTemplate> ModuleClaimTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ModuleSubscriptionTemplates in the schema.
        /// </summary>
        public virtual ICollection<ModuleSubscriptionTemplate> ModuleSubscriptionTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ModulePluginTemplates in the schema.
        /// </summary>
        public virtual ICollection<ModulePluginTemplate> ModulePluginTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ModuleSettingTemplates in the schema.
        /// </summary>
        public virtual ICollection<ModuleSettingTemplate> ModuleSettingTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ModuleDependencyTemplates in the schema.
        /// </summary>
        public virtual ICollection<ModuleDependencyTemplate> ModuleDependencyTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ModuleNotificationConstructTemplates in the schema.
        /// </summary>
        public virtual ICollection<ModuleNotificationConstructTemplate> ModuleNotificationConstructTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ModuleRoleTemplates in the schema.
        /// </summary>
        public virtual ICollection<ModuleRoleTemplate> ModuleRoleTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ModuleArtefactTemplates in the schema.
        /// </summary>
        public virtual ICollection<ModuleArtefactTemplate> ModuleArtefactTemplates
        {
            get;
            set;
        }

        #endregion
    }

}
