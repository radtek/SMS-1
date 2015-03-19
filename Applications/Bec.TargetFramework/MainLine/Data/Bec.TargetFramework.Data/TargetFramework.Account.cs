﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 18/03/2015 19:00:45
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
    /// There are no comments for Bec.TargetFramework.Data.Account in the schema.
    /// </summary>
    [System.Serializable]
    public partial class Account    {

        public Account()
        {
          this.DoNotPhone = false;
          this.DoNotEmail = false;
          this.IsPrivate = false;
          this.DoNotTelephone = false;
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for AccountID in the schema.
        /// </summary>
        public virtual global::System.Guid AccountID
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
        /// There are no comments for CountryTypeID in the schema.
        /// </summary>
        public virtual int CountryTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AccountClassificationTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> AccountClassificationTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CustomerTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> CustomerTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BusinessTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> BusinessTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PreferredContactMethodID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> PreferredContactMethodID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IndustryTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> IndustryTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AccountTypeID in the schema.
        /// </summary>
        public virtual int AccountTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AccountSubTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> AccountSubTypeID
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
        /// There are no comments for EmailAddress1 in the schema.
        /// </summary>
        public virtual string EmailAddress1
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for EmailAddress2 in the schema.
        /// </summary>
        public virtual string EmailAddress2
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for EmailAddress3 in the schema.
        /// </summary>
        public virtual string EmailAddress3
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DoNotPhone in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> DoNotPhone
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DoNotEmail in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> DoNotEmail
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Fax in the schema.
        /// </summary>
        public virtual string Fax
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsPrivate in the schema.
        /// </summary>
        public virtual bool IsPrivate
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Telephone1 in the schema.
        /// </summary>
        public virtual string Telephone1
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Telephone2 in the schema.
        /// </summary>
        public virtual string Telephone2
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Telephone3 in the schema.
        /// </summary>
        public virtual string Telephone3
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StateTypeID in the schema.
        /// </summary>
        public virtual int StateTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OwnerID in the schema.
        /// </summary>
        public virtual global::System.Guid OwnerID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ContactID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ContactID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ParentAccountID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ParentAccountID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for MasterID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> MasterID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DoNotTelephone in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> DoNotTelephone
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for MobileNumber1 in the schema.
        /// </summary>
        public virtual string MobileNumber1
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for MobileNumber2 in the schema.
        /// </summary>
        public virtual string MobileNumber2
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for MobileNumber3 in the schema.
        /// </summary>
        public virtual string MobileNumber3
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ParentID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ParentID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AccountCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> AccountCategoryID
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
        /// There are no comments for ContactOrganisationID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ContactOrganisationID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ParentOrganisationID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> ParentOrganisationID
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
        /// There are no comments for AccountRelationshipTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> AccountRelationshipTypeID
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for InvoiceLineItems in the schema.
        /// </summary>
        public virtual ICollection<InvoiceLineItem> InvoiceLineItems
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ShoppingCartItems in the schema.
        /// </summary>
        public virtual ICollection<ShoppingCartItem> ShoppingCartItems
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
        /// There are no comments for Organisation_ContactOrganisationID in the schema.
        /// </summary>
        public virtual Organisation Organisation_ContactOrganisationID
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Organisation_ParentOrganisationID in the schema.
        /// </summary>
        public virtual Organisation Organisation_ParentOrganisationID
        {
            get;
            set;
        }

        #endregion
    }

}
