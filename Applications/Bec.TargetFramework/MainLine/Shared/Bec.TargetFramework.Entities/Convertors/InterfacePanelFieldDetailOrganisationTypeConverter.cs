﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:15:00
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class InterfacePanelFieldDetailOrganisationTypeConverter
    {

        public static InterfacePanelFieldDetailOrganisationTypeDTO ToDto(this Bec.TargetFramework.Data.InterfacePanelFieldDetailOrganisationType source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static InterfacePanelFieldDetailOrganisationTypeDTO ToDtoWithRelated(this Bec.TargetFramework.Data.InterfacePanelFieldDetailOrganisationType source, int level)
        {
            if (source == null)
              return null;

            var target = new InterfacePanelFieldDetailOrganisationTypeDTO();

            // Properties
            target.InterfacePanelID = source.InterfacePanelID;
            target.InterfacePanelVersionNumber = source.InterfacePanelVersionNumber;
            target.FieldDetailID = source.FieldDetailID;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.IsVisible = source.IsVisible;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsMandatory = source.IsMandatory;
            target.IsFilterable = source.IsFilterable;
            target.OverrideDefaultValue = source.OverrideDefaultValue;
            target.OverrideToolTipValue = source.OverrideToolTipValue;
            target.OverrideToolTipHTML = source.OverrideToolTipHTML;
            target.OverrideToolTipIsHTML = source.OverrideToolTipIsHTML;
            target.OverrideInformationValue = source.OverrideInformationValue;
            target.OverrideInformationHTML = source.OverrideInformationHTML;
            target.OverrideInformationIsHTML = source.OverrideInformationIsHTML;
            target.OverrideHelpValue = source.OverrideHelpValue;
            target.OverrideHelpHTML = source.OverrideHelpHTML;
            target.OverrideHelpIsHTML = source.OverrideHelpIsHTML;
            target.OverrideFieldLabelValue = source.OverrideFieldLabelValue;

            // Navigation Properties
            if (level > 0) {
              target.FieldDetail = source.FieldDetail.ToDtoWithRelated(level - 1);
              target.InterfacePanel = source.InterfacePanel.ToDtoWithRelated(level - 1);
              target.OrganisationType = source.OrganisationType.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.InterfacePanelFieldDetailOrganisationType ToEntity(this InterfacePanelFieldDetailOrganisationTypeDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.InterfacePanelFieldDetailOrganisationType();

            // Properties
            target.InterfacePanelID = source.InterfacePanelID;
            target.InterfacePanelVersionNumber = source.InterfacePanelVersionNumber;
            target.FieldDetailID = source.FieldDetailID;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.IsVisible = source.IsVisible;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.IsMandatory = source.IsMandatory;
            target.IsFilterable = source.IsFilterable;
            target.OverrideDefaultValue = source.OverrideDefaultValue;
            target.OverrideToolTipValue = source.OverrideToolTipValue;
            target.OverrideToolTipHTML = source.OverrideToolTipHTML;
            target.OverrideToolTipIsHTML = source.OverrideToolTipIsHTML;
            target.OverrideInformationValue = source.OverrideInformationValue;
            target.OverrideInformationHTML = source.OverrideInformationHTML;
            target.OverrideInformationIsHTML = source.OverrideInformationIsHTML;
            target.OverrideHelpValue = source.OverrideHelpValue;
            target.OverrideHelpHTML = source.OverrideHelpHTML;
            target.OverrideHelpIsHTML = source.OverrideHelpIsHTML;
            target.OverrideFieldLabelValue = source.OverrideFieldLabelValue;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<InterfacePanelFieldDetailOrganisationTypeDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.InterfacePanelFieldDetailOrganisationType> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<InterfacePanelFieldDetailOrganisationTypeDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.InterfacePanelFieldDetailOrganisationType> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.InterfacePanelFieldDetailOrganisationType> ToEntities(this IEnumerable<InterfacePanelFieldDetailOrganisationTypeDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.InterfacePanelFieldDetailOrganisationType source, InterfacePanelFieldDetailOrganisationTypeDTO target);

        static partial void OnEntityCreating(InterfacePanelFieldDetailOrganisationTypeDTO source, Bec.TargetFramework.Data.InterfacePanelFieldDetailOrganisationType target);

    }

}
