﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 09:50:53
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class OrganisationTeamConverter
    {

        public static OrganisationTeamDTO ToDto(this Bec.TargetFramework.Data.OrganisationTeam source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static OrganisationTeamDTO ToDtoWithRelated(this Bec.TargetFramework.Data.OrganisationTeam source, int level)
        {
            if (source == null)
              return null;

            var target = new OrganisationTeamDTO();

            // Properties
            target.OrganisationTeamID = source.OrganisationTeamID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.EmailAddress = source.EmailAddress;
            target.IsDefault = source.IsDefault;
            target.TeamTypeID = source.TeamTypeID;
            target.TeamSubTypeID = source.TeamSubTypeID;
            target.TeamCategoryID = source.TeamCategoryID;
            target.TeamSubCategoryID = source.TeamSubCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.OrganisationID = source.OrganisationID;

            // Navigation Properties
            if (level > 0) {
              target.UserAccountOrganisationTeams = source.UserAccountOrganisationTeams.ToDtosWithRelated(level - 1);
              target.OrganisationTeamSettings = source.OrganisationTeamSettings.ToDtosWithRelated(level - 1);
              target.Organisation = source.Organisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.OrganisationTeam ToEntity(this OrganisationTeamDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.OrganisationTeam();

            // Properties
            target.OrganisationTeamID = source.OrganisationTeamID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.EmailAddress = source.EmailAddress;
            target.IsDefault = source.IsDefault;
            target.TeamTypeID = source.TeamTypeID;
            target.TeamSubTypeID = source.TeamSubTypeID;
            target.TeamCategoryID = source.TeamCategoryID;
            target.TeamSubCategoryID = source.TeamSubCategoryID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.OrganisationID = source.OrganisationID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<OrganisationTeamDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.OrganisationTeam> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<OrganisationTeamDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.OrganisationTeam> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.OrganisationTeam> ToEntities(this IEnumerable<OrganisationTeamDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.OrganisationTeam source, OrganisationTeamDTO target);

        static partial void OnEntityCreating(OrganisationTeamDTO source, Bec.TargetFramework.Data.OrganisationTeam target);

    }

}
