﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 08/04/2015 17:09:52
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
    /// There are no comments for Bec.TargetFramework.Data.WorkflowTreeStructureActionTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class WorkflowTreeStructureActionTemplate    {

        public WorkflowTreeStructureActionTemplate()
        {
          this.IsVisible = true;
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for WorkflowTreeStructureActionTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowTreeStructureActionTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowTreeStructureTemplateID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> WorkflowTreeStructureTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowActionTemplateID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> WorkflowActionTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsVisible in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsVisible
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
        /// There are no comments for ConditionString in the schema.
        /// </summary>
        public virtual string ConditionString
        {
            get;
            set;
        }


        #endregion
    }

}
