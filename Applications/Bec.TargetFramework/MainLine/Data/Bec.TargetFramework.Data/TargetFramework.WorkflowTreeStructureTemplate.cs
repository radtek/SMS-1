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
    /// There are no comments for Bec.TargetFramework.Data.WorkflowTreeStructureTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class WorkflowTreeStructureTemplate    {

        public WorkflowTreeStructureTemplate()
        {
          this.IsLeafNode = @"B'0'::""bit""";
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for WorkflowTreeStructureTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid WorkflowTreeStructureTemplateID
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
        /// There are no comments for Level in the schema.
        /// </summary>
        public virtual int Level
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsLeafNode in the schema.
        /// </summary>
        public virtual string IsLeafNode
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsActive in the schema.
        /// </summary>
        public virtual string IsActive
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsDeleted in the schema.
        /// </summary>
        public virtual string IsDeleted
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ParentID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ParentID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InterfacePanelTemplateID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> InterfacePanelTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InterfacePanelTemplateVersionNumber in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> InterfacePanelTemplateVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ItemOrder in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ItemOrder
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for InterfacePanelTemplate in the schema.
        /// </summary>
        public virtual InterfacePanelTemplate InterfacePanelTemplate
        {
            get;
            set;
        }

        #endregion
    }

}
