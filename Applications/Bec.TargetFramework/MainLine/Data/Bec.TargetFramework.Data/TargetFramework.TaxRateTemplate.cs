﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 02/04/2015 16:41:46
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
    /// There are no comments for Bec.TargetFramework.Data.TaxRateTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class TaxRateTemplate    {

        public TaxRateTemplate()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for TaxRateTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid TaxRateTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TaxCategoryID in the schema.
        /// </summary>
        public virtual int TaxCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for TaxPercentage in the schema.
        /// </summary>
        public virtual decimal TaxPercentage
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CountryID in the schema.
        /// </summary>
        public virtual int CountryID
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


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for TaxRates in the schema.
        /// </summary>
        public virtual ICollection<TaxRate> TaxRates
        {
            get;
            set;
        }

        #endregion
    }

}
