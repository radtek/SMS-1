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
    /// There are no comments for Bec.TargetFramework.Data.DefaultOrganisationRoleTarget in the schema.
    /// </summary>
    [System.Serializable]
    public partial class DefaultOrganisationRoleTarget    {

        public DefaultOrganisationRoleTarget()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for DefaultOrganisationRoleID in the schema.
        /// </summary>
        public virtual global::System.Guid DefaultOrganisationRoleID
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
        /// There are no comments for DefaultOrganisationUserTargetID in the schema.
        /// </summary>
        public virtual global::System.Guid DefaultOrganisationUserTargetID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for DefaultOrganisationUserTarget in the schema.
        /// </summary>
        public virtual DefaultOrganisationUserTarget DefaultOrganisationUserTarget
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationRole in the schema.
        /// </summary>
        public virtual DefaultOrganisationRole DefaultOrganisationRole
        {
            get;
            set;
        }

        #endregion
    }

}
