﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
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
    /// There are no comments for Bec.TargetFramework.Data.LRTitle in the schema.
    /// </summary>
    [System.Serializable]
    public partial class LRTitle    {

        public LRTitle()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for LRTitleID in the schema.
        /// </summary>
        public virtual global::System.Guid LRTitleID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TitleNumber in the schema.
        /// </summary>
        public virtual string TitleNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StsPropertyID in the schema.
        /// </summary>
        public virtual global::System.Guid StsPropertyID
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
        /// There are no comments for CreatedOn in the schema.
        /// </summary>
        public virtual global::System.DateTime CreatedOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CreatedBy in the schema.
        /// </summary>
        public virtual string CreatedBy
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
        /// There are no comments for ProductPurchaseProductTaskID in the schema.
        /// </summary>
        public virtual global::System.Guid ProductPurchaseProductTaskID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StsSearchPropertyID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> StsSearchPropertyID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LRPropertyTenureTypeID in the schema.
        /// </summary>
        public virtual int LRPropertyTenureTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AddressID in the schema.
        /// </summary>
        public virtual global::System.Guid AddressID
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
        /// There are no comments for LRDocuments in the schema.
        /// </summary>
        public virtual ICollection<LRDocument> LRDocuments
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for LRRegisterExtracts in the schema.
        /// </summary>
        public virtual ICollection<LRRegisterExtract> LRRegisterExtracts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Address in the schema.
        /// </summary>
        public virtual Address Address
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductPurchaseBusTaskProcessLog in the schema.
        /// </summary>
        public virtual ProductPurchaseBusTaskProcessLog ProductPurchaseBusTaskProcessLog
        {
            get;
            set;
        }

        #endregion
    }

}
