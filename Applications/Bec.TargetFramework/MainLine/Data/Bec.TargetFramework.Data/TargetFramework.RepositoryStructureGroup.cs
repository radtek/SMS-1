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
    /// There are no comments for Bec.TargetFramework.Data.RepositoryStructureGroup in the schema.
    /// </summary>
    [System.Serializable]
    public partial class RepositoryStructureGroup    {

        public RepositoryStructureGroup()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for RepositoryStructureID in the schema.
        /// </summary>
        public virtual global::System.Guid RepositoryStructureID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationGroupID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> OrganisationGroupID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationExternalGroupID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> OrganisationExternalGroupID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for RepositoryStructureGroupID in the schema.
        /// </summary>
        public virtual int RepositoryStructureGroupID
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
        /// There are no comments for OrganisationGroup in the schema.
        /// </summary>
        public virtual OrganisationGroup OrganisationGroup
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for RepositoryStructure in the schema.
        /// </summary>
        public virtual RepositoryStructure RepositoryStructure
        {
            get;
            set;
        }

        #endregion
    }

}
