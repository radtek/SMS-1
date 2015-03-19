﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 18/03/2015 19:00:45
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
    /// There are no comments for Bec.TargetFramework.Data.ComponentTier in the schema.
    /// </summary>
    [System.Serializable]
    public partial class ComponentTier    {

        public ComponentTier()
        {
          this.IsPercentageBased = false;
          this.ApplyToTotal = false;
          this.ApplyPerTransaction = false;
          this.IsActive = true;
          this.IsDeleted = false;
          this.HasNoUpperBound = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for ComponentTierID in the schema.
        /// </summary>
        public virtual global::System.Guid ComponentTierID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TotalValueLowerBound in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> TotalValueLowerBound
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TotalValueUpperBound in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> TotalValueUpperBound
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for QuantityCountLowerBound in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> QuantityCountLowerBound
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for QuantityCountUpperBound in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> QuantityCountUpperBound
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsPercentageBased in the schema.
        /// </summary>
        public virtual bool IsPercentageBased
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TierPrice in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> TierPrice
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TierPercentage in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> TierPercentage
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ApplyToTotal in the schema.
        /// </summary>
        public virtual bool ApplyToTotal
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ApplyOnPaymentMethodTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ApplyOnPaymentMethodTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ApplyPerTransaction in the schema.
        /// </summary>
        public virtual bool ApplyPerTransaction
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Name in the schema.
        /// </summary>
        public virtual string Name
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
        /// There are no comments for Order in the schema.
        /// </summary>
        public virtual int Order
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TierOrder in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> TierOrder
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
        /// There are no comments for OrganisationTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> OrganisationTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UserTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> UserTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for HasNoUpperBound in the schema.
        /// </summary>
        public virtual bool HasNoUpperBound
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ParentVersionNumber in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ParentVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ApplyOnPaymentCardTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> ApplyOnPaymentCardTypeID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for OrganisationType in the schema.
        /// </summary>
        public virtual OrganisationType OrganisationType
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for UserType in the schema.
        /// </summary>
        public virtual UserType UserType
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Products in the schema.
        /// </summary>
        public virtual ICollection<Product> Products
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Discounts in the schema.
        /// </summary>
        public virtual ICollection<Discount> Discounts
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PlanTransactions in the schema.
        /// </summary>
        public virtual ICollection<PlanTransaction> PlanTransactions
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Deductions in the schema.
        /// </summary>
        public virtual ICollection<Deduction> Deductions
        {
            get;
            set;
        }

        #endregion
    }

}
