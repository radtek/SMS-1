﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 13/04/2015 17:29:36
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
    /// There are no comments for Bec.TargetFramework.Data.ModuleWorkflowTarget in the schema.
    /// </summary>
    [System.Serializable]
    public partial class ModuleWorkflowTarget    {

        public ModuleWorkflowTarget()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ModuleWorkflowTargetID in the schema.
        /// </summary>
        public virtual global::System.Guid ModuleWorkflowTargetID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ModuleWorkflowID in the schema.
        /// </summary>
        public virtual global::System.Guid ModuleWorkflowID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> OrganisationTypeID
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
        /// There are no comments for ModuleWorkflow in the schema.
        /// </summary>
        public virtual ModuleWorkflow ModuleWorkflow
        {
            get;
            set;
        }

        #endregion
    }

}
