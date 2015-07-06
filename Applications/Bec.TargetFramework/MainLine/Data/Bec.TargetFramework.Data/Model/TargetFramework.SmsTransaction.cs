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
    /// There are no comments for Bec.TargetFramework.Data.SmsTransaction in the schema.
    /// </summary>
    [System.Serializable]
    public partial class SmsTransaction    {

        public SmsTransaction()
        {
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for SmsTransactionID in the schema.
        /// </summary>
        public virtual global::System.Guid SmsTransactionID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AddressID in the schema.
        /// </summary>
        public virtual global::System.Guid AddressID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Price in the schema.
        /// </summary>
        public virtual int Price
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Reference in the schema.
        /// </summary>
        public virtual string Reference
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
        /// There are no comments for TenureTypeID in the schema.
        /// </summary>
        public virtual int TenureTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for OrganisationID in the schema.
        /// </summary>
        public virtual global::System.Nullable<System.Guid> OrganisationID
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
        /// There are no comments for RowVersion in the schema.
        /// </summary>
        public virtual long RowVersion
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
