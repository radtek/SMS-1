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
    /// There are no comments for Bec.TargetFramework.Data.PlanTransactionTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class PlanTransactionTemplate    {

        public PlanTransactionTemplate()
        {
          this.IsTotalValuePricingBound = false;
          this.IsTransactionCountPricingBound = false;
          this.IsActive = true;
          this.IsDeleted = false;
          this.ApplyTransactionTierPricingPerTransaction = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for PlanTransactionTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid PlanTransactionTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid PlanTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PlanTemplateVersionNumber in the schema.
        /// </summary>
        public virtual int PlanTemplateVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ProductTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid ProductTemplateID
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
        /// There are no comments for PlanProductTemplate in the schema.
        /// </summary>
        public virtual PlanProductTemplate PlanProductTemplate
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PlanTemplate in the schema.
        /// </summary>
        public virtual PlanTemplate PlanTemplate
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ComponentTierTemplates in the schema.
        /// </summary>
        public virtual ICollection<ComponentTierTemplate> ComponentTierTemplates
        {
            get;
            set;
        }

        #endregion
    }

}
