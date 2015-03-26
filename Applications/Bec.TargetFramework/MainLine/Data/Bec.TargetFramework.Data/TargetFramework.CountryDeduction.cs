﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 26/03/2015 16:14:57
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
    /// There are no comments for Bec.TargetFramework.Data.CountryDeduction in the schema.
    /// </summary>
    [System.Serializable]
    public partial class CountryDeduction    {

        public CountryDeduction()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsAppliedToAllOrders = true;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for CountryCode in the schema.
        /// </summary>
        public virtual string CountryCode
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DeductionPercentage in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> DeductionPercentage
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DeductionValue in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> DeductionValue
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
        /// There are no comments for IsAppliedToAllOrders in the schema.
        /// </summary>
        public virtual bool IsAppliedToAllOrders
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DeductionID in the schema.
        /// </summary>
        public virtual global::System.Guid DeductionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CountryDeductionID in the schema.
        /// </summary>
        public virtual global::System.Guid CountryDeductionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DeductionVersionNumber in the schema.
        /// </summary>
        public virtual int DeductionVersionNumber
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for CountryCode1 in the schema.
        /// </summary>
        public virtual CountryCode CountryCode1
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Deduction in the schema.
        /// </summary>
        public virtual Deduction Deduction
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ShoppingCarts in the schema.
        /// </summary>
        public virtual ICollection<ShoppingCart> ShoppingCarts
        {
            get;
            set;
        }

        #endregion
    }

}
