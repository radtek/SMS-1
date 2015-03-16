﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 2/12/2015 3:31:04 PM
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
    /// There are no comments for Bec.TargetFramework.Data.StsInvite in the schema.
    /// </summary>
    [System.Serializable]
    public partial class StsInvite    {

        public StsInvite()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.DoesInviteeExistOnSystem = false;
          this.InviteeIsExistingUser = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for StsInviteID in the schema.
        /// </summary>
        public virtual global::System.Guid StsInviteID
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

    
        /// <summary>
        /// There are no comments for NotificationID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> NotificationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CreatedOn in the schema.
        /// </summary>
        public virtual global::System.DateTime CreatedOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InviteTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> InviteTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InviteDetail in the schema.
        /// </summary>
        public virtual string InviteDetail
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
        /// There are no comments for InviteSubTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> InviteSubTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InviteCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> InviteCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InviteSubCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> InviteSubCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DoesInviteeExistOnSystem in the schema.
        /// </summary>
        public virtual bool DoesInviteeExistOnSystem
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InviteeIsExistingUser in the schema.
        /// </summary>
        public virtual bool InviteeIsExistingUser
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for StsInviteProcessLogs in the schema.
        /// </summary>
        public virtual ICollection<StsInviteProcessLog> StsInviteProcessLogs
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for StsSearchActors in the schema.
        /// </summary>
        public virtual ICollection<StsSearchActor> StsSearchActors
        {
            get;
            set;
        }

        #endregion
    }

}
