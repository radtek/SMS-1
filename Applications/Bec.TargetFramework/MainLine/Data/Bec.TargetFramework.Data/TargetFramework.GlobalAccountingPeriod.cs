﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 07/04/2015 09:50:51
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
    /// There are no comments for Bec.TargetFramework.Data.GlobalAccountingPeriod in the schema.
    /// </summary>
    [System.Serializable]
    public partial class GlobalAccountingPeriod    {

        public GlobalAccountingPeriod()
        {
          this.IsFinancialClosePeriod = false;
          this.IsCurrentPeriod = false;
          this.IsClosed = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for GlobalAccountingPeriodID in the schema.
        /// </summary>
        public virtual int GlobalAccountingPeriodID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PeriodNumber in the schema.
        /// </summary>
        public virtual int PeriodNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StartDay in the schema.
        /// </summary>
        public virtual int StartDay
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for EndDay in the schema.
        /// </summary>
        public virtual int EndDay
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Month in the schema.
        /// </summary>
        public virtual int Month
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Year in the schema.
        /// </summary>
        public virtual int Year
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsFinancialClosePeriod in the schema.
        /// </summary>
        public virtual bool IsFinancialClosePeriod
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsCurrentPeriod in the schema.
        /// </summary>
        public virtual bool IsCurrentPeriod
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsClosed in the schema.
        /// </summary>
        public virtual bool IsClosed
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for OrganisationAccountingPeriods in the schema.
        /// </summary>
        public virtual ICollection<OrganisationAccountingPeriod> OrganisationAccountingPeriods
        {
            get;
            set;
        }

        #endregion
    }

}
