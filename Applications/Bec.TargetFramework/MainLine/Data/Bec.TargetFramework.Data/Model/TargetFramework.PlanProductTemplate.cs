﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
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
    /// There are no comments for Bec.TargetFramework.Data.PlanProductTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class PlanProductTemplate    {

        public PlanProductTemplate()
        {
          this.Period = 1;
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
        /// There are no comments for PlanTemplate in the schema.
        /// </summary>
        public virtual PlanTemplate PlanTemplate
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ProductTemplate in the schema.
        /// </summary>
        public virtual ProductTemplate ProductTemplate
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PlanTransactionTemplates in the schema.
        /// </summary>
        public virtual ICollection<PlanTransactionTemplate> PlanTransactionTemplates
        {
            get;
            set;
        }

        #endregion
    }

}