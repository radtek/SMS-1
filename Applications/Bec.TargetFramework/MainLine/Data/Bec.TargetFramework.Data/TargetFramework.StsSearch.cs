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
    /// There are no comments for Bec.TargetFramework.Data.StsSearch in the schema.
    /// </summary>
    [System.Serializable]
    public partial class StsSearch    {

        public StsSearch()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for StsSearchID in the schema.
        /// </summary>
        public virtual global::System.Guid StsSearchID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StsSearchTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> StsSearchTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StsSearchSubTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> StsSearchSubTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StsSearchCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> StsSearchCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StsSearchSubCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> StsSearchSubCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InternalReferenceNumber in the schema.
        /// </summary>
        public virtual string InternalReferenceNumber
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
        /// There are no comments for AssignedToUserAccountOrganisationID in the schema.
        /// </summary>
        public virtual global::System.Guid AssignedToUserAccountOrganisationID
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


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for StsSearchDetails in the schema.
        /// </summary>
        public virtual ICollection<StsSearchDetail> StsSearchDetails
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for StsSearchProcessLogs in the schema.
        /// </summary>
        public virtual ICollection<StsSearchProcessLog> StsSearchProcessLogs
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for StsSearchRelations_BuyerStsSearchID in the schema.
        /// </summary>
        public virtual ICollection<StsSearchRelation> StsSearchRelations_BuyerStsSearchID
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for StsSearchRelations_SellerStsSearchID in the schema.
        /// </summary>
        public virtual ICollection<StsSearchRelation> StsSearchRelations_SellerStsSearchID
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for UserAccountOrganisation in the schema.
        /// </summary>
        public virtual UserAccountOrganisation UserAccountOrganisation
        {
            get;
            set;
        }

        #endregion
    }

}
