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
    /// There are no comments for Bec.TargetFramework.Data.PlanBillingTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class PlanBillingTemplate    {

        public PlanBillingTemplate()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsDefaultBilling = true;
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
        /// There are no comments for BillingTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid BillingTemplateID
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
        /// There are no comments for BillingTemplate in the schema.
        /// </summary>
        public virtual BillingTemplate BillingTemplate
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

        #endregion
    }

}
