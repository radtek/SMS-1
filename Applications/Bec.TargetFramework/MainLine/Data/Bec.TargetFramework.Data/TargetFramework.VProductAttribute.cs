﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 07/04/2015 09:50:51
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
    /// There are no comments for Bec.TargetFramework.Data.VProductAttribute in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VProductAttribute    {

        public VProductAttribute()
        {
        }

        #region Properties
    
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
        /// There are no comments for ProductAttributeName in the schema.
        /// </summary>
        public virtual string ProductAttributeName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProductAttributeDescription in the schema.
        /// </summary>
        public virtual string ProductAttributeDescription
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsProductAttributeRequired in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsProductAttributeRequired
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProductAttributeDisplayOrder in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ProductAttributeDisplayOrder
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PriceAdjustment in the schema.
        /// </summary>
        public virtual decimal PriceAdjustment
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for WeightAdjustement in the schema.
        /// </summary>
        public virtual decimal WeightAdjustement
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Cost in the schema.
        /// </summary>
        public virtual decimal Cost
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
        /// There are no comments for IsPreSelected in the schema.
        /// </summary>
        public virtual bool IsPreSelected
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProductVariantAttributeValueID in the schema.
        /// </summary>
        public virtual global::System.Guid ProductVariantAttributeValueID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AttributeName in the schema.
        /// </summary>
        public virtual string AttributeName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProductProductAttributeID in the schema.
        /// </summary>
        public virtual global::System.Guid ProductProductAttributeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProductAttributeID in the schema.
        /// </summary>
        public virtual global::System.Guid ProductAttributeID
        {
            get;
            set;
        }


        #endregion
    }

}
