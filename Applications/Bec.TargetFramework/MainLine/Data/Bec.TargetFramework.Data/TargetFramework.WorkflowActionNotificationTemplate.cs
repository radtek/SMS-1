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
    /// There are no comments for Bec.TargetFramework.Data.WorkflowActionNotificationTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class WorkflowActionNotificationTemplate    {

        public WorkflowActionNotificationTemplate()
        {
          this.IsConfigurable = false;
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for WorkflowActionNotificationTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowActionNotificationTemplateID
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
        /// There are no comments for IsConfigurable in the schema.
        /// </summary>
        public virtual bool IsConfigurable
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
