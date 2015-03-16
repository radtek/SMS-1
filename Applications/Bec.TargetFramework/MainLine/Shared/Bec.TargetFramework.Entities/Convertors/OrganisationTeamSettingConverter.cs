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

    public static partial class OrganisationTeamSettingConverter
    {

        public static OrganisationTeamSettingDTO ToDto(this Bec.TargetFramework.Data.OrganisationTeamSetting source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static OrganisationTeamSettingDTO ToDtoWithRelated(this Bec.TargetFramework.Data.OrganisationTeamSetting source, int level)
        {
            if (source == null)
              return null;

            var target = new OrganisationTeamSettingDTO();

            // Properties
            target.OrganisationTeamSettingID = source.OrganisationTeamSettingID;
            target.Name = source.Name;
            target.Value = source.Value;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.OrganisationTeamID = source.OrganisationTeamID;

            // Navigation Properties
            if (level > 0) {
              target.OrganisationTeam = source.OrganisationTeam.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.OrganisationTeamSetting ToEntity(this OrganisationTeamSettingDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.OrganisationTeamSetting();

            // Properties
            target.OrganisationTeamSettingID = source.OrganisationTeamSettingID;
            target.Name = source.Name;
            target.Value = source.Value;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.OrganisationTeamID = source.OrganisationTeamID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<OrganisationTeamSettingDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.OrganisationTeamSetting> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<OrganisationTeamSettingDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.OrganisationTeamSetting> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.OrganisationTeamSetting> ToEntities(this IEnumerable<OrganisationTeamSettingDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.OrganisationTeamSetting source, OrganisationTeamSettingDTO target);

        static partial void OnEntityCreating(OrganisationTeamSettingDTO source, Bec.TargetFramework.Data.OrganisationTeamSetting target);

    }

}
