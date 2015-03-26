﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 26/03/2015 16:14:58
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
    /// There are no comments for Bec.TargetFramework.Data.OrganisationBankAccount in the schema.
    /// </summary>
    [System.Serializable]
    public partial class OrganisationBankAccount    {

        public OrganisationBankAccount()
        {
          this.IsPrimary = true;
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsDirectDebtAccount = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for OrganisationBankAccountId in the schema.
        /// </summary>
        public virtual int OrganisationBankAccountId
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
        /// There are no comments for BankAccountTypeID in the schema.
        /// </summary>
        public virtual int BankAccountTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SortCode in the schema.
        /// </summary>
        public virtual string SortCode
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BankAccountNumber in the schema.
        /// </summary>
        public virtual string BankAccountNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IBANNumber in the schema.
        /// </summary>
        public virtual string IBANNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SwiftCode in the schema.
        /// </summary>
        public virtual string SwiftCode
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BankAccountDurationTypeID in the schema.
        /// </summary>
        public virtual int BankAccountDurationTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BankAccountOpeningYear in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> BankAccountOpeningYear
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BankAccountOpeningMonth in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> BankAccountOpeningMonth
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
        /// There are no comments for IsDirectDebtAccount in the schema.
        /// </summary>
        public virtual bool IsDirectDebtAccount
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for OrganisationPaymentMethods in the schema.
        /// </summary>
        public virtual ICollection<OrganisationPaymentMethod> OrganisationPaymentMethods
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Organisation in the schema.
        /// </summary>
        public virtual Organisation Organisation
        {
            get;
            set;
        }

        #endregion
    }

}
