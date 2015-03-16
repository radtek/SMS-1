﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 2/12/2015 3:31:07 PM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class ContactConverter
    {

        public static ContactDTO ToDto(this Bec.TargetFramework.Data.Contact source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static ContactDTO ToDtoWithRelated(this Bec.TargetFramework.Data.Contact source, int level)
        {
            if (source == null)
              return null;

            var target = new ContactDTO();

            // Properties
            target.ContactID = source.ContactID;
            target.ContactName = source.ContactName;
            target.MasterContactID = source.MasterContactID;
            target.ParentID = source.ParentID;
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
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.FirmName = source.FirmName;

            // Navigation Properties
            if (level > 0) {
              target.ContactNames = source.ContactNames.ToDtosWithRelated(level - 1);
              target.ContactPhones = source.ContactPhones.ToDtosWithRelated(level - 1);
              target.ContactRegulators = source.ContactRegulators.ToDtosWithRelated(level - 1);
              target.StsSearchActorDetails_RegisteredProprietorContactID = source.StsSearchActorDetails_RegisteredProprietorContactID.ToDtosWithRelated(level - 1);
              target.StsSearchActorDetails_MortgageBrokerContactID = source.StsSearchActorDetails_MortgageBrokerContactID.ToDtosWithRelated(level - 1);
              target.StsSearchActors = source.StsSearchActors.ToDtosWithRelated(level - 1);
              target.Organisations = source.Organisations.ToDtosWithRelated(level - 1);
              target.Accounts = source.Accounts.ToDtosWithRelated(level - 1);
              target.UserAccountOrganisations = source.UserAccountOrganisations.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.Contact ToEntity(this ContactDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.Contact();

            // Properties
            target.ContactID = source.ContactID;
            target.ContactName = source.ContactName;
            target.MasterContactID = source.MasterContactID;
            target.ParentID = source.ParentID;
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
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.FirmName = source.FirmName;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<ContactDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.Contact> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<ContactDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.Contact> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.Contact> ToEntities(this IEnumerable<ContactDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.Contact source, ContactDTO target);

        static partial void OnEntityCreating(ContactDTO source, Bec.TargetFramework.Data.Contact target);

    }

}
