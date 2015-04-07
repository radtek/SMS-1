﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 16:15:20
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class AddressConverter
    {

        public static AddressDTO ToDto(this Bec.TargetFramework.Data.Address source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static AddressDTO ToDtoWithRelated(this Bec.TargetFramework.Data.Address source, int level)
        {
            if (source == null)
              return null;

            var target = new AddressDTO();

            // Properties
            target.AddressID = source.AddressID;
            target.Name = source.Name;
            target.PrimaryContactName = source.PrimaryContactName;
            target.Line1 = source.Line1;
            target.Line2 = source.Line2;
            target.Line3 = source.Line3;
            target.City = source.City;
            target.StateOrProvince = source.StateOrProvince;
            target.County = source.County;
            target.Country = source.Country;
            target.PostOfficeBox = source.PostOfficeBox;
            target.PostalCode = source.PostalCode;
            target.UTCOffSet = source.UTCOffSet;
            target.Latitude = source.Latitude;
            target.Longitude = source.Longitude;
            target.Telephone1 = source.Telephone1;
            target.Telephone2 = source.Telephone2;
            target.Telephone3 = source.Telephone3;
            target.Fax = source.Fax;
            target.ParentID = source.ParentID;
            target.AddressTypeID = source.AddressTypeID;
            target.AddressNumber = source.AddressNumber;
            target.IsPrimaryAddress = source.IsPrimaryAddress;
            target.AddressCategoryID = source.AddressCategoryID;
            target.AddressSubTypeID = source.AddressSubTypeID;
            target.BuildingName = source.BuildingName;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.CountryCode = source.CountryCode;
            target.AdditionalAddressInformation = source.AdditionalAddressInformation;
            target.Town = source.Town;
            target.Order = source.Order;

            // Navigation Properties
            if (level > 0) {
              target.AddressChronologies = source.AddressChronologies.ToDtosWithRelated(level - 1);
              target.CountryCode1 = source.CountryCode1.ToDtoWithRelated(level - 1);
              target.LRTitles = source.LRTitles.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.Address ToEntity(this AddressDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.Address();

            // Properties
            target.AddressID = source.AddressID;
            target.Name = source.Name;
            target.PrimaryContactName = source.PrimaryContactName;
            target.Line1 = source.Line1;
            target.Line2 = source.Line2;
            target.Line3 = source.Line3;
            target.City = source.City;
            target.StateOrProvince = source.StateOrProvince;
            target.County = source.County;
            target.Country = source.Country;
            target.PostOfficeBox = source.PostOfficeBox;
            target.PostalCode = source.PostalCode;
            target.UTCOffSet = source.UTCOffSet;
            target.Latitude = source.Latitude;
            target.Longitude = source.Longitude;
            target.Telephone1 = source.Telephone1;
            target.Telephone2 = source.Telephone2;
            target.Telephone3 = source.Telephone3;
            target.Fax = source.Fax;
            target.ParentID = source.ParentID;
            target.AddressTypeID = source.AddressTypeID;
            target.AddressNumber = source.AddressNumber;
            target.IsPrimaryAddress = source.IsPrimaryAddress;
            target.AddressCategoryID = source.AddressCategoryID;
            target.AddressSubTypeID = source.AddressSubTypeID;
            target.BuildingName = source.BuildingName;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.CountryCode = source.CountryCode;
            target.AdditionalAddressInformation = source.AdditionalAddressInformation;
            target.Town = source.Town;
            target.Order = source.Order;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<AddressDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.Address> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<AddressDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.Address> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.Address> ToEntities(this IEnumerable<AddressDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.Address source, AddressDTO target);

        static partial void OnEntityCreating(AddressDTO source, Bec.TargetFramework.Data.Address target);

    }

}
