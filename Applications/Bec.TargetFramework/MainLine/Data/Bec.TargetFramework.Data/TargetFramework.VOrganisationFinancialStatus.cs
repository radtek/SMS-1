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
    /// There are no comments for Bec.TargetFramework.Data.VOrganisationFinancialStatus in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VOrganisationFinancialStatus    {

        public VOrganisationFinancialStatus()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for OrganisationFinancialDetailID in the schema.
        /// </summary>
        public virtual global::System.Guid OrganisationFinancialDetailID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FinancialStatusTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> FinancialStatusTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FinancialStatusTypeVersionNumber in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> FinancialStatusTypeVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FinancialStatusTypeValueID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> FinancialStatusTypeValueID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for HasACreditLimit in the schema.
        /// </summary>
        public virtual bool HasACreditLimit
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CreditLimit in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> CreditLimit
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for NumberOfLatePayments in the schema.
        /// </summary>
        public virtual int NumberOfLatePayments
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for HasLatePayments in the schema.
        /// </summary>
        public virtual bool HasLatePayments
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationID in the schema.
        /// </summary>
        public virtual global::System.Guid OrganisationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Name in the schema.
        /// </summary>
        public virtual string Name
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for FinancialStatus in the schema.
        /// </summary>
        public virtual string FinancialStatus
        {
            get;
            set;
        }


        #endregion
    }

}
