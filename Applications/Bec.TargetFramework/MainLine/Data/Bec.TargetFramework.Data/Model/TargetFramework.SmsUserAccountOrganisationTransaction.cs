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
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for SmsUserAccountOrganisationTransactionId in the schema.
        /// </summary>
        public virtual global::System.Guid SmsUserAccountOrganisationTransactionId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UserAccountOrganisationId in the schema.
        /// </summary>
        public virtual global::System.Guid UserAccountOrganisationId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SmsTransactionId in the schema.
        /// </summary>
        public virtual global::System.Guid SmsTransactionId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for SmsUserAccountOrganisationTransactionTypeId in the schema.
        /// </summary>
        public virtual int SmsUserAccountOrganisationTransactionTypeId
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UserAccountAddressId in the schema.
        /// </summary>
        public virtual global::System.Guid UserAccountAddressId
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
        /// There are no comments for UserAccountAddress in the schema.
        /// </summary>
        public virtual UserAccountAddress UserAccountAddress
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

        #endregion
    }

}