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
    /// There are no comments for Bec.TargetFramework.Data.DefaultOrganisationRoleClaimTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class DefaultOrganisationRoleClaimTemplate    {

        public DefaultOrganisationRoleClaimTemplate()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for DefaultOrganisationRoleClaimTemplateID in the schema.
        /// </summary>
        public virtual int DefaultOrganisationRoleClaimTemplateID
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
        /// There are no comments for ResourceID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ResourceID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OperationID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> OperationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StateID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> StateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StateItemID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> StateItemID
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
        /// There are no comments for DefaultOrganisationRoleTemplate in the schema.
        /// </summary>
        public virtual DefaultOrganisationRoleTemplate DefaultOrganisationRoleTemplate
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Operation in the schema.
        /// </summary>
        public virtual Operation Operation
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Resource in the schema.
        /// </summary>
        public virtual Resource Resource
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for State in the schema.
        /// </summary>
        public virtual State State
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for StateItem in the schema.
        /// </summary>
        public virtual StateItem StateItem
        {
            get;
            set;
        }

        #endregion
    }

}
