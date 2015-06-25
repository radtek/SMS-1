﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class VUserAccountOrganisationConverter
    {

        public static VUserAccountOrganisationDTO ToDto(this Bec.TargetFramework.Data.VUserAccountOrganisation source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VUserAccountOrganisationDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VUserAccountOrganisation source, int level)
        {
            if (source == null)
              return null;

            var target = new VUserAccountOrganisationDTO();

            // Properties
            target.ID = source.ID;
            target.IsTemporaryAccount = source.IsTemporaryAccount;
            target.UserAccountOrganisationID = source.UserAccountOrganisationID;
            target.UserTypeID = source.UserTypeID;
            target.OrganisationBranchID = source.OrganisationBranchID;
            target.OrganisationID = source.OrganisationID;
            target.Name = source.Name;
            target.IsBranch = source.IsBranch;
            target.IsHeadOffice = source.IsHeadOffice;
            target.IsUserOrganisation = source.IsUserOrganisation;
            target.IsPaymentProvider = source.IsPaymentProvider;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.OrganisationTypeName = source.OrganisationTypeName;
            target.UserTypeName = source.UserTypeName;
            target.VATNumber = source.VATNumber;
            target.IsVATRegistered = source.IsVATRegistered;
            target.BirthDate = source.BirthDate;
            target.EmailAddress1 = source.EmailAddress1;
            target.FirstName = source.FirstName;
            target.LastName = source.LastName;
            target.MiddleName = source.MiddleName;
            target.Username = source.Username;
            target.Email = source.Email;
            target.ContactID = source.ContactID;
            target.AddressID = source.AddressID;
            target.BuildingName = source.BuildingName;
            target.City = source.City;
            target.CountryCode = source.CountryCode;
            target.County = source.County;
            target.Line1 = source.Line1;
            target.Line2 = source.Line2;
            target.Line3 = source.Line3;
            target.PostalCode = source.PostalCode;
            target.Town = source.Town;
            target.IsPrimaryAddress = source.IsPrimaryAddress;
            target.PinCode = source.PinCode;
            target.PinCreated = source.PinCreated;
            target.Salutation = source.Salutation;
            target.Telephone = source.Telephone;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VUserAccountOrganisation ToEntity(this VUserAccountOrganisationDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VUserAccountOrganisation();

            // Properties
            target.ID = source.ID;
            target.IsTemporaryAccount = source.IsTemporaryAccount;
            target.UserAccountOrganisationID = source.UserAccountOrganisationID;
            target.UserTypeID = source.UserTypeID;
            target.OrganisationBranchID = source.OrganisationBranchID;
            target.OrganisationID = source.OrganisationID;
            target.Name = source.Name;
            target.IsBranch = source.IsBranch;
            target.IsHeadOffice = source.IsHeadOffice;
            target.IsUserOrganisation = source.IsUserOrganisation;
            target.IsPaymentProvider = source.IsPaymentProvider;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.OrganisationTypeName = source.OrganisationTypeName;
            target.UserTypeName = source.UserTypeName;
            target.VATNumber = source.VATNumber;
            target.IsVATRegistered = source.IsVATRegistered;
            target.BirthDate = source.BirthDate;
            target.EmailAddress1 = source.EmailAddress1;
            target.FirstName = source.FirstName;
            target.LastName = source.LastName;
            target.MiddleName = source.MiddleName;
            target.Username = source.Username;
            target.Email = source.Email;
            target.ContactID = source.ContactID;
            target.AddressID = source.AddressID;
            target.BuildingName = source.BuildingName;
            target.City = source.City;
            target.CountryCode = source.CountryCode;
            target.County = source.County;
            target.Line1 = source.Line1;
            target.Line2 = source.Line2;
            target.Line3 = source.Line3;
            target.PostalCode = source.PostalCode;
            target.Town = source.Town;
            target.IsPrimaryAddress = source.IsPrimaryAddress;
            target.PinCode = source.PinCode;
            target.PinCreated = source.PinCreated;
            target.Salutation = source.Salutation;
            target.Telephone = source.Telephone;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VUserAccountOrganisationDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VUserAccountOrganisation> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VUserAccountOrganisationDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VUserAccountOrganisation> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VUserAccountOrganisation> ToEntities(this IEnumerable<VUserAccountOrganisationDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VUserAccountOrganisation source, VUserAccountOrganisationDTO target);

        static partial void OnEntityCreating(VUserAccountOrganisationDTO source, Bec.TargetFramework.Data.VUserAccountOrganisation target);

    }

}
