﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 3/27/2015 9:57:20 AM
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class DefaultOrganisationBranchTemplateConverter
    {

        public static DefaultOrganisationBranchTemplateDTO ToDto(this Bec.TargetFramework.Data.DefaultOrganisationBranchTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static DefaultOrganisationBranchTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.DefaultOrganisationBranchTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new DefaultOrganisationBranchTemplateDTO();

            // Properties
            target.DefaultOrganisationBranchTemplateID = source.DefaultOrganisationBranchTemplateID;
            target.DefaultOrganisationTemplateID = source.DefaultOrganisationTemplateID;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.BranchName = source.BranchName;
            target.BranchSubType = source.BranchSubType;
            target.DefaultOrganisationTemplateVersionNumber = source.DefaultOrganisationTemplateVersionNumber;

            // Navigation Properties
            if (level > 0) {
              target.DefaultOrganisationTemplate = source.DefaultOrganisationTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.DefaultOrganisationBranchTemplate ToEntity(this DefaultOrganisationBranchTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.DefaultOrganisationBranchTemplate();

            // Properties
            target.DefaultOrganisationBranchTemplateID = source.DefaultOrganisationBranchTemplateID;
            target.DefaultOrganisationTemplateID = source.DefaultOrganisationTemplateID;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.BranchName = source.BranchName;
            target.BranchSubType = source.BranchSubType;
            target.DefaultOrganisationTemplateVersionNumber = source.DefaultOrganisationTemplateVersionNumber;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<DefaultOrganisationBranchTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationBranchTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<DefaultOrganisationBranchTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.DefaultOrganisationBranchTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.DefaultOrganisationBranchTemplate> ToEntities(this IEnumerable<DefaultOrganisationBranchTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.DefaultOrganisationBranchTemplate source, DefaultOrganisationBranchTemplateDTO target);

        static partial void OnEntityCreating(DefaultOrganisationBranchTemplateDTO source, Bec.TargetFramework.Data.DefaultOrganisationBranchTemplate target);

    }

}
