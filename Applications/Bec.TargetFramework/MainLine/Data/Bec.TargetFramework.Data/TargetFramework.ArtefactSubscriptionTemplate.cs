﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 2/12/2015 3:31:04 PM
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
    /// There are no comments for Bec.TargetFramework.Data.ArtefactSubscriptionTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class ArtefactSubscriptionTemplate    {

        public ArtefactSubscriptionTemplate()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ArtefactSubscriptionTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid ArtefactSubscriptionTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ArtefactTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid ArtefactTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ArtefactTemplateVersionNumber in the schema.
        /// </summary>
        public virtual int ArtefactTemplateVersionNumber
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
        /// There are no comments for PlanSubscriptionTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid PlanSubscriptionTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanSubscriptionTemplateVersionNumber in the schema.
        /// </summary>
        public virtual int PlanSubscriptionTemplateVersionNumber
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for ArtefactTemplate in the schema.
        /// </summary>
        public virtual ArtefactTemplate ArtefactTemplate
        {
            get;
            set;
        }

        #endregion
    }

}
