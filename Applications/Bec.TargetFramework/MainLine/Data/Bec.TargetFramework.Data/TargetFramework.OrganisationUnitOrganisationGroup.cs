﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 18/03/2015 19:00:44
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
    /// There are no comments for Bec.TargetFramework.Data.OrganisationUnitOrganisationGroup in the schema.
    /// </summary>
    [System.Serializable]
    public partial class OrganisationUnitOrganisationGroup    {

        public OrganisationUnitOrganisationGroup()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for OrganisationUnitID in the schema.
        /// </summary>
        public virtual int OrganisationUnitID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationGroupID in the schema.
        /// </summary>
        public virtual global::System.Guid OrganisationGroupID
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
        /// There are no comments for OrganisationUnit in the schema.
        /// </summary>
        public virtual OrganisationUnit OrganisationUnit
        {
            get;
            set;
        }

        #endregion
    }

}
