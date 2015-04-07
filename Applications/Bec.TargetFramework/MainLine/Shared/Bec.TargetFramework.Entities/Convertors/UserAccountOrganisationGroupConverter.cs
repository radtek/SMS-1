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

    public static partial class UserAccountOrganisationGroupConverter
    {

        public static UserAccountOrganisationGroupDTO ToDto(this Bec.TargetFramework.Data.UserAccountOrganisationGroup source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static UserAccountOrganisationGroupDTO ToDtoWithRelated(this Bec.TargetFramework.Data.UserAccountOrganisationGroup source, int level)
        {
            if (source == null)
              return null;

            var target = new UserAccountOrganisationGroupDTO();

            // Properties
            target.OrganisationGroupID = source.OrganisationGroupID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.UserAccountOrganisationID = source.UserAccountOrganisationID;

            // Navigation Properties
            if (level > 0) {
              target.OrganisationGroup = source.OrganisationGroup.ToDtoWithRelated(level - 1);
              target.UserAccountOrganisation = source.UserAccountOrganisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.UserAccountOrganisationGroup ToEntity(this UserAccountOrganisationGroupDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.UserAccountOrganisationGroup();

            // Properties
            target.OrganisationGroupID = source.OrganisationGroupID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.UserAccountOrganisationID = source.UserAccountOrganisationID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<UserAccountOrganisationGroupDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.UserAccountOrganisationGroup> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<UserAccountOrganisationGroupDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.UserAccountOrganisationGroup> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.UserAccountOrganisationGroup> ToEntities(this IEnumerable<UserAccountOrganisationGroupDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.UserAccountOrganisationGroup source, UserAccountOrganisationGroupDTO target);

        static partial void OnEntityCreating(UserAccountOrganisationGroupDTO source, Bec.TargetFramework.Data.UserAccountOrganisationGroup target);

    }

}
