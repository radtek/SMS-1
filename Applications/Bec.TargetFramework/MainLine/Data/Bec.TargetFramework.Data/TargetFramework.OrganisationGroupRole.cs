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
    /// There are no comments for Bec.TargetFramework.Data.OrganisationGroupRole in the schema.
    /// </summary>
    [System.Serializable]
    public partial class OrganisationGroupRole    {

        public OrganisationGroupRole()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for OrganisationGroupID in the schema.
        /// </summary>
        public virtual global::System.Guid OrganisationGroupID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationRoleID in the schema.
        /// </summary>
        public virtual global::System.Guid OrganisationRoleID
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
        /// There are no comments for ParentID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ParentID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for OrganisationRole in the schema.
        /// </summary>
        public virtual OrganisationRole OrganisationRole
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationGroup in the schema.
        /// </summary>
        public virtual OrganisationGroup OrganisationGroup
        {
            get;
            set;
        }

        #endregion
    }

}
