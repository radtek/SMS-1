﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 3/27/2015 9:57:18 AM
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
    /// There are no comments for Bec.TargetFramework.Data.DiscountRelatedProduct in the schema.
    /// </summary>
    [System.Serializable]
    public partial class DiscountRelatedProduct    {

        public DiscountRelatedProduct()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for DiscountRelatedProductID in the schema.
        /// </summary>
        public virtual global::System.Guid DiscountRelatedProductID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DiscountID in the schema.
        /// </summary>
        public virtual global::System.Guid DiscountID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DiscountVersionNumber in the schema.
        /// </summary>
        public virtual int DiscountVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProductID in the schema.
        /// </summary>
        public virtual global::System.Guid ProductID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProductVersionID in the schema.
        /// </summary>
        public virtual int ProductVersionID
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
        /// There are no comments for Discount in the schema.
        /// </summary>
        public virtual Discount Discount
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Product in the schema.
        /// </summary>
        public virtual Product Product
        {
            get;
            set;
        }

        #endregion
    }

}
