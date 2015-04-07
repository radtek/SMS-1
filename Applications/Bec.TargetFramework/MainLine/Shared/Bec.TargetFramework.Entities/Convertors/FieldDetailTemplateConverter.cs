﻿//------------------------------------------------------------------------------
// This is auto-generated code.
//------------------------------------------------------------------------------
// This code was generated by Devart Entity Developer tool using Data Transfer Object template.
// Code is generated on: 07/04/2015 16:15:20
//
// Changes to this file may cause incorrect behavior and will be lost if
// the code is regenerated.
//------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

namespace Bec.TargetFramework.Entities
{

    public static partial class FieldDetailTemplateConverter
    {

        public static FieldDetailTemplateDTO ToDto(this Bec.TargetFramework.Data.FieldDetailTemplate source)
        {
            return source.ToDtoWithRelated(0);
        }

        public static FieldDetailTemplateDTO ToDtoWithRelated(this Bec.TargetFramework.Data.FieldDetailTemplate source, int level)
        {
            if (source == null)
              return null;

            var target = new FieldDetailTemplateDTO();

            // Properties
            target.FieldDetailTemplateID = source.FieldDetailTemplateID;
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
            target.FieldTypeID = source.FieldTypeID;
            target.IconAlignmentTypeID = source.IconAlignmentTypeID;
            target.IconFileName = source.IconFileName;
            target.IsGridColumn = source.IsGridColumn;
            target.FieldMask = source.FieldMask;

            // Navigation Properties
            if (level > 0) {
              target.InterfacePanelFieldDetailOrganaisationTypeTemplates = source.InterfacePanelFieldDetailOrganaisationTypeTemplates.ToDtosWithRelated(level - 1);
              target.InterfacePanelFieldDetailTemplates = source.InterfacePanelFieldDetailTemplates.ToDtosWithRelated(level - 1);
              target.FieldDetails = source.FieldDetails.ToDtosWithRelated(level - 1);
              target.InterfacePanelFDOrganaisationTypeUserTypeTemplates = source.InterfacePanelFDOrganaisationTypeUserTypeTemplates.ToDtosWithRelated(level - 1);
            }

            // User-defined partial method
            OnDtoCreating(source, target);

            return target;
        }

        public static Bec.TargetFramework.Data.FieldDetailTemplate ToEntity(this FieldDetailTemplateDTO source)
        {
            if (source == null)
              return null;

            var target = new Bec.TargetFramework.Data.FieldDetailTemplate();

            // Properties
            target.FieldDetailTemplateID = source.FieldDetailTemplateID;
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
            target.FieldTypeID = source.FieldTypeID;
            target.IconAlignmentTypeID = source.IconAlignmentTypeID;
            target.IconFileName = source.IconFileName;
            target.IsGridColumn = source.IsGridColumn;
            target.FieldMask = source.FieldMask;

            // User-defined partial method
            OnEntityCreating(source, target);

            return target;
        }

        public static List<FieldDetailTemplateDTO> ToDtos(this IEnumerable<Bec.TargetFramework.Data.FieldDetailTemplate> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDto())
              .ToList();

            return target;
        }

        public static List<FieldDetailTemplateDTO> ToDtosWithRelated(this IEnumerable<Bec.TargetFramework.Data.FieldDetailTemplate> source, int level)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToDtoWithRelated(level))
              .ToList();

            return target;
        }

        public static List<Bec.TargetFramework.Data.FieldDetailTemplate> ToEntities(this IEnumerable<FieldDetailTemplateDTO> source)
        {
            if (source == null)
              return null;

            var target = source
              .Select(src => src.ToEntity())
              .ToList();

            return target;
        }

        static partial void OnDtoCreating(Bec.TargetFramework.Data.FieldDetailTemplate source, FieldDetailTemplateDTO target);

        static partial void OnEntityCreating(FieldDetailTemplateDTO source, Bec.TargetFramework.Data.FieldDetailTemplate target);

    }

}
