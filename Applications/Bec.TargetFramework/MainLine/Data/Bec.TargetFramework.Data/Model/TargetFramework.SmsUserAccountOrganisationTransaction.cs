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
    /// There are no comments for Bec.TargetFramework.Data.SmsUserAccountOrganisationTransaction in the schema.
    /// </summary>
    [System.Serializable]
    public partial class SmsUserAccountOrganisationTransaction    {

        public SmsUserAccountOrganisationTransaction()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.Confirmed = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for SmsUserAccountOrganisationTransactionID in the schema.
        /// </summary>
        public virtual global::System.Guid SmsUserAccountOrganisationTransactionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UserAccountOrganisationID in the schema.
        /// </summary>
        public virtual global::System.Guid UserAccountOrganisationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SmsTransactionID in the schema.
        /// </summary>
        public virtual global::System.Guid SmsTransactionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SmsUserAccountOrganisationTransactionTypeID in the schema.
        /// </summary>
        public virtual int SmsUserAccountOrganisationTransactionTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AddressID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> AddressID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ContactID in the schema.
        /// </summary>
        public virtual global::System.Guid ContactID
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
        /// There are no comments for CreatedOn in the schema.
        /// </summary>
        public virtual global::System.DateTime CreatedOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CreatedBy in the schema.
        /// </summary>
        public virtual string CreatedBy
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ModifiedOn in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> ModifiedOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ModifiedBy in the schema.
        /// </summary>
        public virtual string ModifiedBy
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Confirmed in the schema.
        /// </summary>
        public virtual bool Confirmed
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for LatestBankAccountCheckID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> LatestBankAccountCheckID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for SmsTransaction in the schema.
        /// </summary>
        public virtual SmsTransaction SmsTransaction
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for SmsUserAccountOrganisationTransactionType in the schema.
        /// </summary>
        public virtual SmsUserAccountOrganisationTransactionType SmsUserAccountOrganisationTransactionType
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Address in the schema.
        /// </summary>
        public virtual Address Address
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Contact in the schema.
        /// </summary>
        public virtual Contact Contact
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for UserAccountOrganisation in the schema.
        /// </summary>
        public virtual UserAccountOrganisation UserAccountOrganisation
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for SmsBankAccountChecks in the schema.
        /// </summary>
        public virtual ICollection<SmsBankAccountCheck> SmsBankAccountChecks
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for LatestBankAccountCheck in the schema.
        /// </summary>
        public virtual SmsBankAccountCheck LatestBankAccountCheck
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for SmsSrcFundsBankAccounts in the schema.
        /// </summary>
        public virtual ICollection<SmsSrcFundsBankAccount> SmsSrcFundsBankAccounts
        {
            get;
            set;
        }

        #endregion
    }

}
