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

    public static partial class UserAccountOrganisationTeamConverter
    {

        public static UserAccountOrganisationTeamDTO ToDto(this Bec.TargetFramework.Data.UserAccountOrganisationTeam source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static UserAccountOrganisationTeamDTO ToDtoWithRelated(this Bec.TargetFramework.Data.UserAccountOrganisationTeam source, int level)
        {
            if (source == null)
              return null;

            var target = new UserAccountOrganisationTeamDTO();

            // Properties
            target.UserAccountOrganisationID = source.UserAccountOrganisationID;
            target.OrganisationTeamID = source.OrganisationTeamID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // Navigation Properties
            if (level > 0) {
              target.OrganisationTeam = source.OrganisationTeam.ToDtoWithRelated(level - 1);
              target.UserAccountOrganisation = source.UserAccountOrganisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.UserAccountOrganisationTeam ToEntity(this UserAccountOrganisationTeamDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.UserAccountOrganisationTeam();

            // Properties
            target.UserAccountOrganisationID = source.UserAccountOrganisationID;
            target.OrganisationTeamID = source.OrganisationTeamID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<UserAccountOrganisationTeamDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.UserAccountOrganisationTeam> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<UserAccountOrganisationTeamDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.UserAccountOrganisationTeam> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.UserAccountOrganisationTeam> ToEntities(this IEnumerable<UserAccountOrganisationTeamDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.UserAccountOrganisationTeam source, UserAccountOrganisationTeamDTO target);

        static partial void OnEntityCreating(UserAccountOrganisationTeamDTO source, Bec.TargetFramework.Data.UserAccountOrganisationTeam target);

    }

}
