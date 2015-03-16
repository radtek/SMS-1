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

    public static partial class UserAccountOrganisationStatusConverter
    {

        public static UserAccountOrganisationStatusDTO ToDto(this Bec.TargetFramework.Data.UserAccountOrganisationStatus source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static UserAccountOrganisationStatusDTO ToDtoWithRelated(this Bec.TargetFramework.Data.UserAccountOrganisationStatus source, int level)
        {
            if (source == null)
              return null;

            var target = new UserAccountOrganisationStatusDTO();

            // Properties
            target.UserAccountOrganisationID = source.UserAccountOrganisationID;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.StatusChangedOn = source.StatusChangedOn;
            target.StatusChangedBy = source.StatusChangedBy;
            target.ParentID = source.ParentID;

            // Navigation Properties
            if (level > 0) {
              target.StatusType = source.StatusType.ToDtoWithRelated(level - 1);
              target.StatusTypeValue = source.StatusTypeValue.ToDtoWithRelated(level - 1);
              target.UserAccountOrganisation = source.UserAccountOrganisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.UserAccountOrganisationStatus ToEntity(this UserAccountOrganisationStatusDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.UserAccountOrganisationStatus();

            // Properties
            target.UserAccountOrganisationID = source.UserAccountOrganisationID;
            target.StatusTypeID = source.StatusTypeID;
            target.StatusTypeVersionNumber = source.StatusTypeVersionNumber;
            target.StatusTypeValueID = source.StatusTypeValueID;
            target.StatusChangedOn = source.StatusChangedOn;
            target.StatusChangedBy = source.StatusChangedBy;
            target.ParentID = source.ParentID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<UserAccountOrganisationStatusDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.UserAccountOrganisationStatus> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<UserAccountOrganisationStatusDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.UserAccountOrganisationStatus> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.UserAccountOrganisationStatus> ToEntities(this IEnumerable<UserAccountOrganisationStatusDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.UserAccountOrganisationStatus source, UserAccountOrganisationStatusDTO target);

        static partial void OnEntityCreating(UserAccountOrganisationStatusDTO source, Bec.TargetFramework.Data.UserAccountOrganisationStatus target);

    }

}
