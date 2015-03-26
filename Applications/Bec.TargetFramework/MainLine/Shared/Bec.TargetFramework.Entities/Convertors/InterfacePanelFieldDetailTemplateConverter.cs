﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 26/03/2015 16:15:01
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class InterfacePanelFieldDetailTemplateConverter
    {

        public static InterfacePanelFieldDetailTemplateDTO ToDto(this Bec.TargetFramework.Data.InterfacePanelFieldDetailTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static InterfacePanelFieldDetailTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.InterfacePanelFieldDetailTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new InterfacePanelFieldDetailTemplateDTO();

            // Properties
            target.InterfacePanelTemplateID = source.InterfacePanelTemplateID;
            target.InterfacePanelTemplateVersionNumber = source.InterfacePanelTemplateVersionNumber;
            target.FieldDetailTemplateID = source.FieldDetailTemplateID;
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
              target.FieldDetailTemplate = source.FieldDetailTemplate.ToDtoWithRelated(level - 1);
              target.InterfacePanelTemplate = source.InterfacePanelTemplate.ToDtoWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.InterfacePanelFieldDetailTemplate ToEntity(this InterfacePanelFieldDetailTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.InterfacePanelFieldDetailTemplate();

            // Properties
            target.InterfacePanelTemplateID = source.InterfacePanelTemplateID;
            target.InterfacePanelTemplateVersionNumber = source.InterfacePanelTemplateVersionNumber;
            target.FieldDetailTemplateID = source.FieldDetailTemplateID;
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

        public static List<InterfacePanelFieldDetailTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.InterfacePanelFieldDetailTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<InterfacePanelFieldDetailTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.InterfacePanelFieldDetailTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.InterfacePanelFieldDetailTemplate> ToEntities(this IEnumerable<InterfacePanelFieldDetailTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.InterfacePanelFieldDetailTemplate source, InterfacePanelFieldDetailTemplateDTO target);

        static partial void OnEntityCreating(InterfacePanelFieldDetailTemplateDTO source, Bec.TargetFramework.Data.InterfacePanelFieldDetailTemplate target);

    }

}
