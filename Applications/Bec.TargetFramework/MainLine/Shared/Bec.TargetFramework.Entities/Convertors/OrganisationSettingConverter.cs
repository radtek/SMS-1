﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 02/04/2015 16:41:53
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class OrganisationSettingConverter
    {

        public static OrganisationSettingDTO ToDto(this Bec.TargetFramework.Data.OrganisationSetting source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static OrganisationSettingDTO ToDtoWithRelated(this Bec.TargetFramework.Data.OrganisationSetting source, int level)
        {
            if (source == null)
              return null;

            var target = new OrganisationSettingDTO();

            // Properties
            target.OrganisationSettingID = source.OrganisationSettingID;
            target.Name = source.Name;
            target.Value = source.Value;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.OrganisationID = source.OrganisationID;

            // Navigation Properties
            if (level > 0) {
              target.Organisation = source.Organisation.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.OrganisationSetting ToEntity(this OrganisationSettingDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.OrganisationSetting();

            // Properties
            target.OrganisationSettingID = source.OrganisationSettingID;
            target.Name = source.Name;
            target.Value = source.Value;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.OrganisationID = source.OrganisationID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<OrganisationSettingDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.OrganisationSetting> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<OrganisationSettingDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.OrganisationSetting> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.OrganisationSetting> ToEntities(this IEnumerable<OrganisationSettingDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.OrganisationSetting source, OrganisationSettingDTO target);

        static partial void OnEntityCreating(OrganisationSettingDTO source, Bec.TargetFramework.Data.OrganisationSetting target);

    }

}
