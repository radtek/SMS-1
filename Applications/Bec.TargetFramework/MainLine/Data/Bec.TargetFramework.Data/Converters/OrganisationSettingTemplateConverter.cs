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

    public static partial class OrganisationSettingTemplateConverter
    {

        public static OrganisationSettingTemplateDTO ToDto(this Bec.TargetFramework.Data.OrganisationSettingTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static OrganisationSettingTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.OrganisationSettingTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new OrganisationSettingTemplateDTO();

            // Properties
            target.OrganisationSettingTemplateID = source.OrganisationSettingTemplateID;
            target.Name = source.Name;
            target.Value = source.Value;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.OrganisationSettingTemplate ToEntity(this OrganisationSettingTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.OrganisationSettingTemplate();

            // Properties
            target.OrganisationSettingTemplateID = source.OrganisationSettingTemplateID;
            target.Name = source.Name;
            target.Value = source.Value;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<OrganisationSettingTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.OrganisationSettingTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<OrganisationSettingTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.OrganisationSettingTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.OrganisationSettingTemplate> ToEntities(this IEnumerable<OrganisationSettingTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.OrganisationSettingTemplate source, OrganisationSettingTemplateDTO target);

        static partial void OnEntityCreating(OrganisationSettingTemplateDTO source, Bec.TargetFramework.Data.OrganisationSettingTemplate target);

    }

}