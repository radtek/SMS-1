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
    /// There are no comments for Bec.TargetFramework.Data.PlanGlobalPaymentMethodTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class PlanGlobalPaymentMethodTemplate    {

        public PlanGlobalPaymentMethodTemplate()
        {
          this.IsDefaultPaymentMethod = false;
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
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
        /// There are no comments for GlobalPaymentMethodID in the schema.
        /// </summary>
        public virtual global::System.Guid GlobalPaymentMethodID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsDefaultPaymentMethod in the schema.
        /// </summary>
        public virtual bool IsDefaultPaymentMethod
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
        /// There are no comments for BillingTemplateID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> BillingTemplateID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for GlobalPaymentMethod in the schema.
        /// </summary>
        public virtual GlobalPaymentMethod GlobalPaymentMethod
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
        /// There are no comments for BillingTemplate in the schema.
        /// </summary>
        public virtual BillingTemplate BillingTemplate
        {
            get;
            set;
        }

        #endregion
    }

}
