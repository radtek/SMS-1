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
    /// There are no comments for Bec.TargetFramework.Data.ModuleWorkflowTargetTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class ModuleWorkflowTargetTemplate    {

        public ModuleWorkflowTargetTemplate()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ModuleWorkflowTargetTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid ModuleWorkflowTargetTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ModuleWorkflowTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid ModuleWorkflowTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationTypeID in the schema.
        /// </summary>
        public virtual int OrganisationTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationSubTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> OrganisationSubTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> OrganisationCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationSubCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> OrganisationSubCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UserTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> UserTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UserSubTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> UserSubTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UserCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> UserCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UserSubCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> UserSubCategoryID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for ModuleWorkflowTemplate in the schema.
        /// </summary>
        public virtual ModuleWorkflowTemplate ModuleWorkflowTemplate
        {
            get;
            set;
        }

        #endregion
    }

}
