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
    /// There are no comments for Bec.TargetFramework.Data.AddressChronology in the schema.
    /// </summary>
    [System.Serializable]
    public partial class AddressChronology    {

        public AddressChronology()
        {
          this.IsCurrentAddress = false;
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for AddressChronologyID in the schema.
        /// </summary>
        public virtual global::System.Guid AddressChronologyID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for ParentID in the schema.
        /// </summary>
        public virtual global::System.Guid ParentID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DataFrom in the schema.
        /// </summary>
        public virtual global::System.DateTime DataFrom
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for DateTo in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.DateTime> DateTo
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsCurrentAddress in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsCurrentAddress
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
        /// There are no comments for Address in the schema.
        /// </summary>
        public virtual Address Address
        {
            get;
            set;
        }

        #endregion
    }

}
