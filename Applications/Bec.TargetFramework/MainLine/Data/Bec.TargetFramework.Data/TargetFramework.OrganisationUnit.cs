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
    /// There are no comments for Bec.TargetFramework.Data.OrganisationUnit in the schema.
    /// </summary>
    [System.Serializable]
    public partial class OrganisationUnit    {

        public OrganisationUnit()
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
        /// There are no comments for DivisionName in the schema.
        /// </summary>
        public virtual string DivisionName
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
        /// There are no comments for OrganisationUnitTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> OrganisationUnitTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationUnitCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> OrganisationUnitCategoryID
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
        /// There are no comments for UserAccountOrganisations in the schema.
        /// </summary>
        public virtual ICollection<UserAccountOrganisation> UserAccountOrganisations
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationUnitOrganisationGroups in the schema.
        /// </summary>
        public virtual ICollection<OrganisationUnitOrganisationGroup> OrganisationUnitOrganisationGroups
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationUnitOrganisationRoles in the schema.
        /// </summary>
        public virtual ICollection<OrganisationUnitOrganisationRole> OrganisationUnitOrganisationRoles
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationUnitStructures in the schema.
        /// </summary>
        public virtual ICollection<OrganisationUnitStructure> OrganisationUnitStructures
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
