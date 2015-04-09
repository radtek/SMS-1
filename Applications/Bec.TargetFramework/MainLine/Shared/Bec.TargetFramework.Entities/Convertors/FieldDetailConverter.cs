﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 08/04/2015 17:09:58
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class FieldDetailConverter
    {

        public static FieldDetailDTO ToDto(this Bec.TargetFramework.Data.FieldDetail source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static FieldDetailDTO ToDtoWithRelated(this Bec.TargetFramework.Data.FieldDetail source, int level)
        {
            if (source == null)
              return null;

            var target = new FieldDetailDTO();

            // Properties
            target.FieldDetailID = source.FieldDetailID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.FieldLabelValue = source.FieldLabelValue;
            target.DefaultValue = source.DefaultValue;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ToolTipValue = source.ToolTipValue;
            target.ToolTipHTML = source.ToolTipHTML;
            target.ToolTipIsHTML = source.ToolTipIsHTML;
            target.InformationValue = source.InformationValue;
            target.InformationHTML = source.InformationHTML;
            target.InformationIsHTML = source.InformationIsHTML;
            target.HelpValue = source.HelpValue;
            target.HelpHTML = source.HelpHTML;
            target.HelpIsHTML = source.HelpIsHTML;
            target.IsSecuredByClaim = source.IsSecuredByClaim;
            target.IsGlobal = source.IsGlobal;
            target.IsGridColumn = source.IsGridColumn;
            target.FieldTypeID = source.FieldTypeID;
            target.IconAlignmentTypeID = source.IconAlignmentTypeID;
            target.IconFileName = source.IconFileName;
            target.FieldDetailTemplateID = source.FieldDetailTemplateID;
            target.FieldMask = source.FieldMask;

            // Navigation Properties
            if (level > 0) {
              target.InterfacePanelFieldDetailOrganisationTypes = source.InterfacePanelFieldDetailOrganisationTypes.ToDtosWithRelated(level - 1);
              target.InterfacePanelFDOrganaisationTypeUserTypes = source.InterfacePanelFDOrganaisationTypeUserTypes.ToDtosWithRelated(level - 1);
              target.FieldDetailTemplate = source.FieldDetailTemplate.ToDtoWithRelated(level - 1);
              target.InterfacePanelFieldDetails = source.InterfacePanelFieldDetails.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.FieldDetail ToEntity(this FieldDetailDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.FieldDetail();

            // Properties
            target.FieldDetailID = source.FieldDetailID;
            target.Name = source.Name;
            target.Description = source.Description;
            target.FieldLabelValue = source.FieldLabelValue;
            target.DefaultValue = source.DefaultValue;
            target.IsActive = source.IsActive;
            target.IsDeleted = source.IsDeleted;
            target.ToolTipValue = source.ToolTipValue;
            target.ToolTipHTML = source.ToolTipHTML;
            target.ToolTipIsHTML = source.ToolTipIsHTML;
            target.InformationValue = source.InformationValue;
            target.InformationHTML = source.InformationHTML;
            target.InformationIsHTML = source.InformationIsHTML;
            target.HelpValue = source.HelpValue;
            target.HelpHTML = source.HelpHTML;
            target.HelpIsHTML = source.HelpIsHTML;
            target.IsSecuredByClaim = source.IsSecuredByClaim;
            target.IsGlobal = source.IsGlobal;
            target.IsGridColumn = source.IsGridColumn;
            target.FieldTypeID = source.FieldTypeID;
            target.IconAlignmentTypeID = source.IconAlignmentTypeID;
            target.IconFileName = source.IconFileName;
            target.FieldDetailTemplateID = source.FieldDetailTemplateID;
            target.FieldMask = source.FieldMask;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<FieldDetailDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.FieldDetail> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<FieldDetailDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.FieldDetail> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.FieldDetail> ToEntities(this IEnumerable<FieldDetailDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.FieldDetail source, FieldDetailDTO target);

        static partial void OnEntityCreating(FieldDetailDTO source, Bec.TargetFramework.Data.FieldDetail target);

    }

}
