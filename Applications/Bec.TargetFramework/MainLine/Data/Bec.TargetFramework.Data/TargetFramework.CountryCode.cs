﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 09/04/2015 12:02:52
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
    /// There are no comments for Bec.TargetFramework.Data.CountryCode in the schema.
    /// </summary>
    [System.Serializable]
    public partial class CountryCode    {

        public CountryCode()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for CountryCode1 in the schema.
        /// </summary>
        public virtual string CountryCode1
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CountryName in the schema.
        /// </summary>
        public virtual string CountryName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CurrencyCode in the schema.
        /// </summary>
        public virtual string CurrencyCode
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for PlanTemplates in the schema.
        /// </summary>
        public virtual ICollection<PlanTemplate> PlanTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for InvoiceLineItems in the schema.
        /// </summary>
        public virtual ICollection<InvoiceLineItem> InvoiceLineItems
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Plans in the schema.
        /// </summary>
        public virtual ICollection<Plan> Plans
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Invoices in the schema.
        /// </summary>
        public virtual ICollection<Invoice> Invoices
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for PlanSubscriptions in the schema.
        /// </summary>
        public virtual ICollection<PlanSubscription> PlanSubscriptions
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for CountryDeductions in the schema.
        /// </summary>
        public virtual ICollection<CountryDeduction> CountryDeductions
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for CountryDeductionTemplates in the schema.
        /// </summary>
        public virtual ICollection<CountryDeductionTemplate> CountryDeductionTemplates
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for CurrencyCode1 in the schema.
        /// </summary>
        public virtual CurrencyCode CurrencyCode1
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for ContactPhones in the schema.
        /// </summary>
        public virtual ICollection<ContactPhone> ContactPhones
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for Addresses in the schema.
        /// </summary>
        public virtual ICollection<Address> Addresses
        {
            get;
            set;
        }

        #endregion
    }

}
