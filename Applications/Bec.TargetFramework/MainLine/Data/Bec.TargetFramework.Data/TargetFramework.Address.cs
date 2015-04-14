﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Entity Framework DbContext template.
// Code is generated on: 13/04/2015 17:29:36
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
    /// There are no comments for Bec.TargetFramework.Data.Address in the schema.
    /// </summary>
    [System.Serializable]
    public partial class Address    {

        public Address()
        {
          this.AddressNumber = 0;
          this.IsPrimaryAddress = false;
          this.IsActive = true;
          this.IsDeleted = false;
        }

        #region Properties
    
        /// <summary>
        /// There are no comments for AddressID in the schema.
        /// </summary>
        public virtual global::System.Guid AddressID
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
        /// There are no comments for PrimaryContactName in the schema.
        /// </summary>
        public virtual string PrimaryContactName
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Line1 in the schema.
        /// </summary>
        public virtual string Line1
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Line2 in the schema.
        /// </summary>
        public virtual string Line2
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Line3 in the schema.
        /// </summary>
        public virtual string Line3
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for City in the schema.
        /// </summary>
        public virtual string City
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for StateOrProvince in the schema.
        /// </summary>
        public virtual string StateOrProvince
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for County in the schema.
        /// </summary>
        public virtual string County
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Country in the schema.
        /// </summary>
        public virtual string Country
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PostOfficeBox in the schema.
        /// </summary>
        public virtual string PostOfficeBox
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for PostalCode in the schema.
        /// </summary>
        public virtual string PostalCode
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for UTCOffSet in the schema.
        /// </summary>
        public virtual string UTCOffSet
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Latitude in the schema.
        /// </summary>
        public virtual global::System.Nullable<double> Latitude
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Longitude in the schema.
        /// </summary>
        public virtual global::System.Nullable<double> Longitude
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
        /// There are no comments for Fax in the schema.
        /// </summary>
        public virtual string Fax
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
        /// There are no comments for AddressTypeID in the schema.
        /// </summary>
        public virtual int AddressTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AddressNumber in the schema.
        /// </summary>
        public virtual int AddressNumber
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for IsPrimaryAddress in the schema.
        /// </summary>
        public virtual global::System.Nullable<bool> IsPrimaryAddress
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AddressCategoryID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> AddressCategoryID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AddressSubTypeID in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> AddressSubTypeID
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for BuildingName in the schema.
        /// </summary>
        public virtual string BuildingName
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
        /// There are no comments for CountryCode in the schema.
        /// </summary>
        public virtual string CountryCode
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for AdditionalAddressInformation in the schema.
        /// </summary>
        public virtual string AdditionalAddressInformation
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Town in the schema.
        /// </summary>
        public virtual string Town
        {
            get;
            set;
        }

    
        /// <summary>
        /// There are no comments for Order in the schema.
        /// </summary>
        public virtual global::System.Nullable<int> Order
        {
            get;
            set;
        }


        #endregion

        #region Navigation Properties
    
        /// <summary>
        /// There are no comments for AddressChronologies in the schema.
        /// </summary>
        public virtual ICollection<AddressChronology> AddressChronologies
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for CountryCode1 in the schema.
        /// </summary>
        public virtual CountryCode CountryCode1
        {
            get;
            set;
        }
    
        /// <summary>
        /// There are no comments for LRTitles in the schema.
        /// </summary>
        public virtual ICollection<LRTitle> LRTitles
        {
            get;
            set;
        }

        #endregion
    }

}
