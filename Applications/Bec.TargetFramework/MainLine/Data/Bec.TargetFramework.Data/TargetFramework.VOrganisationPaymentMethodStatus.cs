﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 07/04/2015 16:15:16
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
    /// There are no comments for Bec.TargetFramework.Data.VOrganisationPaymentMethodStatus in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VOrganisationPaymentMethodStatus    {

        public VOrganisationPaymentMethodStatus()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for OrganisationID in the schema.
        /// </summary>
        public virtual global::System.Guid OrganisationID
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
        /// There are no comments for OrganisationBankAccountId in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> OrganisationBankAccountId
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
        /// There are no comments for IsDirectDebit in the schema.
        /// </summary>
        public virtual bool IsDirectDebit
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsBACS in the schema.
        /// </summary>
        public virtual bool IsBACS
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationDirectDebitMandateID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> OrganisationDirectDebitMandateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsPrimary in the schema.
        /// </summary>
        public virtual bool IsPrimary
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusTypeID in the schema.
        /// </summary>
        public virtual global::System.Guid StatusTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusTypeVersionNumber in the schema.
        /// </summary>
        public virtual int StatusTypeVersionNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusTypeValueID in the schema.
        /// </summary>
        public virtual global::System.Guid StatusTypeValueID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PaymentMethodStatus in the schema.
        /// </summary>
        public virtual string PaymentMethodStatus
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationName in the schema.
        /// </summary>
        public virtual string OrganisationName
        {
            get;
            set;
        }


        #endregion
    }

}
