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
    /// There are no comments for Bec.TargetFramework.Data.OrganisationUnitStructure in the schema.
    /// </summary>
    [System.Serializable]
    public partial class OrganisationUnitStructure    {

        public OrganisationUnitStructure()
        {
          this.IsLeafNode = false;
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for OrganisationUnitStructureID in the schema.
        /// </summary>
        public virtual int OrganisationUnitStructureID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationUnitID in the schema.
        /// </summary>
        public virtual int OrganisationUnitID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> OrganisationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ParentOrganisationUnitStructureID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ParentOrganisationUnitStructureID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsLeafNode in the schema.
        /// </summary>
        public virtual bool IsLeafNode
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
        /// There are no comments for OrganisationUnit in the schema.
        /// </summary>
        public virtual OrganisationUnit OrganisationUnit
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Organisation in the schema.
        /// </summary>
        public virtual Organisation Organisation
        {
            get;
            set;
        }

        #endregion
    }

}
