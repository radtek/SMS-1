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
    /// There are no comments for Bec.TargetFramework.Data.VOrganisationBankAccountsWithStatus in the schema.
    /// </summary>
    [System.Serializable]
    public partial class VOrganisationBankAccountsWithStatus    {

        public VOrganisationBankAccountsWithStatus()
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
        /// There are no comments for Name in the schema.
        /// </summary>
        public virtual string Name
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationBankAccountID in the schema.
        /// </summary>
        public virtual global::System.Guid OrganisationBankAccountID
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
        /// There are no comments for Created in the schema.
        /// </summary>
        public virtual global::System.DateTime Created
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Status in the schema.
        /// </summary>
        public virtual string Status
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
        /// There are no comments for Description in the schema.
        /// </summary>
        public virtual string Description
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
        /// There are no comments for StatusChangedOn in the schema.
        /// </summary>
        public virtual global::System.DateTime StatusChangedOn
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StatusChangedBy in the schema.
        /// </summary>
        public virtual string StatusChangedBy
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Notes in the schema.
        /// </summary>
        public virtual string Notes
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AccountName in the schema.
        /// </summary>
        public virtual string AccountName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Address in the schema.
        /// </summary>
        public virtual string Address
        {
            get;
            set;
        }


        #endregion
    }

}
