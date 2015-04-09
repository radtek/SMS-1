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
    /// There are no comments for Bec.TargetFramework.Data.PlanTransaction in the schema.
    /// </summary>
    [System.Serializable]
    public partial class PlanTransaction    {

        public PlanTransaction()
        {
          this.IsTotalValuePricingBound = false;
          this.IsTransactionCountPricingBound = false;
          this.IsActive = true;
          this.IsDeleted = false;
          this.ApplyTransactionTierPricingPerTransaction = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for PlanTransactionID in the schema.
        /// </summary>
        public virtual global::System.Guid PlanTransactionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanID in the schema.
        /// </summary>
        public virtual global::System.Guid PlanID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanVersionNumber in the schema.
        /// </summary>
        public virtual int PlanVersionNumber
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
        /// There are no comments for IsTotalValuePricingBound in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsTotalValuePricingBound
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsTransactionCountPricingBound in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsTransactionCountPricingBound
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsActive in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsActive
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsDeleted in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsDeleted
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
        /// There are no comments for ApplyTransactionTierPricingPerTransaction in the schema.
        /// </summary>
        public virtual bool ApplyTransactionTierPricingPerTransaction
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for PlanProduct in the schema.
        /// </summary>
        public virtual PlanProduct PlanProduct
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Plan in the schema.
        /// </summary>
        public virtual Plan Plan
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ComponentTiers in the schema.
        /// </summary>
        public virtual ICollection<ComponentTier> ComponentTiers
        {
            get;
            set;
        }

        #endregion
    }

}
