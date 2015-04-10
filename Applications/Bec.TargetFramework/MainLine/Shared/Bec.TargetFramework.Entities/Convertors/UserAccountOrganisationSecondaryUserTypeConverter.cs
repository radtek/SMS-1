﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 09/04/2015 12:02:58
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class UserAccountOrganisationSecondaryUserTypeConverter
    {

        public static UserAccountOrganisationSecondaryUserTypeDTO ToDto(this Bec.TargetFramework.Data.UserAccountOrganisationSecondaryUserType source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static UserAccountOrganisationSecondaryUserTypeDTO ToDtoWithRelated(this Bec.TargetFramework.Data.UserAccountOrganisationSecondaryUserType source, int level)
        {
            if (source == null)
              return null;

            var target = new UserAccountOrganisationSecondaryUserTypeDTO();

            // Properties
            target.UserAccountOrganisationID = source.UserAccountOrganisationID;
            target.UserTypeID = source.UserTypeID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.UserType = source.UserType.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.UserAccountOrganisationSecondaryUserType ToEntity(this UserAccountOrganisationSecondaryUserTypeDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.UserAccountOrganisationSecondaryUserType();

            // Properties
            target.UserAccountOrganisationID = source.UserAccountOrganisationID;
            target.UserTypeID = source.UserTypeID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<UserAccountOrganisationSecondaryUserTypeDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.UserAccountOrganisationSecondaryUserType> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<UserAccountOrganisationSecondaryUserTypeDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.UserAccountOrganisationSecondaryUserType> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.UserAccountOrganisationSecondaryUserType> ToEntities(this IEnumerable<UserAccountOrganisationSecondaryUserTypeDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.UserAccountOrganisationSecondaryUserType source, UserAccountOrganisationSecondaryUserTypeDTO target);

        static partial void OnEntityCreating(UserAccountOrganisationSecondaryUserTypeDTO source, Bec.TargetFramework.Data.UserAccountOrganisationSecondaryUserType target);

    }

}
