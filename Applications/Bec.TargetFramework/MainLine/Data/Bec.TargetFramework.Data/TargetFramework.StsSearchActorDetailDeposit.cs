﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 2/12/2015 3:31:04 PM
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
    /// There are no comments for Bec.TargetFramework.Data.StsSearchActorDetailDeposit in the schema.
    /// </summary>
    [System.Serializable]
    public partial class StsSearchActorDetailDeposit    {

        public StsSearchActorDetailDeposit()
        {
          this.DoesDepositGiftorRetainChargeOverProperty = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for StsSearchActorDetailDeposit1 in the schema.
        /// </summary>
        public virtual global::System.Guid StsSearchActorDetailDeposit1
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StsSearchSecondaryActorDetailID in the schema.
        /// </summary>
        public virtual global::System.Guid StsSearchSecondaryActorDetailID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DepositAmount in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> DepositAmount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DepositFromTypeID in the schema.
        /// </summary>
        public virtual int DepositFromTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DoesDepositGiftorRetainChargeOverProperty in the schema.
        /// </summary>
        public virtual bool DoesDepositGiftorRetainChargeOverProperty
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DepositGiftorContactID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> DepositGiftorContactID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LoanProvider in the schema.
        /// </summary>
        public virtual string LoanProvider
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LoanInterestRate in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> LoanInterestRate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LoanFinalRepaymentDate in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> LoanFinalRepaymentDate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LoanMonthlyRepaymentAmount in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> LoanMonthlyRepaymentAmount
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LoanCurrentBalance in the schema.
        /// </summary>
        public virtual decimal LoanCurrentBalance
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for StsSearchActorDetail in the schema.
        /// </summary>
        public virtual StsSearchActorDetail StsSearchActorDetail
        {
            get;
            set;
        }

        #endregion
    }

}
