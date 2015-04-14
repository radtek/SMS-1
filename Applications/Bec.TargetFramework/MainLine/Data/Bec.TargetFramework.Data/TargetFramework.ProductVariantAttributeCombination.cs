﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 13/04/2015 17:29:36
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
    /// There are no comments for Bec.TargetFramework.Data.ProductVariantAttributeCombination in the schema.
    /// </summary>
    [System.Serializable]
    public partial class ProductVariantAttributeCombination    {

        public ProductVariantAttributeCombination()
        {
          this.AllowOutOfStockOrders = false;
          this.StockQuantity = 0;
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ProductVariantAttributeCombinationID in the schema.
        /// </summary>
        public virtual global::System.Guid ProductVariantAttributeCombinationID
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
        /// There are no comments for AllowOutOfStockOrders in the schema.
        /// </summary>
        public virtual bool AllowOutOfStockOrders
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StockQuantity in the schema.
        /// </summary>
        public virtual int StockQuantity
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Sku in the schema.
        /// </summary>
        public virtual string Sku
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ManufacturerPartNumber in the schema.
        /// </summary>
        public virtual string ManufacturerPartNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Gtin in the schema.
        /// </summary>
        public virtual string Gtin
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OverridenPrice in the schema.
        /// </summary>
        public virtual decimal OverridenPrice
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
        /// There are no comments for ProductVersionID in the schema.
        /// </summary>
        public virtual int ProductVersionID
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

        #endregion
    }

}
