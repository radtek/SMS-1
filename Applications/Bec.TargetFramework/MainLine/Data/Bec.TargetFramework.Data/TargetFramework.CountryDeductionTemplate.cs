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
    /// There are no comments for Bec.TargetFramework.Data.CountryDeductionTemplate in the schema.
    /// </summary>
    [System.Serializable]
    public partial class CountryDeductionTemplate    {

        public CountryDeductionTemplate()
        {
          this.IsActive = true;
          this.IsDeleted = false;
          this.IsAppliedToAllOrders = true;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for DeductionTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid DeductionTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CountryCode in the schema.
        /// </summary>
        public virtual string CountryCode
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DeductionPercentage in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> DeductionPercentage
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DeductionValue in the schema.
        /// </summary>
        public virtual global::System.Nullable<decimal> DeductionValue
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
        /// There are no comments for IsAppliedToAllOrders in the schema.
        /// </summary>
        public virtual bool IsAppliedToAllOrders
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CountryDeductionTemplateID in the schema.
        /// </summary>
        public virtual global::System.Guid CountryDeductionTemplateID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DeductionTemplateVersionNumber in the schema.
        /// </summary>
        public virtual int DeductionTemplateVersionNumber
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for CountryCode1 in the schema.
        /// </summary>
        public virtual CountryCode CountryCode1
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for DeductionTemplate in the schema.
        /// </summary>
        public virtual DeductionTemplate DeductionTemplate
        {
            get;
            set;
        }

        #endregion
    }

}
