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
    /// There are no comments for Bec.TargetFramework.Data.LRDocument in the schema.
    /// </summary>
    [System.Serializable]
    public partial class LRDocument    {

        public LRDocument()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for LRDocumentID in the schema.
        /// </summary>
        public virtual global::System.Guid LRDocumentID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LRTitleID in the schema.
        /// </summary>
        public virtual global::System.Guid LRTitleID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AttachmentID in the schema.
        /// </summary>
        public virtual global::System.Guid AttachmentID
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
        /// There are no comments for ProductPurchaseProductTaskID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ProductPurchaseProductTaskID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for LRTitle in the schema.
        /// </summary>
        public virtual LRTitle LRTitle
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Attachment in the schema.
        /// </summary>
        public virtual Attachment Attachment
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
