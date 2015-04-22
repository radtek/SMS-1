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

    public static partial class InterfacePanelFieldDetailConverter
    {

        public static InterfacePanelFieldDetailDTO ToDto(this Bec.TargetFramework.Data.InterfacePanelFieldDetail source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static InterfacePanelFieldDetailDTO ToDtoWithRelated(this Bec.TargetFramework.Data.InterfacePanelFieldDetail source, int level)
        {
            if (source == null)
              return null;

            var target = new InterfacePanelFieldDetailDTO();

            // Properties
            target.InterfacePanelID = source.InterfacePanelID;
            target.InterfacePanelVersionNumber = source.InterfacePanelVersionNumber;
            target.FieldDetailID = source.FieldDetailID;
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
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.InterfacePanelFieldDetail ToEntity(this InterfacePanelFieldDetailDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.InterfacePanelFieldDetail();

            // Properties
            target.InterfacePanelID = source.InterfacePanelID;
            target.InterfacePanelVersionNumber = source.InterfacePanelVersionNumber;
            target.FieldDetailID = source.FieldDetailID;
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

        public static List<InterfacePanelFieldDetailDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.InterfacePanelFieldDetail> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<InterfacePanelFieldDetailDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.InterfacePanelFieldDetail> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.InterfacePanelFieldDetail> ToEntities(this IEnumerable<InterfacePanelFieldDetailDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.InterfacePanelFieldDetail source, InterfacePanelFieldDetailDTO target);

        static partial void OnEntityCreating(InterfacePanelFieldDetailDTO source, Bec.TargetFramework.Data.InterfacePanelFieldDetail target);

    }

}
