﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 09/04/2015 12:02:52
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
    /// There are no comments for Bec.TargetFramework.Data.Structure in the schema.
    /// </summary>
    [System.Serializable]
    public partial class Structure    {

        public Structure()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for RepositoryMapID in the schema.
        /// </summary>
        public virtual global::System.Guid RepositoryMapID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationRoleID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> OrganisationRoleID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationExternalRoleID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> OrganisationExternalRoleID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StructureID in the schema.
        /// </summary>
        public virtual int StructureID
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
    }

}
