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
    /// There are no comments for Bec.TargetFramework.Data.PluginTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class PluginTemplate    {

        public PluginTemplate()
        {
          this.PluginTemplateVersionNumber = 0;
          this.DisplayOrder = 0;
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for PluginTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid PluginTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PluginTemplateVersionNumber in the schema.
        /// </summary>
        public virtual int PluginTemplateVersionNumber
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
        /// There are no comments for Version in the schema.
        /// </summary>
        public virtual string Version
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for VersionNumber in the schema.
        /// </summary>
        public virtual int VersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Author in the schema.
        /// </summary>
        public virtual string Author
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SystemName in the schema.
        /// </summary>
        public virtual string SystemName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DisplayOrder in the schema.
        /// </summary>
        public virtual int DisplayOrder
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PluginFileName in the schema.
        /// </summary>
        public virtual string PluginFileName
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
        /// There are no comments for ModulePluginTemplates in the schema.
        /// </summary>
        public virtual ICollection<ModulePluginTemplate> ModulePluginTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Plugins in the schema.
        /// </summary>
        public virtual ICollection<Plugin> Plugins
        {
            get;
            set;
        }

        #endregion
    }

}
