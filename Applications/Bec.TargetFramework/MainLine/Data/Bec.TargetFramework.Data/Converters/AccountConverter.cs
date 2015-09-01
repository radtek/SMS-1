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

    public static partial class AccountConverter
    {

        public static AccountDTO ToDto(this Bec.TargetFramework.Data.Account source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static AccountDTO ToDtoWithRelated(this Bec.TargetFramework.Data.Account source, int level)
        {
            if (source == null)
              return null;

            var target = new AccountDTO();

            // Properties
            target.AccountID = source.AccountID;
            target.AccountName = source.AccountName;
            target.CountryTypeID = source.CountryTypeID;
            target.AccountClassificationTypeID = source.AccountClassificationTypeID;
            target.CustomerTypeID = source.CustomerTypeID;
            target.BusinessTypeID = source.BusinessTypeID;
            target.PreferredContactMethodID = source.PreferredContactMethodID;
            target.IndustryTypeID = source.IndustryTypeID;
            target.AccountTypeID = source.AccountTypeID;
            target.AccountSubTypeID = source.AccountSubTypeID;
            target.Description = source.Description;
            target.EmailAddress1 = source.EmailAddress1;
            target.EmailAddress2 = source.EmailAddress2;
            target.EmailAddress3 = source.EmailAddress3;
            target.DoNotPhone = source.DoNotPhone;
            target.DoNotEmail = source.DoNotEmail;
            target.Fax = source.Fax;
            target.IsPrivate = source.IsPrivate;
            target.Telephone1 = source.Telephone1;
            target.Telephone2 = source.Telephone2;
            target.Telephone3 = source.Telephone3;
            target.StateTypeID = source.StateTypeID;
            target.OwnerID = source.OwnerID;
            target.ContactID = source.ContactID;
            target.ParentAccountID = source.ParentAccountID;
            target.MasterID = source.MasterID;
            target.DoNotTelephone = source.DoNotTelephone;
            target.MobileNumber1 = source.MobileNumber1;
            target.MobileNumber2 = source.MobileNumber2;
            target.MobileNumber3 = source.MobileNumber3;
            target.ParentID = source.ParentID;
            target.AccountCategoryID = source.AccountCategoryID;
            target.IsActive = source.IsActive;
            target.ContactOrganisationID = source.ContactOrganisationID;
            target.ParentOrganisationID = source.ParentOrganisationID;
            target.IsDeleted = source.IsDeleted;
            target.AccountRelationshipTypeID = source.AccountRelationshipTypeID;

            // Navigation Properties
            if (level > 0) {
              target.InvoiceLineItems = source.InvoiceLineItems.ToDtosWithRelated(level - 1);
              target.ShoppingCartItems = source.ShoppingCartItems.ToDtosWithRelated(level - 1);
              target.Contact = source.Contact.ToDtoWithRelated(level - 1);
              target.Organisation_ContactOrganisationID = source.Organisation_ContactOrganisationID.ToDtoWithRelated(level - 1);
              target.Organisation_ParentOrganisationID = source.Organisation_ParentOrganisationID.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.Account ToEntity(this AccountDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.Account();

            // Properties
            target.AccountID = source.AccountID;
            target.AccountName = source.AccountName;
            target.CountryTypeID = source.CountryTypeID;
            target.AccountClassificationTypeID = source.AccountClassificationTypeID;
            target.CustomerTypeID = source.CustomerTypeID;
            target.BusinessTypeID = source.BusinessTypeID;
            target.PreferredContactMethodID = source.PreferredContactMethodID;
            target.IndustryTypeID = source.IndustryTypeID;
            target.AccountTypeID = source.AccountTypeID;
            target.AccountSubTypeID = source.AccountSubTypeID;
            target.Description = source.Description;
            target.EmailAddress1 = source.EmailAddress1;
            target.EmailAddress2 = source.EmailAddress2;
            target.EmailAddress3 = source.EmailAddress3;
            target.DoNotPhone = source.DoNotPhone;
            target.DoNotEmail = source.DoNotEmail;
            target.Fax = source.Fax;
            target.IsPrivate = source.IsPrivate;
            target.Telephone1 = source.Telephone1;
            target.Telephone2 = source.Telephone2;
            target.Telephone3 = source.Telephone3;
            target.StateTypeID = source.StateTypeID;
            target.OwnerID = source.OwnerID;
            target.ContactID = source.ContactID;
            target.ParentAccountID = source.ParentAccountID;
            target.MasterID = source.MasterID;
            target.DoNotTelephone = source.DoNotTelephone;
            target.MobileNumber1 = source.MobileNumber1;
            target.MobileNumber2 = source.MobileNumber2;
            target.MobileNumber3 = source.MobileNumber3;
            target.ParentID = source.ParentID;
            target.AccountCategoryID = source.AccountCategoryID;
            target.IsActive = source.IsActive;
            target.ContactOrganisationID = source.ContactOrganisationID;
            target.ParentOrganisationID = source.ParentOrganisationID;
            target.IsDeleted = source.IsDeleted;
            target.AccountRelationshipTypeID = source.AccountRelationshipTypeID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<AccountDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.Account> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<AccountDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.Account> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.Account> ToEntities(this IEnumerable<AccountDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.Account source, AccountDTO target);

        static partial void OnEntityCreating(AccountDTO source, Bec.TargetFramework.Data.Account target);

    }

}