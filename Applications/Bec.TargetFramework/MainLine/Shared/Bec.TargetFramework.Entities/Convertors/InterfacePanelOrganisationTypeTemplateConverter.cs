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

    public static partial class InterfacePanelOrganisationTypeTemplateConverter
    {

        public static InterfacePanelOrganisationTypeTemplateDTO ToDto(this Bec.TargetFramework.Data.InterfacePanelOrganisationTypeTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static InterfacePanelOrganisationTypeTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.InterfacePanelOrganisationTypeTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new InterfacePanelOrganisationTypeTemplateDTO();

            // Properties
            target.InterfacePanelTemplateID = source.InterfacePanelTemplateID;
            target.InterfacePanelTemplateVersionNumber = source.InterfacePanelTemplateVersionNumber;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsVisible = source.IsVisible;
            target.ParentID = source.ParentID;
            target.InterfacePanelOrganisationTypeTemplateLabel = source.InterfacePanelOrganisationTypeTemplateLabel;

            // Navigation Properties
            if (level > 0) {
              target.OrganisationType = source.OrganisationType.ToDtoWithRelated(level - 1);
              target.InterfacePanelTemplate = source.InterfacePanelTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.InterfacePanelOrganisationTypeTemplate ToEntity(this InterfacePanelOrganisationTypeTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.InterfacePanelOrganisationTypeTemplate();

            // Properties
            target.InterfacePanelTemplateID = source.InterfacePanelTemplateID;
            target.InterfacePanelTemplateVersionNumber = source.InterfacePanelTemplateVersionNumber;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsVisible = source.IsVisible;
            target.ParentID = source.ParentID;
            target.InterfacePanelOrganisationTypeTemplateLabel = source.InterfacePanelOrganisationTypeTemplateLabel;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<InterfacePanelOrganisationTypeTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.InterfacePanelOrganisationTypeTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<InterfacePanelOrganisationTypeTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.InterfacePanelOrganisationTypeTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.InterfacePanelOrganisationTypeTemplate> ToEntities(this IEnumerable<InterfacePanelOrganisationTypeTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.InterfacePanelOrganisationTypeTemplate source, InterfacePanelOrganisationTypeTemplateDTO target);

        static partial void OnEntityCreating(InterfacePanelOrganisationTypeTemplateDTO source, Bec.TargetFramework.Data.InterfacePanelOrganisationTypeTemplate target);

    }

}
