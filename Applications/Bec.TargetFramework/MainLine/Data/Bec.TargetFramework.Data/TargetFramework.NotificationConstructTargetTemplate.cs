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
    /// There are no comments for Bec.TargetFramework.Data.NotificationConstructTargetTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class NotificationConstructTargetTemplate    {

        public NotificationConstructTargetTemplate()
        {
          this.IsSingleUser = false;
          this.IsOrganisationBranchOnly = false;
          this.IsDefaultTarget = false;
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for NotificationConstructTargetTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid NotificationConstructTargetTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NotificationConstructTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid NotificationConstructTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NotificationConstructTemplateVersionNumber in the schema.
        /// </summary>
        public virtual int NotificationConstructTemplateVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> OrganisationTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UserTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> UserTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsSingleUser in the schema.
        /// </summary>
        public virtual bool IsSingleUser
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsOrganisationBranchOnly in the schema.
        /// </summary>
        public virtual bool IsOrganisationBranchOnly
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsDefaultTarget in the schema.
        /// </summary>
        public virtual bool IsDefaultTarget
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
        /// There are no comments for NotificationConstructTemplate in the schema.
        /// </summary>
        public virtual NotificationConstructTemplate NotificationConstructTemplate
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for OrganisationType in the schema.
        /// </summary>
        public virtual OrganisationType OrganisationType
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for UserType in the schema.
        /// </summary>
        public virtual UserType UserType
        {
            get;
            set;
        }

        #endregion
    }

}
