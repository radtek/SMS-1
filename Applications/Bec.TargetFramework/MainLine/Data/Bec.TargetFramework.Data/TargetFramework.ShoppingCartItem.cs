﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 18/03/2015 19:00:44
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
    /// There are no comments for Bec.TargetFramework.Data.ShoppingCartItem in the schema.
    /// </summary>
    [System.Serializable]
    public partial class ShoppingCartItem    {

        public ShoppingCartItem()
        {
          this.IsDeleted = false;
          this.IsActive = true;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ShoppingCartItemID in the schema.
        /// </summary>
        public virtual global::System.Guid ShoppingCartItemID
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
        /// There are no comments for IsActive in the schema.
        /// </summary>
        public virtual bool IsActive
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
        /// There are no comments for Quantity in the schema.
        /// </summary>
        public virtual int Quantity
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
        /// There are no comments for ShoppingCartID in the schema.
        /// </summary>
        public virtual global::System.Guid ShoppingCartID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for InvoiceLineItemID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> InvoiceLineItemID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AccountID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> AccountID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for Product in the schema.
        /// </summary>
        public virtual Product Product
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ShoppingCart in the schema.
        /// </summary>
        public virtual ShoppingCart ShoppingCart
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InvoiceLineItem in the schema.
        /// </summary>
        public virtual InvoiceLineItem InvoiceLineItem
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ShoppingCartItemProductAttributes in the schema.
        /// </summary>
        public virtual ICollection<ShoppingCartItemProductAttribute> ShoppingCartItemProductAttributes
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ShoppingCartItemProductSpecifications in the schema.
        /// </summary>
        public virtual ICollection<ShoppingCartItemProductSpecification> ShoppingCartItemProductSpecifications
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Account in the schema.
        /// </summary>
        public virtual Account Account
        {
            get;
            set;
        }

        #endregion
    }

}
