﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 3/27/2015 9:57:18 AM
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
    /// There are no comments for Bec.TargetFramework.Data.CurrencyCode in the schema.
    /// </summary>
    [System.Serializable]
    public partial class CurrencyCode    {

        public CurrencyCode()
        {
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for CurrencyCode1 in the schema.
        /// </summary>
        public virtual string CurrencyCode1
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for CurrencyName in the schema.
        /// </summary>
        public virtual string CurrencyName
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for CountryCodes in the schema.
        /// </summary>
        public virtual ICollection<CountryCode> CountryCodes
        {
            get;
            set;
        }

        #endregion
    }

}
