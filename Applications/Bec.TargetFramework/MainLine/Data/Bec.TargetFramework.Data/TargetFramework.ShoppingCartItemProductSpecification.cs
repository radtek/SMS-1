﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 08/04/2015 17:09:52
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
    /// There are no comments for Bec.TargetFramework.Data.ShoppingCartItemProductSpecification in the schema.
    /// </summary>
    [System.Serializable]
    public partial class ShoppingCartItemProductSpecification    {

        public ShoppingCartItemProductSpecification()
        {
          this.Quantity = 0m;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ShoppingCartItemProductSpecificationID in the schema.
        /// </summary>
        public virtual global::System.Guid ShoppingCartItemProductSpecificationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProductSpecificationAttributeID in the schema.
        /// </summary>
        public virtual global::System.Guid ProductSpecificationAttributeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProductSpecificationAttributeOptionID in the schema.
        /// </summary>
        public virtual global::System.Guid ProductSpecificationAttributeOptionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Quantity in the schema.
        /// </summary>
        public virtual decimal Quantity
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ShoppingCartItemID in the schema.
        /// </summary>
        public virtual global::System.Guid ShoppingCartItemID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for ProductSpecificationAttributeOption in the schema.
        /// </summary>
        public virtual ProductSpecificationAttributeOption ProductSpecificationAttributeOption
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ShoppingCartItem in the schema.
        /// </summary>
        public virtual ShoppingCartItem ShoppingCartItem
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductSpecificationAttribute in the schema.
        /// </summary>
        public virtual ProductSpecificationAttribute ProductSpecificationAttribute
        {
            get;
            set;
        }

        #endregion
    }

}
