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
    /// There are no comments for Bec.TargetFramework.Data.GlobalDirectDebitCollectionPeriod in the schema.
    /// </summary>
    [System.Serializable]
    public partial class GlobalDirectDebitCollectionPeriod    {

        public GlobalDirectDebitCollectionPeriod()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsCurrentPeriod = false;
          this.IsManuallyDrivenOnly = false;
          this.IsClosed = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for GlobalDirectDebitCollectionPeriodID in the schema.
        /// </summary>
        public virtual global::System.Guid GlobalDirectDebitCollectionPeriodID
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
        /// There are no comments for CollectionDay in the schema.
        /// </summary>
        public virtual int CollectionDay
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CollectionMonth in the schema.
        /// </summary>
        public virtual int CollectionMonth
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CollectionYear in the schema.
        /// </summary>
        public virtual int CollectionYear
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
        /// There are no comments for IsCurrentPeriod in the schema.
        /// </summary>
        public virtual bool IsCurrentPeriod
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsManuallyDrivenOnly in the schema.
        /// </summary>
        public virtual bool IsManuallyDrivenOnly
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
    }

}
