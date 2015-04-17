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
    /// There are no comments for Bec.TargetFramework.Data.OrganisationTeam in the schema.
    /// </summary>
    [System.Serializable]
    public partial class OrganisationTeam    {

        public OrganisationTeam()
        {
          this.IsDefault = false;
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for OrganisationTeamID in the schema.
        /// </summary>
        public virtual global::System.Guid OrganisationTeamID
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
        /// There are no comments for EmailAddress in the schema.
        /// </summary>
        public virtual string EmailAddress
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsDefault in the schema.
        /// </summary>
        public virtual bool IsDefault
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TeamTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> TeamTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TeamSubTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> TeamSubTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TeamCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> TeamCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TeamSubCategoryID in the schema.
        /// </summary>
        public virtual int TeamSubCategoryID
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
        /// There are no comments for OrganisationID in the schema.
        /// </summary>
        public virtual global::System.Guid OrganisationID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for UserAccountOrganisationTeams in the schema.
        /// </summary>
        public virtual ICollection<UserAccountOrganisationTeam> UserAccountOrganisationTeams
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationTeamSettings in the schema.
        /// </summary>
        public virtual ICollection<OrganisationTeamSetting> OrganisationTeamSettings
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
