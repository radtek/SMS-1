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
    /// There are no comments for Bec.TargetFramework.Data.ModuleSettingTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class ModuleSettingTemplate    {

        public ModuleSettingTemplate()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.CanOrganisationChange = false;
          this.CanUserChange = false;
          this.ModuleTemplateVersionNumber = 0;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ModuleSettingTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid ModuleSettingTemplateID
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
        /// There are no comments for Value in the schema.
        /// </summary>
        public virtual string Value
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
        /// There are no comments for CanOrganisationChange in the schema.
        /// </summary>
        public virtual bool CanOrganisationChange
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CanUserChange in the schema.
        /// </summary>
        public virtual bool CanUserChange
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

        #endregion
    }

}
