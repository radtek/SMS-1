﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:55
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bec.TargetFramework.Entities
{

    [DataContractAttribute(IsReference=true)]
    [System.Serializable]
    public partial class AddressDTO
    {
        #region Constructors
  
        public AddressDTO() {
        }

        public AddressDTO(global::System.Guid addressID, string name, string primaryContactName, string line1, string line2, string line3, string city, string stateOrProvince, string county, string country, string postOfficeBox, string postalCode, string uTCOffSet, global::System.Nullable<double> latitude, global::System.Nullable<double> longitude, string telephone1, string telephone2, string telephone3, string fax, global::System.Guid parentID, int addressTypeID, int addressNumber, global::System.Nullable<bool> isPrimaryAddress, global::System.Nullable<int> addressCategoryID, global::System.Nullable<int> addressSubTypeID, string buildingName, bool isActive, bool isDeleted, string countryCode, string additionalAddressInformation, string town, global::System.Nullable<int> order, List<AddressChronologyDTO> addressChronologies, CountryCodeDTO countryCode1, List<LRTitleDTO> lRTitles) {

          this.AddressID = addressID;
          this.Name = name;
          this.PrimaryContactName = primaryContactName;
          this.Line1 = line1;
          this.Line2 = line2;
          this.Line3 = line3;
          this.City = city;
          this.StateOrProvince = stateOrProvince;
          this.County = county;
          this.Country = country;
          this.PostOfficeBox = postOfficeBox;
          this.PostalCode = postalCode;
          this.UTCOffSet = uTCOffSet;
          this.Latitude = latitude;
          this.Longitude = longitude;
          this.Telephone1 = telephone1;
          this.Telephone2 = telephone2;
          this.Telephone3 = telephone3;
          this.Fax = fax;
          this.ParentID = parentID;
          this.AddressTypeID = addressTypeID;
          this.AddressNumber = addressNumber;
          this.IsPrimaryAddress = isPrimaryAddress;
          this.AddressCategoryID = addressCategoryID;
          this.AddressSubTypeID = addressSubTypeID;
          this.BuildingName = buildingName;
          this.IsActive = isActive;
          this.IsDeleted = isDeleted;
          this.CountryCode = countryCode;
          this.AdditionalAddressInformation = additionalAddressInformation;
          this.Town = town;
          this.Order = order;
          this.AddressChronologies = addressChronologies;
          this.CountryCode1 = countryCode1;
          this.LRTitles = lRTitles;
        }

        #endregion

        #region Properties

        [DataMember]
        public global::System.Guid AddressID { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string PrimaryContactName { get; set; }

        [DataMember]
        public string Line1 { get; set; }

        [DataMember]
        public string Line2 { get; set; }

        [DataMember]
        public string Line3 { get; set; }

        [DataMember]
        public string City { get; set; }

        [DataMember]
        public string StateOrProvince { get; set; }

        [DataMember]
        public string County { get; set; }

        [DataMember]
        public string Country { get; set; }

        [DataMember]
        public string PostOfficeBox { get; set; }

        [DataMember]
        public string PostalCode { get; set; }

        [DataMember]
        public string UTCOffSet { get; set; }

        [DataMember]
        public global::System.Nullable<double> Latitude { get; set; }

        [DataMember]
        public global::System.Nullable<double> Longitude { get; set; }

        [DataMember]
        public string Telephone1 { get; set; }

        [DataMember]
        public string Telephone2 { get; set; }

        [DataMember]
        public string Telephone3 { get; set; }

        [DataMember]
        public string Fax { get; set; }

        [DataMember]
        public global::System.Guid ParentID { get; set; }

        [DataMember]
        public int AddressTypeID { get; set; }

        [DataMember]
        public int AddressNumber { get; set; }

        [DataMember]
        public global::System.Nullable<bool> IsPrimaryAddress { get; set; }

        [DataMember]
        public global::System.Nullable<int> AddressCategoryID { get; set; }

        [DataMember]
        public global::System.Nullable<int> AddressSubTypeID { get; set; }

        [DataMember]
        public string BuildingName { get; set; }

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public bool IsDeleted { get; set; }

        [DataMember]
        public string CountryCode { get; set; }

        [DataMember]
        public string AdditionalAddressInformation { get; set; }

        [DataMember]
        public string Town { get; set; }

        [DataMember]
        public global::System.Nullable<int> Order { get; set; }

        #endregion

        #region Navigation Properties

        [DataMember]
        public List<AddressChronologyDTO> AddressChronologies { get; set; }

        [DataMember]
        public CountryCodeDTO CountryCode1 { get; set; }

        [DataMember]
        public List<LRTitleDTO> LRTitles { get; set; }

        #endregion
    }

}
