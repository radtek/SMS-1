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
    /// There are no comments for Bec.TargetFramework.Data.VBranch in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VBranch    {

        public VBranch()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ParentOrganisationID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ParentOrganisationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BranchOrganisationID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> BranchOrganisationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsHeadOffice in the schema.
        /// </summary>
        public virtual bool IsHeadOffice
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ContactID in the schema.
        /// </summary>
        public virtual global::System.Guid ContactID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BranchName in the schema.
        /// </summary>
        public virtual string BranchName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ContactName in the schema.
        /// </summary>
        public virtual string ContactName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for EmailAddress1 in the schema.
        /// </summary>
        public virtual string EmailAddress1
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Telephone1 in the schema.
        /// </summary>
        public virtual string Telephone1
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsPrimaryContact in the schema.
        /// </summary>
        public virtual bool IsPrimaryContact
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
        /// There are no comments for Telephone2 in the schema.
        /// </summary>
        public virtual string Telephone2
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for MobileNumber1 in the schema.
        /// </summary>
        public virtual string MobileNumber1
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for MobileNumber2 in the schema.
        /// </summary>
        public virtual string MobileNumber2
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for EmailAddress2 in the schema.
        /// </summary>
        public virtual string EmailAddress2
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WebSiteURL in the schema.
        /// </summary>
        public virtual string WebSiteURL
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ContactCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ContactCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ContactTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ContactTypeID
        {
            get;
            set;
        }


        #endregion
    }

}
