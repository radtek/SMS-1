﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 02/04/2015 16:41:46
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
    /// There are no comments for Bec.TargetFramework.Data.VProductSpecification in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VProductSpecification    {

        public VProductSpecification()
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
        /// There are no comments for SpecificationName in the schema.
        /// </summary>
        public virtual string SpecificationName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SpecificationDescription in the schema.
        /// </summary>
        public virtual string SpecificationDescription
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SpecificationDisplayOrder in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> SpecificationDisplayOrder
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsMandatory in the schema.
        /// </summary>
        public virtual bool IsMandatory
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsMultiSelect in the schema.
        /// </summary>
        public virtual bool IsMultiSelect
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
        /// There are no comments for MinimumSelectionLimit in the schema.
        /// </summary>
        public virtual int MinimumSelectionLimit
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for MaximumSelectionLimit in the schema.
        /// </summary>
        public virtual int MaximumSelectionLimit
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsUserDefined in the schema.
        /// </summary>
        public virtual bool IsUserDefined
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsPriceDriven in the schema.
        /// </summary>
        public virtual bool IsPriceDriven
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
        /// There are no comments for SpecDefaultOptionPriceAdjustement in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> SpecDefaultOptionPriceAdjustement
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SpecDefaultOptionCost in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> SpecDefaultOptionCost
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SpecDefaultOptionDefaultValue in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> SpecDefaultOptionDefaultValue
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SpecDefaultOptionDefaultQuantity in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> SpecDefaultOptionDefaultQuantity
        {
            get;
            set;
        }


        #endregion
    }

}
