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
    /// There are no comments for Bec.TargetFramework.Data.PlanProduct in the schema.
    /// </summary>
    [System.Serializable]
    public partial class PlanProduct    {

        public PlanProduct()
        {
          this.Period = 1;
          this.IsActive = true;
          this.IsDeleted = false;
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
        /// There are no comments for Period in the schema.
        /// </summary>
        public virtual int Period
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PeriodUnitID in the schema.
        /// </summary>
        public virtual int PeriodUnitID
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
        /// There are no comments for PlanProductStatusID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> PlanProductStatusID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for Plan in the schema.
        /// </summary>
        public virtual Plan Plan
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
    
        /// <summary>
        /// There are no comments for PlanTransactions in the schema.
        /// </summary>
        public virtual ICollection<PlanTransaction> PlanTransactions
        {
            get;
            set;
        }

        #endregion
    }

}
