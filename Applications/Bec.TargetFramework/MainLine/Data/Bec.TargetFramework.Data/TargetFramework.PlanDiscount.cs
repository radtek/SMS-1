﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 17/04/2015 16:46:51
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
    /// There are no comments for Bec.TargetFramework.Data.PlanDiscount in the schema.
    /// </summary>
    [System.Serializable]
    public partial class PlanDiscount    {

        public PlanDiscount()
        {
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
        /// There are no comments for DiscountID in the schema.
        /// </summary>
        public virtual global::System.Guid DiscountID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DiscountVersionNumber in the schema.
        /// </summary>
        public virtual int DiscountVersionNumber
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


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for Discount in the schema.
        /// </summary>
        public virtual Discount Discount
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
