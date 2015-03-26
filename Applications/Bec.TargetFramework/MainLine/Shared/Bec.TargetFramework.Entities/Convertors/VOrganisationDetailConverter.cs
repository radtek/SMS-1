﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:15:01
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class VOrganisationDetailConverter
    {

        public static VOrganisationDetailDTO ToDto(this Bec.TargetFramework.Data.VOrganisationDetail source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VOrganisationDetailDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VOrganisationDetail source, int level)
        {
            if (source == null)
              return null;

            var target = new VOrganisationDetailDTO();

            // Properties
            target.OrganisationID = source.OrganisationID;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.OrganisationSubTypeID = source.OrganisationSubTypeID;
            target.OrganisationCategoryID = source.OrganisationCategoryID;
            target.IsBranch = source.IsBranch;
            target.IsHeadOffice = source.IsHeadOffice;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsUserOrganisation = source.IsUserOrganisation;
            target.CreatedOn = source.CreatedOn;
            target.CreatedBy = source.CreatedBy;
            target.ModifiedOn = source.ModifiedOn;
            target.ModifiedBy = source.ModifiedBy;
            target.OrganisationSubCategoryID = source.OrganisationSubCategoryID;
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;
            target.ParentID = source.ParentID;
            target.ParentOrganisationID = source.ParentOrganisationID;
            target.IsPaymentProvider = source.IsPaymentProvider;
            target.ContactID = source.ContactID;
            target.ContactName = source.ContactName;
            target.MasterContactID = source.MasterContactID;
            target.OwnerID = source.OwnerID;
            target.CustomerTypeID = source.CustomerTypeID;
            target.PreferredContactMethodID = source.PreferredContactMethodID;
            target.IsBackOfficeCustomer = source.IsBackOfficeCustomer;
            target.Salutation = source.Salutation;
            target.JobTitle = source.JobTitle;
            target.FirstName = source.FirstName;
            target.Department = source.Department;
            target.NickName = source.NickName;
            target.MiddleName = source.MiddleName;
            target.LastName = source.LastName;
            target.BirthDate = source.BirthDate;
            target.Description = source.Description;
            target.GenderTypeID = source.GenderTypeID;
            target.HasChildren = source.HasChildren;
            target.EducationTypeID = source.EducationTypeID;
            target.WebSiteURL = source.WebSiteURL;
            target.EmailAddress1 = source.EmailAddress1;
            target.EmailAddress2 = source.EmailAddress2;
            target.EmailAddress3 = source.EmailAddress3;
            target.AssistantName = source.AssistantName;
            target.AssistantPhone = source.AssistantPhone;
            target.ManagerName = source.ManagerName;
            target.ManagerPhone = source.ManagerPhone;
            target.CountryTypeID = source.CountryTypeID;
            target.DoNotFax = source.DoNotFax;
            target.DoNotEmail = source.DoNotEmail;
            target.DoNotTelephone = source.DoNotTelephone;
            target.IsPrivate = source.IsPrivate;
            target.Telephone1 = source.Telephone1;
            target.Telephone2 = source.Telephone2;
            target.Telephone3 = source.Telephone3;
            target.Fax = source.Fax;
            target.MobileNumber1 = source.MobileNumber1;
            target.MobileNumber2 = source.MobileNumber2;
            target.MobileNumber3 = source.MobileNumber3;
            target.OrganisationUnitID = source.OrganisationUnitID;
            target.ParentContactID = source.ParentContactID;
            target.IsPrimaryContact = source.IsPrimaryContact;
            target.ContactTypeID = source.ContactTypeID;
            target.ContactSubTypeID = source.ContactSubTypeID;
            target.ContactCategoryID = source.ContactCategoryID;
            target.FirmName = source.FirmName;
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
            target.AddressTypeID = source.AddressTypeID;
            target.AddressNumber = source.AddressNumber;
            target.IsPrimaryAddress = source.IsPrimaryAddress;
            target.AddressCategoryID = source.AddressCategoryID;
            target.AddressSubTypeID = source.AddressSubTypeID;
            target.BuildingName = source.BuildingName;
            target.Order = source.Order;
            target.CountryCode = source.CountryCode;
            target.AdditionalAddressInformation = source.AdditionalAddressInformation;
            target.Town = source.Town;
            target.IsVATRegistered = source.IsVATRegistered;
            target.VATNumber = source.VATNumber;
            target.IsCompanyHouseRegistered = source.IsCompanyHouseRegistered;
            target.RegisteredCompanyNumber = source.RegisteredCompanyNumber;
            target.PartnersCount = source.PartnersCount;
            target.RegisteredPractitionersCount = source.RegisteredPractitionersCount;
            target.StaffCount = source.StaffCount;
            target.MonthlyCompletionsCount = source.MonthlyCompletionsCount;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VOrganisationDetail ToEntity(this VOrganisationDetailDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VOrganisationDetail();

            // Properties
            target.OrganisationID = source.OrganisationID;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.OrganisationSubTypeID = source.OrganisationSubTypeID;
            target.OrganisationCategoryID = source.OrganisationCategoryID;
            target.IsBranch = source.IsBranch;
            target.IsHeadOffice = source.IsHeadOffice;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsUserOrganisation = source.IsUserOrganisation;
            target.CreatedOn = source.CreatedOn;
            target.CreatedBy = source.CreatedBy;
            target.ModifiedOn = source.ModifiedOn;
            target.ModifiedBy = source.ModifiedBy;
            target.OrganisationSubCategoryID = source.OrganisationSubCategoryID;
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;
            target.ParentID = source.ParentID;
            target.ParentOrganisationID = source.ParentOrganisationID;
            target.IsPaymentProvider = source.IsPaymentProvider;
            target.ContactID = source.ContactID;
            target.ContactName = source.ContactName;
            target.MasterContactID = source.MasterContactID;
            target.OwnerID = source.OwnerID;
            target.CustomerTypeID = source.CustomerTypeID;
            target.PreferredContactMethodID = source.PreferredContactMethodID;
            target.IsBackOfficeCustomer = source.IsBackOfficeCustomer;
            target.Salutation = source.Salutation;
            target.JobTitle = source.JobTitle;
            target.FirstName = source.FirstName;
            target.Department = source.Department;
            target.NickName = source.NickName;
            target.MiddleName = source.MiddleName;
            target.LastName = source.LastName;
            target.BirthDate = source.BirthDate;
            target.Description = source.Description;
            target.GenderTypeID = source.GenderTypeID;
            target.HasChildren = source.HasChildren;
            target.EducationTypeID = source.EducationTypeID;
            target.WebSiteURL = source.WebSiteURL;
            target.EmailAddress1 = source.EmailAddress1;
            target.EmailAddress2 = source.EmailAddress2;
            target.EmailAddress3 = source.EmailAddress3;
            target.AssistantName = source.AssistantName;
            target.AssistantPhone = source.AssistantPhone;
            target.ManagerName = source.ManagerName;
            target.ManagerPhone = source.ManagerPhone;
            target.CountryTypeID = source.CountryTypeID;
            target.DoNotFax = source.DoNotFax;
            target.DoNotEmail = source.DoNotEmail;
            target.DoNotTelephone = source.DoNotTelephone;
            target.IsPrivate = source.IsPrivate;
            target.Telephone1 = source.Telephone1;
            target.Telephone2 = source.Telephone2;
            target.Telephone3 = source.Telephone3;
            target.Fax = source.Fax;
            target.MobileNumber1 = source.MobileNumber1;
            target.MobileNumber2 = source.MobileNumber2;
            target.MobileNumber3 = source.MobileNumber3;
            target.OrganisationUnitID = source.OrganisationUnitID;
            target.ParentContactID = source.ParentContactID;
            target.IsPrimaryContact = source.IsPrimaryContact;
            target.ContactTypeID = source.ContactTypeID;
            target.ContactSubTypeID = source.ContactSubTypeID;
            target.ContactCategoryID = source.ContactCategoryID;
            target.FirmName = source.FirmName;
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
            target.AddressTypeID = source.AddressTypeID;
            target.AddressNumber = source.AddressNumber;
            target.IsPrimaryAddress = source.IsPrimaryAddress;
            target.AddressCategoryID = source.AddressCategoryID;
            target.AddressSubTypeID = source.AddressSubTypeID;
            target.BuildingName = source.BuildingName;
            target.Order = source.Order;
            target.CountryCode = source.CountryCode;
            target.AdditionalAddressInformation = source.AdditionalAddressInformation;
            target.Town = source.Town;
            target.IsVATRegistered = source.IsVATRegistered;
            target.VATNumber = source.VATNumber;
            target.IsCompanyHouseRegistered = source.IsCompanyHouseRegistered;
            target.RegisteredCompanyNumber = source.RegisteredCompanyNumber;
            target.PartnersCount = source.PartnersCount;
            target.RegisteredPractitionersCount = source.RegisteredPractitionersCount;
            target.StaffCount = source.StaffCount;
            target.MonthlyCompletionsCount = source.MonthlyCompletionsCount;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VOrganisationDetailDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VOrganisationDetail> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VOrganisationDetailDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VOrganisationDetail> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VOrganisationDetail> ToEntities(this IEnumerable<VOrganisationDetailDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VOrganisationDetail source, VOrganisationDetailDTO target);

        static partial void OnEntityCreating(VOrganisationDetailDTO source, Bec.TargetFramework.Data.VOrganisationDetail target);

    }

}
