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
    /// There are no comments for Bec.TargetFramework.Data.PlanBilling in the schema.
    /// </summary>
    [System.Serializable]
    public partial class PlanBilling    {

        public PlanBilling()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsDefaultBilling = false;
        }

        #region Properties
    
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
        /// There are no comments for BillingID in the schema.
        /// </summary>
        public virtual global::System.Guid BillingID
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
        /// There are no comments for IsDefaultBilling in the schema.
        /// </summary>
        public virtual bool IsDefaultBilling
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for Billing in the schema.
        /// </summary>
        public virtual Billing Billing
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

        #endregion
    }

}
