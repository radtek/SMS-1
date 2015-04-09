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

    public static partial class VFieldDetailForUIConverter
    {

        public static VFieldDetailForUIDTO ToDto(this Bec.TargetFramework.Data.VFieldDetailForUI source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static VFieldDetailForUIDTO ToDtoWithRelated(this Bec.TargetFramework.Data.VFieldDetailForUI source, int level)
        {
            if (source == null)
              return null;

            var target = new VFieldDetailForUIDTO();

            // Properties
            target.InterfacePanelName = source.InterfacePanelName;
            target.FieldDetailID = source.FieldDetailID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.OverrideFieldLabelValue = source.OverrideFieldLabelValue;
            target.OverrideDefaultValue = source.OverrideDefaultValue;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.OverrideToolTipValue = source.OverrideToolTipValue;
            target.OverrideToolTipHTML = source.OverrideToolTipHTML;
            target.OverrideToolTipIsHTML = source.OverrideToolTipIsHTML;
            target.OverrideInformationValue = source.OverrideInformationValue;
            target.OverrideInformationHTML = source.OverrideInformationHTML;
            target.OverrideInformationIsHTML = source.OverrideInformationIsHTML;
            target.OverrideHelpValue = source.OverrideHelpValue;
            target.OverrideHelpHTML = source.OverrideHelpHTML;
            target.OverrideHelpIsHTML = source.OverrideHelpIsHTML;
            target.IsSecuredByClaim = source.IsSecuredByClaim;
            target.IsGlobal = source.IsGlobal;
            target.FieldDetailTemplateID = source.FieldDetailTemplateID;
            target.FieldTypeID = source.FieldTypeID;
            target.IconAlignment = source.IconAlignment;
            target.IconFileName = source.IconFileName;
            target.IsGridColumn = source.IsGridColumn;
            target.FieldMask = source.FieldMask;
            target.IsVisible = source.IsVisible;
            target.IsMandatory = source.IsMandatory;
            target.IsFilterable = source.IsFilterable;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.UserTypeID = source.UserTypeID;
            target.ID = source.ID;

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.VFieldDetailForUI ToEntity(this VFieldDetailForUIDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.VFieldDetailForUI();

            // Properties
            target.InterfacePanelName = source.InterfacePanelName;
            target.FieldDetailID = source.FieldDetailID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.OverrideFieldLabelValue = source.OverrideFieldLabelValue;
            target.OverrideDefaultValue = source.OverrideDefaultValue;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.OverrideToolTipValue = source.OverrideToolTipValue;
            target.OverrideToolTipHTML = source.OverrideToolTipHTML;
            target.OverrideToolTipIsHTML = source.OverrideToolTipIsHTML;
            target.OverrideInformationValue = source.OverrideInformationValue;
            target.OverrideInformationHTML = source.OverrideInformationHTML;
            target.OverrideInformationIsHTML = source.OverrideInformationIsHTML;
            target.OverrideHelpValue = source.OverrideHelpValue;
            target.OverrideHelpHTML = source.OverrideHelpHTML;
            target.OverrideHelpIsHTML = source.OverrideHelpIsHTML;
            target.IsSecuredByClaim = source.IsSecuredByClaim;
            target.IsGlobal = source.IsGlobal;
            target.FieldDetailTemplateID = source.FieldDetailTemplateID;
            target.FieldTypeID = source.FieldTypeID;
            target.IconAlignment = source.IconAlignment;
            target.IconFileName = source.IconFileName;
            target.IsGridColumn = source.IsGridColumn;
            target.FieldMask = source.FieldMask;
            target.IsVisible = source.IsVisible;
            target.IsMandatory = source.IsMandatory;
            target.IsFilterable = source.IsFilterable;
            target.OrganisationTypeID = source.OrganisationTypeID;
            target.UserTypeID = source.UserTypeID;
            target.ID = source.ID;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<VFieldDetailForUIDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.VFieldDetailForUI> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<VFieldDetailForUIDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.VFieldDetailForUI> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.VFieldDetailForUI> ToEntities(this IEnumerable<VFieldDetailForUIDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.VFieldDetailForUI source, VFieldDetailForUIDTO target);

        static partial void OnEntityCreating(VFieldDetailForUIDTO source, Bec.TargetFramework.Data.VFieldDetailForUI target);

    }

}
