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

    public static partial class UserAccountOrganisationConverter
    {

        public static UserAccountOrganisationDTO ToDto(this Bec.TargetFramework.Data.UserAccountOrganisation source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static UserAccountOrganisationDTO ToDtoWithRelated(this Bec.TargetFramework.Data.UserAccountOrganisation source, int level)
        {
            if (source == null)
              return null;

            var target = new UserAccountOrganisationDTO();

            // Properties
            target.UserID = source.UserID;
            target.OrganisationUnitID = source.OrganisationUnitID;
            target.OrganisationID = source.OrganisationID;
            target.JobTitle = source.JobTitle;
            target.NickName = source.NickName;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.UserSubTypeID = source.UserSubTypeID;
            target.UserCategoryID = source.UserCategoryID;
            target.UserAccountOrganisationID = source.UserAccountOrganisationID;
            target.UserJobTypeID = source.UserJobTypeID;
            target.PrimaryContactID = source.PrimaryContactID;
            target.UserTypeID = source.UserTypeID;
            target.ParentID = source.ParentID;
            target.PinCode = source.PinCode;
            target.PinCreated = source.PinCreated;
            target.PinAttempts = source.PinAttempts;

            // Navigation Properties
            if (level > 0) {
              target.OrganisationUnit = source.OrganisationUnit.ToDtoWithRelated(level - 1);
              target.UserType = source.UserType.ToDtoWithRelated(level - 1);
              target.UserAccount = source.UserAccount.ToDtoWithRelated(level - 1);
              target.UserAccountOrganisationTeams = source.UserAccountOrganisationTeams.ToDtosWithRelated(level - 1);
              target.UserAccountOrganisationRoles = source.UserAccountOrganisationRoles.ToDtosWithRelated(level - 1);
              target.UserAccountOrganisationGroups = source.UserAccountOrganisationGroups.ToDtosWithRelated(level - 1);
              target.UserAccountOrganisationStatus = source.UserAccountOrganisationStatus.ToDtosWithRelated(level - 1);
              target.NotificationRecipients = source.NotificationRecipients.ToDtosWithRelated(level - 1);
              target.ShoppingCarts = source.ShoppingCarts.ToDtosWithRelated(level - 1);
              target.Invoices = source.Invoices.ToDtosWithRelated(level - 1);
              target.Contact = source.Contact.ToDtoWithRelated(level - 1);
              target.Organisation = source.Organisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.UserAccountOrganisation ToEntity(this UserAccountOrganisationDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.UserAccountOrganisation();

            // Properties
            target.UserID = source.UserID;
            target.OrganisationUnitID = source.OrganisationUnitID;
            target.OrganisationID = source.OrganisationID;
            target.JobTitle = source.JobTitle;
            target.NickName = source.NickName;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.UserSubTypeID = source.UserSubTypeID;
            target.UserCategoryID = source.UserCategoryID;
            target.UserAccountOrganisationID = source.UserAccountOrganisationID;
            target.UserJobTypeID = source.UserJobTypeID;
            target.PrimaryContactID = source.PrimaryContactID;
            target.UserTypeID = source.UserTypeID;
            target.ParentID = source.ParentID;
            target.PinCode = source.PinCode;
            target.PinCreated = source.PinCreated;
            target.PinAttempts = source.PinAttempts;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<UserAccountOrganisationDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.UserAccountOrganisation> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<UserAccountOrganisationDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.UserAccountOrganisation> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.UserAccountOrganisation> ToEntities(this IEnumerable<UserAccountOrganisationDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.UserAccountOrganisation source, UserAccountOrganisationDTO target);

        static partial void OnEntityCreating(UserAccountOrganisationDTO source, Bec.TargetFramework.Data.UserAccountOrganisation target);

    }

}
