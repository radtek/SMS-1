﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 07/04/2015 16:15:16
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
    /// There are no comments for Bec.TargetFramework.Data.DefaultOrganisationGroupRoleTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class DefaultOrganisationGroupRoleTemplate    {

        public DefaultOrganisationGroupRoleTemplate()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for DefaultOrganisationGroupTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid DefaultOrganisationGroupTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DefaultOrganisationRoleTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid DefaultOrganisationRoleTemplateID
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
        /// There are no comments for DefaultOrganisationGroupTemplate in the schema.
        /// </summary>
        public virtual DefaultOrganisationGroupTemplate DefaultOrganisationGroupTemplate
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DefaultOrganisationRoleTemplate in the schema.
        /// </summary>
        public virtual DefaultOrganisationRoleTemplate DefaultOrganisationRoleTemplate
        {
            get;
            set;
        }

        #endregion
    }

}
