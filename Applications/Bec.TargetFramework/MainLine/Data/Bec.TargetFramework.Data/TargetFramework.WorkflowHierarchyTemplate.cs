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
    /// There are no comments for Bec.TargetFramework.Data.WorkflowHierarchyTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class WorkflowHierarchyTemplate    {

        public WorkflowHierarchyTemplate()
        {
          this.IsChildDependentOnParent = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for WorkflowHierarchyTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowHierarchyTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WorkflowTransistionTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowTransistionTemplateID
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

    
        /// <summary>
        /// There are no comments for ChildComponentID in the schema.
        /// </summary>
        public virtual global::System.Guid ChildComponentID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ParentComponentID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ParentComponentID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsTransistionStart in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsTransistionStart
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsTranistionEnd in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsTranistionEnd
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsChildDependentOnParent in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsChildDependentOnParent
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for WorkflowTransistionTemplate in the schema.
        /// </summary>
        public virtual WorkflowTransistionTemplate WorkflowTransistionTemplate
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

        #endregion
    }

}
