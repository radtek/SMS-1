﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 13/04/2015 17:29:39
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class DefaultOrganisationUserTypeConverter
    {

        public static DefaultOrganisationUserTypeDTO ToDto(this Bec.TargetFramework.Data.DefaultOrganisationUserType source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DefaultOrganisationUserTypeDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DefaultOrganisationUserType source, int level)
        {
            if (source == null)
              return null;

            var target = new DefaultOrganisationUserTypeDTO();

            // Properties
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;
            target.UserTypeID = source.UserTypeID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsForDefaultUser = source.IsForDefaultUser;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisation = source.DefaultOrganisation.ToDtoWithRelated(level - 1);
              target.UserType = source.UserType.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DefaultOrganisationUserType ToEntity(this DefaultOrganisationUserTypeDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DefaultOrganisationUserType();

            // Properties
            target.DefaultOrganisationID = source.DefaultOrganisationID;
            target.DefaultOrganisationVersionNumber = source.DefaultOrganisationVersionNumber;
            target.UserTypeID = source.UserTypeID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsForDefaultUser = source.IsForDefaultUser;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DefaultOrganisationUserTypeDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationUserType> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DefaultOrganisationUserTypeDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationUserType> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DefaultOrganisationUserType> ToEntities(this IEnumerable<DefaultOrganisationUserTypeDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DefaultOrganisationUserType source, DefaultOrganisationUserTypeDTO target);

        static partial void OnEntityCreating(DefaultOrganisationUserTypeDTO source, Bec.TargetFramework.Data.DefaultOrganisationUserType target);

    }

}
